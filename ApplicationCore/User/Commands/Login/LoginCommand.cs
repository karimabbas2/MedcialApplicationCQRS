using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ApplicationCore.HandleResponse;
using MediatR;

namespace ApplicationCore.User.Commands.Login
{
    public class LoginCommand : IRequest<ServiceResponse>
    {
        public string? Email { get; set; }
        public string? Password { get; set; }
    }
}