using System.Net.NetworkInformation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ApplicationCore.Interfaces;
using ApplicationDomain;
using ApplicationPersistence.Context;
using Microsoft.EntityFrameworkCore;
using System.Security.Cryptography.X509Certificates;
using System.Linq.Expressions;

namespace ApplicationPersistence.Repositories
{
    public class AppointmentRepository : GenericRepository<Appointment, string>, IAppointmentRepoistory
    {
        private readonly MyDbContext _myDbContext;
        public AppointmentRepository(MyDbContext myDbContext) : base(myDbContext)
        {
            _myDbContext = myDbContext;
        }
        public async Task<List<Appointment>> GetAllAsync()
        {
            return await _myDbContext.Appointments.AsNoTracking().Include(x => x.Doctor).ToListAsync();
        }

        public async Task<Appointment> GetLastAppointment()
        {
            return await _myDbContext.Appointments.Include(x => x.Doctor).OrderBy(x => x.Id).FirstOrDefaultAsync();
        }

        public async Task<ApplicationDomain.Appointment> GetFirstAsync(Expression<Func<Appointment, bool>> expression)
        {
            return await _myDbContext.Appointments.Include(x => x.Doctor).FirstOrDefaultAsync(expression);
        }
    }


}