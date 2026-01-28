using System.Net.Http;

namespace Sentdm.Exceptions;

public class SentDm4xxException : SentDmApiException
{
    public SentDm4xxException(HttpRequestException? innerException = null)
        : base(innerException) { }
}
