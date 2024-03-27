using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ApplicationCore.Exceptions;
using ApplicationCore.HandleResponse;
using ApplicationDomain;
using ApplicationPersistence.SeedData.Roles;
using MediatR;
using Microsoft.AspNetCore.Identity;

namespace ApplicationCore.User.Commands.Register
{
    public class RegisterCommandHandler : IRequestHandler<RegisterCommand, ServiceResponse>
    {
        private readonly UserManager<ApplicationDomain.User> _userManager;

        public RegisterCommandHandler(UserManager<ApplicationDomain.User> userManager)
        {
            _userManager = userManager;

        }
        public async Task<ServiceResponse> Handle(RegisterCommand request, CancellationToken cancellationToken)
        {
            var validator = new RegisterCommandValidation();
            var validationResult = await validator.ValidateAsync(request, cancellationToken);

            if (!validationResult.IsValid) throw new CustomValidationException(validationResult.Errors);

            if (await _userManager.FindByEmailAsync(request.Email) is not null) throw new CustomException($"This Email {request.Email} is Taken before");

            ApplicationDomain.User user = new()
            {
                Id = Guid.NewGuid().ToString(),
                UserName = request.FullName,
                Email = request.Email,
                PhoneNumber = request.PhoneNumber,
            };

            var result = await _userManager.CreateAsync(user, request.Password);
            if (!result.Succeeded)
            {
                foreach (var error in result.Errors)
                {
                    List<string> listOfErrors = [error.Description];
                    throw new CustomException(listOfErrors);
                }
            }
            await _userManager.AddToRoleAsync(user, AppRoles.CLIENT);
            return new ServiceResponse(true, $"You Registerd Successfully , Welcome {user.UserName}");

        }
    }
}