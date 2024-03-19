using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FluentValidation.Results;

namespace ApplicationCore.Exceptions
{
    public class CustomValidationException(List<ValidationFailure> validationFailures) : ApplicationException
    {
        public readonly List<ValidationFailure> _validationFailures = validationFailures;
    }
}