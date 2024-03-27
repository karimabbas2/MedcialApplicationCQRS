using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FluentValidation;

namespace ApplicationCore.User.Commands.Login
{
    public class LoginCommandValidation : AbstractValidator<LoginCommand>
    {
        public LoginCommandValidation()
        {
            RuleFor(x => x.Email).NotNull().WithMessage("Email Is Requierd").EmailAddress().WithMessage("Enter Valid Email");
            RuleFor(x => x.Password).NotNull().WithMessage("PAssword is requierd");
        }
    }
}