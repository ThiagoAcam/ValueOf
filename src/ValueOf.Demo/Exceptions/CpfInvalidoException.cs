using System;

namespace ValueOf.Demo.Exceptions
{
    public class CpfInvalidoException : Exception
    {
        public CpfInvalidoException()
            : base("O CPF informado é inválido")
        { }
    }
}
