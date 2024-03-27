using ApplicationCore.Doctors.Commands.AddDoctor;
using ApplicationCore.Doctors.Queries;
using ApplicationCore.Doctors.Queries.GetlDoctorById;
using ApplicationCore.Exceptions;
using ApplicationCore.HandleResponse;
using ApplicationPersistence.SeedData.Roles;
using MediatR;
using Microsoft.AspNetCore.Authorization;
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
        [Authorize(Roles = "client")]
        public async Task<IActionResult> GetAllDoctors()
        {
            try
            {
                return Ok(await _mediator.Send(new GetAllDoctorsQuery()));
            }
            catch (Exception)
            {
                // return BadRequest(new ServiceResponse(false, $"Error Message : {ex.Message}"));
                throw;
            }
        }

        [HttpGet("{id}")]
        [Authorize(Roles = AppRoles.CLIENT)]
        public async Task<IActionResult> GetDoctor([FromRoute] string id)
        {
            try
            {
                return Ok(await _mediator.Send(new DoctorQuery(id)));
            }
            catch (System.Exception)
            {
                throw;
            }
        }

    }
}