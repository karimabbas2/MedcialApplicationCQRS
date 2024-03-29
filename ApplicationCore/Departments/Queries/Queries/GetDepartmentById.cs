using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ApplicationCore.Departments.Queries.GetAllDepartments;
using ApplicationCore.HandleResponse;
using MediatR;

namespace ApplicationCore.Departments.Queries.Queries
{
    public class GetDepartmentById(string Id) : IRequest<ResponseResult<DepartmentListDto>>
    {
        public string Id { get; set; } = Id;

    }
}