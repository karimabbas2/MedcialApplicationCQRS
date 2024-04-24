using System.Linq.Expressions;
using ApplicationCore.Doctors.Queries;
using ApplicationCore.Doctors.Queries.Results;
using ApplicationCore.Interfaces;
using ApplicationDomain;
using ApplicationPersistence.Context;
using Microsoft.EntityFrameworkCore;

namespace ApplicationPersistence.Repositories
{
    public class DoctorRepository : GenericRepository<Doctor, string>, IDoctorRepository
    {
        private readonly MyDbContext _myDbContext;
        public DoctorRepository(MyDbContext myDbContext) : base(myDbContext)
        {
            _myDbContext = myDbContext;
        }

        //Hidding and masking this function
        public async Task<List<Doctor>> GetAllAsync()
        {
            return await _myDbContext.Doctors.AsNoTracking()
            .Include(x => x.Appointments)
            .Include(d => d.Department)
            .ToListAsync();
        }

        public Doctor GetDoctorById(string id)
        {
            throw new NotImplementedException();
        }

        public async Task<Doctor> GetDoctorByIdAsync(string id)
        {
            return await _myDbContext.Doctors.AsNoTracking().Where(x => x.Id == id)
            .Include(x => x.Appointments)
            .Include(x => x.Department).FirstOrDefaultAsync();
        }

        public async Task<Doctor> GetFirstAsync(Expression<Func<Doctor, bool>> expression)
        {
            return await _myDbContext.Doctors.Include(x => x.Department).FirstOrDefaultAsync(expression);
        }

        public async Task<List<DeptDoctorsWithSP>> Get_all_DeptDoctors_With_SP()
        {
            return await _myDbContext.Set<DeptDoctorsWithSP>().FromSqlRaw("EXEC Get_all_DeptDoctors_With_SP").IgnoreQueryFilters().ToListAsync();
        }


    }
}