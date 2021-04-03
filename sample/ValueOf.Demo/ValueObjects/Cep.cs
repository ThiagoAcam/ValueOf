using ValueOf.Demo.Extensions;
using ValueOfLib;

namespace ValueOf.Demo.ValueObjects
{
    public class Cep : ValueOf<string, Cep>
    {
        public Cep(string cep)
            :base(cep.OnlyNumbers())
        { }

        protected override bool Equals(Cep obj)
            => obj.Value.Equals(Value);

        protected override bool Validate()
        {
            if (Value.Length != 8)
                return false;

            return true;
        }
    }
}
