using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using InvoiceAPI.Models;

namespace InvoiceAPI.Tools
{
    public class DataExtractor : IDataExtractor
    {
        public string ExtractInvoiceParamsAsJson(string[] pdfArray)
        {
            return JsonConvert.SerializeObject(ParsePdf(pdfArray));
        }

        private PdfData ParsePdf(string[] pdfArray)
        {
            if(pdfArray.Length < 38) return new PdfData(string.Empty, default(int), default(double));

            var address = pdfArray[2] ?? string.Empty;
            var avi = GetAvi(pdfArray[0]) ?? default(int);
            var amountDue = GetAmountDue(pdfArray[37]) ?? default(double);

            return new PdfData(address, avi, amountDue);
        }

        private int? GetAvi(string s)
        {
            var sb = new StringBuilder();
            foreach (char c in s)
            {
                if (char.IsDigit(c))
                {
                    sb.Append(c);
                }
            }

            if (int.TryParse(sb.ToString(), out int result)) return result;

            return null;
        }

        private double? GetAmountDue(string s)
        {
            var numbers = new[] {'0', '1', '2', '3', '4', '5', '6', '7', '8', '9'};
            var start = s.IndexOfAny(numbers);
            var length = s.LastIndexOf(' ') - start;

            if (start < 0) return null;
            if (length < 0) return null;
            if (double.TryParse(s.Substring(start, length), out double result)) return result / 100;
            return null;
        }
    }
}