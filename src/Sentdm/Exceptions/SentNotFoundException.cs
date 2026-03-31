using System.Net.Http;

namespace Sentdm.Exceptions;

public class SentNotFoundException : Sent4xxException
{
    public SentNotFoundException(HttpRequestException? innerException = null)
        : base(innerException) { }
}
