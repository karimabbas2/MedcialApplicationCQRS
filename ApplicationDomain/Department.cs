using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ApplicationDomain.Concrets;

namespace ApplicationDomain
{
    public class Department : BaseEntity
    {
        public string? Name { get; set; }
        public string? Details { get; set; }
        public List<Doctor>? Doctors { get; set; }

    }
}