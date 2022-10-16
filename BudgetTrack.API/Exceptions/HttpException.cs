using System.Net;

namespace BudgetTrack.API.Exceptions
{
    public class HttpException : Exception
    {
        public int StatusCode { get; }
        public string? MessageDetail { get; set; }
        public string? Message { get; set; }

        public HttpException(HttpStatusCode statusCode, string message = null, string messageDetail = null) : base(message)
        {
            StatusCode = (int)statusCode;
            Message = message;
            MessageDetail = messageDetail;
        }
    }
}
