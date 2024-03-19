using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using ApplicationCore.HandleResponse;
using ApplicationDomain.Enums;
using MediatR;

namespace ApplicationCore.Appointment.Commands.AddAppointment
{
    public class MakeAppointmentCommand : IRequest<ServiceResponse>
    {
        public DateTime ResevtionDate { get; set; }
        public AppointmentStatus AppointmentStatus { get; set; }
        public string? DoctorId { get; set; }
        public string? PatientName { get; set; }
        public string? PatientPhone { get; set; }
        public string? PatientEmail { get; set; }
        public string? PatientNotes { get; set; }

    }
}