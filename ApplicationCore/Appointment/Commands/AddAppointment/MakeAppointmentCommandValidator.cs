using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FluentValidation;

namespace ApplicationCore.Appointment.Commands.AddAppointment
{
    public class MakeAppointmentCommandValidator : AbstractValidator<MakeAppointmentCommand>
    {
        public MakeAppointmentCommandValidator()
        {
            RuleFor(x => x.ResevtionDate)
            .NotEmpty()
            .WithMessage("Date is Requerid");

            RuleFor(x => x.DoctorId)
            .NotEmpty()
            .WithMessage("Doctor Is Requierd");

            RuleFor(x => x.PatientName)
            .NotEmpty()
            .WithMessage("Patient Name is Requierd");

            RuleFor(x => x.PatientPhone)
            .NotEmpty().WithMessage("Patient Phone is Requierd");

            RuleFor(x => x.PatientEmail)
            .NotEmpty().WithMessage("Patient Email is Requierd")
            .EmailAddress().WithMessage("Please, Enter Vaild Email");
        }
    }
}