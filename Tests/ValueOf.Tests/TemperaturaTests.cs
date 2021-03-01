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
            Assert.IsAssignableFrom<ValueOf<Tuple<double, double, double>, Temperatura>>(temperatura);
            Assert.Equal(0, temperatura.Celsius);
            Assert.Equal(273.15, temperatura.kelvin);
            Assert.Equal(32, temperatura.Fahrenheit);
        }

    }
}
