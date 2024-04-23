using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using ApplicationCore.Exceptions;
using ApplicationCore.HandleResponse;
using ApplicationCore.User.Commands.Login;
using ApplicationCore.User.Commands.Register;
using ApplicationCore.User.Queries.Logout;
using ApplicationDomain;
using ApplicationPersistence.Dto;
using ApplicationPersistence.Jwt;
using ApplicationPersistence.SeedData.Roles;
using MediatR;
using MedicalApplication.Server.Controllers.Base;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.UI.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.WebUtilities;

namespace MedicalApplication.Server.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AuthController(JwtService jwtService, UserManager<ApplicationDomain.User> userManager, IEmailSender emailService) : ApplicationControllerBase
    {
        private readonly JwtService _jwtService = jwtService;
        private readonly UserManager<ApplicationDomain.User> _userManager = userManager;
        private readonly IEmailSender _emailService = emailService;



        [HttpPost("Register")]
        public async Task<IActionResult> Register([FromBody] RegisterCommand registerCommand)
        {
            try
            {
                var result = await Mediator.Send(registerCommand);
                var link = await GenerateEmailConfirmationLinkAsync(result._User);
                var msgHtml = $"<lable>Please click the link for confirm Email address:</lable><a href='{link}'>Confirm Email</a>";
                await _emailService.SendEmailAsync(result._User.Email, "Confirmation Email(WebBeautyBook)", msgHtml);
                // return Ok($"Welcome {result._User.UserName}, We have sent Email Confirmation to You");
                return Ok(result._User);
            }
            catch (CustomValidationException ex)
            {
                return BadRequest(ex._validationFailures.Select(x => new ServiceResponse(false, $"{x.ErrorCode} , {x.ErrorMessage}")));
            }
            catch (CustomException ex)
            {
                if (ex._Message is not null)
                    return BadRequest(new ServiceResponse(false, $"{ex._Message}"));
                else
                    return BadRequest(ex._errros?.Select(x => new ServiceResponse(false, x)));
            }
            catch (Exception ex)
            {
                return BadRequest(new ServiceResponse(false, $"{ex.Message}"));
            }
        }

        [HttpPost("Login")]
        public async Task<IActionResult> Login([FromBody] LoginCommand loginCommand)
        {
            try
            {
                var result = await Mediator.Send(loginCommand);
                if (result._ISuccess)
                {
                    var GenerateToken = await _jwtService.GenerateToken(result._User.Id);
                    return Ok(new
                    {
                        AccsessToken = GenerateToken.Token,
                        RefreshToken = GenerateToken.RefreshToken?.Token,
                        ExpireDate = GenerateToken.TokenExpire,
                        user=result._User,
                    });
                }
                return BadRequest();
            }
            catch (CustomValidationException ex)
            {
                return BadRequest(ex._validationFailures.Select(x => new ServiceResponse(false, $"{x.ErrorCode} , {x.ErrorMessage}")));
            }
            catch (CustomException ex)
            {
                return BadRequest(new ServiceResponse(false, $"{ex._Message}"));
            }
            catch (Exception ex)
            {
                return BadRequest(new ServiceResponse(false, $"{ex.Message}"));
            }
        }

        [HttpPost]
        [Route("RefreshToken")]
        public async Task<IActionResult> RefreshToken([FromBody] TokenRequest tokenRequest)
        {
            try
            {
                return Ok(await _jwtService.VerifyTokenAndGenerate(tokenRequest));
            }
            catch (CustomException ex)
            {
                return BadRequest(new ServiceResponse(false, $"{ex._Message}"));
            }
            catch (Exception ex)
            {
                return BadRequest(new ServiceResponse(false, $"{ex.Message}"));
            }
        }


        [HttpGet("CurrentUser")]
        public ActionResult<User> CurrentUser()
        {
            try
            {
                var userClaims = User.Claims.Select(c => new { c.Type, c.Value });
                return Ok(userClaims);
            }
            catch (System.Exception ex)
            {
                return Ok(new { message = ex.Message });
            }

        }

        private async Task<string> GenerateEmailConfirmationLinkAsync(ApplicationDomain.User user)
        {
            var token = await _userManager.GenerateEmailConfirmationTokenAsync(user);//error
            var param = new Dictionary<string, string>
            {
                {"token", token },
                {"email", user.Email }
            };
            var confirmationLink = QueryHelpers.AddQueryString(Request.Scheme + "://" + Request.Host.Value + "/emailConfirmation", param);
            return confirmationLink;
        }

    }
}