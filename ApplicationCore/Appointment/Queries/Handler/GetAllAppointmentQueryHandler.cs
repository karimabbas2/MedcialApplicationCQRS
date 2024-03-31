using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ApplicationCore.HandleResponse;
using ApplicationCore.Interfaces;
using AutoMapper;
using MediatR;

namespace ApplicationCore.Appointment.Queries.GetAllApointment
{
    public class GetAllAppointmentQueryHandler(IAppointmentRepoistory appointmentRepoistory, IMapper mapper)
    : IRequestHandler<GetAllAppointmentQuery, ResponseResult<List<AppointmentsDto>>>
    {
        private readonly IAppointmentRepoistory _appointmentRepoistory = appointmentRepoistory;
        private readonly IMapper _mapper = mapper;


        public async Task<ResponseResult<List<AppointmentsDto>>> Handle(GetAllAppointmentQuery request, CancellationToken cancellationToken)
        {
            var allAppointments = await _appointmentRepoistory.GetAllAsync();
            return ResponseHandler.Success(_mapper.Map<List<AppointmentsDto>>(allAppointments));

        }
    }
}