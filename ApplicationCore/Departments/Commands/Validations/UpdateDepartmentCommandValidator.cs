using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ApplicationCore.Departments.Commands.UpdateDepartment;
using FluentValidation;

namespace ApplicationCore.Departments.Commands.Validations
{
    public class UpdateDepartmentCommandValidator : AbstractValidator<UpdateDepartmentCommand>
    {
        public UpdateDepartmentCommandValidator()
        {
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
}