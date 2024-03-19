using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ApplicationDomain;

namespace ApplicationCore.Interfaces
{
    public interface IDoctorDeptsRepository : IGenericRepository<DoctorDepartment,string>
    {
        Task<List<DoctorDepartment>> GetAllAsyncIncluded();
        List<DoctorDepartment> FindDoctorDeptsByDoctorId(string id);
        
    }
}