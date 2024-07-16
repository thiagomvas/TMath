using System.Diagnostics.CodeAnalysis;
using System.Globalization;
using System.Numerics;
using System.Text;
using System.Text.RegularExpressions;

namespace TMath.Numerics
{
    public class Polynomial<T> : INumberBase<Polynomial<T>>, IComparisonOperators<Polynomial<T>, Polynomial<T>, bool>
        where T : INumberBase<T>, IComparisonOperators<T, T, bool>
    {
        // x0 -> xn
        private readonly T[] _coefficients;
        public T[] Coefficients => _coefficients;
        public char Variable { get; set; } = 'x';
        public int Degree => _coefficients.Length - 1;

        public static Polynomial<T> One => new(T.One);

        public static int Radix => T.Radix;

        public static Polynomial<T> Zero => new(T.Zero);

        public static Polynomial<T> AdditiveIdentity => Zero;

        public static Polynomial<T> MultiplicativeIdentity => One;

        public Polynomial(params T[] coefficients)
        {
            _coefficients = coefficients;

            // Remove trailing zeros
            for (int i = _coefficients.Length - 1; i >= 0; i--)
            {
                if (!T.IsZero(_coefficients[i]))
                {
                    _coefficients = _coefficients[..(i + 1)];
                    break;
                }
            }
        }

        public T Evaluate(T x)
        {
            var pow = T.One;
            var result = T.Zero;

            foreach (var coefficient in _coefficients)
            {
                result += coefficient * pow;
                pow *= x;
            }

            return result;
        }

        public Func<T,T> AsFunc()
        {
            return Evaluate;
        }

        public Polynomial<T> Integral()
        {
            var newCoefficients = new T[_coefficients.Length + 1];
            newCoefficients[0] = T.Zero;
            T div = T.One;

            for (var i = 0; i < _coefficients.Length; i++)
            {
                newCoefficients[i + 1] = _coefficients[i] / div;
                div++;
            }

            return new Polynomial<T>(newCoefficients);
        }

        public Polynomial<T> Derivative()
        {
            var newCoefficients = new T[_coefficients.Length - 1];
            T mult = T.One;
            for(int i = 1; i < _coefficients.Length; i++)
            {
                newCoefficients[i - 1] = _coefficients[i] * mult;
                mult++;
            }

            return new Polynomial<T>(newCoefficients);
        }

        public override string ToString()
        {
            return ToString(null, null);
        }

        public static Polynomial<T> Abs(Polynomial<T> value)
        {
            return new Polynomial<T>(value.Coefficients.Select(c => T.Abs(c)).ToArray());
        }

        public static bool IsCanonical(Polynomial<T> value)
        {
            return value.Coefficients.Any(c => !T.IsZero(c));
        }

        public static bool IsComplexNumber(Polynomial<T> value)
        {
            return value.Coefficients.Any(c => T.IsComplexNumber(c));
        }

        public static bool IsEvenInteger(Polynomial<T> value)
        {
            return value.Coefficients.Length == 0 && T.IsEvenInteger(value.Coefficients[0]);
        }

        public static bool IsFinite(Polynomial<T> value)
        {
            return value.Coefficients.All(c => T.IsFinite(c));
        }

        public static bool IsImaginaryNumber(Polynomial<T> value)
        {
            return value.Coefficients.Any(c => T.IsImaginaryNumber(c));
        }

        public static bool IsInfinity(Polynomial<T> value)
        {
            return value.Coefficients.Any(c => T.IsInfinity(c));
        }

        public static bool IsInteger(Polynomial<T> value)
        {
            return value.Coefficients.Length == 0 && T.IsInteger(value.Coefficients[0]);
        }

        public static bool IsNaN(Polynomial<T> value)
        {
            return value.Coefficients.Any(c => T.IsNaN(c));
        }

        public static bool IsNegative(Polynomial<T> value)
        {
            return T.IsNegative(value.Coefficients[value.Coefficients.Length - 1]);
        }

        public static bool IsNegativeInfinity(Polynomial<T> value)
        {
            return value.Coefficients.Any(c => T.IsNegativeInfinity(c));
        }

        public static bool IsNormal(Polynomial<T> value)
        {
            return value.Coefficients.All(c => T.IsNormal(c));
        }

        public static bool IsOddInteger(Polynomial<T> value)
        {
            return value.Coefficients.Length == 0 && T.IsOddInteger(value.Coefficients[0]);
        }

        public static bool IsPositive(Polynomial<T> value)
        {
            return T.IsPositive(value.Coefficients[value.Coefficients.Length - 1]);
        }

        public static bool IsPositiveInfinity(Polynomial<T> value)
        {
            return value.Coefficients.Any(c => T.IsPositiveInfinity(c));
        }

        public static bool IsRealNumber(Polynomial<T> value)
        {
            return value.Coefficients.All(c => T.IsRealNumber(c));
        }

        public static bool IsSubnormal(Polynomial<T> value)
        {
            return value.Coefficients.All(c => T.IsSubnormal(c));
        }

        public static bool IsZero(Polynomial<T> value)
        {
            return value.Coefficients.All(c => T.IsZero(c));
        }

        public static Polynomial<T> MaxMagnitude(Polynomial<T> x, Polynomial<T> y)
        {
            if(x.Coefficients.Length > y.Coefficients.Length)
                return x;
            if(x.Coefficients.Length < y.Coefficients.Length)
                return y;

            var lastCoefX = x.Coefficients[x.Coefficients.Length - 1];
            var lastCoefY = y.Coefficients[y.Coefficients.Length - 1];
            var max = T.MaxMagnitude(lastCoefX, lastCoefY);

            if(max == lastCoefX)
                return x;

            return y;
        }

        public static Polynomial<T> MaxMagnitudeNumber(Polynomial<T> x, Polynomial<T> y)
        {
            if (IsNaN(x))
                return y;
            if(IsNaN(y))
                return x;

            if (IsInfinity(x))
                return y;
            if(IsInfinity(y))
                return x;

            return MaxMagnitude(x, y);
        }

        public static Polynomial<T> MinMagnitude(Polynomial<T> x, Polynomial<T> y)
        {
            if (x.Coefficients.Length > y.Coefficients.Length)
                return y;
            if (x.Coefficients.Length < y.Coefficients.Length)
                return x;

            var lastCoefX = x.Coefficients[x.Coefficients.Length - 1];
            var lastCoefY = y.Coefficients[y.Coefficients.Length - 1];
            var min = T.MinMagnitude(lastCoefX, lastCoefY);

            if (min == lastCoefX)
                return x;

            return y;
        }

        public static Polynomial<T> MinMagnitudeNumber(Polynomial<T> x, Polynomial<T> y)
        {
            if (IsNaN(x))
                return y;
            if (IsNaN(y))
                return x;

            if (IsInfinity(x))
                return y;
            if (IsInfinity(y))
                return x;

            return MinMagnitude(x, y);
        }

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

            var result = new Polynomial<T>(coefficients.ToArray());
            result.Variable = matches[0].Groups["var"].Value[0];

            return result;
        }

