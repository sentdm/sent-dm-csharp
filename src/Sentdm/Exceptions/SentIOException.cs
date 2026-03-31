using System;
using System.Net.Http;

namespace Sentdm.Exceptions;

public class SentIOException : SentException
{
    public new HttpRequestException InnerException
    {
        get
        {
            if (base.InnerException == null)
            {
                throw new ArgumentNullException();
            }
            return (HttpRequestException)base.InnerException;
        }
    }

    public SentIOException(string message, HttpRequestException? innerException = null)
        : base(message, innerException) { }
}
