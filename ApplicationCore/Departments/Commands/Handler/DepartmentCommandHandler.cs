using ApplicationCore.Departments.Commands.UpdateDepartment;
using ApplicationCore.Departments.Commands.Validations;
using ApplicationCore.Departments.Queries.DeleteDepartment;
using ApplicationCore.Departments.Queries.GetAllDepartments;
using ApplicationCore.Exceptions;
using ApplicationCore.HandleResponse;
using ApplicationCore.interfaces;
using ApplicationCore.Interfaces.Invoice;
using ApplicationDomain;
using AutoMapper;
using MediatR;

namespace ApplicationCore.Departments.Commands.AddDepartment
{
    public class DepartmentCommandHandler(IDepartmentRepository departmentRepository, IMapper mapper)
    : IRequestHandler<AddDepartmentCommand, ResponseResult<object>>,
    IRequestHandler<UpdateDepartmentCommand, ResponseResult<object>>,
    IRequestHandler<DeleteDepartmentCommand, ResponseResult<string>>
    {
        private readonly IDepartmentRepository _departmentReposiroty = departmentRepository;
        private readonly IMapper _mapper = mapper;

        //Create Command
        public async Task<ResponseResult<object>> Handle(AddDepartmentCommand request, CancellationToken cancellationToken)
        {
            //Validation
            var validator = new AddDepartmentCommandValidator();
            var validationResult = await validator.ValidateAsync(request, cancellationToken);
            if (!validationResult.IsValid) return ResponseHandler.ValidtionErrors<object>(validationResult.Errors[0].ToString());

            var department = _mapper.Map<Department>(request);
            await _departmentReposiroty.InsertAsync(department);
            
            return ResponseHandler.Created<object>(_mapper.Map<DepartmentListDto>(department));

        }

        //Update Command
        public async Task<ResponseResult<object>> Handle(UpdateDepartmentCommand request, CancellationToken cancellationToken)
        {
            //Validation
            var validator = new UpdateDepartmentCommandValidator();
            var validationResult = await validator.ValidateAsync(request, cancellationToken);
            if (!validationResult.IsValid) return ResponseHandler.ValidtionErrors<object>(validationResult.Errors[0].ToString());

            var dept = await _departmentReposiroty.GetAsync(request.Id);
            if (dept is null) return ResponseHandler.NotFound<object>("this Departments dose not exist");

            var UpdatedDept = _mapper.Map<Department>(request);
            await _departmentReposiroty.UpdateAsync(request.Id, UpdatedDept);
            
            return ResponseHandler.Success<object>(_mapper.Map<DepartmentListDto>(UpdatedDept));
        }

        //Delete Command
        public async Task<ResponseResult<string>> Handle(DeleteDepartmentCommand request, CancellationToken cancellationToken)
        {
            await _departmentReposiroty.DeleteAsync(request.Id);
            return ResponseHandler.Success("Department Deleted Successfully");
        }

    }
}