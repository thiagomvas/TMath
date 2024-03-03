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
			throw new NotImplementedException();
		}

		public static explicit operator T(Fraction<T> value)
		{
			throw new NotImplementedException();
		}

		static bool INumberBase<Fraction<T>>.TryConvertFromChecked<TOther>(TOther value, out Fraction<T> result)
		{
			throw new NotImplementedException();
		}

		static bool INumberBase<Fraction<T>>.TryConvertFromSaturating<TOther>(TOther value, out Fraction<T> result)
		{
			throw new NotImplementedException();
		}

		static bool INumberBase<Fraction<T>>.TryConvertFromTruncating<TOther>(TOther value, out Fraction<T> result)
		{
			throw new NotImplementedException();
		}

		static bool INumberBase<Fraction<T>>.TryConvertToChecked<TOther>(Fraction<T> value, out TOther result)
		{
			throw new NotImplementedException();
		}

		static bool INumberBase<Fraction<T>>.TryConvertToSaturating<TOther>(Fraction<T> value, out TOther result)
		{
			throw new NotImplementedException();
		}

		static bool INumberBase<Fraction<T>>.TryConvertToTruncating<TOther>(Fraction<T> value, out TOther result)
		{
			throw new NotImplementedException();
		}

	}
}
