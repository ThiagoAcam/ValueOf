using System.Linq;
using ValueOf.Demo.ValueObjectsWithFluentValidation;
using ValueOfLib.Exceptions;
using ValueOfLib.FluentValidation;
using Xunit;

namespace ValueOf.Tests.ValueObjectsWithFluentValidation
{
    public class TemperaturaTests
    {
        [Fact]
        public void Temperatura_InstanciarTemperaturaInvalido_Retornar_UmObjetoInvalido()
        {
            //Arrange & Act
            var temperatura = new Temperatura(-500);

            //Assert
            Assert.False(temperatura.IsValid);
            Assert.Equal("A temperatura mínima para celsius é -273.15", temperatura.ValidationResult.Errors.FirstOrDefault().ErrorMessage);
            Assert.Throws<ValueObjectInvalidException>(() => temperatura.Value);
        }

        [Fact]
        public void Temperatura_InstanciarTemperaturaValida_Retornar_UmaInstanciaValida()
        {
            //Arrange & Act
            var temperatura = new Temperatura(0);

            //Assert
            Assert.IsType<Temperatura>(temperatura);
            Assert.IsAssignableFrom<ValueOfWithFluentValidation.WithNotifications<(double Celsius, double kelvin, double Fahrenheit), Temperatura, TemperaturaValidator>>(temperatura);
            Assert.Equal(0, temperatura.Value.Celsius);
            Assert.Equal(273.15, temperatura.Value.kelvin);
            Assert.Equal(32, temperatura.Value.Fahrenheit);
        }

        [Fact]
        public void Temperatura_Instanciar2TemperaturasValidas_VerificarIgualdade_DeveSerTrue()
        {
            //Arrange & Act
            var temperatura1 = new Temperatura(30);
            var temperatura2 = new Temperatura(30);

            //Assert
            Assert.True(temperatura1.Equals(temperatura2));
        }
    }
}
