using System.Net.Http;

namespace Sentdm.Exceptions;

public class SentDmUnprocessableEntityException : SentDm4xxException
{
    public SentDmUnprocessableEntityException(HttpRequestException? innerException = null)
        : base(innerException) { }
}
