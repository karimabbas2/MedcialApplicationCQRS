using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ApplicationCore.HandleResponse;
using ApplicationCore.interfaces;
using MediatR;

namespace ApplicationCore.Departments.Queries.DeleteDepartment
{
    public class DeleteDepartmentQueryHandler(IDepartmentRepository departmentRepository) : IRequestHandler<DeleteDepartmentCommand, ServiceResponse>
    {
        private readonly IDepartmentRepository _departmentRepository = departmentRepository;
        public async Task<ServiceResponse> Handle(DeleteDepartmentCommand request, CancellationToken cancellationToken)
        {
            if (await _departmentRepository.GetAsync(request.Id) is null) return new ServiceResponse(false, "No Department with this Id");
            await _departmentRepository.DeleteAsync(request.Id);
            return new ServiceResponse(true, "Department Deleted Successfully");
        }
    }
}