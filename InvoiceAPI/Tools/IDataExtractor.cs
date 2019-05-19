using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InvoiceAPI.Tools
{
    public interface IDataExtractor
    {
        /// <summary>
        /// A function that extracts the address, avi, and, amountDue parameters and returns it as a Json string
        /// </summary>
        /// <param name="pdfArray"></param>
        /// <returns>Json formatted string</returns>
        string ExtractInvoiceParamsAsJson(string[] pdfArray);
    }
}
