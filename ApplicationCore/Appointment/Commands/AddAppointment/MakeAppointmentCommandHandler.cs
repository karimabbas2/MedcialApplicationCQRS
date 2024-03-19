using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ApplicationCore.Appointment.Commands.AddAppointment;
using ApplicationCore.Exceptions;
using ApplicationCore.HandleResponse;
using ApplicationCore.Interfaces;
using ApplicationDomain;
using MediatR;

namespace ApplicationCore.Appointment.Commands
{
    public class MakeAppointmentCommandHandler : IRequestHandler<MakeAppointmentCommand, ServiceResponse>
    {
        private readonly IAppointmentRepoistory _appointmentRepoistory;
        public MakeAppointmentCommandHandler(IAppointmentRepoistory appointmentRepoistory)
        {
            _appointmentRepoistory = appointmentRepoistory;
        }
        public async Task<ServiceResponse> Handle(MakeAppointmentCommand request, CancellationToken cancellationToken)
        {
            var validator = new MakeAppointmentCommandValidator();
            var validationResult = await validator.ValidateAsync(request, cancellationToken);
            if (!validationResult.IsValid) throw new CustomValidationException(validationResult.Errors);

            ApplicationDomain.Appointment appointment = new()
            {
                Id = Guid.NewGuid().ToString(),
                PatientName = request.PatientName,
                PatientEmail = request.PatientEmail,
                PatientPhone = request.PatientPhone,
                PatientNotes = request.PatientNotes,
                ResevtionDate = request.ResevtionDate,
                DoctorId = request.DoctorId,
                AppointmentStatus = request.AppointmentStatus
            };

            if (await _appointmentRepoistory.GetAsync(appointment.Id) is not null) return new ServiceResponse(false, "This Appointment is Exsit");
            await _appointmentRepoistory.InsertAsync(appointment);
            return new ServiceResponse(true, "New Apponintmet Resirved Successfully");
        }
    }
}