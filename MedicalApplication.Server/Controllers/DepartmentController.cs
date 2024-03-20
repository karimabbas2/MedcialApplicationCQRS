using ApplicationCore.Departments.Commands.AddDepartment;
using ApplicationCore.Departments.Commands.UpdateDepartment;
using ApplicationCore.Departments.Queries.DeleteDepartment;
using ApplicationCore.Departments.Queries.GetAllDepartments;
using ApplicationCore.Exceptions;
using ApplicationCore.HandleResponse;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace MedicalApplication.Server.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class DepartmentController(IMediator mediator) : ControllerBase
    {
        private IMediator _mediator = mediator;
        // protected IMediator Mediator => _mediator ??= HttpContext.RequestServices.GetService(typeof(IMediator)) as IMediator;

        [HttpGet]
        public async Task<IActionResult> GetAllDepts()
        {
            try
            {
                return Ok(await _mediator.Send(new GetAllDepartmentQuery()));
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
                return Ok(await _mediator.Send(addDepartmentCommand));
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
                return Ok(await _mediator.Send(updateDepartmentCommand));
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
                return Ok(await _mediator.Send(new DeleteDepartmentCommand(Id)));
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