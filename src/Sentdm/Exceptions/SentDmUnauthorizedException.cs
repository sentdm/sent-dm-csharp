using System.Net.Http;

namespace Sentdm.Exceptions;

public class SentDmUnauthorizedException : SentDm4xxException
{
    public SentDmUnauthorizedException(HttpRequestException? innerException = null)
        : base(innerException) { }
}
