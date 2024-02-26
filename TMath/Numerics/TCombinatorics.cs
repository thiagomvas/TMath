using System.Numerics;
using TMath.Numerics.Core;
using static TMath.TFunctions;
namespace TMath.Numerics
{
	public static class TCombinatorics
	{
		public static T Permutations<T>(T n, T k) where T : INumber<T>, IBinaryInteger<T>
			=> Factorial(n) / Factorial(n - k);

		public static T Permutations<T>(IEnumerable<T> elements,T k ) where T : INumber<T>, IBinaryInteger<T>
			=> Factorial(Helpers.Count<T, T>(elements)) / Factorial(Helpers.Count<T, T>(elements) - k);

		public static T Combinations<T>(T n, T k) where T : INumber<T>, IBinaryInteger<T>
			=> Factorial(n) / (Factorial(k) * Factorial(n - k));

		public static T Combinations<T>(IEnumerable<T> elements, T k) where T : INumber<T>, IBinaryInteger<T>
			=> Factorial(Helpers.Count<T, T>(elements)) / (Factorial(k) * Factorial(Helpers.Count<T, T>(elements) - k));

	}
}
