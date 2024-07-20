using System.Diagnostics.CodeAnalysis;
using System.Globalization;
using System.Numerics;
using System.Text.RegularExpressions;

namespace TMath.Types
{
    public partial class Polynomial<T> : INumber<Polynomial<T>>
        where T : INumber<T>
    {

        public static Polynomial<T> Parse(ReadOnlySpan<char> s)
        {
            return Parse(s, NumberStyles.Any, null);
        }

        public static Polynomial<T> Parse(string s)
        {
            return Parse(s.AsSpan());
        }

        public static Polynomial<T> Parse(ReadOnlySpan<char> s, NumberStyles style, IFormatProvider? provider)
        {
            var regex = new Regex(@"(?<sign>[+-]?)\s*(?<coeff>\d+)?\s*(?<var>[a-zA-Z])?\s*(\^\s*(?<exp>\d+))?");
            var matches = regex.Matches(s.ToString());
            var coefficients = new List<T>();
            foreach (Match match in matches)
            {
                var sign = match.Groups["sign"].Value;
                var coeff = match.Groups["coeff"].Value;
                var var = match.Groups["var"].Value;
                var exp = match.Groups["exp"].Value;

                if (string.IsNullOrEmpty(coeff))
                {
                    coeff = "1";
                }
                if (string.IsNullOrEmpty(exp))
                {
                    exp = "0";
                }

                var coefficient = T.Parse(coeff, style, provider);
                var exponent = int.Parse(exp, style, provider);

                if (sign == "-")
                {
                    coefficient = -coefficient;
                }

                if (exponent >= coefficients.Count)
                {
                    coefficients.AddRange(Enumerable.Repeat(T.Zero, exponent - coefficients.Count + 1));
                }

                coefficients[exponent] = coefficient;
            }

            var result = new Polynomial<T>(coefficients);
            result.Variable = matches[0].Groups["var"].Value;

            return result;
        }

        public static Polynomial<T> Parse(string s, NumberStyles style, IFormatProvider? provider)
        {
            return Parse(s.AsSpan(), style, provider);
        }

        public static Polynomial<T> Parse(ReadOnlySpan<char> s, IFormatProvider? provider)
        {
            return Parse(s, NumberStyles.Any, provider);
        }

        public static Polynomial<T> Parse(string s, IFormatProvider? provider)
        {
            return Parse(s.AsSpan(), provider);
        }

        public static bool TryParse(ReadOnlySpan<char> s, NumberStyles style, IFormatProvider? provider, [MaybeNullWhen(false)] out Polynomial<T> result)
        {
            try
            {
                result = Parse(s, style, provider);
                return true;
            }
            catch
            {
                result = null;
                return false;
            }
        }

        public static bool TryParse([NotNullWhen(true)] string? s, NumberStyles style, IFormatProvider? provider, [MaybeNullWhen(false)] out Polynomial<T> result)
        {
            try
            {
                result = Parse(s, style, provider);
                return true;
            }
            catch
            {
                result = null;
                return false;
            }
        }

        public static bool TryParse(ReadOnlySpan<char> s, IFormatProvider? provider, [MaybeNullWhen(false)] out Polynomial<T> result)
        {
            return TryParse(s, NumberStyles.Any, provider, out result);
        }

        public static bool TryParse([NotNullWhen(true)] string? s, IFormatProvider? provider, [MaybeNullWhen(false)] out Polynomial<T> result)
        {
            return TryParse(s, NumberStyles.Any, provider, out result);
        }
    }
}
