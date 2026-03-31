using System;

namespace Sentdm.Exceptions;

public class SentInvalidDataException : SentException
{
    public SentInvalidDataException(string message, Exception? innerException = null)
        : base(message, innerException) { }
}
