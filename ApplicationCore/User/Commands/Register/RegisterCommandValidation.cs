using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FluentValidation;

namespace ApplicationCore.User.Commands.Register
{
    public class RegisterCommandValidation : AbstractValidator<RegisterCommand>
    {
        public RegisterCommandValidation()
        {
            RuleFor(x => x.FullName).NotNull().WithMessage("Full Name is required.");
            RuleFor(x=>x.Email).NotNull().WithMessage("Email Is Requierd").EmailAddress().WithMessage("Enter Valid Email");
            RuleFor(x=>x.PhoneNumber).NotNull().WithMessage("Phone is requierd");
            RuleFor(x=>x.Password).NotNull().WithMessage("PAssword is requierd");
        }
    }
}