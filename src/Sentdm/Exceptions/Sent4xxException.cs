using System.Net.Http;

namespace Sentdm.Exceptions;

public class Sent4xxException : SentApiException
{
    public Sent4xxException(HttpRequestException? innerException = null)
        : base(innerException) { }
}
