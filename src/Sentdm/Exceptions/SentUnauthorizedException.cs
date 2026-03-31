using System.Net.Http;

namespace Sentdm.Exceptions;

public class SentUnauthorizedException : Sent4xxException
{
    public SentUnauthorizedException(HttpRequestException? innerException = null)
        : base(innerException) { }
}
