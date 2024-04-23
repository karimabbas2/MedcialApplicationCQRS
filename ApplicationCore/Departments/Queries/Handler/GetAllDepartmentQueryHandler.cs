using ApplicationCore.Departments.Queries.Queries;
using ApplicationCore.HandleResponse;
using ApplicationCore.interfaces;
using ApplicationDomain;
using AutoMapper;
using MediatR;

namespace ApplicationCore.Departments.Queries.GetAllDepartments
{
    public class GetAllDepartmentQueryHandler(IDepartmentRepository departmentRepository, IMapper mapper) :
    IRequestHandler<GetAllDepartmentQuery, ResponseResult<List<DepartmentListDto>>>,
    IRequestHandler<GetDepartmentById, ResponseResult<object>>
    {
        private readonly IDepartmentRepository _departmentReposiroty = departmentRepository;
        private readonly IMapper _mapper = mapper;

        public async Task<ResponseResult<List<DepartmentListDto>>> Handle(GetAllDepartmentQuery request, CancellationToken cancellationToken)
        {
            var Alldepts = await _departmentReposiroty.GetAllAsync();
            return ResponseHandler.Success(_mapper.Map<List<DepartmentListDto>>(Alldepts));
        }

        public async Task<ResponseResult<object>> Handle(GetDepartmentById request, CancellationToken cancellationToken)
        {
            var dept = await _departmentReposiroty.GetDepartmentByIdAsync(request.Id);
            if (dept is null) return ResponseHandler.NotFound<object>("No Department Found");
            return ResponseHandler.Success<object>(dept);
        }
    }

}