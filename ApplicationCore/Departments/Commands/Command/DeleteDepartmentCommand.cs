using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ApplicationCore.HandleResponse;
using MediatR;

namespace ApplicationCore.Departments.Queries.DeleteDepartment
{
    public class DeleteDepartmentCommand(string Id) : IRequest<ResponseResult<string>>
    {
        public string? Id { get; set; } = Id;
    }
}