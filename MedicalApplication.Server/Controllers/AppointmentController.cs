using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ApplicationCore.Appointment.Commands.AddAppointment;
using ApplicationCore.Appointment.Queries.GetAllApointment;
using ApplicationCore.Exceptions;
using ApplicationCore.HandleResponse;
using MediatR;
using MedicalApplication.Server.Controllers.Base;
using Microsoft.AspNetCore.Mvc;

namespace MedicalApplication.Server.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AppointmentController : ApplicationControllerBase
    {

        [HttpPost]
        public async Task<IActionResult> CreateAppointment([FromBody] MakeAppointmentCommand makeAppointmentCommand)
        {
            return MyResponseResult(await Mediator.Send(makeAppointmentCommand));
        }

        [HttpGet]
        public async Task<IActionResult> GetAllAppointment()
        {
            try
            {
                return MyResponseResult(await Mediator.Send(new GetAllAppointmentQuery()));
            }
            catch (Exception ex)
            {
                return BadRequest($"Error Message : {ex.Message}");
            }
        }

    }
}