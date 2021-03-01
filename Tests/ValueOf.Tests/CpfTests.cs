using Xunit;
using ValueOfLib;
using ValueOf.Demo;
using ValueOf.Demo.Exceptions;

namespace ValueOf.Tests
{
    public class CpfTests
    {

        [Fact]
        public void Cpf_InstanciarCpfComTamanhoInvalido_Retornar_CpfTamanhoException()
        {
            //Arrange & Act & Assert
            Assert.Throws<CpfTamanhoException>(() => new Cpf("111.111.111"));
        }

        [Fact]
        public void Cpf_InstanciarCpfInvalido_Retornar_CpfInvalidoException()
        {
            //Arrange & Act & Assert
            Assert.Throws<CpfInvalidoException>(() => new Cpf("111.111.111-00"));
        }

        [Fact]
        public void Cpf_InstanciarCpfValido_Retornar_UmaInstanciaValida()
        {
            //Arrange & Act
            var cpf = new Cpf("111.111.111-11");
            
            //Assert
            Assert.IsType<Cpf>(cpf);
            Assert.IsAssignableFrom<ValueOf<string, Cpf>>(cpf);
            Assert.Equal("11111111111", cpf.Value);
        }

    }
}
