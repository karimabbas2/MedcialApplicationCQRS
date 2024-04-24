using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ApplicationCore.Doctors.Queries;
using ApplicationCore.Doctors.Queries.Results;
using ApplicationDomain;

namespace ApplicationCore.Interfaces
{
    public interface IDoctorRepository : IGenericRepository<Doctor, string>
    {
        public Doctor GetDoctorById(string id);
        Task<Doctor> GetDoctorByIdAsync(string id);
        Task<List<DeptDoctorsWithSP>> Get_all_DeptDoctors_With_SP();

    }
}