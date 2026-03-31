using System.Net.Http;

namespace Sentdm.Exceptions;

public class SentUnexpectedStatusCodeException : SentApiException
{
    public SentUnexpectedStatusCodeException(HttpRequestException? innerException = null)
        : base(innerException) { }
}
