using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using InvoiceAPI.Models;

namespace InvoiceUnitTests.Builders.InvoiceApiTestBuilders
{
    public class PdfDataBuilder : PdfData
    {
        public PdfDataBuilder() : base(string.Empty, default(int), default(double))
        {
        }

        public PdfDataBuilder(string address, int avi, double amountDue) : base(address, avi, amountDue)
        {
        }

        public override bool Equals(object obj)
        {
            return base.Equals(obj);
        }

        public override int GetHashCode()
        {
            return base.GetHashCode();
        }

        public override string ToString()
        {
            return base.ToString();
        }

        public PdfDataBuilder SetAddress(string address)
        {
            this.Address = address;
            return this;
        }

        public PdfDataBuilder SetAvi(int avi)
        {
            this.Avi = avi;
            return this;
        }

        public PdfDataBuilder SetAmountDue(double amountDue)
        {
            this.AmountDue = amountDue;
            return this;
        }
    }
}
