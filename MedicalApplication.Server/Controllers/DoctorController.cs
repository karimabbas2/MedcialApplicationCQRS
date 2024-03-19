using ApplicationCore.Doctors.Commands.AddDoctor;
using ApplicationCore.Doctors.Queries;
using ApplicationCore.Exceptions;
using ApplicationCore.HandleResponse;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace MedicalApplication.Server.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class DoctorController(IMediator mediator) : ControllerBase
    {
        private readonly IMediator _mediator = mediator;

        [HttpPost]
        public async Task<IActionResult> CreateDoctor([FromForm] AddDoctorCommand addDoctorCommand)
        {
            try
            {
                return Ok(await _mediator.Send(addDoctorCommand));
            }
            catch (CustomValidationException ex)
            {
                return BadRequest(ex._validationFailures.Select(x => new ServiceResponse(false, $"{x.ErrorCode} , {x.ErrorMessage}")));
            }
        }
        [HttpGet]
        public async Task<IActionResult> GetAllDoctors()
        {
            try
            {
                return Ok(await _mediator.Send(new GetAllDoctorsQuery()));
            }
            catch (System.Exception)
            {
                throw;
            }
        }

    }
}