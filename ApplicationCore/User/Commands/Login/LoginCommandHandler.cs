using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using ApplicationCore.Exceptions;
using ApplicationCore.HandleResponse;
using MediatR;
using Microsoft.AspNetCore.Identity;

namespace ApplicationCore.User.Commands.Login
{
    public class LoginCommandHandler(UserManager<ApplicationDomain.User> userManager, SignInManager<ApplicationDomain.User> signInManager) : IRequestHandler<LoginCommand, ServiceResponse>
    {
        private readonly UserManager<ApplicationDomain.User> _userManager = userManager;
        private readonly SignInManager<ApplicationDomain.User> _signInManager = signInManager;
        public async Task<ServiceResponse> Handle(LoginCommand request, CancellationToken cancellationToken)
        {
            var validator = new LoginCommandValidation();
            var validationResult = await validator.ValidateAsync(request, cancellationToken);
            if (!validationResult.IsValid) throw new CustomValidationException(validationResult.Errors);

            var user = await _userManager.FindByEmailAsync(request.Email) ?? throw new CustomException($"This Email {request.Email} dosen't Exist");
            var Password = await _userManager.CheckPasswordAsync(user, request.Password);
            if (Password)
            {
                var result = await _signInManager.PasswordSignInAsync(user, request.Password, false, false);
                if (result.Succeeded)
                {
                    return new ServiceResponse(true, user);
                }
            }
            throw new CustomException("password is not correct");
        }
    }
}