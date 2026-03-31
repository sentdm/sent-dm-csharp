using System.Net.Http;

namespace Sentdm.Exceptions;

public class SentBadRequestException : Sent4xxException
{
    public SentBadRequestException(HttpRequestException? innerException = null)
        : base(innerException) { }
}
