using System.Collections;
using System.Numerics;
using TMath.Numerics.Interfaces;

namespace TMath.Numerics.LinearAlgebra
{
	public class TVector2<T>
		: IAdditionOperators<TVector2<T>, TVector2<T>, TVector2<T>>,
		ISubtractionOperators<TVector2<T>, TVector2<T>, TVector2<T>>,
		IMultiplyOperators<TVector2<T>, T, TVector2<T>>,
		IDivisionOperators<TVector2<T>, T, TVector2<T>>,
		IEqualityOperators<TVector2<T>, TVector2<T>, bool>,
		IComparisonOperators<TVector2<T>, TVector2<T>, bool>,
		IIncrementOperators<TVector2<T>>,
		IDecrementOperators<TVector2<T>>,
		IAdditiveIdentity<TVector2<T>, TVector2<T>>,
		IMultiplicativeIdentity<TVector2<T>, T>
		where T : INumber<T>, new()
	{

		public T X;
		public T Y;

		public static TVector2<T> AdditiveIdentity => throw new NotImplementedException();

		public static T MultiplicativeIdentity => throw new NotImplementedException();


		public static TVector2<T> operator +(TVector2<T> left, TVector2<T> right)
		{
			throw new NotImplementedException();
		}

		public static TVector2<T> operator -(TVector2<T> left, TVector2<T> right)
		{
			throw new NotImplementedException();
		}

		public static TVector2<T> operator ++(TVector2<T> value)
		{
			throw new NotImplementedException();
		}

		public static TVector2<T> operator --(TVector2<T> value)
		{
			throw new NotImplementedException();
		}

		public static TVector2<T> operator *(TVector2<T> left, T right)
		{
			throw new NotImplementedException();
		}

		public static TVector2<T> operator /(TVector2<T> left, T right)
		{
			throw new NotImplementedException();
		}

		public static bool operator ==(TVector2<T>? left, TVector2<T>? right)
		{
			throw new NotImplementedException();
		}

		public static bool operator !=(TVector2<T>? left, TVector2<T>? right)
		{
			throw new NotImplementedException();
		}

		public static bool operator <(TVector2<T> left, TVector2<T> right)
		{
			throw new NotImplementedException();
		}

		public static bool operator >(TVector2<T> left, TVector2<T> right)
		{
			throw new NotImplementedException();
		}

		public static bool operator <=(TVector2<T> left, TVector2<T> right)
		{
			throw new NotImplementedException();
		}

		public static bool operator >=(TVector2<T> left, TVector2<T> right)
		{
			throw new NotImplementedException();
		}
	}
}
