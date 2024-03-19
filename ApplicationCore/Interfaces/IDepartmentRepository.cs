using ApplicationCore.Interfaces;
using ApplicationDomain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ApplicationCore.interfaces
{
    public interface IDepartmentRepository : IGenericRepository<Department,string>
    {
        Task SomeExteraMethod();
    }
}