using FluentValidation;
using ValueOf.Demo.ValueObjectsWithFluentValidationWithExceptions;
using ValueOfLib.FluentValidation;
using Xunit;

namespace ValueOf.Tests.ValueObjectsWithFluentValidationWithExceptions
{
    public class CpfTests
    {
        [Fact]
        public void Cpf_InstanciarCpfComTamanhoInvalido_Retornar_UmObjetoInvalido()
        {
            //Arrange & Act & Assert
            Assert.Throws<ValidationException>(() => new Cpf("111.111.111"));
        }

        [Fact]
        public void Cpf_InstanciarCpfInvalido_Retornar_UmObjetoInvalido()
        {
            //Arrange & Act & Assert
            Assert.Throws<ValidationException>(() => new Cpf("111.111.111-00"));
        }

        [Fact]
        public void Cpf_InstanciarCpfValido_Retornar_UmaInstanciaValida()
        {
            //Arrange & Act
            var cpf = new Cpf("111.111.111-11");

            //Assert
            Assert.IsType<Cpf>(cpf);
            Assert.IsAssignableFrom<ValueOfWithFluentValidation.WithExceptions<string, Cpf, CpfValidator>>(cpf);
            Assert.Equal("11111111111", cpf.Value);
        }

        [Fact]
        public void Cpf_Instanciar2CpfsValidos_VerificarIgualdade_DeveSerTrue()
        {
            //Arrange & Act
            var cpf1 = new Cpf("111.111.111-11");
            var cpf2 = new Cpf("111.111.111-11");

            //Assert
            Assert.True(cpf1 == cpf2);
        }
    }
}
