using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MediatR;

namespace ApplicationCore.Departments.Queries.GetAllDepartments
{
    public class GetAllDepartmentQuery : IRequest<List<DepartmentListDto>>
    {

    }
}