using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Threading.Tasks;
using ApplicationDomain;
using ApplicationDomain.Enums;

namespace ApplicationCore.Appointment.Queries.GetAllApointment
{
    public class AppointmentsDto
    {
        public string? Id {get;set;}
        public DateTime ResevtionDate { get; set; }
        public AppointmentStatus AppointmentStatus { get; set; }
        public string? DoctorId { get; set; }
        public string? PatientName { get; set; }
        public string? PatientPhone { get; set; }
        public string? PatientEmail { get; set; }
        public string? PatientNotes { get; set; }
        public DateTime CreadtedAt { get; set; }
        public Doctor? Doctor { get; set; }

    }
}