using ValueOf.Demo.Exceptions;
using ValueOf.Demo.Extensions;
using ValueOfLib;

namespace ValueOf.Demo
{
    public class Cpf : ValueOfBase<string, Cpf>
    {
        static int[] multiplicador1 = new int[9] { 10, 9, 8, 7, 6, 5, 4, 3, 2 };
        static int[] multiplicador2 = new int[10] { 11, 10, 9, 8, 7, 6, 5, 4, 3, 2 };

        public Cpf(string cpf)
            : base(cpf.OnlyNumbers())
        { }

        protected override bool Equals(Cpf obj)
            => Value == obj.Value;

        protected override bool Validate()
        {
            string tempCpf;
            string digito;
            int soma;
            int resto;

            if (Value.Length != 11)
                throw new CpfTamanhoException();

            tempCpf = Value.Substring(0, 9);

            soma = 0;

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

            if (!Value.EndsWith(digito))
                throw new CpfInvalidoException();

            return true;
        }
    }
}
