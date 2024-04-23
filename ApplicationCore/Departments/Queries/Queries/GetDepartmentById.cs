using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ApplicationCore.Departments.Queries.GetAllDepartments;
using ApplicationCore.HandleResponse;
using ApplicationDomain;
using MediatR;

namespace ApplicationCore.Departments.Queries.Queries
{
    public class GetDepartmentById(string Id) : IRequest<ResponseResult<object>>
    {
        public string Id { get; set; } = Id;

    }
}