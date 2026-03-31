using System.Net.Http;

namespace Sentdm.Exceptions;

public class Sent5xxException : SentApiException
{
    public Sent5xxException(HttpRequestException? innerException = null)
        : base(innerException) { }
}
