using System.Net.Http;

namespace Sentdm.Exceptions;

public class SentDmUnexpectedStatusCodeException : SentDmApiException
{
    public SentDmUnexpectedStatusCodeException(HttpRequestException? innerException = null)
        : base(innerException) { }
}
