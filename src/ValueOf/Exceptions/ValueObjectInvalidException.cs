using System;

namespace ValueOfLib.Exceptions
{
    public class ValueObjectInvalidException : Exception
    {
        public ValueObjectInvalidException()
            : base("This Value Object is not valid")
        { }
    }
}
