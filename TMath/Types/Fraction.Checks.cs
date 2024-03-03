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
		public static bool IsCanonical(Fraction<T> value) => value.SimplifyAsNew() == value;

		public static bool IsComplexNumber(Fraction<T> value) => false;

		public static bool IsEvenInteger(Fraction<T> value)
		{
			if (IsInfinity(value))
				return false;
			return value.Numerator % (T.CreateChecked(2) * value.Denominator) == T.Zero;
		}

		public static bool IsFinite(Fraction<T> value) => value.Denominator != T.Zero;

		public static bool IsImaginaryNumber(Fraction<T> value) => false;

		public static bool IsInfinity(Fraction<T> value) => value.Denominator == T.Zero;

		public static bool IsInteger(Fraction<T> value)
		{
			if(IsInfinity(value))
				return false; 
			return value.Numerator % value.Denominator == T.Zero;
		}

		public static bool IsNaN(Fraction<T> value) => value.Numerator == T.Zero && value.Denominator == T.Zero;

		public static bool IsNegative(Fraction<T> value) => value.Numerator < T.Zero;

		public static bool IsNegativeInfinity(Fraction<T> value) => value.Numerator < T.Zero && value.Denominator == T.Zero;

		public static bool IsNormal(Fraction<T> value) => true;

		public static bool IsOddInteger(Fraction<T> value) => !IsEvenInteger(value);

		public static bool IsPositive(Fraction<T> value) => value.Numerator > T.Zero;

		public static bool IsPositiveInfinity(Fraction<T> value) => value.Numerator > T.Zero && value.Denominator == T.Zero;

		public static bool IsRealNumber(Fraction<T> value) => !(IsInfinity(value) || IsNaN(value));

		public static bool IsSubnormal(Fraction<T> value)
		{
			return (value.Numerator == T.Zero && value.Denominator != T.Zero)
				|| (value.Numerator != T.Zero && value.Denominator == T.Zero);
		}

		public static bool IsZero(Fraction<T> value)
		{
			if(IsNaN(value) || IsInfinity(value))
				return false;
			return value.Numerator == T.Zero;
		}

		public static Fraction<T> MaxMagnitude(Fraction<T> x, Fraction<T> y) => x > y ? x : y;

		public static Fraction<T> MaxMagnitudeNumber(Fraction<T> x, Fraction<T> y)
		{
			if(IsNaN(x))
				return y;
			if(IsNaN(y))
				return x;
			return x > y ? x : y;
		}

		public static Fraction<T> MinMagnitude(Fraction<T> x, Fraction<T> y) => x < y ? x : y;

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
