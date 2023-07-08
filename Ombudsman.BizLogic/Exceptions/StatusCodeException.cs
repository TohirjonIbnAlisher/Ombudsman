using System.Net;

namespace Ombudsman.BizLogic.Exceptions;

public class StatusCodeException : Exception
{
    public HttpStatusCode HttpStatusCode { get; set; }

    public StatusCodeException() { }

    public StatusCodeException(HttpStatusCode httpStatusCode, string message)
        : base(message)
    {
        this.HttpStatusCode = httpStatusCode;
    }
}
