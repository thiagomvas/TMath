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
	public static class NumberTheory
	{ 
		public static T GCD<T>(IEnumerable<T> source) where T : INumber<T>
		{
			return source.Aggregate(GCD);
		}

		public static T LCM<T>(IEnumerable<T> source) where T : INumber<T>
		{
			return source.Distinct().Aggregate((a, b) => a * b / GCD(a, b));
		}

		public static IEnumerable<T> Dividers<T>(T number) where T : INumber<T>
		{
			List<T> dividers = new();
			for(T i = T.One; i <= number / IntToT<T>(2); i++)
			{
				if(number % i == T.Zero)
					dividers.Add(i);
			}

			dividers.Add(number);

			return dividers.AsEnumerable();
		}

		public static T EulersTotient<T>(T number) where T : INumber<T>
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

		public static bool IsPerfectNumber<T>(T number) where T : INumber<T>, IBinaryInteger<T>
		{
			return number == Dividers(number).Aggregate((a, b) => a + b) - number;
		}

		public static IEnumerable<T> CollatzConjecture<T>(T number) where T : INumber<T>, IBinaryInteger<T>
		{
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
