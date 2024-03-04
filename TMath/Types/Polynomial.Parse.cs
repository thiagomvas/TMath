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

		public static Polynomial<T> Parse(ReadOnlySpan<char> s, NumberStyles style, IFormatProvider? provider)
		{
			throw new NotImplementedException();
		}

		public static Polynomial<T> Parse(string s, NumberStyles style, IFormatProvider? provider)
		{
			throw new NotImplementedException();
		}

		public static Polynomial<T> Parse(ReadOnlySpan<char> s, IFormatProvider? provider)
		{
			throw new NotImplementedException();
		}

		public static Polynomial<T> Parse(string s, IFormatProvider? provider)
		{
			throw new NotImplementedException();
		}

		public static bool TryParse(ReadOnlySpan<char> s, NumberStyles style, IFormatProvider? provider, [MaybeNullWhen(false)] out Polynomial<T> result)
		{
			throw new NotImplementedException();
		}

		public static bool TryParse([NotNullWhen(true)] string? s, NumberStyles style, IFormatProvider? provider, [MaybeNullWhen(false)] out Polynomial<T> result)
		{
			throw new NotImplementedException();
		}

		public static bool TryParse(ReadOnlySpan<char> s, IFormatProvider? provider, [MaybeNullWhen(false)] out Polynomial<T> result)
		{
			throw new NotImplementedException();
		}

		public static bool TryParse([NotNullWhen(true)] string? s, IFormatProvider? provider, [MaybeNullWhen(false)] out Polynomial<T> result)
		{
			throw new NotImplementedException();
		}
	}
}
