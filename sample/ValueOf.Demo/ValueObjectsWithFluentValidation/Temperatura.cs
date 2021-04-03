using FluentValidation;
using ValueOfLib.FluentValidation;

namespace ValueOf.Demo.ValueObjectsWithFluentValidation
{
    public class Temperatura : ValueOfWithFluentValidation.WithNotifications<(double Celsius, double kelvin, double Fahrenheit), Temperatura, TemperaturaValidator>
    {
        public Temperatura(double celsius)
            : base((celsius, celsius + 273.15, celsius * 1.8 + 32))
        { }

        protected override bool Equals(Temperatura obj)
            => Value.Celsius == obj.Value.Celsius;
    }

    public class TemperaturaValidator : AbstractValidator<Temperatura>
    {
        public TemperaturaValidator()
        {
            RuleFor(p => p.Value.Celsius)
                .GreaterThanOrEqualTo(-273.15)
                .WithMessage("A temperatura mínima para celsius é -273.15");
        }
    }
}
