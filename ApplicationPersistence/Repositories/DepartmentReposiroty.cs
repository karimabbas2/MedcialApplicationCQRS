using ApplicationCore.interfaces;
using ApplicationDomain;
using ApplicationPersistence.Context;

namespace ApplicationPersistence.Repositories
{
    public class DepartmentReposiroty : GenericRepository<Department, string>, IDepartmentRepository
    {
        public DepartmentReposiroty(MyDbContext myDbContext) : base(myDbContext)
        {

        }
        public Task SomeExteraMethod()
        {
            throw new NotImplementedException();
        }
    }
}