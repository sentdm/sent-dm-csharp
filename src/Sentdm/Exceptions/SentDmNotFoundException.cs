using System.Net.Http;

namespace Sentdm.Exceptions;

public class SentDmNotFoundException : SentDm4xxException
{
    public SentDmNotFoundException(HttpRequestException? innerException = null)
        : base(innerException) { }
}
