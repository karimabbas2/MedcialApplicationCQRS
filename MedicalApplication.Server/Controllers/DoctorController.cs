using ApplicationCore.Doctors.Command.Commands;
using ApplicationCore.Doctors.Commands.AddDoctor;
using ApplicationCore.Doctors.Queries;
using ApplicationCore.Doctors.Queries.GetlDoctorById;
using ApplicationCore.Doctors.Queries.Queries;
using MedicalApplication.Server.Controllers.Base;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace MedicalApplication.Server.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class DoctorController : ApplicationControllerBase
    {

        [HttpPost]
        public async Task<IActionResult> CreateDoctor([FromBody] AddDoctorCommand addDoctorCommand)
        {
            return MyResponseResult(await Mediator.Send(addDoctorCommand));
        }
        [HttpGet]
        // [Authorize(Roles = "admin")]
        public async Task<IActionResult> GetAllDoctors()
        {
            try
            {
                return Ok(await Mediator.Send(new GetAllDoctorsQuery()));
            }
            catch (Exception)
            {
                // return BadRequest(new ServiceResponse(false, $"Error Message : {ex.Message}"));
                throw;
            }
        }

        [HttpGet("WithSP")]
        public async Task<IActionResult> GetAllDeptWithSP()
        {
            try
            {
                return MyResponseResult(await Mediator.Send(new GetAllDeptDoctorsWithSP()));
            }
            catch (Exception ex)
            {
                return BadRequest($"Error Message : {ex.Message}");
            }
        }

        [HttpPut]
        public async Task<IActionResult> UpdateDoctor([FromBody] UpdateDoctorCommand updateDoctorCommand)
        {
            return MyResponseResult(await Mediator.Send(updateDoctorCommand));
        }

        [HttpGet("{id}")]
        // [Authorize(Roles = AppRoles.CLIENT)]
        public async Task<IActionResult> GetDoctor([FromRoute] string id)
        {
            return Ok(await Mediator.Send(new DoctorQuery(id)));
        }

        [HttpDelete("{Id}")]
        public async Task<IActionResult> DeleteDoctor([FromRoute] string Id)
        {
            return MyResponseResult(await Mediator.Send(new DeleteDoctorCommand(Id)));
        }

    }
}