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
		IMultiplicativeIdentity<TVector3<T>, T>,
		IUnaryNegationOperators<TVector3<T>, TVector3<T>>
		where T : INumber<T>, new()
	{

		public T X;
		public T Y;
		public T Z;

		public static TVector3<T> Zero => new(T.Zero, T.Zero, T.Zero);
		public static TVector3<T> One => new(T.One, T.One, T.One);

		#region Constructors
		public TVector3(T x, T y, T z)
		{
			X = x;
			Y = y;
			Z = z;
		}

		public TVector3(T[] values)
		{
			X = values[0];
			Y = values[1];
			Z = values[2];
		}
		public TVector3()
		{
			X = T.Zero;
			Y = T.Zero;
			Z = T.Zero;
		}
		#endregion

		public T DotProduct(TVector3<T> other) => X * other.X + Y * other.Y + Z * other.Z;
		public TVector3<T> CrossProduct(TVector3<T> other) => new(Y * other.Z - Z * other.Y, Z * other.X - X * other.Z, X * other.Y - Y * other.X);
		public TVector3<T> Normalize() => this == TVector3<T>.Zero ? new(T.Zero, T.Zero, T.Zero ) : this / Length;

		public T Length => TFunctions.Sqrt<T, T>(X * X + Y * Y + Z * Z);

		public static TVector3<T> AdditiveIdentity => throw new NotImplementedException();

		public static T MultiplicativeIdentity => throw new NotImplementedException();

		#region Operators

		public static TVector3<T> operator +(TVector3<T> left, TVector3<T> right) => new(left.X + right.X, left.Y + right.Y, left.Z + right.Z);

		public static TVector3<T> operator -(TVector3<T> left, TVector3<T> right) => new(left.X - right.X, left.Y - right.Y, left.Z - right.Z);

		public static TVector3<T> operator ++(TVector3<T> value) => new(value.X + T.One, value.Y + T.One, value.Z + T.One);

		public static TVector3<T> operator --(TVector3<T> value) => new(value.X - T.One, value.Y - T.One, value.Z - T.One);

		public static TVector3<T> operator *(TVector3<T> left, T right) => new(left.X * right, left.Y * right, left.Z * right);

		public static TVector3<T> operator *(T left, TVector3<T> right) => new(left * right.X, left * right.Y, left * right.Z);

		public static TVector3<T> operator /(TVector3<T> left, T right) => new(left.X / right, left.Y / right, left.Z / right);

		#endregion
		#region Comparison Operators
		public static bool operator ==(TVector3<T> left, TVector3<T> right) => left.X == right.X && left.Y == right.Y && left.Z == right.Z;

		public static bool operator !=(TVector3<T> left, TVector3<T> right) => left.X != right.X || left.Y != right.Y || left.Z != right.Z;

		public static bool operator <(TVector3<T> left, TVector3<T> right) => left.Length < right.Length;

		public static bool operator >(TVector3<T> left, TVector3<T> right) => left.Length > right.Length;

		public static bool operator <=(TVector3<T> left, TVector3<T> right) => left.Length <= right.Length;

		public static bool operator >=(TVector3<T> left, TVector3<T> right) => left.Length >= right.Length;

		public static TVector3<T> operator -(TVector3<T> value) => new(-value.X, -value.Y, -value.Z);
		#endregion

		public override string ToString() => $"<{X}, {Y}, {Z}>";
	}
}
