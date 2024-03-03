using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Globalization;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace TMath.Types
{
	public partial class Fraction<T> : INumber<Fraction<T>>
		where T : INumber<T>
	{

		public T Numerator { get; }
		public T Denominator { get; }

		public Fraction(T numerator, T denominator)
		{
			Numerator = numerator;
			if(denominator.Equals(T.Zero))
				throw new DivideByZeroException();
		}

		public Fraction<T> Simplify()
		{
			throw new NotImplementedException();
		}

		public static Fraction<T> One => throw new NotImplementedException();

		public static int Radix => throw new NotImplementedException();

		public static Fraction<T> Zero => throw new NotImplementedException();

		public static Fraction<T> AdditiveIdentity => throw new NotImplementedException();

		public static Fraction<T> MultiplicativeIdentity => throw new NotImplementedException();

		public static Fraction<T> Abs(Fraction<T> value)
		{
			throw new NotImplementedException();
		}



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

		public string ToString(string? format, IFormatProvider? formatProvider)
		{
			throw new NotImplementedException();
		}

		public bool TryFormat(Span<char> destination, out int charsWritten, ReadOnlySpan<char> format, IFormatProvider? provider)
		{
			throw new NotImplementedException();
		}
	}
}
