using System.Linq;
using Xunit;
using ValueOf.Demo.ValueObjectsWithFluntContract;
using ValueOfLib.Exceptions;
using ValueOfLib.Flunt;

namespace ValueOf.Tests.ValueObjectsWithFluntContract
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
            Assert.Equal("Invalid temperature", temperatura.Notifications.FirstOrDefault().Message);
            Assert.Throws<ValueObjectInvalidException>(() => temperatura.Value);
        }

        [Fact]
        public void Temperatura_InstanciarTemperaturaValida_Retornar_UmaInstanciaValida()
        {
            //Arrange & Act
            var temperatura = new Temperatura(0);

            //Assert
            Assert.IsType<Temperatura>(temperatura);
            Assert.IsAssignableFrom<ValueOfWithFlunt<(double Celsius, double kelvin, double Fahrenheit), Temperatura>>(temperatura);
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
