using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ApplicationCore.HandleResponse;
using ApplicationCore.Interfaces;
using ApplicationCore.Interfaces.Invoice;
using ApplicationCore.PDF.Query;
using MediatR;

namespace ApplicationCore.PDF.Handler
{
    public class PdfQueryHandler(IInvoice invoice, IAppointmentRepoistory appointmentRepoistory) : IRequestHandler<PdfResultQuery, ResponseResult<string>>
    {
        private readonly IInvoice _invoice = invoice;
        private readonly IAppointmentRepoistory _appointmentRepoistory = appointmentRepoistory;

        public async Task<ResponseResult<string>> Handle(PdfResultQuery request, CancellationToken cancellationToken)
        {
            var appointment = await _appointmentRepoistory.GetLastAppointment();

            //Write Bytes of Genertited File
            var FileContentResult = _invoice.GenerteInvoice(appointment);
            byte[] fileContents = FileContentResult.FileContents;
            string desktopFolderPath = Environment.GetFolderPath(Environment.SpecialFolder.DesktopDirectory);
            string filePath = Path.Combine(desktopFolderPath, $"C:\\Users\\20115\\Desktop\\MedicalPdf\\{appointment.PatientName}.pdf");
            File.WriteAllBytes(filePath, fileContents);
            return ResponseHandler.Success("Appointment Inovice Genertated Successfully");
        }
    }
}