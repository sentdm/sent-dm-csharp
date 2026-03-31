using System;
using System.Net.Http;

namespace Sentdm.Exceptions;

public class SentException : Exception
{
    public SentException(string message, Exception? innerException = null)
        : base(message, innerException) { }

    protected SentException(HttpRequestException? innerException)
        : base(null, innerException) { }
}
