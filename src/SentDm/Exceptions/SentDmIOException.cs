using System;
using System.Net.Http;

namespace SentDm.Exceptions;

public class SentDmIOException : SentDmException
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

    public SentDmIOException(string message, HttpRequestException? innerException = null)
        : base(message, innerException) { }
}
