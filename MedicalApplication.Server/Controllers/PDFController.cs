using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace MedicalApplication.Server.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class PDFController(IMediator mediator) : ControllerBase
    {
        private IMediator _mediator = mediator;

        // [HttpGet]
        // public async Task<IActionResult> GeneratePdf()
        // {
        //     try
        //     {
        //         _mediator.Send()
        //     }
        //     catch (System.Exception ex)
        //     {
        //         // TODO
        //     }
        // }
    }
    
}