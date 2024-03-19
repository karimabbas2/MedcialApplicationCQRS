using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ApplicationDomain;

namespace ApplicationCore.Interfaces
{
    public interface IDoctorRepository : IGenericRepository<Doctor, string>
    {
        public Doctor GetDoctorById(string id);
        Task <Doctor> GetDoctorByIdAsync(string id);

    }
}