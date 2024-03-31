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
            return await _myDbContext.Doctors.Include(x => x.Appointments).Include(x => x.DoctorDepartments).ThenInclude(d => d.Department).ToListAsync();

        }

        public Doctor GetDoctorById(string id)
        {
            throw new NotImplementedException();
        }

        public async Task<Doctor> GetDoctorByIdAsync(string id)
        {
            return await _myDbContext.Doctors.Where(x => x.Id == id).Include(x => x.Appointments).Include(x => x.DoctorDepartments).ThenInclude(x => x.Department).FirstOrDefaultAsync();
        }
    }
}