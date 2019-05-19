using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web;
using System.Web.Http;
using InvoiceAPI.Tools;
using RestSharp;
using System.Threading.Tasks;


namespace InvoiceAPI.Controllers
{
    public class InvoiceController : ApiController
    {
        public InvoiceController(IPdfParser pdfParser)
        {
            this.pdfParser = pdfParser;
        }

        private IPdfParser pdfParser;

        public string Get()
        {
            return "working";
        }

        // POST: api/Invoice
        [HttpPost]
        public async Task<string> Post()
        {
            HttpContext.Current.Response.AddHeader("Access-Control-Allow-Origin", "*");
            return await pdfParser.GenerateJsonResponse(HttpContext.Current.Request);
        }
    }
}
