using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Globalization;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;
using TMath.Numerics.AdvancedMath;

namespace TMath.Types
{
	public partial class Fraction<T> : INumber<Fraction<T>>
		where T : INumber<T>
	{

		public T Numerator { get; private set; }
		public T Denominator { get; private set; }

		public Fraction(T numerator, T denominator)
		{
			if (T.IsNegative(denominator))
			{
				Numerator = -numerator;
				Denominator = -denominator;
			}
			else
			{
				Numerator = numerator;
				if (denominator == T.Zero)
					throw new DivideByZeroException();
				Denominator = denominator;
			}
			
		}
		public Fraction(T numerator, T denominator, bool allowZeroDenominator)
		{
			if (T.IsNegative(denominator))
			{
				Numerator = -numerator;
				Denominator = -denominator;
			}
			else
			{
				Numerator = numerator;
				if (denominator == T.Zero)
					throw new DivideByZeroException();
				Denominator = denominator;
			}
		}

		public Fraction(T numerator) : this(numerator, T.One) { }


		public Fraction<T> SimplifyAsNew()
		{
			if (Numerator == T.Zero)
			{
				Numerator = T.Zero;
				Denominator = T.One;
			}
			T gcd;
			var epsilon = T.CreateSaturating(1e-9);
			T a = Numerator, b = Denominator;
			while (b - epsilon > T.Zero)
			{
				T temp = b;
				b = a % b;
				a = temp;
			}
			gcd = TFunctions.Abs(a);
			return new Fraction<T>(Numerator / gcd, Denominator / gcd);
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
			while(T.Abs(b) - epsilon > T.Zero)
			{
				T temp = b;
				b = a % b; 
				a = temp;
			}
			gcd = T.Abs(a);
			if (gcd == T.One)
				return this;
			Numerator /= gcd;
			Denominator /= gcd;
			return this;
		}
		public static Fraction<T> One => new Fraction<T>(T.One, T.One);

		public static int Radix => 2;

		public static Fraction<T> Zero => new(T.Zero, T.One);

		public static Fraction<T> AdditiveIdentity => Zero;

		public static Fraction<T> MultiplicativeIdentity => One;

		public static Fraction<T> Abs(Fraction<T> value) => new(TFunctions.Abs(value.Numerator), value.Numerator);



		public int CompareTo(object? obj)
		{
			if (obj == null)
				return 1; // A non-null object is always greater than null.

			if (obj is Fraction<T> otherFraction)
			{
				return CompareTo(otherFraction);
			}

			throw new ArgumentException($"Object must be of type {nameof(Fraction<T>)}");
		}

		public int CompareTo(Fraction<T>? other)
		{
			if(IsNaN(this) || IsNaN(other))
				throw new ArgumentException("Cannot compare NaN values");
			if(IsInfinity(this) && IsInfinity(other))
				return 0;
			if(IsInfinity(this))
				return IsPositiveInfinity(this) ? 1 : -1;
			if(IsInfinity(other))
				return IsPositiveInfinity(other) ? -1 : 1;
			return (Numerator * other.Denominator).CompareTo(other.Numerator * Denominator);
		}

		public bool Equals(Fraction<T>? other) => this == other;

		public override string ToString()
		{
			Simplify();
			if (Numerator == T.Zero)
				return "0";
			if(Denominator == T.One)
				return Numerator.ToString();
			return $"{Numerator}/{Denominator}";
		}

		public string ToString(string? format, IFormatProvider? formatProvider)
		{
			Simplify();
			if(Numerator == T.Zero)
				return "0";
			if(Denominator == T.One)
				return Numerator.ToString(format, formatProvider);

			return $"{Numerator.ToString(format, formatProvider)}/{Denominator.ToString(format, formatProvider)}";
		}

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
	}
}
