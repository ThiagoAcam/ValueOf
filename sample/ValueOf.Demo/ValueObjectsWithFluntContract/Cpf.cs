using Flunt.Validations;
using ValueOf.Demo.Extensions;
using ValueOfLib.Flunt;

namespace ValueOf.Demo.ValueObjectsWithFluntContract
{
    public class Cpf : ValueOfWithFlunt<string, Cpf>
    {
        public Cpf(string cpf)
            : base(cpf.OnlyNumbers())
        { }

        protected override bool Equals(Cpf obj)
            => Value == obj.Value;

        protected override void Validations()
        {
            AddNotifications(new CreateCpfContract(this));
        }
    }

    public class CreateCpfContract:Contract<Cpf>
    {
        private static int[] multiplicador1 = new int[9] { 10, 9, 8, 7, 6, 5, 4, 3, 2 };
        private static int[] multiplicador2 = new int[10] { 11, 10, 9, 8, 7, 6, 5, 4, 3, 2 };

        public CreateCpfContract(Cpf cpf)
        {
            Requires()
                .IsNotNullOrEmpty(cpf.Value, "Cpf", "Cpf with invalid format")
                .AreEquals(cpf.Value.Length, 11, "Cpf", "Cpf with invalid format");

            if (IsValid && !ValidateDigits(cpf.Value))
                AddNotification("Cpf", "Cpf invalid");
        }

        private bool ValidateDigits(string cpf)
        {
            string tempCpf = cpf.Substring(0, 9);
            string digito;
            int soma = 0;
            int resto;

            for (int i = 0; i < 9; i++)
                soma += int.Parse(tempCpf[i].ToString()) * multiplicador1[i];

            resto = soma % 11;

            if (resto < 2)
                resto = 0;
            else
                resto = 11 - resto;

            digito = resto.ToString();
            tempCpf = tempCpf + digito;
            soma = 0;

            for (int i = 0; i < 10; i++)
                soma += int.Parse(tempCpf[i].ToString()) * multiplicador2[i];

            resto = soma % 11;

            if (resto < 2)
                resto = 0;
            else
                resto = 11 - resto;

            digito = digito + resto.ToString();

            if (!cpf.EndsWith(digito))
                return false;

            return true;
        }
    }
}
