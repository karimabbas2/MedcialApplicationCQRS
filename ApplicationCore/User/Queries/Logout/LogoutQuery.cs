using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ApplicationCore.HandleResponse;
using MediatR;

namespace ApplicationCore.User.Queries.Logout
{
    public class LogoutQuery : IRequest<ServiceResponse>
    {
    }
}