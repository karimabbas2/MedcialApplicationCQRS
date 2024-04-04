using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ApplicationCore.Interfaces.Invoice;
using ApplicationCore.PDF.Query;
using MediatR;
using MedicalApplication.Server.Controllers.Base;
using Microsoft.AspNetCore.Mvc;
using PdfSharp.Pdf;
using PdfSharp.Pdf.AcroForms;

namespace MedicalApplication.Server.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class PDFController : ApplicationControllerBase
    {

        [HttpGet("AppointmentInoivce")]
        public async Task<IActionResult> GeneratePdf()
        {
            try
            {
                return MyResponseResult(await Mediator.Send(new PdfResultQuery()));
            }
            catch (System.Exception ex)
            {
                throw;
            }
        }
    }

}