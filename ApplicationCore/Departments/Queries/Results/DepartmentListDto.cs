using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ApplicationDomain;

namespace ApplicationCore.Departments.Queries.GetAllDepartments
{
    public class DepartmentListDto
    {
        public string? Id { get; set; }
        public string? Name { get; set; }
        public string? Details { get; set; }
        public string? CreadtedAt { get; set; }
        public string? CreatedBy { get; set; }
        public string? UpdatedAt { get; set; }
        public string[]? Doctors {get;set;}
    }
}