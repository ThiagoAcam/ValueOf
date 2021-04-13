using ValueOf.Demo.Extensions;
using ValueOfLib.Flunt;

namespace ValueOf.Demo.ValueObjectsWithFlunt
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
            if (Value.Length != 8)
                AddNotification("Cep", "O CEP está em um formato inválido");
        }
    }
}
