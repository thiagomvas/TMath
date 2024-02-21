using System;
using System.Collections.Generic;
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
