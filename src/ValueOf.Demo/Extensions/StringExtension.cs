using System.Linq;

namespace ValueOf.Demo.Extensions
{
    public static class StringExtension
    {
        public static string OnlyNumbers(this string value)
            => string.Join("", value.Where(c => char.IsDigit(c)).Select(c => c));
    }
}
