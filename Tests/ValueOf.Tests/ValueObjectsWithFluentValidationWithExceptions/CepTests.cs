using FluentValidation;
using ValueOf.Demo.ValueObjectsWithFluentValidationWithExceptions;
using ValueOfLib.FluentValidation;
using Xunit;

namespace ValueOf.Tests.ValueObjectsWithFluentValidationWithExceptions
{
    public class CepTests
    {
        [Fact]
        public void Cep_InstanciarCepInvalido_Retornar_UmaInstanciaInvalida()
        {
            //Arrange & Act & Assert
            Assert.Throws<ValidationException>(() => new Cep("23--!000"));
        }

        [Fact]
        public void Cep_InstanciarCepValido_Retornar_UmaInstanciaValida()
        {
            //Arrange & Act
            var cep = new Cep("12345678");

            //Assert
            Assert.IsType<Cep>(cep);
            Assert.IsAssignableFrom<ValueOfWithFluentValidation.WithExceptions<string, Cep, CepValidator>>(cep);
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
