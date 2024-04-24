using ApplicationCore.Departments.Commands.AddDepartment;
using ApplicationCore.Departments.Commands.UpdateDepartment;
using ApplicationCore.Departments.Queries.DeleteDepartment;
using ApplicationCore.Departments.Queries.GetAllDepartments;
using ApplicationCore.Departments.Queries.Queries;
using ApplicationCore.Exceptions;
using ApplicationPersistence.SeedData.Roles;
using ApplicationPersistence.Services;
using MediatR;
using MedicalApplication.Server.Controllers.Base;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Serilog;

namespace MedicalApplication.Server.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class DepartmentController : ApplicationControllerBase
    {

        // [Authorize(Roles = AppRoles.ADMIN)]
        [HttpGet]
        public async Task<IActionResult> GetAllDepts()
        {
            try
            {
                // Log.Information("All Departments");
                return MyResponseResult(await Mediator.Send(new GetAllDepartmentQuery()));
            }
            catch (Exception ex)
            {
                return BadRequest($"Error Message : {ex.Message}");
            }
        }


        [HttpPost]
        public async Task<IActionResult> CreateDept([FromBody] AddDepartmentCommand addDepartmentCommand)
        {
            return MyResponseResult(await Mediator.Send(addDepartmentCommand));
        }

        [HttpPut]
        public async Task<IActionResult> UpdateDept([FromBody] UpdateDepartmentCommand updateDepartmentCommand)
        {
            return MyResponseResult(await Mediator.Send(updateDepartmentCommand));
        }

        [HttpDelete("{Id}")]
        public async Task<IActionResult> DeleteDept([FromRoute] string Id)
        {
            return MyResponseResult(await Mediator.Send(new DeleteDepartmentCommand(Id)));
        }

        [HttpGet("{Id}")]
        public async Task<IActionResult> GetDept([FromRoute] string Id)
        {
            return MyResponseResult(await Mediator.Send(new GetDepartmentById(Id)));
        }

    }
}