using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ApplicationCore.Doctors.Command.Commands;
using FluentValidation;

namespace ApplicationCore.Doctors.Command.Validations
{
    public class UpdateDoctorCommandValidation : AbstractValidator<UpdateDoctorCommand>
    {
        public UpdateDoctorCommandValidation()
        {
            RuleFor(x => x.Name).NotNull().WithMessage("Name is required.");
            RuleFor(x => x.Surname).NotNull().WithMessage("Surname is required.");
            RuleFor(x => x.Phone).NotNull().WithMessage("phone is requierd");
            RuleFor(x => x.Fee).NotNull().WithMessage("Fee is required.");
            RuleFor(x => x.Email).NotNull().EmailAddress().WithMessage("Invalid Mail");
        }
    }
}