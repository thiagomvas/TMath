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
