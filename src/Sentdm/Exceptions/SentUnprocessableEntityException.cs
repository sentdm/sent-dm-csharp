using System.Net.Http;

namespace Sentdm.Exceptions;

public class SentUnprocessableEntityException : Sent4xxException
{
    public SentUnprocessableEntityException(HttpRequestException? innerException = null)
        : base(innerException) { }
}
