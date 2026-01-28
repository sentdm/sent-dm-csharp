using System;
using System.Net.Http;

namespace Sentdm.Exceptions;

public class SentDmException : Exception
{
    public SentDmException(string message, Exception? innerException = null)
        : base(message, innerException) { }

    protected SentDmException(HttpRequestException? innerException)
        : base(null, innerException) { }
}
