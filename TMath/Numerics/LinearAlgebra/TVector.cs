using System.Diagnostics.CodeAnalysis;
using System.Numerics;

namespace TMath.Numerics.LinearAlgebra
{
	public class TVector<T>
		: IAdditionOperators<TVector<T>, TVector<T>, TVector<T>>,
		ISubtractionOperators<TVector<T>, TVector<T>, TVector<T>>,
		IMultiplyOperators<TVector<T>, T, TVector<T>>,
		IDivisionOperators<TVector<T>, T, TVector<T>>,
		IEqualityOperators<TVector<T>, TVector<T>, bool>,
		IComparisonOperators<TVector<T>, TVector<T>, bool>,
		IIncrementOperators<TVector<T>>,
		IDecrementOperators<TVector<T>>,
		IAdditiveIdentity<TVector<T>, TVector<T>>,
		IMultiplicativeIdentity<TVector<T>, T>
		where T : INumber<T>, new()
	{
		public static TVector<T> AdditiveIdentity => throw new NotImplementedException();

		public static T MultiplicativeIdentity => throw new NotImplementedException();

		public static TVector<T> operator +(TVector<T> left, TVector<T> right)
		{
			throw new NotImplementedException();
		}

		public static TVector<T> operator -(TVector<T> left, TVector<T> right)
		{
			throw new NotImplementedException();
		}

		public static TVector<T> operator ++(TVector<T> value)
		{
			throw new NotImplementedException();
		}

		public static TVector<T> operator --(TVector<T> value)
		{
			throw new NotImplementedException();
		}

		public static bool operator ==(TVector<T>? left, TVector<T>? right)
		{
			throw new NotImplementedException();
		}

		public static bool operator !=(TVector<T>? left, TVector<T>? right)
		{
			throw new NotImplementedException();
		}

		public static bool operator <(TVector<T> left, TVector<T> right)
		{
			throw new NotImplementedException();
		}

		public static bool operator >(TVector<T> left, TVector<T> right)
		{
			throw new NotImplementedException();
		}

		public static bool operator <=(TVector<T> left, TVector<T> right)
		{
			throw new NotImplementedException();
		}

		public static bool operator >=(TVector<T> left, TVector<T> right)
		{
			throw new NotImplementedException();
		}

		public static TVector<T> operator /(TVector<T> left, T right)
		{
			throw new NotImplementedException();
		}

		public static TVector<T> operator *(TVector<T> left, T right)
		{
			throw new NotImplementedException();
		}
	}
}
