using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

using static TMath.TFunctions;

namespace TMath.Numerics.AdvancedMath.NumberTheory
{
	public static class TNumberTheory
	{
		/// <summary>
		/// Calculates the Greatest Common Divisor (GCD) of a collection of numbers.
		/// </summary>
		/// <remarks>
		/// The GCD is the largest positive integer that divides each number in the collection without a remainder.
		/// Requires numbers to implement <see cref="INumber{T}"/> and <see cref="IBinaryInteger{T}"/> interfaces.
		/// </remarks>
		/// <typeparam name="T">Type of numbers in the collection implementing <see cref="INumber{T}"/> and <see cref="IBinaryInteger{T}"/>.</typeparam>
		/// <param name="source">Collection of numbers for GCD calculation.</param>
		/// <returns>The Greatest Common Divisor of the numbers in the collection.</returns>
		/// <exception cref="ArgumentNullException">Thrown when the input collection is null.</exception>
		/// <exception cref="ArgumentException">Thrown when the input collection is empty.</exception>

		public static T GCD<T>(IEnumerable<T> source) where T : INumber<T>, IBinaryInteger<T>
		{
			if (source == null)
				throw new ArgumentNullException(nameof(source), "Collection must not be null");

			if (!source.Any())
				throw new ArgumentException("Collection must not be empty", nameof(source));

			return source.Aggregate(GCD);
		}

		/// <summary>
		/// Calculates the Least Common Multiple (LCM) of a collection of numbers.
		/// </summary>
		/// <remarks>
		/// The LCM is the smallest positive integer that is divisible by each number in the collection.
		/// Requires numbers to implement <see cref="INumber{T}"/> and <see cref="IBinaryInteger{T}"/> interfaces.
		/// </remarks>
		/// <typeparam name="T">Type of numbers in the collection implementing <see cref="INumber{T}"/> and <see cref="IBinaryInteger{T}"/>.</typeparam>
		/// <param name="source">Collection of numbers for LCM calculation.</param>
		/// <returns>The Least Common Multiple of the numbers in the collection.</returns>
		/// <exception cref="ArgumentNullException">Thrown when the input collection is null.</exception>
		/// <exception cref="ArgumentException">Thrown when the input collection is empty.</exception>

		public static T LCM<T>(IEnumerable<T> source) where T : INumber<T>, IBinaryInteger<T>
		{
			if (source == null)
				throw new ArgumentNullException(nameof(source), "Collection must not be null");

			if (!source.Any())
				throw new ArgumentException("Collection must not be empty", nameof(source));

			return source.Distinct().Aggregate((a, b) => a * b / GCD(a, b));
		}

		/// <summary>
		/// Retrieves the dividers of a given number.
		/// </summary>
		/// <remarks>
		/// The dividers are the positive integers that divide the given number without a remainder.
		/// Requires the number to be greater than 0 and to implement <see cref="INumber{T}"/> and <see cref="IBinaryInteger{T}"/> interfaces.
		/// </remarks>
		/// <typeparam name="T">Type of the number implementing <see cref="INumber{T}"/> and <see cref="IBinaryInteger{T}"/>.</typeparam>
		/// <param name="number">The number for which to retrieve the dividers.</param>
		/// <returns>Enumerable collection of dividers of the given number.</returns>
		/// <exception cref="ArgumentOutOfRangeException">Thrown when the input number is less than or equal to 0.</exception>

		public static IEnumerable<T> Dividers<T>(T number) where T : INumber<T>, IBinaryInteger<T>
		{
			if (number < T.One)
				throw new ArgumentOutOfRangeException(nameof(number), "Number must be greater than 0");

			List<T> dividers = new();
			for(T i = T.One; i <= number / IntToT<T>(2); i++)
			{
				if(number % i == T.Zero)
					dividers.Add(i);
			}

			dividers.Add(number);

			return dividers.AsEnumerable();
		}

		/// <summary>
		/// Calculates Euler's Totient function for a given number.
		/// </summary>
		/// <remarks>
		/// Euler's Totient function, denoted as φ(n), is the count of positive integers less than or equal to n that are coprime to n.
		/// Requires the number to implement <see cref="INumber{T}"/> and <see cref="IBinaryInteger{T}"/> interfaces.
		/// </remarks>
		/// <typeparam name="T">Type of the number implementing <see cref="INumber{T}"/> and <see cref="IBinaryInteger{T}"/>.</typeparam>
		/// <param name="number">The number for which to calculate Euler's Totient.</param>
		/// <returns>The result of Euler's Totient function for the given number.</returns>

