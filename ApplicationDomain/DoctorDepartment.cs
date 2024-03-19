using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ApplicationDomain.Concrets;

namespace ApplicationDomain
{
    public class DoctorDepartment : BaseEntity
    {
        public string? DoctorId { get; set; }
        public Doctor? Doctor { get; set; }
        public string? DepartmentId { get; set; }
        public Department? Department { get; set; }
    }
}