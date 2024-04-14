using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ApplicationCore.HandleResponse;
using MediatR;

namespace ApplicationCore.Departments.Commands.UpdateDepartment
{
    public class UpdateDepartmentCommand : IRequest<ResponseResult<object>>
    {
        public string Id{get;set;}
        public string? Name { get; set; }
        public string? Details { get; set; }
    }
}