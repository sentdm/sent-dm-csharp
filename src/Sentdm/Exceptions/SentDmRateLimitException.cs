using System.Net.Http;

namespace Sentdm.Exceptions;

public class SentDmRateLimitException : SentDm4xxException
{
    public SentDmRateLimitException(HttpRequestException? innerException = null)
        : base(innerException) { }
}
