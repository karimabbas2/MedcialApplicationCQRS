using ApplicationCore.interfaces;
using MediatR;

namespace ApplicationCore.Departments.Queries.GetAllDepartments
{
    public class GetAllDepartmentQueryHandler(IDepartmentRepository departmentRepository) : IRequestHandler<GetAllDepartmentQuery, List<DepartmentListDto>>
    {
        private readonly IDepartmentRepository _departmentReposiroty = departmentRepository;

        public async Task<List<DepartmentListDto>> Handle(GetAllDepartmentQuery request, CancellationToken cancellationToken)
        {
            var Alldepts = await _departmentReposiroty.GetAllAsync();

            return Alldepts.Select(x => new DepartmentListDto
            {
                Id = x.Id,
                CreatedBy = x.CreatedBy,
                CreadtedAt = x.CreatedAt,
                Name = x.Name,
                Details = x.Details,
                UpdatedAt = x.UpdatedAt
            }).ToList();

        }
    }

}