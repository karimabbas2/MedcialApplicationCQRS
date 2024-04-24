using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ApplicationCore.Doctors.Queries.Results;
using ApplicationCore.HandleResponse;
using ApplicationDomain;
using MediatR;

namespace ApplicationCore.Doctors.Queries.Queries
{
    public class GetAllDeptDoctorsWithSP : IRequest<ResponseResult<List<DeptDoctorsWithSP>>>
    {

    }
}