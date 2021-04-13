using Flunt.Validations;
using ValueOf.Demo.Extensions;
using ValueOfLib.Flunt;

namespace ValueOf.Demo.ValueObjectsWithFluntContract
{
    public class Cep : ValueOfWithFlunt<string, Cep>
    {
        public Cep(string cep)
            : base(cep.OnlyNumbers())
        { }

        protected override bool Equals(Cep obj)
            => obj.Value.Equals(Value);

        protected override void Validations()
        {
            AddNotifications(new CreateCepContract(this));
        }
    }

    public class CreateCepContract : Contract<Cep>
    {
        public CreateCepContract(Cep cep)
        {
            Requires()
                .IsNotNullOrEmpty(cep.Value, "Cep", "O CEP está em um formato inválido")
                .AreEquals(cep.Value.Length, 8, "Cep", "O CEP está em um formato inválido");
        }
    }
}
