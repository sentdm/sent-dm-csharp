using System.Net.Http;

namespace SentDm.Exceptions;

public class SentDmUnauthorizedException : SentDm4xxException
{
    public SentDmUnauthorizedException(HttpRequestException? innerException = null)
        : base(innerException) { }
}
