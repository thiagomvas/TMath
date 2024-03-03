using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace TMath.Types
{
	public partial class Fraction<T> : INumber<Fraction<T>>
		where T : INumber<T>
	{
		public static Fraction<T> operator +(Fraction<T> value) => new Fraction<T>(+value.Numerator, +value.Denominator).Simplify();

		public static Fraction<T> operator +(Fraction<T> left, Fraction<T> right)
		{
			if (left.Denominator == right.Denominator)
				return new Fraction<T>(left.Numerator + right.Numerator, left.Denominator).Simplify();

			return new Fraction<T>(left.Numerator * right.Denominator + right.Numerator * left.Denominator, left.Denominator * right.Denominator).Simplify();
		}

		public static Fraction<T> operator -(Fraction<T> value) => new Fraction<T>(-value.Numerator, value.Denominator).Simplify();

		public static Fraction<T> operator -(Fraction<T> left, Fraction<T> right)
		{
			return new Fraction<T>(left.Numerator * right.Denominator - right.Numerator * left.Denominator, left.Denominator * right.Denominator);
		}
		public static Fraction<T> operator -(Fraction<T> left, T right)
		{
			var foo = new Fraction<T>(left.Numerator - right * left.Denominator, left.Denominator);
			return new Fraction<T>(left.Numerator - right * left.Denominator, left.Denominator);
		}



		public static Fraction<T> operator ++(Fraction<T> value) => new Fraction<T>(value.Numerator + value.Denominator, value.Denominator).Simplify();

		public static Fraction<T> operator --(Fraction<T> value) => new Fraction<T>(value.Numerator - value.Denominator, value.Denominator).Simplify();

		public static Fraction<T> operator *(Fraction<T> left, Fraction<T> right) => new Fraction<T>(left.Numerator * right.Numerator, left.Denominator * right.Denominator).Simplify();

		public static Fraction<T> operator /(Fraction<T> left, Fraction<T> right) => new Fraction<T>(left.Numerator * right.Denominator, left.Denominator * right.Numerator).Simplify();

		public static Fraction<T> operator %(Fraction<T> left, Fraction<T> right) => new Fraction<T>(left.Numerator * right.Denominator % (right.Numerator * left.Denominator), left.Denominator * right.Denominator).Simplify();

		public static bool operator ==(Fraction<T>? left, Fraction<T>? right)
		{
			if(left is null && right is null)
				return true;
			if(left is null || right is null)
				return false;
			return left.Numerator * right.Denominator == right.Numerator * left.Denominator;
		}

		public static bool operator !=(Fraction<T>? left, Fraction<T>? right)
		{
			if(left is null && right is null)
				return false;
			if(left is null || right is null)
				return true;
			return left.Numerator * right.Denominator != right.Numerator * left.Denominator;
		}

		public static bool operator <(Fraction<T> left, Fraction<T> right)
		{
			return left.Numerator * right.Denominator < right.Numerator * left.Denominator;
		}

		public static bool operator >(Fraction<T> left, Fraction<T> right)
		{
			return left.Numerator * right.Denominator > right.Numerator * left.Denominator;
		}

		public static bool operator <=(Fraction<T> left, Fraction<T> right)
		{
			return left.Numerator * right.Denominator <= right.Numerator * left.Denominator;
		}

		public static bool operator >=(Fraction<T> left, Fraction<T> right)
		{
			return left.Numerator * right.Denominator >= right.Numerator * left.Denominator;
		}
	}
}