using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FluentValidation;

namespace ApplicationCore.Doctors.Commands.AddDoctor
{
    public class AddDoctorCommandValidation : AbstractValidator<AddDoctorCommand>
    {
        public AddDoctorCommandValidation()
        {
            RuleFor(x => x.Name).NotNull().WithMessage("Name is required.");
            RuleFor(x => x.Surname).NotNull().WithMessage("Surname is required.");
            RuleFor(x => x.Phone).NotNull().WithMessage("phone is requierd");
            RuleFor(x => x.Fee).NotNull().WithMessage("Fee is required.");
            RuleFor(x => x.Email).NotNull().EmailAddress().WithMessage("Invalid Mail");
        }
    }
}