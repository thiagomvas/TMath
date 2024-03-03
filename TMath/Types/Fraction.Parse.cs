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

		public static Fraction<T> Parse(string s, NumberStyles style, IFormatProvider? provider)
		{
			if(string.IsNullOrWhiteSpace(s))
				throw new ArgumentNullException(nameof(s));
			var split = s.Split('/');
			if (split.Length != 2)
				throw new FormatException("Input span was not in a correct format.");

			var num = T.Parse(split[0], style, provider);
			var den = T.Parse(split[1], style, provider);

			return new Fraction<T>(num, den);
		}

		public static Fraction<T> Parse(ReadOnlySpan<char> s, IFormatProvider? provider) => Parse(s, default, provider);

		public static Fraction<T> Parse(string s, IFormatProvider? provider) => Parse(s, default, provider);

		public static Fraction<T> Parse(ReadOnlySpan<char> s) => Parse(s, default, CultureInfo.CurrentCulture);
		public static Fraction<T> Parse(string s) => Parse(s, default, CultureInfo.CurrentCulture);


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

		public static bool TryParse(ReadOnlySpan<char> s, [MaybeNullWhen(false)] out Fraction<T> result) => TryParse(s, default, CultureInfo.CurrentCulture, out result);

		public static bool TryParse([NotNullWhen(true)] string? s, [MaybeNullWhen(false)] out Fraction<T> result) => TryParse(s, default, CultureInfo.CurrentCulture, out result);
	}
}
