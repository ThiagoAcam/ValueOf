using System.Linq;
using ValueOfLib.Exceptions;
using Xunit;
using ValueOf.Demo.ValueObjectsWithFlunt;
using ValueOfLib.Flunt;

namespace ValueOf.Tests.ValueObjectsWithFlunt
{
    public class CpfTests
    {
        [Fact]
        public void Cpf_InstanciarCpfComTamanhoInvalido_Retornar_UmObjetoInvalido()
        {
            //Arrange & Act
            var cpf = new Cpf("111.111.111");

            //Assert
            Assert.False(cpf.IsValid);
            Assert.Equal("Cpf with invalid format", cpf.Notifications.FirstOrDefault().Message);
            Assert.Throws<ValueObjectInvalidException>(() => cpf.Value);
        }

        [Fact]
        public void Cpf_InstanciarCpfInvalido_Retornar_UmObjetoInvalido()
        {
            //Arrange & Act
            var cpf = new Cpf("111.111.111-00");

            //Assert
            Assert.False(cpf.IsValid);
            Assert.Equal("Cpf invalid", cpf.Notifications.FirstOrDefault().Message);
            Assert.Throws<ValueObjectInvalidException>(() => cpf.Value);
        }

        [Fact]
        public void Cpf_InstanciarCpfValido_Retornar_UmaInstanciaValida()
        {
            //Arrange & Act
            var cpf = new Cpf("111.111.111-11");

            //Assert
            Assert.IsType<Cpf>(cpf);
            Assert.IsAssignableFrom<ValueOfWithFlunt<string, Cpf>>(cpf);
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
