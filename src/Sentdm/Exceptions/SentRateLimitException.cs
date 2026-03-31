using System.Net.Http;

namespace Sentdm.Exceptions;

public class SentRateLimitException : Sent4xxException
{
    public SentRateLimitException(HttpRequestException? innerException = null)
        : base(innerException) { }
}
