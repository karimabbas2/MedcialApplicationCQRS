using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MediatR;
using MedicalApplication.Server.Controllers.Base;
using Microsoft.AspNetCore.Mvc;

namespace MedicalApplication.Server.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class PDFController : ApplicationControllerBase
    {

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