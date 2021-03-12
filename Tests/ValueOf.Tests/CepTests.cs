using Xunit;
using ValueOfLib;
using ValueOf.Demo;
using ValueOfLib.Exceptions;

namespace ValueOf.Tests
{
    public class CepTests
    {

        [Fact]
        public void Cep_InstanciarCepInvalido_Retornar_ValueObjectInvalidException()
        {
            //Arrange & Act & Assert
            Assert.Throws<ValueObjectInvalidException>(() => new Cep("23--!000"));
        }

        [Fact]
        public void Cep_InstanciarCepValido_Retornar_UmaInstanciaValida()
        {
            //Arrange & Act
            var cep = new Cep("12345678");

            //Assert
            Assert.IsType<Cep>(cep);
            Assert.IsAssignableFrom<ValueOf<string, Cep>>(cep);
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
