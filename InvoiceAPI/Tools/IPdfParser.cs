using System.IO;
using System.Web;

namespace InvoiceAPI.Tools
{
    public interface IPdfParser
    {
        /// <summary>
        /// A function that takes a stream containing a pdf file and converts it to a json string containing addess, avi, and, ammount due
        /// </summary>
        /// <param name="stream"></param>
        /// <returns>json formatted string</returns>
        string GenerateJsonResponse(HttpRequest request);
    }
}
