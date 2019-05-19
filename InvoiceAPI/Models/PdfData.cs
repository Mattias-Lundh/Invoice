using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace InvoiceAPI.Models
{
    public class PdfData
    {
        public PdfData(string address, int avi, double amountDue)
        {
            Address = address;
            Avi = avi;
            AmountDue = amountDue;
        }

        public string Address { get; set; }
        public int Avi  { get; set; }
        public double AmountDue { get; set; }
    }
}