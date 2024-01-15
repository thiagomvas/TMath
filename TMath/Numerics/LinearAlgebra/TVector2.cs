using System.Numerics;

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
		IMultiplicativeIdentity<TVector2<T>, T>,
		IUnaryNegationOperators<TVector2<T>, TVector2<T>>
		where T : INumber<T>, new()
	{

		public T X;
		public T Y;

		public static TVector2<T> Zero => new(T.Zero, T.Zero);
		public static TVector2<T> One => new(T.One, T.One);

		#region Constructors
		public TVector2(T x, T y)
		{
			X = x;
			Y = y;
		}

		public TVector2()
		{
			X = T.Zero;
			Y = T.Zero;
		}
		#endregion

		public static TVector2<T> AdditiveIdentity => new(T.Zero, T.Zero);

		public static T MultiplicativeIdentity => T.One;

		public T Length => TFunctions.Sqrt<T, T>(X * X + Y * Y);

		#region Operators
		public static TVector2<T> operator +(TVector2<T> left, TVector2<T> right) => new(left.X + right.X, left.Y + right.Y);

		public static TVector2<T> operator -(TVector2<T> left, TVector2<T> right) => new(left.X - right.X, left.Y - right.Y);

		public static TVector2<T> operator ++(TVector2<T> value) => new(value.X + T.One, value.Y + T.One);

		public static TVector2<T> operator --(TVector2<T> value) => new(value.X - T.One, value.Y - T.One);

		public static TVector2<T> operator *(TVector2<T> left, T right) => new(left.X * right, left.Y * right);

		public static TVector2<T> operator *(T left, TVector2<T> right) => new(left * right.X, left * right.Y);

		public static TVector2<T> operator /(TVector2<T> left, T right) => new(left.X / right, left.Y / right);
		#endregion

		#region Comparison Operators
		public static bool operator ==(TVector2<T>? left, TVector2<T>? right) => left.X == right.X && left.Y == right.Y;

		public static bool operator !=(TVector2<T>? left, TVector2<T>? right) => left.X != right.X || left.Y != right.Y;

		public static bool operator <(TVector2<T> left, TVector2<T> right) => left.Length < right.Length;

		public static bool operator >(TVector2<T> left, TVector2<T> right) => left.Length > right.Length;

		public static bool operator <=(TVector2<T> left, TVector2<T> right) => left.Length <= right.Length;

		public static bool operator >=(TVector2<T> left, TVector2<T> right) => left.Length >= right.Length;

		public static TVector2<T> operator -(TVector2<T> value) => new(-value.X, -value.Y);
		#endregion

		public override string ToString() => $"<{X}, {Y}>";
	}
}
