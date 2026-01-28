using System.Net.Http;

namespace SentDm.Exceptions;

public class SentDm5xxException : SentDmApiException
{
    public SentDm5xxException(HttpRequestException? innerException = null)
        : base(innerException) { }
}
