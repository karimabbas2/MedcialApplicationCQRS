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
                return MyResponseResult(await Mediator.Send(new GetAllDepartmentQuery()));
            }
            catch (Exception ex)
            {
                return BadRequest(new ServiceResponse(false, $"Error Message : {ex.Message}"));
            }
        }

        [HttpPost]
        public async Task<IActionResult> CreateDept([FromBody] AddDepartmentCommand addDepartmentCommand)
        {
            try
            {
                return MyResponseResult(await Mediator.Send(addDepartmentCommand));
            }
            catch (CustomValidationException ex)
            {
                return BadRequest(ex._validationFailures.Select(x => new ServiceResponse(false, $"{x.ErrorCode} , {x.ErrorMessage}")));
            }
        }

        [HttpPut]
        public async Task<IActionResult> UpdateDept([FromBody] UpdateDepartmentCommand updateDepartmentCommand)
        {
            try
            {
                return MyResponseResult(await Mediator.Send(updateDepartmentCommand));
            }
            catch (CustomValidationException ex)
            {
                return BadRequest(ex._validationFailures.Select(x => new ServiceResponse(false, $"{x.ErrorCode} , {x.ErrorMessage}")));
            }
            catch (Exception ex)
            {
                return BadRequest(new ServiceResponse(false, $"Error Message : {ex.Message}"));
            }
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteDept([FromRoute] string Id)
        {
            try
            {
                return MyResponseResult(await Mediator.Send(new DeleteDepartmentCommand(Id)));
            }
            catch (Exception ex)
            {
                return BadRequest(new ServiceResponse(false, $"Error Message : {ex.Message}"));
            }
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetDept([FromRoute] string id)
        {
            try
            {
                return MyResponseResult(await Mediator.Send(new GetDepartmentById(id)));
            }
            catch (Exception ex)
            {
                return BadRequest(new ServiceResponse(false, $"Error Message : {ex.Message}"));
            }
        }

        // [HttpPost]
        // public async Task<IActionResult> CreateDept([FromBody] AddDepartmentCommand addDepartmentCommand)
        // {
        //     try
        //     {
        //         Department department = new()
        //         {
        //             Id = Guid.NewGuid().ToString(),
        //             Details = addDepartmentCommand.Details,
        //             Name = addDepartmentCommand.Name,
        //         };
        //         return Ok(await _departmentService.AddAsync(department));
        //     }
        //     catch (System.Exception)
        //     {
        //         throw;
        //     }
        // }

    }
}