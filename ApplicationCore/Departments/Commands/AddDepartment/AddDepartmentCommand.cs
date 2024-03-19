using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ApplicationCore.HandleResponse;
using MediatR;
using Microsoft.AspNetCore.Http;

namespace ApplicationCore.Departments.Commands.AddDepartment
{
    public class AddDepartmentCommand : IRequest<ServiceResponse>
    {
        public string? Name { get; set; }
        public string? Details { get; set; }
    }
}