using System.Linq;
using ValueOf.Demo.ValueObjectsWithFluentValidation;
using ValueOfLib.Exceptions;
using ValueOfLib.FluentValidation;
using Xunit;

namespace ValueOf.Tests.ValueObjectsWithFluentValidation
{
    public class CepTests
    {
        [Fact]
        public void Cep_InstanciarCepInvalido_Retornar_UmaInstanciaInvalida()
        {
            //Arrange & Act
            var cep = new Cep("23--!000");

            //Assert
            Assert.False(cep.IsValid);
            Assert.Equal("CEP inválido", cep.ValidationResult.Errors.FirstOrDefault().ErrorMessage);
            Assert.Throws<ValueObjectInvalidException>(() => cep.Value);
        }

        [Fact]
        public void Cep_InstanciarCepValido_Retornar_UmaInstanciaValida()
        {
            //Arrange & Act
            var cep = new Cep("12345678");

            //Assert
            Assert.IsType<Cep>(cep);
            Assert.IsAssignableFrom<ValueOfWithFluentValidation.WithNotifications<string, Cep, CepValidator>>(cep);
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
