using ApplicationCore.interfaces;
using AutoMapper;
using MediatR;

namespace ApplicationCore.Departments.Queries.GetAllDepartments
{
    public class GetAllDepartmentQueryHandler(IDepartmentRepository departmentRepository, IMapper mapper) : IRequestHandler<GetAllDepartmentQuery, List<DepartmentListDto>>
    {
        private readonly IDepartmentRepository _departmentReposiroty = departmentRepository;
        private readonly IMapper _mapper = mapper;

        public async Task<List<DepartmentListDto>> Handle(GetAllDepartmentQuery request, CancellationToken cancellationToken)
        {
            var Alldepts = await _departmentReposiroty.GetAllAsync();
            return _mapper.Map<List<DepartmentListDto>>(Alldepts);
        }
    }

}