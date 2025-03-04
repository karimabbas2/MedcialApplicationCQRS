using ApplicationCore.interfaces;
using ApplicationDomain;
using ApplicationPersistence.Context;
using Microsoft.EntityFrameworkCore;

namespace ApplicationPersistence.Repositories
{
    public class DepartmentReposiroty : GenericRepository<Department, string>, IDepartmentRepository
    {
        private readonly MyDbContext _myDbContext;

        public DepartmentReposiroty(MyDbContext myDbContext) : base(myDbContext)
        {
            _myDbContext = myDbContext;
        }

        public async Task<List<Department>> GetAllAsync()
        {
            return await _myDbContext.Departments.AsNoTracking()
            .Include(d => d.Doctors).ToListAsync();
        }

        public async Task<Department> GetDepartmentByIdAsync(string id)
        {
            return await _myDbContext.Departments.AsNoTracking()
            .Where(x => x.Id == id)
            .Include(x => x.Doctors).FirstOrDefaultAsync();
        }
    }
}