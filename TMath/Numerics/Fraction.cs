using System.Diagnostics.CodeAnalysis;
using System.Globalization;
using System.Numerics;

namespace TMath.Numerics
{
    public class Fraction : Fraction<double>
    {
        public Fraction(double numerator, double denominator) : base(numerator, denominator)
        {
        }

        public Fraction(double numerator) : base(numerator)
        {
        }

        public static implicit operator Fraction(double value)
        {
            return new Fraction(value);
        }

        public static explicit operator double(Fraction value)
        {
            return (double) value.Numerator / value.Denominator;
        }

    }
    public class Fraction<T> : INumberBase<Fraction<T>>,
        IComparisonOperators<Fraction<T>, Fraction<T>, bool>
        where T : INumberBase<T>, IComparisonOperators<T, T, bool>
    {
        private T _numerator, _denominator;

        public T Numerator
        {
            get => _numerator;
            set => _numerator = value;
        }

        public T Denominator
        {
            get => _denominator;
            set
            {
                if(T.IsZero(value))
                    throw new DivideByZeroException("Denominator cannot be zero.");
                if(T.IsNegative(value))
                {
                    _numerator = -_numerator;
                    _denominator = -value;
                }
                else
                {
                    _denominator = value;
                }
            }
        }

        public Fraction(T numerator, T denominator)
        {
            Numerator = numerator;
            Denominator = denominator;
        }

        public Fraction(T numerator) : this(numerator, T.One) { }

        public Fraction<T> SimplifyThis()
        {
            if (Numerator == T.Zero)
            {
                Numerator = T.Zero;
                Denominator = T.One;
            }
            T gcd;
            var epsilon = T.CreateSaturating(1e-9);
            T a = Numerator, b = Denominator;
            while (T.Abs(b) - epsilon > T.Zero)
            {
                T temp = b;
                b = MathT.Modulus(a, b);
                a = temp;
            }
            gcd = T.Abs(a);
            if (gcd == T.One)
                return this;
            Numerator /= gcd;
            Denominator /= gcd;
            return this;
        }

        public Fraction<T> Simplify()
        {
            if (Numerator == T.Zero)
            {
                Numerator = T.Zero;
                Denominator = T.One;
            }
            T gcd;
            var epsilon = T.CreateSaturating(1e-9);
            T a = Numerator, b = Denominator;
            while (T.Abs(b) - epsilon > T.Zero)
            {
                T temp = b;
                b = MathT.Modulus(a, b);
                a = temp;
            }
            gcd = T.Abs(a);
            if (gcd == T.One)
                return this;
            return new(Numerator / gcd, Denominator / gcd);
        }

        /// <inheritdoc/>
        public static Fraction<T> One => new(T.One);

        /// <inheritdoc/>
        public static int Radix => T.Radix;

        /// <inheritdoc/>
        public static Fraction<T> Zero => new(T.Zero);

        /// <inheritdoc/>
        public static Fraction<T> AdditiveIdentity => Zero;

        /// <inheritdoc/>
        public static Fraction<T> MultiplicativeIdentity => One;

        /// <inheritdoc/>
        public static Fraction<T> Abs(Fraction<T> value)
        {
            return new Fraction<T>(T.Abs(value.Numerator), T.Abs(value.Denominator));
        }

        /// <inheritdoc/>
        public static bool IsCanonical(Fraction<T> value)
        {
            return MathT.GCD(value.Numerator, value.Denominator) == T.One;
        }

        /// <inheritdoc/>
        public static bool IsComplexNumber(Fraction<T> value)
        {
            return T.IsComplexNumber(value.Numerator) || T.IsComplexNumber(value.Denominator);
        }

        /// <inheritdoc/>
        public static bool IsEvenInteger(Fraction<T> value)
        {
             return MathT.Modulus(value.Numerator / value.Denominator, T.One + T.One) == T.Zero;
        }

        /// <inheritdoc/>
        public static bool IsFinite(Fraction<T> value)
        {
            return T.IsFinite(value.Numerator) && T.IsFinite(value.Denominator) && !T.IsZero(value.Denominator);
        }

        /// <inheritdoc/>
        public static bool IsImaginaryNumber(Fraction<T> value)
        {
            return T.IsImaginaryNumber(value.Numerator) || T.IsImaginaryNumber(value.Denominator);
        }

        /// <inheritdoc/>
        public static bool IsInfinity(Fraction<T> value)
        {
            return T.IsInfinity(value.Numerator) || T.IsZero(value.Denominator);
        }

        /// <inheritdoc/>
        public static bool IsInteger(Fraction<T> value)
        {
            return MathT.Modulus(value.Numerator, value.Denominator) == T.Zero;
        }

        /// <inheritdoc/>
        public static bool IsNaN(Fraction<T> value)
        {
            return T.IsNaN(value.Numerator) || T.IsNaN(value.Denominator) || T.IsZero(value.Denominator);
        }

        /// <inheritdoc/>
        public static bool IsNegative(Fraction<T> value)
        {
            return T.IsNegative(value.Numerator) ^ T.IsNegative(value.Denominator);
        }

        /// <inheritdoc/>
        public static bool IsNegativeInfinity(Fraction<T> value)
        {
            return T.IsNegativeInfinity(value.Numerator) || (T.IsZero(value.Denominator) && T.IsNegative(value.Numerator));
        }

        /// <inheritdoc/>
        public static bool IsNormal(Fraction<T> value)
        {
            return T.IsNormal(value.Numerator) && T.IsNormal(value.Denominator);
        }

        /// <inheritdoc/>
        public static bool IsOddInteger(Fraction<T> value)
        {
            return MathT.Modulus(value.Numerator / value.Denominator, T.One + T.One) == T.One;
        }

        /// <inheritdoc/>
        public static bool IsPositive(Fraction<T> value)
        {
            return T.IsPositive(value.Numerator) ^ T.IsNegative(value.Denominator);
        }

        /// <inheritdoc/>
        public static bool IsPositiveInfinity(Fraction<T> value)
        {
            return T.IsPositiveInfinity(value.Numerator) || (T.IsZero(value.Denominator) && T.IsPositive(value.Numerator));
        }

        public static bool IsRealNumber(Fraction<T> value)
        {
            return T.IsRealNumber(value.Numerator) && T.IsRealNumber(value.Denominator);
        }

        /// <inheritdoc/>
        public static bool IsSubnormal(Fraction<T> value)
        {
            return T.IsSubnormal(value.Numerator) || T.IsSubnormal(value.Denominator);
        }

        /// <inheritdoc/>
        public static bool IsZero(Fraction<T> value)
        {
            return T.IsZero(value.Numerator) && !T.IsZero(value.Denominator);
        }

        /// <inheritdoc/>
        public static Fraction<T> MaxMagnitude(Fraction<T> x, Fraction<T> y)
        {
            return T.MaxMagnitude((T) x, (T) y);
        }

        /// <inheritdoc/>
        public static Fraction<T> MaxMagnitudeNumber(Fraction<T> x, Fraction<T> y)
        {
            return T.MaxMagnitudeNumber((T) x, (T) y);
        }

        /// <inheritdoc/>
        public static Fraction<T> MinMagnitude(Fraction<T> x, Fraction<T> y)
        {
            return T.MinMagnitude((T) x, (T) y);
        }

        /// <inheritdoc/>
        public static Fraction<T> MinMagnitudeNumber(Fraction<T> x, Fraction<T> y)
        {
            return T.MinMagnitudeNumber((T) x, (T) y);
        }


        /// <inheritdoc/>
        public static Fraction<T> Parse(ReadOnlySpan<char> s, NumberStyles style, IFormatProvider? provider)
        {
            if (s == null)
                throw new ArgumentNullException(nameof(s));
            if (s.IsEmpty)
                throw new FormatException("Input span was not in a correct format.");

            var split = s.ToString().Split('/');
            if (split.Length != 2)
                throw new FormatException("Input span was not in a correct format.");

            var num = T.Parse(split[0], style, provider);
            var den = T.Parse(split[1], style, provider);

            return new Fraction<T>(num, den);

        }

        /// <inheritdoc/>
        public static Fraction<T> Parse(string s, NumberStyles style, IFormatProvider? provider)
        {
            if (string.IsNullOrWhiteSpace(s))
                throw new ArgumentNullException(nameof(s));
            var split = s.Split('/');
            if (split.Length != 2)
                throw new FormatException("Input span was not in a correct format.");

            var num = T.Parse(split[0], style, provider);
            var den = T.Parse(split[1], style, provider);

            return new Fraction<T>(num, den);
        }

        /// <inheritdoc/>
        public static Fraction<T> Parse(ReadOnlySpan<char> s, IFormatProvider? provider) => Parse(s, default, provider);

        /// <inheritdoc/>
        public static Fraction<T> Parse(string s, IFormatProvider? provider) => Parse(s, default, provider);

        /// <inheritdoc/>
        public static Fraction<T> Parse(ReadOnlySpan<char> s) => Parse(s, default, CultureInfo.CurrentCulture);
        /// <inheritdoc/>
        public static Fraction<T> Parse(string s) => Parse(s, default, CultureInfo.CurrentCulture);


        /// <inheritdoc/>
        public static bool TryParse(ReadOnlySpan<char> s, NumberStyles style, IFormatProvider? provider, [MaybeNullWhen(false)] out Fraction<T> result)
        {
            try
            {
                result = Parse(s, style, provider);
                return true;
            }
            catch
            {
                result = default;
                return false;
            }
        }

        /// <inheritdoc/>
        public static bool TryParse([NotNullWhen(true)] string? s, NumberStyles style, IFormatProvider? provider, [MaybeNullWhen(false)] out Fraction<T> result)
        {
            try
            {
                result = Parse(s, style, provider);
                return true;
            }
            catch
            {
                result = default;
                return false;
            }
        }

        /// <inheritdoc/>
        public static bool TryParse(ReadOnlySpan<char> s, IFormatProvider? provider, [MaybeNullWhen(false)] out Fraction<T> result)
        {
            try
            {
                result = Parse(s, provider);
                return true;
            }
            catch
            {
                result = default;
                return false;
            }
        }

        /// <inheritdoc/>
        public static bool TryParse([NotNullWhen(true)] string? s, IFormatProvider? provider, [MaybeNullWhen(false)] out Fraction<T> result)
        {
            try
            {
                result = Parse(s, provider);
                return true;
            }
            catch
            {
                result = default;
                return false;
            }
        }

        /// <inheritdoc/>
        public static bool TryParse(ReadOnlySpan<char> s, [MaybeNullWhen(false)] out Fraction<T> result) => TryParse(s, default, CultureInfo.CurrentCulture, out result);

        /// <inheritdoc/>
        public static bool TryParse([NotNullWhen(true)] string? s, [MaybeNullWhen(false)] out Fraction<T> result) => TryParse(s, default, CultureInfo.CurrentCulture, out result);

        /// <inheritdoc/>
        static bool INumberBase<Fraction<T>>.TryConvertFromChecked<TOther>(TOther value, out Fraction<T> result)
        {
            if (value is Fraction<T> f)
            {
                result = f;
                return true;
            }
            try
            {
                var num = T.CreateChecked(value);
                result = new Fraction<T>(num, T.One);
                return true;
            }
            catch
            {
                result = Fraction<T>.Zero;
                return false;
            }
        }

        /// <inheritdoc/>
        static bool INumberBase<Fraction<T>>.TryConvertFromSaturating<TOther>(TOther value, out Fraction<T> result)
        {
            if (value is Fraction<T> f)
            {
                result = f;
                return true;
            }
            try
            {
                var num = T.CreateSaturating(value);
                result = new Fraction<T>(num, T.One);
                return true;
            }
            catch
            {
                result = Fraction<T>.Zero;
                return false;
            }
        }

        /// <inheritdoc/>
        static bool INumberBase<Fraction<T>>.TryConvertFromTruncating<TOther>(TOther value, out Fraction<T> result)
        {
            if (value is Fraction<T> f)
            {
                result = f;
                return true;
            }
            try
            {
                var num = T.CreateTruncating(value);
                result = new Fraction<T>(num, T.One);
                return true;
            }
            catch
            {
                result = Fraction<T>.Zero;
                return false;
            }
        }

        /// <inheritdoc/>
        static bool INumberBase<Fraction<T>>.TryConvertToChecked<TOther>(Fraction<T> value, out TOther result)
        {
            if (value.Denominator == T.Zero)
            {
                result = default;
                return false;
            }

            try
            {
                T val = (T)value;
                result = TOther.CreateChecked(val);
                return true;
            }
            catch
            {
                result = default;
                return false;
            }
        }

        /// <inheritdoc/>
        static bool INumberBase<Fraction<T>>.TryConvertToSaturating<TOther>(Fraction<T> value, out TOther result)
        {
            if (value.Denominator == T.Zero)
            {
                result = default;
                return false;
            }

            try
            {
                T val = (T)value;
                result = TOther.CreateSaturating(val);
                return true;
            }
            catch
            {
                result = default;
                return false;
            }
        }

        /// <inheritdoc/>
        static bool INumberBase<Fraction<T>>.TryConvertToTruncating<TOther>(Fraction<T> value, out TOther result)
        {
            if (value.Denominator == T.Zero)
            {
                result = default;
                return false;
            }

            try
            {
                T val = (T)value;
                result = TOther.CreateTruncating(val);
                return true;
            }
            catch
            {
                result = default;
                return false;
            }
        }

        /// <inheritdoc/>
        public bool Equals(Fraction<T>? other)
        {
            return this == other;
        }

        public override string ToString()
        {
            SimplifyThis();
            if (Numerator == T.Zero)
                return "0";
            if (Denominator == T.One)
                return Numerator.ToString();

            return $"{Numerator}/{Denominator}";
        }

        /// <inheritdoc/>
        public string ToString(string? format, IFormatProvider? formatProvider)
        {
            if (formatProvider == null) return ToString();
            SimplifyThis();
            if (Numerator == T.Zero)
                return "0";
            if (Denominator == T.One)
                return Numerator.ToString(format, formatProvider);

            return $"{Numerator.ToString(format, formatProvider)}/{Denominator.ToString(format, formatProvider)}";
        }

        /// <inheritdoc/>
        public bool TryFormat(Span<char> destination, out int charsWritten, ReadOnlySpan<char> format, IFormatProvider? provider)
        {
            string formattedFraction = this.ToString(format.ToString(), provider);

            if (formattedFraction.Length <= destination.Length)
            {
                formattedFraction.AsSpan().CopyTo(destination);
                charsWritten = formattedFraction.Length;
                return true;
            }
            charsWritten = 0;
            return false;
        }

        /// <summary>
        /// Implicitly converts a value to a Fraction.
        /// </summary>
        /// <param name="value">The value to convert to a fraction</param>
        public static implicit operator Fraction<T>(T value)
        {
            return new Fraction<T>(value);
        }

        /// <summary>
        /// Explicitly converts a fraction to a value by calculating the division.
        /// </summary>
        /// <param name="value">The fraction to convert</param>
        public static explicit operator T(Fraction<T> value)
        {
            return value.Numerator / value.Denominator;
        }

        /// <inheritdoc/>
        public static Fraction<T> operator +(Fraction<T> value)
        {
            return value;
        }

        /// <inheritdoc/>
        public static Fraction<T> operator +(Fraction<T> left, Fraction<T> right)
        {
            return new Fraction<T>(left.Numerator * right.Denominator + right.Numerator * left.Denominator, left.Denominator * right.Denominator);
        }

        /// <inheritdoc/>
        public static Fraction<T> operator -(Fraction<T> value)
        {
            return new Fraction<T>(-value.Numerator, value.Denominator);
        }

        /// <inheritdoc/>
        public static Fraction<T> operator -(Fraction<T> left, Fraction<T> right)
        {
            return new Fraction<T>(left.Numerator * right.Denominator - right.Numerator * left.Denominator, left.Denominator * right.Denominator);
        }

        /// <inheritdoc/>
        public static Fraction<T> operator ++(Fraction<T> value)
        {
            return new(value.Numerator + value.Denominator, value.Denominator);
        }

        /// <inheritdoc/>
        public static Fraction<T> operator --(Fraction<T> value)
        {
            return new(value.Numerator - value.Denominator, value.Denominator);
        }

        /// <inheritdoc/>
        public static Fraction<T> operator *(Fraction<T> left, Fraction<T> right)
        {
            return new Fraction<T>(left.Numerator * right.Numerator, left.Denominator * right.Denominator);
        }

        /// <inheritdoc/>
        public static Fraction<T> operator /(Fraction<T> left, Fraction<T> right)
        {
            return new Fraction<T>(left.Numerator * right.Denominator, left.Denominator * right.Numerator);
        }

        /// <inheritdoc/>
        public static bool operator ==(Fraction<T>? left, Fraction<T>? right)
        {
            if(left is null && right is null)
                return true;
            if(left is null || right is null)
                return false;
            return (T) left == (T) right;
        }

        /// <inheritdoc/>
        public static bool operator !=(Fraction<T>? left, Fraction<T>? right)
        {
            if(left is null && right is null)
                return false;
            if(left is null || right is null)
                return true;
            return (T) left != (T) right;
        }

        /// <inheritdoc/>
        public static bool operator <(Fraction<T> left, Fraction<T> right)
        {
            return (left.Numerator * right.Denominator) < (right.Numerator * left.Denominator);
        }

        /// <inheritdoc/>
        public static bool operator >(Fraction<T> left, Fraction<T> right)
        {
            return (left.Numerator * right.Denominator) > (right.Numerator * left.Denominator);
        }

        /// <inheritdoc/>
        public static bool operator <=(Fraction<T> left, Fraction<T> right)
        {
            return (left.Numerator * right.Denominator) <= (right.Numerator * left.Denominator);
        }

        /// <inheritdoc/>
        public static bool operator >=(Fraction<T> left, Fraction<T> right)
        {
            return (left.Numerator * right.Denominator) >= (right.Numerator * left.Denominator);
        }
    }
}
