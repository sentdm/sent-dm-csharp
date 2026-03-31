using System.Net.Http;

namespace Sentdm.Exceptions;

public class SentForbiddenException : Sent4xxException
{
    public SentForbiddenException(HttpRequestException? innerException = null)
        : base(innerException) { }
}
