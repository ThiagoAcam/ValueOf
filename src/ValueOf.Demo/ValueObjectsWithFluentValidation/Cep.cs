using FluentValidation;
using ValueOf.Demo.Extensions;
using ValueOfLib.FluentValidation;

namespace ValueOf.Demo.ValueObjectsWithFluentValidation
{
    public class Cep : ValueOfWithFluentValidation.WithNotifications<string, Cep, CepValidator>
    {
        public Cep(string cep)
            :base(cep.OnlyNumbers())
        { }

        protected override bool Equals(Cep obj)
            => obj.Value.Equals(Value);
    }

    public class CepValidator : AbstractValidator<Cep>
    {
        public CepValidator()
        {
            RuleFor(p => p.Value)
                .Length(8)
                .WithMessage("CEP inválido");
        }
    }
}
