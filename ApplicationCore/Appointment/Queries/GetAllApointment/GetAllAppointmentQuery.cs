using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MediatR;

namespace ApplicationCore.Appointment.Queries.GetAllApointment
{
    public class GetAllAppointmentQuery : IRequest<List<AppointmentsDto>>
    {

    }
}