using System.Net;

namespace LoggingPOC.Models
{
    public class ErrorResponse
    {
        public string Message { get; set; }
        public HttpStatusCode StatusCode { get; set; }
    }
}
