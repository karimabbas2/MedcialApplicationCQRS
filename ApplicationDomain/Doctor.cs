using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ApplicationDomain.Concrets;

namespace ApplicationDomain
{
    public class Doctor : BaseEntity
    {
        public string? Name { get; set; }
        public string? Surname { get; set; }
        public string? Title { get; set; }
        public string? Description { get; set; }
        public string? Education { get; set; }
        public string? Experience { get; set; }
        public double? Fee { get; set; }
        public string? Phone { get; set; }
        public string? Email { get; set; }
        public string? ImageURL { get; set; }
        public string? DepartmentId { get;set;}
        public Department? Department {get;set;}
        public List<Appointment>? Appointments {get;set;}

    }
}