        public static Polynomial<T> Parse(string s, NumberStyles style, IFormatProvider? provider)
        {
            return Parse(s.AsSpan(), style, provider);
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

        public bool Equals(Polynomial<T>? other)
        {
            return other != null && Coefficients.SequenceEqual(other.Coefficients);
        }
        public bool TryFormat(Span<char> destination, out int charsWritten, ReadOnlySpan<char> format, IFormatProvider? provider)
        {
            var formatString = format.ToString();
            var formattedString = ToString(formatString, provider);

            if (formattedString.Length > destination.Length)
            {
                charsWritten = 0;
                return false;
            }

            formattedString.AsSpan().CopyTo(destination);
            charsWritten = formattedString.Length;
            return true;
        }

        public string ToString(string? format, IFormatProvider? formatProvider)
        {

            if (Coefficients.Length == 0)
                return "0";

            if (format == null)
            {
                return ToString();
            }

            StringBuilder sb = new();
            bool first = true;
            for (int i = Coefficients.Length - 1; i >= 0; i--)
            {
                if (T.IsZero(Coefficients[i]))
                {
                    continue;
                }
                if(!first)
                {
                    if (T.IsNegative(Coefficients[i]))
                    {
                        sb.Append(" - ");
                    }
                    else
                    {
                        sb.Append(" + ");
                    }
                }
                if((i == 0) || T.Abs(Coefficients[i]) != T.One)
                {
                    sb.Append(Coefficients[i].ToString(format, formatProvider));
                }
                if (i > 0)
                {
                    sb.Append(Variable);
                    if (i > 1)
                    {
                        sb.Append("^");
                        sb.Append(i.ToString(format, formatProvider));
                    }
                }
                first = false;
            }
            return sb.ToString();
        }

        public static Polynomial<T> Parse(ReadOnlySpan<char> s, IFormatProvider? provider)
        {
            return Parse(s, NumberStyles.Any, provider);
        }

        public static bool TryParse(ReadOnlySpan<char> s, IFormatProvider? provider, [MaybeNullWhen(false)] out Polynomial<T> result)
        {
            return TryParse(s, NumberStyles.Any, provider, out result);
        }

        public static Polynomial<T> Parse(string s, IFormatProvider? provider)
        {
            return Parse(s.AsSpan(), provider);
        }

        public static bool TryParse([NotNullWhen(true)] string? s, IFormatProvider? provider, [MaybeNullWhen(false)] out Polynomial<T> result)
        {
            return TryParse(s, NumberStyles.Any, provider, out result);
        }

        static bool INumberBase<Polynomial<T>>.TryConvertFromChecked<TOther>(TOther value, out Polynomial<T> result)
        {
            if(value is Polynomial<T> p)
            {
                result = p;
                return true;
            }
            try
            {
                var num = T.CreateChecked(value);
                result = new Polynomial<T>(num);
                return true;
            }
            catch
            {
                result = null;
                return false;
            }
        }

        static bool INumberBase<Polynomial<T>>.TryConvertFromSaturating<TOther>(TOther value, out Polynomial<T> result)
        {
            if (value is Polynomial<T> p)
            {
                result = p;
                return true;
            }
            try
            {
                var num = T.CreateSaturating(value);
                result = new Polynomial<T>(num);
                return true;
            }
            catch
            {
                result = null;
                return false;
            }
        }

        static bool INumberBase<Polynomial<T>>.TryConvertFromTruncating<TOther>(TOther value, out Polynomial<T> result)
        {
            if (value is Polynomial<T> p)
            {
                result = p;
                return true;
            }
            try
            {
                var num = T.CreateTruncating(value);
                result = new Polynomial<T>(num);
                return true;
            }
            catch
            {
                result = null;
                return false;
            }
        }

        static bool INumberBase<Polynomial<T>>.TryConvertToChecked<TOther>(Polynomial<T> value, out TOther result)
        {
            try
            {
                result = TOther.CreateChecked(value);
                return true;
            }
            catch
            {
                result = default;
                return false;

            }
        }

        static bool INumberBase<Polynomial<T>>.TryConvertToSaturating<TOther>(Polynomial<T> value, out TOther result)
        {
            try
            {
                result = TOther.CreateSaturating(value);
                return true;
            }
            catch
            {
                result = default;
                return false;

            }
        }

        static bool INumberBase<Polynomial<T>>.TryConvertToTruncating<TOther>(Polynomial<T> value, out TOther result)
        {
            try
            {
                result = TOther.CreateTruncating(value);
                return true;
            }
            catch
            {
                result = default;
                return false;

            }
        }

        public static Polynomial<T> operator +(Polynomial<T> left, Polynomial<T> right)
        {
            T[] newCoefs;
            if(left.Degree > right.Degree)
                newCoefs = new T[left.Degree + 1].Select(c => T.Zero).ToArray();
            else
                newCoefs = new T[right.Degree + 1].Select(c => T.Zero).ToArray();

            for(int i = 0; i < newCoefs.Length; i++)
            {
                if(i <= left.Degree)
                    newCoefs[i] = left.Coefficients[i];
                if(i <= right.Degree)
                    newCoefs[i] += right.Coefficients[i];
            }

            return new(newCoefs);
        }

        public static Polynomial<T> operator --(Polynomial<T> value)
        {
            var coefs = value.Coefficients.Select(c => c--).ToArray();
            return new(coefs);
        }

        public static Polynomial<T> operator /(Polynomial<T> left, Polynomial<T> right)
        {

            if (right.Degree <= 0 && right.Coefficients[0] == T.Zero)
            {
                throw new ArgumentException("Division by zero is not allowed.");
            }

            int numeratorDegree = left.Degree;
            int denominatorDegree = right.Degree;

            // If the numerator has a lower degree than the denominator, the result is zero
            if (numeratorDegree < denominatorDegree)
            {
                return new Polynomial<T>();
            }

            // Initialize arrays to store the quotient and remainder
            T[] quotientCoefficients = new T[numeratorDegree - denominatorDegree + 1];
            T[] remainderCoefficients = new T[numeratorDegree + 1];

            // Copy the numerator coefficients to the remainder array
            Array.Copy(left.Coefficients, remainderCoefficients, left.Coefficients.Length);

            int iterations = 0, maxiterations = 1000;

            // Perform polynomial division
            while (numeratorDegree >= denominatorDegree)
            {
                // Calculate the term to add to the quotient
                T term = remainderCoefficients[numeratorDegree] / right.Coefficients[denominatorDegree];

                // Update the quotient coefficient
                quotientCoefficients[numeratorDegree - denominatorDegree] = term;

                // Subtract the term * right from the current remainder
                for (int i = 0; i <= denominatorDegree; i++)
                {
                    remainderCoefficients[numeratorDegree - i] = (remainderCoefficients[numeratorDegree - i] - (term * right.Coefficients[denominatorDegree - i]));
                }

                if (remainderCoefficients[numeratorDegree] == T.Zero)
                    remainderCoefficients = remainderCoefficients.Take(remainderCoefficients.Length - 1).ToArray();

                // Update the degree of the current remainder
                numeratorDegree = remainderCoefficients.Length - 1;
                iterations++;

                if (iterations >= maxiterations)
                {
                    throw new InvalidOperationException("The division algorithm did not converge.");
                }
            }

            return new Polynomial<T>(quotientCoefficients);
        }

        public static bool operator ==(Polynomial<T>? left, Polynomial<T>? right)
        {
            if(left is null && right is null)
                return true;
            if(left is null || right is null)
                return false;

            return left.Degree == right.Degree && left.Coefficients.SequenceEqual(right.Coefficients);
        }

        public static bool operator !=(Polynomial<T>? left, Polynomial<T>? right)
        {
            if(left is null && right is null)
                return false;
            if(left is null || right is null)
                return true;


            return left.Degree != right.Degree || !left.Coefficients.SequenceEqual(right.Coefficients);
        }

        public static Polynomial<T> operator ++(Polynomial<T> value)
        {
            var coefs = value.Coefficients.Select(c => c++).ToArray();
            return new(coefs);
        }

        public static Polynomial<T> operator *(Polynomial<T> left, Polynomial<T> right)
        {
            var newCoefs = new T[left.Degree + right.Degree + 1].Select(c => T.Zero).ToArray();
            for(int i = 0; i <= left.Degree; i++)
            {
                for(int j = 0; j <= right.Degree; j++)
                {
                    newCoefs[i + j] += left.Coefficients[i] * right.Coefficients[j];
                }
            }

            return new(newCoefs);
        }

        public static Polynomial<T> operator -(Polynomial<T> left, Polynomial<T> right)
        {
            T[] newCoefs;
            if (left.Degree > right.Degree)
                newCoefs = new T[left.Degree + 1].Select(c => T.Zero).ToArray();
            else
                newCoefs = new T[right.Degree + 1].Select(c => T.Zero).ToArray();

            for (int i = 0; i < newCoefs.Length; i++)
            {
                T l = T.Zero, r = T.Zero;
                if(i <= left.Degree)
                    l = left.Coefficients[i];
                if(i <= right.Degree)
                    r = right.Coefficients[i];

                newCoefs[i] = l - r;
            }
            return new Polynomial<T>(newCoefs);
        }

        public static Polynomial<T> operator -(Polynomial<T> value)
        {
            return new(value.Coefficients.Select(c => -c).ToArray());
        }

        public static Polynomial<T> operator +(Polynomial<T> value)
        {
            return value;
        }

        public static bool operator >(Polynomial<T> left, Polynomial<T> right)
        {
            if(left.Degree == right.Degree)
            {
                for(int i = left.Degree; i >= 0; i--)
                {
                    if (left.Coefficients[i] > right.Coefficients[i])
                        return true;
                    if (left.Coefficients[i] < right.Coefficients[i])
                        return false;
                }
            }
            if (left.Coefficients[left.Degree] < right.Coefficients[right.Degree])
                return T.IsNegative(right.Coefficients[right.Degree]);

            return T.IsPositive(left.Coefficients[left.Degree]);
        }

        public static bool operator >=(Polynomial<T> left, Polynomial<T> right)
        {
            if (left == right)
                return true;
            else return left > right;
        }

        public static bool operator <(Polynomial<T> left, Polynomial<T> right)
        {
            if(left.Degree == right.Degree)
            {
                for(int i = left.Degree; i >= 0; i--)
                {
                    if (left.Coefficients[i] < right.Coefficients[i])
                        return true;
                    if (left.Coefficients[i] > right.Coefficients[i])
                        return false;
                }
            }
            if (left.Coefficients[left.Degree] > right.Coefficients[right.Degree])
                return T.IsNegative(left.Coefficients[left.Degree]);

            return T.IsPositive(right.Coefficients[right.Degree]);
        }

        public static bool operator <=(Polynomial<T> left, Polynomial<T> right)
        {
            if (left == right)
                return true;
            else return left < right;
        }
    }
}
