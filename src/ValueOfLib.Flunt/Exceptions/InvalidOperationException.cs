using System;

namespace ValueOfLib.Flunt.Exceptions
{
    public class InvalidCallMomentException : Exception
    {
        public InvalidCallMomentException(string message)
            : base(message)
        { }
    }
}
