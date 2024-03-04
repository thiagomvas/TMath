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
	public partial class Polynomial<T> : INumber<Polynomial<T>>
		where T : INumber<T>
	{

		// From x^0 to x^n
		public T[] Coefficients { get; private set; }

		public int Degree => Coefficients.Length - 1;

		#region Constructors
		public Polynomial(IEnumerable<T> coefficients)
		{
			Coefficients = coefficients.ToArray();
		}

		public Polynomial(params T[] coefficients)
		{
			Coefficients = coefficients;
		}
		#endregion

		public Polynomial<T> Integral => throw new NotImplementedException();
		public Polynomial<T> Derivative => throw new NotImplementedException();

		public Func<T, T> AsFunc() => EvaluateAt;
		public T EvaluateAt(T x)
		{
			T result = Coefficients[0];
			for (int i = 1; i < Coefficients.Length; i++)
			{
				result += Coefficients[i] * x;
				x *= x;
			}
			return result;
		}

		public IEnumerable<T> FindRealRoots()
		{
			throw new NotImplementedException();
		}

		public static Polynomial<T> One => throw new NotImplementedException();

		public static int Radix => throw new NotImplementedException();

		public static Polynomial<T> Zero => throw new NotImplementedException();

		public static Polynomial<T> AdditiveIdentity => throw new NotImplementedException();

		public static Polynomial<T> MultiplicativeIdentity => throw new NotImplementedException();

		public static Polynomial<T> Abs(Polynomial<T> value)
		{
			throw new NotImplementedException();
		}

		public int CompareTo(object? obj)
		{
			throw new NotImplementedException();
		}

		public int CompareTo(Polynomial<T>? other)
		{
			throw new NotImplementedException();
		}

		public bool Equals(Polynomial<T>? other)
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
