using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ApplicationCore.Interfaces.Email
{
    public interface IEmail
    {
        Task SendEmailAsync(string Reciver, string Subject, string MessageText);
    }
}