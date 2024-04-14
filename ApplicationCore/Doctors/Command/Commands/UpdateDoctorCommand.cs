using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ApplicationCore.HandleResponse;
using MediatR;

namespace ApplicationCore.Doctors.Command.Commands
{
    public class UpdateDoctorCommand : IRequest<ResponseResult<object>>
    {

    }
}