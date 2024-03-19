using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ApplicationCore.Interfaces;
using ApplicationDomain;
using ApplicationPersistence.Context;

namespace ApplicationPersistence.Repositories
{
    public class AppointmentRepository : GenericRepository<Appointment, string>, IAppointmentRepoistory
    {
        public AppointmentRepository(MyDbContext myDbContext) : base(myDbContext)
        {

        }
    }
}