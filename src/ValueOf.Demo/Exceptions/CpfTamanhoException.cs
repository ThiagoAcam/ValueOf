using System;

namespace ValueOf.Demo.Exceptions
{
    public class CpfTamanhoException: Exception
    {
        public CpfTamanhoException()
            :base("O tamanho do CPF deve conter 11 dígitos")
        { }
    }
}
