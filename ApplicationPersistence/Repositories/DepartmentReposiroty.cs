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
            return await _myDbContext.Departments.Include(d => d.DoctorDepartments).ThenInclude(c => c.Doctor).ToListAsync();
        }
        public Task SomeExteraMethod()
        {
            throw new NotImplementedException();
        }
    }
}