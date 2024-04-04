using ApplicationCore.Interfaces.Invoice;
using ApplicationDomain;
using ApplicationPersistence.Context;
using Microsoft.AspNetCore.Mvc;
using PdfSharp.Drawing;
using PdfSharp.Fonts;
using PdfSharp.Pdf;

namespace ApplicationPersistence.Repositories
{
    public class InvoiceRepository(MyDbContext myDbContext) : IInvoice
    {
        private readonly MyDbContext _myDbContext = myDbContext;
        public FileContentResult GenerteInvoice(Appointment appointment)
        {
            AppointmentInovice invoice = new()
            {
                Appointment = appointment,
                DoctorName = appointment.Doctor?.Name,
                Appointment_Status = appointment.AppointmentStatus,
                Appoitnment_Date = appointment.ResevtionDate,
                PatientName = appointment.PatientName,
                PatientPhone = appointment.PatientPhone

            };
            _myDbContext.AppointmentInovice.Add(invoice);
            _myDbContext.SaveChanges();
            var InvoicePdf = GenerateInvoicePdf(invoice);
            return new FileContentResult(InvoicePdf, "application/pdf");
        }

        private static byte[] GenerateInvoicePdf(AppointmentInovice invoice)
        {
            string htmlContent = "<div style = 'margin: 20px auto; max-width: 600px; padding: 20px; border: 1px solid #ccc; background-color: #FFFFFF; font-family: Arial, sans-serif;' >";
            htmlContent += "<div style = 'margin-bottom: 20px; text-align: center;'>";
            htmlContent += "<img src = 'https://encrypted-tbn0.gstatic.com/images?q=tbn:ANd9GcROnYPD5QO8ZJvPQt8ClnJNPXduCeX89dSOxA&usqp=CAU' alt = 'School Logo' style = 'max-width: 100px; margin-bottom: 10px;' >";
            htmlContent += "</div>";
            htmlContent += "<p style = 'margin: 0;' >Jobin School Management</p>";
            htmlContent += "<p style = 'margin: 0;' > 123 School Street, Sample Street</p>";
            htmlContent += "<p style = 'margin: 0;' > Phone: 123 - 456 - 7890 </p>";
            htmlContent += "<p style = 'margin: 0;' > Tamilnadu </p>";
            htmlContent += "<div style = 'text-align: center; margin-bottom: 20px;'>";
            htmlContent += "<h1> Fees Structure </h1>";
            htmlContent += "</div>";
            htmlContent += "<h3> StudentDetails:</h3>";
            htmlContent += "<p> Name:</p>";
            htmlContent += "<p> STD:</p>";
            htmlContent += "<table style = 'width: 100%; border-collapse: collapse;'>";
            htmlContent += "<thead>";
            htmlContent += "<tr>";
            htmlContent += "<th style = 'padding: 8px; text-align: left; border-bottom: 1px                           solid #ddd;' > Fee Description </th>";
            htmlContent += "<th style = 'padding: 8px; text-align: left; border-bottom: 1px solid #ddd;' > Amount(INR) </th>";
            htmlContent += "</tr><hr/>";
            htmlContent += "</thead>";
            htmlContent += "<tbody>";
            htmlContent += "<tr>";
            htmlContent += "<td style = 'padding: 8px; text-align: left; border-bottom: 1px solid #ddd;' > Tuition Fee </td>";
            htmlContent += "<td style = 'padding: 8px; text-align: left; border-bottom: 1px solid #ddd;' >RS500/- </td>";
            htmlContent += "</tr>";
            htmlContent += "<tr>";
            htmlContent += "<td style = 'padding: 8px; text-align: left; border-bottom: 1px solid #ddd;' > Transportation Fee </td>";
            htmlContent += "<td style = 'padding: 8px; text-align: left; border-bottom: 1px solid #ddd;' >RS100/- </td>";
            htmlContent += "</tr>";
            htmlContent += "<tr>";
            htmlContent += "<td style = 'padding: 8px; text-align: left; border-bottom: 1px solid #ddd;' > Books and Supplies</td>";
            htmlContent += "<td style = 'padding: 8px; text-align: left; border-bottom: 1px solid #ddd;' >RS50/- </td>";
            htmlContent += "</tr>";
            htmlContent += "</tbody>";
            htmlContent += "<tfoot>";
            htmlContent += "<tr>";
            htmlContent += "<td style = 'padding: 8px; text-align: right; font-weight: bold;'> Total:</td>";
            htmlContent += "<td style = 'padding: 8px; text-align: left; border-top: 1px solid #ddd;' >$650 </td>";
            htmlContent += "</tr>";
            htmlContent += "</tfoot>";
            htmlContent += "</table>";
            htmlContent += "</div>";

            PdfDocument Document = new();
            PdfPage page = Document.AddPage();
            XGraphics gfx = XGraphics.FromPdfPage(page);
            // PdfDocument pdfDocument = PdfGenerator.GeneratePdf(htmlContent, PageSize.A4);

            GlobalFontSettings.FontResolver ??= new FileFontResolver();

            XFont font = new(GlobalFontSettings.DefaultFontName, 12);
            int y = 20;
            gfx.DrawString($"DoctorName:{invoice.DoctorName}", font, XBrushes.Blue, 20, y);
            y += 20;
            gfx.DrawString($"Appointment_Status: {invoice.Appointment_Status}", font, XBrushes.Black, 20, y);
            y += 40;
            gfx.DrawString($"Appoitnment_Date: {invoice.Appoitnment_Date.ToShortDateString()}", font, XBrushes.Black, 20, y);
            y += 20;
            gfx.DrawString($"PatientName: {invoice.PatientName}", font, XBrushes.Black, 20, y);
            y += 40;
            gfx.DrawString($"PatientPhone: {invoice.PatientPhone}", font, XBrushes.Black, 20, y);
            y += 40;

            MemoryStream memoryStream = new();
            Document.Save(memoryStream, false);
            byte[] pdfBytes = memoryStream.ToArray();
            memoryStream.Close();

            return pdfBytes;

        }

        public class FileFontResolver : IFontResolver
        {
            public static string DefaultFontName => "Roboto-Black";

            public byte[]? GetFont(string faceName)
            {
                string desktopFolderPath = Environment.GetFolderPath(Environment.SpecialFolder.DesktopDirectory);
                string fontFileName = "roboto/Roboto-Black.ttf";
                string fontFilePath = Path.Combine(desktopFolderPath, fontFileName);

                if (File.Exists(fontFilePath))
                {
                    return File.ReadAllBytes(fontFilePath);
                }
                throw new FileNotFoundException($"{fontFileName} Not Found in DeskTop");

            }

            public FontResolverInfo? ResolveTypeface(string familyName, bool isBold, bool isItalic)
            {
                return new FontResolverInfo("roboto/Roboto-Black.ttf", true, true);

            }
        }

        public Task<AppointmentInovice> GetInvoicByAppointmentId(string id)
        {
            throw new NotImplementedException();
        }
    }
}