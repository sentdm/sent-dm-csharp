using System.Net.Http;

namespace SentDm.Exceptions;

public class SentDmForbiddenException : SentDm4xxException
{
    public SentDmForbiddenException(HttpRequestException? innerException = null)
        : base(innerException) { }
}
