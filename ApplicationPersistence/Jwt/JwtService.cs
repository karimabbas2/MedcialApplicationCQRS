using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using ApplicationCore.Exceptions;
using ApplicationDomain;
using ApplicationPersistence.Context;
using ApplicationPersistence.Dto;
using ApplicationPersistence.SeedData.Roles;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;

namespace ApplicationPersistence.Jwt
{
    public class JwtService(IConfiguration configuration, MyDbContext myDbContext, UserManager<User> userManager)
    {
        private readonly IConfiguration _config = configuration;
        private readonly MyDbContext _myDbContext = myDbContext;
        private readonly UserManager<User> _userManager = userManager;

        public async Task<TokenResponse> GenerateToken(string userid)
        {
            var user = _myDbContext.Users.Find(userid);
            var UserRoles = await _userManager.GetRolesAsync(user);

            var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_config["Jwt:Key"]));
            var credentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256);

            var MyClaims = new Dictionary<string, object>
                   {
                       {ClaimTypes.NameIdentifier,user.Id},
                       {ClaimTypes.MobilePhone,user.PhoneNumber },
                       {ClaimTypes.Email,user.Email},
                       {ClaimTypes.Name,user.UserName}
                   };
            foreach (var role in UserRoles)
            {
                MyClaims.Add(ClaimTypes.Role, role);
            }

            ///With Descriptor can create cllaimsidentity like this without neededto pass it as a param form authController
            var descriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity([

                    new Claim(JwtRegisteredClaimNames.Jti,Guid.NewGuid().ToString()),
                    new Claim(JwtRegisteredClaimNames.Iat , DateTime.UtcNow.ToUniversalTime().ToString())

                ]),
                Issuer = _config["Jwt:Issuer"],
                Audience = _config["Jwt:Audience"],
                Expires = DateTime.UtcNow.AddMinutes(30),
                SigningCredentials = credentials,
                Claims = MyClaims
            };

            var Token = new JwtSecurityTokenHandler().CreateToken(descriptor);
            var AccessToken = new JwtSecurityTokenHandler().WriteToken(Token);

            RefreshToken refreshToken = new()
            {
                JwtId = Token.Id,
                IsUsed = false,
                IsRevoked = false,
                UserId = user.Id,
                AddedDate = DateTime.Now,
                ExpireDate = DateTime.Now.AddMonths(3),
                Token = GenerateRefreshToken()
            };

            _myDbContext.RefreshTokens.Add(refreshToken);
            _myDbContext.SaveChanges();

            return new TokenResponse()
            {
                Token = AccessToken,
                RefreshToken = refreshToken,
                TokenExpire = Token.ValidTo
            };
        }
        public string GenerateRefreshToken()
        {
            var randomNumber = new byte[64];
            using var rng = RandomNumberGenerator.Create();
            rng.GetBytes(randomNumber);
            return Convert.ToBase64String(randomNumber);
        }

        public async Task<object> VerifyTokenAndGenerate(TokenRequest tokenRequest)
        {
            var JwtSecurityTokenHandler = new JwtSecurityTokenHandler();

            var TokenValidationParameters = new TokenValidationParameters
            {
                ////For Development onlyyyyyyyy===>>>>>> RequireExpirationTime=false
                RequireExpirationTime = false,
                ValidateIssuer = true,
                ValidateAudience = true,
                ValidateLifetime = true,
                ValidateIssuerSigningKey = false,
                ValidIssuer = _config["Jwt:Issuer"],
                ValidAudience = _config["Jwt:Audience"],
                IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_config["Jwt:key"]))
            };

            try
            {
                TokenValidationParameters.ValidateLifetime = true;

                ///Validtion 1 ------ valdiation JWT token format
                var tokenHandler = new JwtSecurityTokenHandler();
                var principal = tokenHandler.ValidateToken(tokenRequest.Token, TokenValidationParameters, out SecurityToken validatedToken);

                //Validation 2 ------- validate encryiption alg
                if (validatedToken is JwtSecurityToken jwtSecurityToken)
                {
                    var res = jwtSecurityToken.Header.Alg.Equals(SecurityAlgorithms.HmacSha256, StringComparison.InvariantCultureIgnoreCase);
                    if (res == false)
                    {
                        throw new SecurityTokenException("Invalid token");
                    }
                }

                //Validation 3 ---- validate expire date

                var UtcExpiryDate = long.Parse(principal.Claims.FirstOrDefault(x => x.Type == JwtRegisteredClaimNames.Exp).Value);

                var expiryDate = UnixTimeStampToDateTime(UtcExpiryDate);
                DateTime dt1 = expiryDate;
                DateTime dt2 = DateTime.Now;
                int date = DateTime.Compare(dt1, dt2);
                if (date > 0) throw new CustomException("Token Has Not Yet Expired");

                //Validation 4 
                var storedToken = _myDbContext.RefreshTokens.FirstOrDefault(x => x.Token == tokenRequest.RefreshToken) ?? throw new CustomException("Token Does Not Exist");

                //Validtion 5 
                if (storedToken.IsUsed) throw new CustomException("Token has been Used before");

                ///Validation 6 
                if (storedToken.IsRevoked) throw new CustomException("Token has been Revoked");

                ///Validtion 7
                var jti = principal.Claims.FirstOrDefault(x => x.Type == JwtRegisteredClaimNames.Jti)?.Value;
                if (storedToken.JwtId != jti) throw new CustomException("Token Does'nt Match");

                storedToken.IsUsed = true;
                _myDbContext.RefreshTokens.Update(storedToken);
                _myDbContext.SaveChanges();

                var DBuser = _myDbContext.Users.Find(storedToken.UserId);
                var result = await GenerateToken(DBuser.Id);

                return new TokenResponse()
                {
                    Token = result.Token,
                    RefreshToken = result.RefreshToken,
                    TokenExpire = result.TokenExpire
                };

            }
            catch (Exception ex)
            {
                throw;
            }
        }

        private static DateTime UnixTimeStampToDateTime(long unixTimeStamp)
        {
            var dateTimeVal = new DateTime(1970, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc);
            dateTimeVal = dateTimeVal.AddSeconds(unixTimeStamp).ToLocalTime();
            return dateTimeVal;
        }
    }
}