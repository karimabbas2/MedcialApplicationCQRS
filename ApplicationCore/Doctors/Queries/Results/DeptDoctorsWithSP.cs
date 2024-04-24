using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ApplicationCore.Doctors.Queries.Results
{
    public class DeptDoctorsWithSP
    {
        public string? Id { get; set; }
        public string? DocName { get; set; }
        public string? Surname { get; set; }
        public string? Title { get; set; }
        public string? Description { get; set; }
        public string? Education { get; set; }
        public string? Experience { get; set; }
        public double? Fee { get; set; }
        public string? Phone { get; set; }
        public string? Email { get; set; }
        public string? ImageURL { get; set; }
        public string? DepartmentID { get; set; }
        public string? DeptName { get; set; }
        public string? DeptDetails { get; set; }


    }
}