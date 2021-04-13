﻿using Flunt.Validations;
using ValueOfLib.Flunt;

namespace ValueOf.Demo.ValueObjectsWithFluntContract
{
    public class Temperatura : ValueOfWithFlunt<(double Celsius, double kelvin, double Fahrenheit), Temperatura>
    {
        public Temperatura(double celsius)
            : base((celsius, celsius + 273.15, celsius * 1.8 + 32))
        { }

        protected override bool Equals(Temperatura obj)
            => Value.Celsius == obj.Value.Celsius;

        protected override void Validations()
        {
            AddNotifications(new CreateTemperaturaContract(this));
        }
    }

    public class CreateTemperaturaContract : Contract<Temperatura>
    {
        public CreateTemperaturaContract(Temperatura temperatura)
        {
            Requires()
                .IsGreaterThan(temperatura.Value.Celsius, -273.15, "Temperature", "Invalid temperature");
        }
    }
}
