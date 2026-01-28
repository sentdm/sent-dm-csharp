using System;

namespace Sentdm.Exceptions;

public class SentDmInvalidDataException : SentDmException
{
    public SentDmInvalidDataException(string message, Exception? innerException = null)
        : base(message, innerException) { }
}
