using Xunit;
using ValueOfLib;
using ValueOf.Demo;
using ValueOf.Demo.Exceptions;
using System;

namespace ValueOf.Tests
{
    public class TemperaturaTests
    {

        [Fact]
        public void Temperatura_InstanciarTemperaturaInvalido_Retornar_CelsiusMinimoExcedidoException()
        {
            //Arrange & Act & Assert
            Assert.Throws<CelsiusMinimoExcedidoException>(() => new Temperatura(-500));
        }

        [Fact]
        public void Temperatura_InstanciarTemperaturaValida_Retornar_UmaInstanciaValida()
        {
            //Arrange & Act
            var temperatura = new Temperatura(0);

            //Assert
            Assert.IsType<Temperatura>(temperatura);
            Assert.IsAssignableFrom<ValueOf<(double Celsius, double kelvin, double Fahrenheit), Temperatura>>(temperatura);
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
