using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.UI.Services;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Options;
using Microsoft.VisualBasic.FileIO;
using SendGrid;
using SendGrid.Helpers.Mail;

namespace ApplicationInfrastructure.EmailService
{
    public class SendGrid(IConfiguration configuration) : IEmailSender
    {

        private readonly IConfiguration _configuration = configuration;

        public async Task SendEmailAsync(string email, string subject, string htmlMessage)
        {
            var emailSettings = _configuration.GetSection("EmailSettings");

            string apiKey = emailSettings["ApiKey"];
            var client = new SendGridClient(apiKey);
            var msg = new SendGridMessage()
            {
                From = new EmailAddress(emailSettings["Username"], "MedcialAdmin"),
                Subject = subject,
                PlainTextContent = subject
            };
            msg.AddTo(new EmailAddress(email));
            await client.SendEmailAsync(msg);
        }
    }
}