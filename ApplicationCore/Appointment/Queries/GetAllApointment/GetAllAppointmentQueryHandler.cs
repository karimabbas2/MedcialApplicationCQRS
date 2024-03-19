using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ApplicationCore.Interfaces;
using MediatR;

namespace ApplicationCore.Appointment.Queries.GetAllApointment
{
    public class GetAllAppointmentQueryHandler(IAppointmentRepoistory appointmentRepoistory, IDoctorRepository doctorRepository) : IRequestHandler<GetAllAppointmentQuery, List<AppointmentsDto>>
    {
        private readonly IAppointmentRepoistory _appointmentRepoistory = appointmentRepoistory;
        private readonly IDoctorRepository _doctorRepository = doctorRepository;
        public async Task<List<AppointmentsDto>> Handle(GetAllAppointmentQuery request, CancellationToken cancellationToken)
        {
            var allAppointments = await _appointmentRepoistory.GetAllAsync();

            return allAppointments.Select(x => new AppointmentsDto
            {
                Id = x.Id,
                Doctor = _doctorRepository.GetDoctorById(x.DoctorId),
                PatientEmail = x.PatientEmail,
                PatientName = x.PatientName,
                PatientPhone = x.PatientPhone,
                PatientNotes = x.PatientNotes,
                ResevtionDate = x.ResevtionDate,
                AppointmentStatus = x.AppointmentStatus,
                CreadtedAt = x.CreatedAt

            }).ToList();
        }
    }
}