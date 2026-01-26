using System.Net.Http;

namespace SentDm.Exceptions;

public class SentDmUnexpectedStatusCodeException : SentDmApiException
{
    public SentDmUnexpectedStatusCodeException(HttpRequestException? innerException = null)
        : base(innerException) { }
}
