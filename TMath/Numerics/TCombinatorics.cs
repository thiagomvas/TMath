using System.Numerics;
using TMath.Numerics.Core;
using static TMath.TFunctions;
namespace TMath.Numerics
{
	public static class TCombinatorics
	{
		public static T Permutations<T>(T n, T k) where T : INumber<T>, IBinaryInteger<T>
			=> Factorial(n) / Factorial(n - k);

		public static T Permutations<T>(IEnumerable<T> elements, T k) where T : INumber<T>, IBinaryInteger<T>
			=> Factorial(Helpers.Count<T, T>(elements)) / Factorial(Helpers.Count<T, T>(elements) - k);

		public static IEnumerable<IEnumerable<T>> GeneratePermutations<T>(IEnumerable<T> elements, int k)
		{
			if (k == 0)
			{
				yield return new T[0];
			}
			else
			{
				int i = 0;
				foreach (var element in elements)
				{
					var nextElements = elements.Where((e, index) => index != i);
					foreach (var permutation in GeneratePermutations(nextElements, k - 1))
					{
						yield return new T[] { element }.Concat(permutation);
					}
					i++;
				}
			}
		}



		public static T Combinations<T>(T n, T k) where T : INumber<T>, IBinaryInteger<T>
			=> Factorial(n) / (Factorial(k) * Factorial(n - k));

		public static T Combinations<T>(IEnumerable<T> elements, T k) where T : INumber<T>, IBinaryInteger<T>
			=> Factorial(Helpers.Count<T, T>(elements)) / (Factorial(k) * Factorial(Helpers.Count<T, T>(elements) - k));

		public static IEnumerable<IEnumerable<T>> GenerateCombinations<T>(IEnumerable<T> elements, int k)
		{
			if (k == 0)
			{
				yield return new T[0];
			}
			else
			{
				int i = 0;
				foreach (var element in elements)
				{
					var nextElements = elements.Where((e, index) => index > i);
					foreach (var combination in GenerateCombinations(nextElements, k - 1))
					{
						yield return new T[] { element }.Concat(combination);
					}
					i++;
				}
			}
		}

		
	}
}
