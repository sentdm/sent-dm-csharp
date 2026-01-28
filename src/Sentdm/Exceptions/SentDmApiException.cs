using System;
using System.Net;
using System.Net.Http;

namespace Sentdm.Exceptions;

public class SentDmApiException : SentDmException
{
    public new HttpRequestException InnerException
    {
        get
        {
            if (base.InnerException == null)
            {
                throw new ArgumentNullException();
            }
            return (HttpRequestException)base.InnerException;
        }
    }

    public SentDmApiException(string message, HttpRequestException? innerException = null)
        : base(message, innerException) { }

    protected SentDmApiException(HttpRequestException? innerException)
        : base(innerException) { }

    public required HttpStatusCode StatusCode { get; init; }

    public required string ResponseBody { get; init; }

    public override string Message
    {
        get { return string.Format("Status Code: {0}\n{1}", StatusCode, ResponseBody); }
    }
}
