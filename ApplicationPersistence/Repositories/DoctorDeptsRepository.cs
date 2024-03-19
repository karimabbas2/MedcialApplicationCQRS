using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ApplicationCore.Interfaces;
using ApplicationDomain;
using ApplicationPersistence.Context;
using Microsoft.EntityFrameworkCore;

namespace ApplicationPersistence.Repositories
{
    public class DoctorDeptsRepository : GenericRepository<DoctorDepartment, string>, IDoctorDeptsRepository
    {
        private readonly MyDbContext _myDbContext;
        public DoctorDeptsRepository(MyDbContext myDbContext) : base(myDbContext)
        {
            _myDbContext = myDbContext;
        }

        public List<DoctorDepartment> FindDoctorDeptsByDoctorId(string id)
        {
            var doctor = _myDbContext.Doctors.Find(id);
            if (doctor is not null)
                return [.. _myDbContext.DoctorDepartments.Where(x => x.DoctorId == doctor.Id)];
            return [];
        }

        public async Task<List<DoctorDepartment>> GetAllAsyncIncluded()
        {
            return await _myDbContext.DoctorDepartments.Include(x => x.DoctorId).Include(x => x.Department).ToListAsync();
        }
    }
}