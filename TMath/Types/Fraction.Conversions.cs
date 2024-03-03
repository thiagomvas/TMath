using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace TMath.Types
{
	public partial class Fraction<T> : INumber<Fraction<T>>
		where T : INumber<T>
	{
		public static implicit operator Fraction<T>(T value)
		{
			return new Fraction<T>(value);
		}

		public static explicit operator T(Fraction<T> value)
		{
			return value.Numerator / value.Denominator;
		}

		static bool INumberBase<Fraction<T>>.TryConvertFromChecked<TOther>(TOther value, out Fraction<T> result)
		{
			if(value is Fraction<T> f)
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

		static bool INumberBase<Fraction<T>>.TryConvertFromSaturating<TOther>(TOther value, out Fraction<T> result)
		{
			if(value is Fraction<T> f)
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

		static bool INumberBase<Fraction<T>>.TryConvertFromTruncating<TOther>(TOther value, out Fraction<T> result)
		{
			if(value is Fraction<T> f)
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

		static bool INumberBase<Fraction<T>>.TryConvertToChecked<TOther>(Fraction<T> value, out TOther result)
		{
			if(value.Denominator == T.Zero)
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

		static bool INumberBase<Fraction<T>>.TryConvertToSaturating<TOther>(Fraction<T> value, out TOther result)
		{
			if(value.Denominator == T.Zero)
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

		static bool INumberBase<Fraction<T>>.TryConvertToTruncating<TOther>(Fraction<T> value, out TOther result)
		{
			if(value.Denominator == T.Zero)
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

	}
}
