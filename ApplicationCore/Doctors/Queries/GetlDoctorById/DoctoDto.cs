using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ApplicationDomain;

namespace ApplicationCore.Doctors.Queries.GetlDoctorById
{
    public class DoctoDto
    {
        public string? Id { get; set; }
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
        public List<Department>? Departments { get; set; }

    }
}