using System.IO;
using System.Threading.Tasks;
using System.Web;

namespace InvoiceAPI.Tools
{
    public interface IPdfParser
    {
        /// <summary>
        /// A function that takes a stream containing a pdf file and converts it to a json string containing addess, avi, and, ammount due.
        /// Simulates a delay for loading bar purposes
        /// </summary>
        /// <param name="stream"></param>
        /// <returns>json formatted string</returns>
        Task<string> GenerateJsonResponse(HttpRequest request);
    }
}
