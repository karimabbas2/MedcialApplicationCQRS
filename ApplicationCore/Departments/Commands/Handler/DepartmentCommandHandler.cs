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

            Department department = new()
            {
                Details = request.Details,
                Name = request.Name,
            };

            if (await _departmentReposiroty.GetAsync(department.Id) is not null)
                return ResponseHandler.Conflicted<object>("this Departments is exist");

            await _departmentReposiroty.InsertAsync(department);
            var result = _mapper.Map<DepartmentListDto>(department);

            return ResponseHandler.Created<object>(result);

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

            dept.Name = request.Name;
            dept.Details = request.Details;

            await _departmentReposiroty.UpdateAsync(request.Id, dept);
            var result = _mapper.Map<DepartmentListDto>(dept);
            return ResponseHandler.Success<object>(result);
        }

        //Delete Command
        public async Task<ResponseResult<string>> Handle(DeleteDepartmentCommand request, CancellationToken cancellationToken)
        {
            // if (await _departmentReposiroty.GetAsync(request.Id) is null) return ResponseHandler.NotFound<string>("No Department with this Id");
            await _departmentReposiroty.DeleteAsync(request.Id);
            return ResponseHandler.Success("Department Deleted Successfully");
        }

    }
}