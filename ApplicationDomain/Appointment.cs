using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using ApplicationDomain.Concrets;
using ApplicationDomain.Enums;

namespace ApplicationDomain
{
    public class Appointment : BaseEntity
    {
        [DataType(DataType.DateTime)]
        public DateTime ResevtionDate { get; set; }
        public AppointmentStatus AppointmentStatus { get; set; }
        public string? DoctorId { get; set; }
        public Doctor? Doctor { get; set; }
        public string? PatientName { get; set; }
        public string? PatientPhone { get; set; }
        public string? PatientEmail { get; set; }
        public string? PatientNotes { get; set; }
    }
}