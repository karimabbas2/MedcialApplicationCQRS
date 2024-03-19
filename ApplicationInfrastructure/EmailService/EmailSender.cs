using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Threading.Tasks;
using ApplicationCore.Interfaces.Email;
using Microsoft.Extensions.Configuration;
using SendGrid;
using SendGrid.Helpers.Mail;

namespace ApplicationInfrastructure.EmailService
{
    public class EmailSender(IConfiguration configuration) : IEmail
    {
        private readonly IConfiguration _configuration = configuration;
        public async Task SendEmailAsync(string Reciver, string Subject, string MessageText)
        {
            var emailSettings = _configuration.GetSection("EmailSettings");

            //way 1
            var client = new SmtpClient("sandbox.smtp.mailtrap.io", 2525)
            {
                Credentials = new NetworkCredential(emailSettings["Username"], emailSettings["Password"]),
                EnableSsl = true
            };
            client.Send("from@MedicalAppliction.com", Reciver, Subject, MessageText);
            System.Console.WriteLine("Sent");

            //way 2
            // string apiKey = Environment.GetEnvironmentVariable("ApiKey");
            // var client = new SendGridClient(apiKey);
            // var msg = new SendGridMessage()
            // {
            //     From = new EmailAddress(emailSettings["Username"], "MedcialAdmin"),
            //     Subject = $"{Subject}",
            //     PlainTextContent = $"{MessageText}"
            // };
            // msg.AddTo(new EmailAddress(Reciver));
            // var response = await client.SendEmailAsync(msg);

        }
    }
}