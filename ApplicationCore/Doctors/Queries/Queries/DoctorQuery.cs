using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ApplicationCore.HandleResponse;
using MediatR;

namespace ApplicationCore.Doctors.Queries.GetlDoctorById
{
    public class DoctorQuery(string Id) : IRequest<ResponseResult<DoctorListDto>>
    {
        public string Id { get; set; } = Id;
    }
}