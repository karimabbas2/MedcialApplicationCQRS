using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ApplicationDomain;
using ApplicationPersistence.Repositories;

namespace ApplicationPersistence.Services
{
    public class DepartmentService(DepartmentReposiroty departmentReposiroty)
    {
        private readonly DepartmentReposiroty _departmentReposiroty = departmentReposiroty;

        // public async Task<Department> GetAsync(int id)
        // {
        //     return await _departmentReposiroty.GetAsync(id);
        // }
        // public async Task<ServiceResponse> AddAsync(Department department)
        // {
        //     try
        //     {
        //         if (await GetAsync(department.Id) is not null) return new ServiceResponse(false, "this Departments is exist");
        //         await _departmentReposiroty.InsertAsync(department);
        //         return new ServiceResponse(true, "Department Created Successfully");
                
        //     }
        //     catch (Exception ex)
        //     {
        //         return new ServiceResponse(false, ex.Message);
        //     }
        // }

        public async Task<IEnumerable<Department>> GetAllAsync()
        {
            return await _departmentReposiroty.GetAllAsync();
        }

    }
}