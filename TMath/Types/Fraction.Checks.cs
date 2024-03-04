using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace TMath.Types
{
	public partial class Fraction<T> : INumber<Fraction<T>>
		where T : INumber<T>
	{

		/// <inheritdoc/>
		public static bool IsCanonical(Fraction<T> value) => value.SimplifyAsNew() == value;

		/// <inheritdoc/>
		/// <remarks>This is always false</remarks>
		public static bool IsComplexNumber(Fraction<T> value) => false;

		/// <inheritdoc/>
		public static bool IsEvenInteger(Fraction<T> value)
		{
			if (IsInfinity(value))
				return false;
			return value.Numerator % (T.CreateChecked(2) * value.Denominator) == T.Zero;
		}

		/// <inheritdoc/>
		/// <remarks>It is a finite number if the denominator is different than zero.</remarks>
		public static bool IsFinite(Fraction<T> value) => value.Denominator != T.Zero;

		/// <inheritdoc/>
		/// <remarks>This is always false</remarks>
		public static bool IsImaginaryNumber(Fraction<T> value) => false;

		/// <inheritdoc/>
		/// <remarks>It is infinity if the denominator is zero.</remarks>
		public static bool IsInfinity(Fraction<T> value) => value.Denominator == T.Zero;

		/// <inheritdoc/>
		public static bool IsInteger(Fraction<T> value)
		{
			if(IsInfinity(value))
				return false; 
			return value.Numerator % value.Denominator == T.Zero;
		}

		/// <inheritdoc/>
		/// <remarks>It is NaN if, and only if, both numerator and denominator are zero</remarks>
		public static bool IsNaN(Fraction<T> value) => value.Numerator == T.Zero && value.Denominator == T.Zero;

		/// <inheritdoc/>
		public static bool IsNegative(Fraction<T> value) => value.Numerator < T.Zero;

		/// <inheritdoc/>
		/// <remarks>It is negative infinity if the denominator is zero and the numerator is negative.</remarks>
		public static bool IsNegativeInfinity(Fraction<T> value) => value.Numerator < T.Zero && value.Denominator == T.Zero;

		/// <inheritdoc/>
		/// <remarks>This is always true.</remarks>
		public static bool IsNormal(Fraction<T> value) => true;

		/// <inheritdoc/>
		public static bool IsOddInteger(Fraction<T> value) => !IsEvenInteger(value);

		/// <inheritdoc/>
		public static bool IsPositive(Fraction<T> value) => value.Numerator > T.Zero;

		/// <inheritdoc/>
		/// <remarks>It is positive infinity if the denominator is zero and the numerator is positive.</remarks>
		public static bool IsPositiveInfinity(Fraction<T> value) => value.Numerator > T.Zero && value.Denominator == T.Zero;

		/// <inheritdoc/>
		/// <remarks>It is a real number if it isn't infinity or NaN</remarks>
		public static bool IsRealNumber(Fraction<T> value) => !(IsInfinity(value) || IsNaN(value));

		/// <inheritdoc/>
		/// <remarks>It is subnormal if only one of the the numerator or denominator are zero</remarks>
		public static bool IsSubnormal(Fraction<T> value)
		{
			return (value.Numerator == T.Zero && value.Denominator != T.Zero)
				|| (value.Numerator != T.Zero && value.Denominator == T.Zero);
		}

		/// <inheritdoc/>
		public static bool IsZero(Fraction<T> value)
		{
			if(IsNaN(value) || IsInfinity(value))
				return false;
			return value.Numerator == T.Zero;
		}

		/// <inheritdoc/>
		public static Fraction<T> MaxMagnitude(Fraction<T> x, Fraction<T> y) => x > y ? x : y;

		/// <inheritdoc/>
		public static Fraction<T> MaxMagnitudeNumber(Fraction<T> x, Fraction<T> y)
		{
			if(IsNaN(x))
				return y;
			if(IsNaN(y))
				return x;
			return x > y ? x : y;
		}

		/// <inheritdoc/>
		public static Fraction<T> MinMagnitude(Fraction<T> x, Fraction<T> y) => x < y ? x : y;

		/// <inheritdoc/>
		public static Fraction<T> MinMagnitudeNumber(Fraction<T> x, Fraction<T> y)
		{
			if(IsNaN(x))
				return y;
			if(IsNaN(y))
				return x;
			return x < y ? x : y;
		}
	}
}
