using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ApplicationCore.HandleResponse;
using MediatR;

namespace ApplicationCore.Doctors.Queries
{
    public class GetAllDoctorsQuery :IRequest<ResponseResult<List<DoctorListDto>>>
    {
        
    }
}