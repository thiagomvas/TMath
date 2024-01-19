using System.Numerics;
using TMath.Numerics.Interfaces;

namespace TMath.Numerics.LinearAlgebra
{
	/// <summary>
	/// Represents a 3-dimensional vector with arithmetic and comparison operations.
	/// </summary>
	/// <typeparam name="T">The type of elements in the vector, constrained to <see cref="INumber{T}"/> and <see cref="new"/>.</typeparam>
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
		/// <summary>
		/// The X component of the vector.
		/// </summary>
		public T X;

		/// <summary>
		/// The Y component of the vector.
		/// </summary>
		public T Y;

		/// <summary>
		/// The Z component of the vector.
		/// </summary>
		public T Z;

		/// <summary>
		/// Gets a vector with all components set to zero.
		/// </summary>
		public static TVector3<T> Zero => new(T.Zero, T.Zero, T.Zero);
		/// <summary>
		/// Gets a vector with all components set to one.
		/// </summary>
		public static TVector3<T> One => new(T.One, T.One, T.One);

		/// <summary>
		/// Gets a 3D vector with unit length in the X direction (1, 0, 0).
		/// </summary>
		public static TVector3<T> UnitX => new(T.One, T.Zero, T.Zero);

		/// <summary>
		/// Gets a 3D vector with unit length in the Y direction (0, 1, 0).
		/// </summary>
		public static TVector3<T> UnitY => new(T.Zero, T.One, T.Zero);

		/// <summary>
		/// Gets a 3D vector with unit length in the Z direction (0, 0, 1).
		/// </summary>
		public static TVector3<T> UnitZ => new(T.Zero, T.Zero, T.One);


		#region Constructors
		/// <summary>
		/// Creates a new 3D vector with the specified components.
		/// </summary>
		/// <param name="x">The X component.</param>
		/// <param name="y">The Y component.</param>
		/// <param name="z">The Z component.</param>
		public TVector3(T x, T y, T z)
		{
			X = x;
			Y = y;
			Z = z;
		}

		/// <summary>
		/// Creates a new 3D vector from a list of values, where the value at index 0 is the X coordinate, the value at index 1 is the Y coordinate, and the value at index 2 is the Z coordinate.
		/// </summary>
		public TVector3(T[] values)
		{
			X = values[0];
			Y = values[1];
			Z = values[2];
		}
		/// <summary>
		/// Creates a new 3D vector with all components set to zero.
		/// </summary>
		public TVector3()
		{
			X = T.Zero;
			Y = T.Zero;
			Z = T.Zero;
		}
		#endregion

		/// <summary>
		/// Calculates the dot product of this vector and another.
		/// </summary>
		/// <param name="other">The other vector to calculate the dot product with</param>
		/// <returns>The dot product of this vector with <paramref name="other"/></returns>
		public T DotProduct(TVector3<T> other) => X * other.X + Y * other.Y + Z * other.Z;

		/// <summary>
		/// Calculates the cross product of this vector and another.
		/// </summary>
		/// <param name="other">The other vector to calculate the cross product with</param>
		/// <returns>The cross product of this vector with <paramref name="other"/></returns>
		public TVector3<T> CrossProduct(TVector3<T> other) => new(Y * other.Z - Z * other.Y, Z * other.X - X * other.Z, X * other.Y - Y * other.X);

		/// <summary>
		/// Calculates the normalized form of this vector.
		/// </summary>
		public TVector3<T> Normalize => this == TVector3<T>.Zero ? new(T.Zero, T.Zero, T.Zero ) : this / Length;

		/// <summary>
		/// Gets the length of the vector.
		/// </summary>
		public T Length => TFunctions.Sqrt<T, T>(X * X + Y * Y + Z * Z);

		public static TVector3<T> AdditiveIdentity => throw new NotImplementedException();

		public static T MultiplicativeIdentity => throw new NotImplementedException();

		#region Operators
		/// <summary>
		/// Adds two vectors together.
		/// </summary>
		public static TVector3<T> operator +(TVector3<T> left, TVector3<T> right) => new(left.X + right.X, left.Y + right.Y, left.Z + right.Z);

		/// <summary>
		/// Subtracts one vector from another.
		/// </summary>
		public static TVector3<T> operator -(TVector3<T> left, TVector3<T> right) => new(left.X - right.X, left.Y - right.Y, left.Z - right.Z);

		/// <summary>
		/// Increments all the coordinates of this vector by one.
		/// </summary>
		public static TVector3<T> operator ++(TVector3<T> value) => new(value.X + T.One, value.Y + T.One, value.Z + T.One);
		/// <summary>
		/// Decrements all the coordinates of this vector by one.
		/// </summary>
		public static TVector3<T> operator --(TVector3<T> value) => new(value.X - T.One, value.Y - T.One, value.Z - T.One);
		/// <summary>
		/// Multiplies a vector by a scalar.
		/// </summary>
		public static TVector3<T> operator *(TVector3<T> left, T right) => new(left.X * right, left.Y * right, left.Z * right);
		/// <summary>
		/// Multiplies a vector by a scalar.
		/// </summary>
		public static TVector3<T> operator *(T left, TVector3<T> right) => new(left * right.X, left * right.Y, left * right.Z);

		/// <summary>
		/// Divides a vector by a scalar.
		/// </summary>
		public static TVector3<T> operator /(TVector3<T> left, T right) => new(left.X / right, left.Y / right, left.Z / right);

		#endregion
		#region Comparison Operators
		/// <summary>
		/// Compares the coordinates of the vector for equality.
		/// </summary>
		public static bool operator ==(TVector3<T> left, TVector3<T> right) => left.X == right.X && left.Y == right.Y && left.Z == right.Z;
		/// <summary>
		/// Compares the coordinates of the vector for inequality.
		/// </summary>
		public static bool operator !=(TVector3<T> left, TVector3<T> right) => left.X != right.X || left.Y != right.Y || left.Z != right.Z;
		/// <summary>
		/// Compares the lengths of two vectors.
		/// </summary>
		public static bool operator <(TVector3<T> left, TVector3<T> right) => left.Length < right.Length;
		/// <summary>
		/// Compares the lengths of two vectors.
		/// </summary>
		public static bool operator >(TVector3<T> left, TVector3<T> right) => left.Length > right.Length;
		/// <summary>
		/// Compares the lengths of two vectors.
		/// </summary>
		public static bool operator <=(TVector3<T> left, TVector3<T> right) => left.Length <= right.Length;
		/// <summary>
		/// Compares the lengths of two vectors.
		/// </summary>
		public static bool operator >=(TVector3<T> left, TVector3<T> right) => left.Length >= right.Length;
		/// <summary>
		/// Compares the lengths of two vectors.
		/// </summary>
		public static TVector3<T> operator -(TVector3<T> value) => new(-value.X, -value.Y, -value.Z);
		#endregion
		/// <summary>
		/// Converts this vector to a string representation in the format of &lt;X, Y, Z&gt;.
		/// </summary>
		public override string ToString() => $"<{X}, {Y}, {Z}>";
	}
}
