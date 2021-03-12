using System;
using ValueOf.Demo.Exceptions;
using ValueOfLib;

namespace ValueOf.Demo
{
    public class Temperatura:ValueOf<(double Celsius, double kelvin, double Fahrenheit), Temperatura>
    {
        public Temperatura(double celsius)
            :base((celsius, celsius + 273.15, celsius * 1.8 + 32))
        { }

        protected override bool Equals(Temperatura obj)
            => Value.Celsius == obj.Value.Celsius;

        protected override bool Validate()
        {
            if(Value.Celsius < -273.15)
                throw new CelsiusMinimoExcedidoException();

            return true;
        }
    }
}
