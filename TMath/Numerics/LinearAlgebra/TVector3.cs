using System.Numerics;
using TMath.Numerics.Interfaces;

namespace TMath.Numerics.LinearAlgebra
{
	public class TVector3<T>
		: IAdditionOperators<TVector3<T>, TVector3<T>, TVector3<T>>,
		ISubtractionOperators<TVector3<T>, TVector3<T>, TVector3<T>>,
		IMultiplyOperators<TVector3<T>, T, TVector3<T>>,
		IDivisionOperators<TVector3<T>, T, TVector3<T>>,
		IEqualityOperators<TVector3<T>, TVector3<T>, bool>,
		IComparisonOperators<TVector3<T>, TVector3<T>, bool>,
		IIncrementOperators<TVector3<T>>,
		IDecrementOperators<TVector3<T>>,
		IAdditiveIdentity<TVector3<T>, TVector3<T>>,
		IMultiplicativeIdentity<TVector3<T>, T>
		where T : INumber<T>, new()
	{

		public T X;
		public T Y;
		public T Z;
		
		public static TVector3<T> AdditiveIdentity => throw new NotImplementedException();

		public static T MultiplicativeIdentity => throw new NotImplementedException();


		public static TVector3<T> operator +(TVector3<T> left, TVector3<T> right)
		{
			throw new NotImplementedException();
		}

		public static TVector3<T> operator -(TVector3<T> left, TVector3<T> right)
		{
			throw new NotImplementedException();
		}

		public static TVector3<T> operator ++(TVector3<T> value)
		{
			throw new NotImplementedException();
		}

		public static TVector3<T> operator --(TVector3<T> value)
		{
			throw new NotImplementedException();
		}

		public static TVector3<T> operator *(TVector3<T> left, T right)
		{
			throw new NotImplementedException();
		}

		public static TVector3<T> operator /(TVector3<T> left, T right)
		{
			throw new NotImplementedException();
		}

		public static bool operator ==(TVector3<T> left, TVector3<T> right)
		{
			throw new NotImplementedException();
		}

		public static bool operator !=(TVector3<T> left, TVector3<T> right)
		{
			throw new NotImplementedException();
		}

		public static bool operator <(TVector3<T> left, TVector3<T> right)
		{
			throw new NotImplementedException();
		}

		public static bool operator >(TVector3<T> left, TVector3<T> right)
		{
			throw new NotImplementedException();
		}

		public static bool operator <=(TVector3<T> left, TVector3<T> right)
		{
			throw new NotImplementedException();
		}

		public static bool operator >=(TVector3<T> left, TVector3<T> right)
		{
			throw new NotImplementedException();
		}
	}
}
