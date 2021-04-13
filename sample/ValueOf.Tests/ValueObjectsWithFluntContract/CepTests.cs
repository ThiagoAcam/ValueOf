using System.Linq;
using ValueOfLib.Exceptions;
using Xunit;
using ValueOf.Demo.ValueObjectsWithFluntContract;
using ValueOfLib.Flunt;

namespace ValueOf.Tests.ValueObjectsWithFluntContract
{
    public class CepTests
    {

        [Fact]
        public void Cep_InstanciarCepInvalido_Retornar_ValueObjectInvalidException()
        {
            //Arrange & Act
            var cep = new Cep("23--!000");

            //Assert
            Assert.False(cep.IsValid);
            Assert.Equal("O CEP está em um formato inválido", cep.Notifications.FirstOrDefault().Message);
            Assert.Throws<ValueObjectInvalidException>(() => cep.Value);
        }

        [Fact]
        public void Cep_InstanciarCepValido_Retornar_UmaInstanciaValida()
        {
            //Arrange & Act
            var cep = new Cep("12345678");

            //Assert
            Assert.IsType<Cep>(cep);
            Assert.IsAssignableFrom<ValueOfWithFlunt<string, Cep>>(cep);
            Assert.Equal("12345678", cep.Value);
        }

        [Fact]
        public void Cep_Instanciar2CepsValidos_VerificarIgualdade_DeveSerTrue()
        {
            //Arrange & Act
            var cep1 = new Cep("12345678");
            var cep2 = new Cep("12345678");

            //Assert
            Assert.True(cep1.Equals(cep2));
        }

    }
}
