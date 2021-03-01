using System;
using ValueOf.Demo.Exceptions;
using ValueOfLib;

namespace ValueOf.Demo
{
    public class Temperatura:ValueOf<Tuple<double, double, double>, Temperatura>
    {
        public double Celsius => Value.Item1;
        public double kelvin => Value.Item2;
        public double Fahrenheit => Value.Item3;

        public Temperatura(double celsius)
            :base(new Tuple<double, double, double>(celsius, celsius + 273.15, celsius * 1.8 + 32))
        { }

        protected override bool Equals(Temperatura obj)
            => Value.Item1 == obj.Celsius;

        protected override void Validate()
        {
            if(Value.Item1 < -273.15)
                throw new CelsiusMinimoExcedidoException();
        }
    }
}
