using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace TMath.Types
{
	public partial class Polynomial<T> : INumber<Polynomial<T>>
		where T : INumber<T>
	{


		static bool INumberBase<Polynomial<T>>.TryConvertFromChecked<TOther>(TOther value, out Polynomial<T> result)
		{
			throw new NotImplementedException();
		}

		static bool INumberBase<Polynomial<T>>.TryConvertFromSaturating<TOther>(TOther value, out Polynomial<T> result)
		{
			throw new NotImplementedException();
		}

		static bool INumberBase<Polynomial<T>>.TryConvertFromTruncating<TOther>(TOther value, out Polynomial<T> result)
		{
			throw new NotImplementedException();
		}

		static bool INumberBase<Polynomial<T>>.TryConvertToChecked<TOther>(Polynomial<T> value, out TOther result)
		{
			throw new NotImplementedException();
		}

		static bool INumberBase<Polynomial<T>>.TryConvertToSaturating<TOther>(Polynomial<T> value, out TOther result)
		{
			throw new NotImplementedException();
		}

		static bool INumberBase<Polynomial<T>>.TryConvertToTruncating<TOther>(Polynomial<T> value, out TOther result)
		{
			throw new NotImplementedException();
		}
	}
}
