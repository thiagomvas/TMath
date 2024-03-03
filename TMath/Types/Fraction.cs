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
			Numerator = numerator;
			if(denominator == T.Zero)
				throw new DivideByZeroException();
			if(denominator < T.Zero)
			{
				Numerator = -numerator;
				Denominator = -denominator;
			}
			Denominator = denominator;
		}
		public Fraction(T numerator, T denominator, bool allowZeroDenominator)
		{
			Numerator = numerator;
			if (denominator < T.Zero)
			{
				Numerator = -numerator;
				Denominator = -denominator;
			}
			Denominator = denominator;
		}


		public Fraction<T> SimplifyAsNew()
		{
			if (Numerator == T.Zero) return Zero;
			T gcd;
			T a = Numerator, b = Denominator;
			while(b != T.Zero)
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
			T a = Numerator, b = Denominator;
			while(b != T.Zero)
			{
				T temp = b;
				b = a % b; 
				a = temp;
			}
			gcd = TFunctions.Abs(a);
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
			throw new NotImplementedException();
		}

		public int CompareTo(Fraction<T>? other)
		{
			throw new NotImplementedException();
		}

		public bool Equals(Fraction<T>? other)
		{
			throw new NotImplementedException();
		}

		public string ToString(string? format, IFormatProvider? formatProvider) => $"{Numerator}/{Denominator}";

		public bool TryFormat(Span<char> destination, out int charsWritten, ReadOnlySpan<char> format, IFormatProvider? provider)
		{
			throw new NotImplementedException();
		}
	}
}
