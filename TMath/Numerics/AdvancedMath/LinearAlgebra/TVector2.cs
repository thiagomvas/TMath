using System.Numerics;

namespace TMath.Numerics.AdvancedMath.LinearAlgebra
{
    /// <summary>
    /// Represents a 2-dimensional vector with arithmetic and comparison operations.
    /// </summary>
    /// <typeparam name="T">The type of elements in the vector, constrained to <see cref="INumber{T}"/> and <see cref="new"/>.</typeparam>
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
        /// <summary>
        /// The X component of the vector.
        /// </summary>
        public T X;

        /// <summary>
        /// The Y component of the vector.
        /// </summary>
        public T Y;

        /// <summary>
        /// A vector with all components set to zero.
        /// </summary>
        public static TVector2<T> Zero => new(T.Zero, T.Zero);

        /// <summary>
        /// A vector with all components set to one.
        /// </summary>
        public static TVector2<T> One => new(T.One, T.One);

        /// <summary>
        /// Gets a 2D vector with unit length in the X direction (1, 0).
        /// </summary>
        public static TVector2<T> UnitX => new(T.One, T.Zero);

        /// <summary>
        /// Gets a 2D vector with unit length in the Y direction (0, 1).
        /// </summary>
        public static TVector2<T> UnitY => new(T.Zero, T.One);



        #region Constructors
        /// <summary>
        /// Creates a new 2D vector with the specified components.
        /// </summary>
        /// <param name="x">The X component.</param>
        /// <param name="y">The Y component.</param>
        public TVector2(T x, T y)
        {
            X = x;
            Y = y;
        }

        /// <summary>
        /// Creates a new 2D vector from a list of values, where the value at index 0 is the X coordinate and the value at index 1 is the Y coordinate.
        /// </summary>
        /// <param name="values">The list of values to create the vector from</param>
        public TVector2(T[] values)
        {
            X = values[0];
            Y = values[1];
        }

        /// <summary>
        /// Creates a new 2D vector with all components set to zero.
        /// </summary>
        public TVector2()
        {
            X = T.Zero;
            Y = T.Zero;
        }
        #endregion

        /// <summary>
        /// The additive identity for a 2D vector is a vector where all components are zero.
        /// </summary>
        public static TVector2<T> AdditiveIdentity => new(T.Zero, T.Zero);

        /// <summary>
        /// The multiplicative identity for a 2D vector is a vector where all components are one.
        /// </summary>
        public static T MultiplicativeIdentity => T.One;

        /// <summary>
        /// Gets the length of the vector.
        /// </summary>
        public T Length => TFunctions.Sqrt<T, T>(X * X + Y * Y);

        /// <summary>
        /// Calculates the dot product of this vector and another.
        /// </summary>
        /// <param name="other">The other vector to calculate the dot product with</param>
        /// <returns>The dot product of this vector with <paramref name="other"/></returns>
        public T DotProduct(TVector2<T> other) => X * other.X + Y * other.Y;

        /// <summary>
        /// Calculates the cross product of this vector and another.
        /// </summary>
        /// <param name="other">The other vector to calculate the cross product with</param>
        /// <returns>The cross product of this vector with <paramref name="other"/></returns>
        public T CrossProduct(TVector2<T> other) => X * other.Y - Y * other.X;

        /// <summary>
        /// Calculates the normalized form of this vector.
        /// </summary>
        public TVector2<T> Normalize => this == TVector2<T>.Zero ? new(T.Zero, T.Zero) : this / Length;


        #region Operators
        /// <summary>
        /// Adds two vectors together.
        /// </summary>
        public static TVector2<T> operator +(TVector2<T> left, TVector2<T> right) => new(left.X + right.X, left.Y + right.Y);

        /// <summary>
        /// Subtracts one vector from another.
        /// </summary>
        public static TVector2<T> operator -(TVector2<T> left, TVector2<T> right) => new(left.X - right.X, left.Y - right.Y);

        /// <summary>
        /// Increments all the coordinates of this vector by one.
        /// </summary>
        public static TVector2<T> operator ++(TVector2<T> value) => new(value.X + T.One, value.Y + T.One);

        /// <summary>
        /// Decrements all the coordinates of this vector by one.
        /// </summary>
        public static TVector2<T> operator --(TVector2<T> value) => new(value.X - T.One, value.Y - T.One);

        /// <summary>
        /// Multiplies a vector by a scalar.
        /// </summary>
        public static TVector2<T> operator *(TVector2<T> left, T right) => new(left.X * right, left.Y * right);

        /// <summary>
        /// Multiplies a vector by a scalar.
        /// </summary>
        public static TVector2<T> operator *(T left, TVector2<T> right) => new(left * right.X, left * right.Y);

        /// <summary>
        /// Divides a vector by a scalar.
        /// </summary>
        public static TVector2<T> operator /(TVector2<T> left, T right) => new(left.X / right, left.Y / right);
        #endregion

        #region Comparison Operators
        /// <summary>
        /// Compares the coordinates of the vector for equality.
        /// </summary>
        public static bool operator ==(TVector2<T>? left, TVector2<T>? right) => left.X == right.X && left.Y == right.Y;

        /// <summary>
        /// Compares the coordinates of the vector for inequality.
        /// </summary>
        public static bool operator !=(TVector2<T>? left, TVector2<T>? right) => left.X != right.X || left.Y != right.Y;

        /// <summary>
        /// Compares the lengths of two vectors.
        /// </summary>
        public static bool operator <(TVector2<T> left, TVector2<T> right) => left.Length < right.Length;

        /// <summary>
        /// Compares the lengths of two vectors.
        /// </summary>
        public static bool operator >(TVector2<T> left, TVector2<T> right) => left.Length > right.Length;

        /// <summary>
        /// Compares the lengths of two vectors.
        /// </summary>
        public static bool operator <=(TVector2<T> left, TVector2<T> right) => left.Length <= right.Length;

        /// <summary>
        /// Compares the lengths of two vectors.
        /// </summary>
        public static bool operator >=(TVector2<T> left, TVector2<T> right) => left.Length >= right.Length;

        /// <summary>
        /// Compares the lengths of two vectors.
        /// </summary>
        public static TVector2<T> operator -(TVector2<T> value) => new(-value.X, -value.Y);
        #endregion

        /// <summary>
        /// Converts this vector to a string representation in the format of &lt;X, Y&gt;.
        /// </summary>
        public override string ToString() => $"<{X}, {Y}>";
    }
}
