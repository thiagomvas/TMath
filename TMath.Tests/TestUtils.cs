using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TMath.Tests
{
	internal static class TestUtils
	{
		public static bool EnumerableAreEqual<T>(IEnumerable<T> a, IEnumerable<T> b)
		{
			if(a == null && b == null)
				return true;

			if(a == null || b == null)
				return false;

			if(a.Count() != b.Count())
				return false;

			return a.SequenceEqual(b);
		}
	
	}
}
