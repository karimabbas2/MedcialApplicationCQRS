using ApplicationCore.HandleResponse;
using ApplicationCore.interfaces;
using MediatR;

namespace ApplicationCore.Departments.Commands.UpdateDepartment
{
    public class UpdateDepartmentCommandHandler(IDepartmentRepository departmentRepository) : IRequestHandler<UpdateDepartmentCommand, ServiceResponse>
    {
        private readonly IDepartmentRepository _departmentRepository = departmentRepository;
        public async Task<ServiceResponse> Handle(UpdateDepartmentCommand request, CancellationToken cancellationToken)
        {
            var dept = await _departmentRepository.GetAsync(request.Id);
            if (dept is null) return new ServiceResponse(false, "this Departments dose not exist");
            dept.Name = request.Name;
            dept.Details = request.Details;
            await _departmentRepository.UpdateAsync(request.Id, dept);
            return new ServiceResponse(true, "Department Updated Successfully");
        }
    }
}