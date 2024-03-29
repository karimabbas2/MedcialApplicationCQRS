using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FluentValidation;

namespace ApplicationCore.Departments.Commands.AddDepartment
{
    public class AddDepartmentCommandValidator : AbstractValidator<AddDepartmentCommand>
    {
        public AddDepartmentCommandValidator()
        {
            RuleFor(x => x.Name)
            .NotEmpty().WithMessage("Department Name is Requierd")
            .MaximumLength(100)
            .MinimumLength(3);

            RuleFor(x => x.Details)
            .NotNull();
        }

    }
}