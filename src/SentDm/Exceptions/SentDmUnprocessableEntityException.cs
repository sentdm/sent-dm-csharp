using System.Net.Http;

namespace SentDm.Exceptions;

public class SentDmUnprocessableEntityException : SentDm4xxException
{
    public SentDmUnprocessableEntityException(HttpRequestException? innerException = null)
        : base(innerException) { }
}
