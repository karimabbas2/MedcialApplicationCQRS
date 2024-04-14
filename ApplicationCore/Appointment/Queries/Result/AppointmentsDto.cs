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
        public int? Id {get;set;}
        public string? ResevtionDate { get; set; }
        public AppointmentStatus AppointmentStatus { get; set; }
        public string? PatientName { get; set; }
        public string? PatientPhone { get; set; }
        public string? PatientEmail { get; set; }
        public string? PatientNotes { get; set; }
        public string? CreadtedAt { get; set; }
        public string? Doctor { get; set; }

    }
}