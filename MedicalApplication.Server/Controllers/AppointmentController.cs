using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ApplicationCore.Appointment.Commands.AddAppointment;
using ApplicationCore.Appointment.Commands.Command;
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
    public class AppointmentController(ILogger<AppointmentController> logger) : ApplicationControllerBase
    {
        private readonly ILogger<AppointmentController> _logger = logger   ;

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
                _logger.LogInformation("get all appointments");
                _logger.LogWarning("wraning los {user}","karim");
                return MyResponseResult(await Mediator.Send(new GetAllAppointmentQuery()));
            }
            catch (Exception ex)
            {
                return BadRequest($"Error Message : {ex.Message}");
            }
        }

        [HttpDelete("{Id}")]
        public async Task<IActionResult> DeleteAppointment([FromRoute] string Id)
        {
            return MyResponseResult(await Mediator.Send(new DeleteAppointmentCommand(Id)));
        }

        [HttpPut]
        public async Task<IActionResult> UpdateDept([FromBody] UpdateAppointmentCommand updateAppointmentCommand)
        {
            return MyResponseResult(await Mediator.Send(updateAppointmentCommand));
        }

    }
}