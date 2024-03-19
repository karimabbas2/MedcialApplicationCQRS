using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ApplicationCore.Appointment.Commands.AddAppointment;
using ApplicationCore.Appointment.Queries.GetAllApointment;
using ApplicationCore.Exceptions;
using ApplicationCore.HandleResponse;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace MedicalApplication.Server.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AppointmentController(IMediator mediator) : ControllerBase
    {
        private readonly IMediator _mediator = mediator;

        [HttpPost]
        public async Task<IActionResult> CreateAppointment([FromForm] MakeAppointmentCommand makeAppointmentCommand)
        {
            try
            {
                return Ok(await _mediator.Send(makeAppointmentCommand));
            }
            catch (CustomValidationException ex)
            {
                return BadRequest(ex._validationFailures.Select(x => new ServiceResponse(false, $"{x.ErrorCode} , {x.ErrorMessage}")));
            }
        }

        [HttpGet]
        public async Task<IActionResult> GetAllAppointment()
        {
            try
            {
                return Ok(await _mediator.Send(new GetAllAppointmentQuery()));
            }
            catch (Exception)
            {
                throw;
            }
        }

    }
}