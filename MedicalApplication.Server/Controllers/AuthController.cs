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
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace MedicalApplication.Server.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AuthController(IMediator mediator, JwtService jwtService) : ControllerBase
    {
        private readonly IMediator _mediator = mediator;
        private readonly JwtService _jwtService = jwtService;

        [HttpPost("Register")]
        public async Task<IActionResult> Register([FromBody] RegisterCommand registerCommand)
        {
            try
            {
                return Ok(await _mediator.Send(registerCommand));
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
                var result = await _mediator.Send(loginCommand);
                if (result._ISuccess)
                {
                    var GenerateToken = await _jwtService.GenerateToken(result._Message);
                    return Ok(new
                    {
                        AccsessToken = GenerateToken.Token,
                        RefreshToken = GenerateToken.RefreshToken?.Token,
                        ExpireDate = GenerateToken.TokenExpire
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
    }
}