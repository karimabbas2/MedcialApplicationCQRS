using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ApplicationCore.HandleResponse;
using MediatR;

namespace ApplicationCore.Appointment.Commands.Command
{
    public class UpdateAppointmentCommand : IRequest<ResponseResult<object>>
    {
        public string? Id { get; set; }
        public DateTime ResevtionDate { get; set; }
        public string? AppointmentStatus { get; set; }
        public string? DoctorId { get; set; }
        public string? PatientName { get; set; }
        public string? PatientPhone { get; set; }
        public string? PatientEmail { get; set; }
        public string? PatientNotes { get; set; }

    }
}