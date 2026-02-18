using System.Net.Http;

namespace SentDm.Exceptions;

public class SentDmBadRequestException : SentDm4xxException
{
    public SentDmBadRequestException(HttpRequestException? innerException = null)
        : base(innerException) { }
}
