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

		public static T[] Coefficients { get; private set; }

		public Polynomial<T> Integral => throw new NotImplementedException();
		public Polynomial<T> Derivative => throw new NotImplementedException();

		public T EvaluateAt(T value)
		{
			throw new NotImplementedException();
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
