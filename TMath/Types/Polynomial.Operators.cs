using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;
using TMath.Numerics.Core;

namespace TMath.Types
{
	public partial class Polynomial<T> : INumber<Polynomial<T>>
		where T : INumber<T>
	{

		public static Polynomial<T> operator +(Polynomial<T> value) => value;

		public static Polynomial<T> operator +(Polynomial<T> left, Polynomial<T> right)
		{
			T[] larger = Helpers.GetLargerEnumerable(left.Coefficients, right.Coefficients).ToArray();
			T[] smaller = Helpers.GetSmallerEnumerable(left.Coefficients, right.Coefficients).ToArray();

			var result = new T[larger.Count()];
			for (int i = 0; i < result.Count(); i++)
			{
				if (i < smaller.Count())
				{
					result[i] = larger[i] + smaller[i];
				}
				else
				{
					result[i] = larger[i];
				}
			}

			return new Polynomial<T>(result);
		}

		public static Polynomial<T> operator -(Polynomial<T> value) => new Polynomial<T>(value.Coefficients.Select(x => -x).ToArray());

		public static Polynomial<T> operator -(Polynomial<T> left, Polynomial<T> right)
		{
			T[] larger = Helpers.GetLargerEnumerable(left.Coefficients, right.Coefficients).ToArray();
			T[] smaller = Helpers.GetSmallerEnumerable(left.Coefficients, right.Coefficients).ToArray();

			var result = new T[larger.Count()];
			for (int i = 0; i < result.Count(); i++)
			{
				if (i < smaller.Count())
				{
					result[i] = larger[i] - smaller[i];
				}
				else
				{
					result[i] = larger[i];
				}
			}

			return new Polynomial<T>(result);
		}

		public static Polynomial<T> operator ++(Polynomial<T> value) => new(value.Coefficients.Select(x => x + T.One).ToArray());

		public static Polynomial<T> operator --(Polynomial<T> value) => new(value.Coefficients.Select(x => x - T.One).ToArray());

		public static Polynomial<T> operator *(Polynomial<T> left, Polynomial<T> right)
		{
			T[] result = new T[left.Degree + right.Degree + 1];
			for (int i = 0; i <= left.Degree; i++)
			{
				for (int j = 0; j <= right.Degree; j++)
				{
					result[i + j] += left.Coefficients[i] * right.Coefficients[j];
				}
			}
			return new Polynomial<T>(result);

		}
		/// <inheritdoc/>
		/// <remarks>
		/// <b>IMPORTANT!!! </b>
		/// This division algorithm is based on the polynomial long division algorithm.
		/// However, due to limitations, if in the long division process, there is a member that cannot be written as ax^n,
		/// the result will be incorrect. It will simply ignore the member and continue the division.
		/// When using this method, make sure that the numerator divided by the denominator results in a monic polynomial.
		/// </remarks>
		public static Polynomial<T> operator /(Polynomial<T> left, Polynomial<T> right)
		{
			if (right.Degree <= 0 && right.Coefficients[0] == T.Zero)
			{
				throw new ArgumentException("Division by zero is not allowed.");
			}

			int numeratorDegree = left.Degree;
			int denominatorDegree = right.Degree;

			// If the numerator has a lower degree than the denominator, the result is zero
			if (numeratorDegree < denominatorDegree)
			{
				return new Polynomial<T>();
			}

			// Initialize arrays to store the quotient and remainder
			T[] quotientCoefficients = new T[numeratorDegree - denominatorDegree + 1];
			T[] remainderCoefficients = new T[numeratorDegree + 1];

			// Copy the numerator coefficients to the remainder array
			Array.Copy(left.Coefficients, remainderCoefficients, left.Coefficients.Length);

			int iterations = 0, maxiterations = 1000;

			// Perform polynomial division
			while (numeratorDegree >= denominatorDegree)
			{
				// Calculate the term to add to the quotient
				T term = remainderCoefficients[numeratorDegree]/right.Coefficients[denominatorDegree];

				// Update the quotient coefficient
				quotientCoefficients[numeratorDegree - denominatorDegree] = term;

				// Subtract the term * right from the current remainder
				for (int i = 0; i <= denominatorDegree; i++)
				{
					remainderCoefficients[numeratorDegree - i] = (remainderCoefficients[numeratorDegree - i] - (term * right.Coefficients[denominatorDegree - i]));
				}

				if (remainderCoefficients[numeratorDegree] == T.Zero)
				remainderCoefficients = remainderCoefficients.Take(remainderCoefficients.Length - 1).ToArray();

				// Update the degree of the current remainder
				numeratorDegree = remainderCoefficients.Length - 1;
				iterations++;

				if(iterations >= maxiterations)
				{
					throw new InvalidOperationException("The division algorithm did not converge.");
				}
			}

			return new Polynomial<T>(quotientCoefficients);
		}

		public static Polynomial<T> operator %(Polynomial<T> left, Polynomial<T> right)
		{
			throw new NotImplementedException();
		}

		public static bool operator ==(Polynomial<T>? left, Polynomial<T>? right)
		{
			if(left is null && right is null)
			{
				return true;
			}

			else if(left is null || right is null)
			{
				return false;
			}
			else
			{
				return left.Equals(right);
			}
		}

		public static bool operator !=(Polynomial<T>? left, Polynomial<T>? right)
		{
			return !(left == right);
		}

		public static bool operator <(Polynomial<T> left, Polynomial<T> right)
		{
			if(left.Degree < right.Degree)
			{
				return true;
			}
			else if(left.Degree > right.Degree)
			{
				return false;
			}
			else
			{
				for(int i = left.Degree; i >= 0; i--)
				{
					if (left.Coefficients[i] < right.Coefficients[i])
					{
						return true;
					}
					else if (left.Coefficients[i] > right.Coefficients[i])
					{
						return false;
					}
				}
				return false;
			}
		}

		public static bool operator >(Polynomial<T> left, Polynomial<T> right)
		{
			if (left.Degree > right.Degree)
			{
				return true;
			}
			else if (left.Degree < right.Degree)
			{
				return false;
			}
			else
			{
				for (int i = left.Degree; i >= 0; i--)
				{
					if (left.Coefficients[i] > right.Coefficients[i])
					{
						return true;
					}
					else if (left.Coefficients[i] < right.Coefficients[i])
					{
						return false;
					}
				}
				return false;
			}
		}

		public static bool operator <=(Polynomial<T> left, Polynomial<T> right)
		{
			if (left.Degree < right.Degree)
			{
				return true;
			}
			else if (left.Degree > right.Degree)
			{
				return false;
			}
			else
			{
				for (int i = left.Degree; i >= 0; i--)
				{
					if (left.Coefficients[i] < right.Coefficients[i])
					{
						return true;
					}
					else if (left.Coefficients[i] > right.Coefficients[i])
					{
						return false;
					}
				}
				return true;
			}
		}

		public static bool operator >=(Polynomial<T> left, Polynomial<T> right)
		{
			if (left.Degree > right.Degree)
			{
				return true;
			}
			else if (left.Degree < right.Degree)
			{
				return false;
			}
			else
			{
				for (int i = left.Degree; i >= 0; i--)
				{
					if (left.Coefficients[i] > right.Coefficients[i])
					{
						return true;
					}
					else if (left.Coefficients[i] < right.Coefficients[i])
					{
						return false;
					}
				}
				return true;
			}
		}

		public override bool Equals(object? obj)
		{
			if(ReferenceEquals(this, obj))
			{
				return true;
			}

			if(obj == null)
			{
				return false;
			}


			if(obj is Polynomial<T> polynomial)
			{
				return Helpers.EnumerableAreEqual(this.Coefficients, polynomial.Coefficients);
			}

			return false;
		}
	}
}

