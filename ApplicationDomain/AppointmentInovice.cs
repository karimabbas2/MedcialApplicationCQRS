using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ApplicationDomain.Enums;

namespace ApplicationDomain
{
    public class AppointmentInovice
    {
        public int? Id { get; set; }
        public DateTime CreatedAt { get; set; } = DateTime.Now;
        public string? DoctorName { get; set; }
        public string? Dept { get; set; }
        public string? PatientName { get; set; }
        public string? PatientPhone { get; set; }
        public DateTime Appoitnment_Date { get; set; }
        public Appointment? Appointment { get; set; }
        public AppointmentStatus Appointment_Status { get; set; }
    }
}