		public static T EulersTotient<T>(T number) where T : INumber<T>, IBinaryInteger<T>
		{
			T result = number;
			for(T i = IntToT<T>(2); i * i <= number; i++)
			{
				if(number % i == T.Zero)
				{
					while(number % i == T.Zero)
					{
						number /= i;
					}
					result -= result / i;
				}
			}
			if(number > T.One)
			{
				result -= result / number;
			}
			return result;
		}
		/// <summary>
		/// Checks if a given number is a perfect number.
		/// </summary>
		/// <remarks>
		/// A perfect number is a positive integer that is equal to the sum of its proper divisors (excluding itself).
		/// Requires the number to be greater than 0 and to implement <see cref="INumber{T}"/> and <see cref="IBinaryInteger{T}"/> interfaces.
		/// </remarks>
		/// <typeparam name="T">Type of the number implementing <see cref="INumber{T}"/> and <see cref="IBinaryInteger{T}"/>.</typeparam>
		/// <param name="number">The number to check for perfection.</param>
		/// <returns>True if the number is a perfect number, otherwise false.</returns>

		public static bool IsPerfectNumber<T>(T number) where T : INumber<T>, IBinaryInteger<T>
		{
			if (number < T.One)
				return false;

			return number == Dividers(number).Aggregate((a, b) => a + b) - number;
		}

		/// <summary>
		/// Generates the Collatz Conjecture sequence for a given number.
		/// </summary>
		/// <remarks>
		/// The Collatz Conjecture is a sequence defined for a positive integer:
		/// If the number is even, divide it by 2; if it's odd, multiply it by 3 and add 1.
		/// The sequence continues until the number becomes 1.
		/// Requires the number to be greater than 0 and to implement <see cref="INumber{T}"/> and <see cref="IBinaryInteger{T}"/> interfaces.
		/// </remarks>
		/// <typeparam name="T">Type of the number implementing <see cref="INumber{T}"/> and <see cref="IBinaryInteger{T}"/>.</typeparam>
		/// <param name="number">The starting number for the Collatz Conjecture sequence.</param>
		/// <returns>Enumerable collection representing the Collatz Conjecture sequence for the given number.</returns>
		/// <exception cref="ArgumentOutOfRangeException">Thrown when the input number is less than or equal to 0.</exception>

		public static IEnumerable<T> CollatzConjecture<T>(T number) where T : INumber<T>, IBinaryInteger<T>
		{

			if (number < T.One)
				throw new ArgumentOutOfRangeException(nameof(number), "Number must be greater than 0");

			List<T> vals = new() { number };
			T Two = T.One + T.One;
			T Three = Two + T.One;
			while(number != T.One)
			{
				if(number % Two == T.Zero)
					number /= Two;
				else
					number = number * Three + T.One;
				vals.Add(number);
			}
			return vals.AsEnumerable();
		}

		/// <summary>
		/// Checks if a given number is a prime number.
		/// </summary>
		/// <remarks>
		/// A prime number is a positive integer greater than 1 that has no positive divisors other than 1 and itself.
		/// Requires the number to implement <see cref="INumber{T}"/> and <see cref="IBinaryInteger{T}"/> interfaces.
		/// </remarks>
		/// <typeparam name="T">Type of the number implementing <see cref="INumber{T}"/> and <see cref="IBinaryInteger{T}"/>.</typeparam>
		/// <param name="number">The number to check for primality.</param>
		/// <returns>True if the number is prime, otherwise false.</returns>

		public static bool IsPrime<T>(T number) where T : INumber<T>, IBinaryInteger<T>
		{
			T two = T.One + T.One;
			if(number < two)
				return false;
			if(number == two)
				return true;
			if(number % (two) == T.Zero)
				return false;
			for(T i = two + T.One; i * i <= number; i += two)
			{
				if(number % i == T.Zero)
					return false;
			}
			return true;
		}

		/// <summary>
		/// Generates a sequence of prime numbers up to a given limit.
		/// </summary>
		/// <remarks>
		/// Generates all prime numbers up to the specified limit using the Sieve of Eratosthenes algorithm.
		/// Requires the number to be greater than 0 and to implement <see cref="INumber{T}"/> and <see cref="IBinaryInteger{T}"/> interfaces.
		/// </remarks>
		/// <typeparam name="T">Type of the number implementing <see cref="INumber{T}"/> and <see cref="IBinaryInteger{T}"/>.</typeparam>
		/// <param name="number">The limit up to which to generate prime numbers.</param>
		/// <returns>Enumerable collection of prime numbers up to the specified limit.</returns>
		/// <exception cref="ArgumentOutOfRangeException">Thrown when the input number is less than or equal to 0.</exception>

		public static IEnumerable<T> GeneratePrimesUpTo<T>(T number) where T : INumber<T>, IBinaryInteger<T>
		{
			if(number < T.One)
				throw new ArgumentOutOfRangeException(nameof(number), "Number must be greater than 0");

			T[] nums = TGeneration.NumberSequence<T>(T.One, number).ToArray();

			T p = T.One + T.One;

			int index = 1;

			while(p * p <= number)
			{
				p = nums[index];
				for(T i = T.One + T.One; i * p <= number; i++)
				{
					nums[int.CreateSaturating((i * p) - T.One)] = T.Zero;
				}

				index++;
				while (nums[index] == T.Zero)
				{
					index++;
				}
			}
			return nums.Where(x => x > T.One);

		}

		private static T GCD<T>(T a, T b) where T : INumber<T>
		{
			while(b != T.Zero)
			{
				(a, b) = (b, a % b);
			}
			return a;
		}
	}
}
