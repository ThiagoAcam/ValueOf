using System;

namespace ValueOf.Demo.Exceptions
{
    public class CelsiusMinimoExcedidoException: Exception
    {
        public CelsiusMinimoExcedidoException()
            : base("A temperatura mínima para celsius é -273.15")
        {

        }
    }
}
