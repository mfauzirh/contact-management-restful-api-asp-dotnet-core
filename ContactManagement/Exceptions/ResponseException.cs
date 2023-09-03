using System.Net;

namespace ContactManagement.Exceptions;

public class ResponseException : Exception
{
    public HttpStatusCode StatusCode { get; set; }

    public ResponseException(HttpStatusCode statusCode, string message) : base(message)
    {
        StatusCode = statusCode;
    }
}