using System.Net.Http;

namespace Sentdm.Exceptions;

public class SentDmBadRequestException : SentDm4xxException
{
    public SentDmBadRequestException(HttpRequestException? innerException = null)
        : base(innerException) { }
}
