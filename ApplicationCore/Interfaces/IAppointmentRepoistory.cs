using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ApplicationDomain;

namespace ApplicationCore.Interfaces
{
    public interface IAppointmentRepoistory : IGenericRepository<ApplicationDomain.Appointment, string>
    {
        Task<ApplicationDomain.Appointment> GetLastAppointment();
    }
}