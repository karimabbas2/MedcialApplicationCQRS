using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ApplicationDomain.Concrets;

namespace ApplicationDomain
{
    public class Invoice : BaseEntity
    {
        public string? InvoiceNumber { get; set; }
        public DateTime InvoiceDate { get; set; }
        public string? CustomerName { get; set; }
        public double TotalPrice { get; set; }
    }
}