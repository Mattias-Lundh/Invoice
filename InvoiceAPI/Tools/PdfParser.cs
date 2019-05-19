using iTextSharp.text.pdf.parser;
using iTextSharp.text.pdf;
using System.IO;
using System;
using System.Web;

namespace InvoiceAPI.Tools
{
    public class PdfParser : IPdfParser
    {
        public PdfParser(IDataExtractor dataExtractor)
        {
            this.dataExtractor = dataExtractor;
        }

        private IDataExtractor dataExtractor;

        public string GenerateJsonResponse(HttpRequest request)
        {
            if (request.Files.Count < 1) throw new Exception("file not found");

            return dataExtractor.ExtractInvoiceParamsAsJson(GetPdfTextArray(request.Files[0].InputStream));
        }

        private string GetPdfText(Stream stream)
        {
            PdfReader reader = new PdfReader(stream);
            string text = string.Empty;
            for (int page = 1; page <= reader.NumberOfPages; page++)
            {
                text += PdfTextExtractor.GetTextFromPage(reader, page);
            }
            reader.Close();
            return text;
        }

        private string[] GetPdfTextArray(Stream stream)
        {
            return GetPdfText(stream).Split(new[] { "\n" }, StringSplitOptions.None);
        }
    }
}