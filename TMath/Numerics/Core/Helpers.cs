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
	}
}
