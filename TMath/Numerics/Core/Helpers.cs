using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace TMath.Numerics.Core
{
	internal static class Helpers
	{
		public static TTarget Count<TTarget, TSource>(IEnumerable<TSource> elements) where TTarget : INumber<TTarget>
		{
			TTarget total = TTarget.Zero;
			foreach (var element in elements)
			{
				total++;
			}
			return total;
		}

		public static bool EnumerableAreEqual<T>(IEnumerable<T> a, IEnumerable<T> b)
		{
			if (a == null && b == null)
				return true;

			if (a == null || b == null)
				return false;

			if (a.Count() != b.Count())
				return false;

			return a.SequenceEqual(b);
		}

		public static IEnumerable<T> GetLargerEnumerable<T>(IEnumerable<T> a, IEnumerable<T> b)
		{
			if (a.Count() >= b.Count())
				return a;
			else
				return b;
		}

		public static IEnumerable<T> GetSmallerEnumerable<T>(IEnumerable<T> a, IEnumerable<T> b)
		{
			if (a.Count() < b.Count())
				return a;
			else
				return b;
		}

	}
}
