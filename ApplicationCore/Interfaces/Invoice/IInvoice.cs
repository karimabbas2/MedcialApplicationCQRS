using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ApplicationDomain;
using Microsoft.AspNetCore.Mvc;

namespace ApplicationCore.Interfaces.Invoice
{
    public interface IInvoice
    {
        FileContentResult GenerteInvoice(Department obj);
    }
}