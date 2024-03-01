using System.Numerics;
using TMath.Numerics.Core;
using static TMath.TFunctions;
namespace TMath.Numerics
{
	/// <summary>
	/// A mathematical utility class providing combinatorics functions for generic numeric and collection types.
	/// </summary>
	public static class TCombinatorics
	{
		/// <summary>
		/// Calculates the number of permutations for selecting k elements from a set of n elements.
		/// </summary>
		/// <remarks>
		/// Permutations represent the number of ways to arrange k elements from a set of n elements without replacement.
		/// Requires numbers to implement <see cref="INumber{T}"/> and <see cref="IBinaryInteger{T}"/> interfaces.
		/// </remarks>
		/// <typeparam name="T">Type of numbers implementing <see cref="INumber{T}"/> and <see cref="IBinaryInteger{T}"/>.</typeparam>
		/// <param name="n">The total number of elements in the set.</param>
		/// <param name="k">The number of elements to select for each permutation.</param>
		/// <param name="allowDuplicates">Whether to allow duplicate elements in the permutations.</param>
		/// <returns>The number of permutations for selecting k elements from a set of n elements.</returns>

		public static T Permutations<T>(T n, T k, bool allowDuplicates = false) where T : INumber<T>, IBinaryInteger<T>
			=> allowDuplicates ? Pow<T, T>(n, k) : Factorial(n) / Factorial(n - k);

		/// <summary>
		/// Calculates the number of permutations for selecting k elements from a collection of distinct elements.
		/// </summary>
		/// <remarks>
		/// Permutations represent the number of ways to arrange k elements from a collection without replacement.
		/// Requires numbers to implement <see cref="INumber{TTarget}"/> and <see cref="IBinaryInteger{TTarget}"/> interfaces.
		/// </remarks>
		/// <typeparam name="TSource">Type of elements in the collection.</typeparam>
		/// <typeparam name="TTarget">Type of the count used for permutations, implementing <see cref="INumber{TTarget}"/> and <see cref="IBinaryInteger{TTarget}"/>.</typeparam>
		/// <param name="elements">The collection of distinct elements.</param>
		/// <param name="k">The number of elements to select for each permutation.</param>
		/// <param name="allowDuplicates">Whether to allow duplicate elements in the permutations.</param>
		/// <returns>The number of permutations for selecting k elements from the collection.</returns>

		public static TTarget Permutations<TSource, TTarget>(IEnumerable<TSource> elements, TTarget k, bool allowDuplicates = false) where TTarget : INumber<TTarget>, IBinaryInteger<TTarget>
			=> allowDuplicates ? Pow<TTarget, int>(elements.Count(), int.CreateSaturating(k))
							   : Factorial(Helpers.Count<TTarget, TSource>(elements)) / Factorial(Helpers.Count<TTarget, TSource>(elements) - k);

		/// <summary>
		/// Generates all permutations of k elements from a given collection.
		/// </summary>
		/// <typeparam name="T">Type of elements in the collection.</typeparam>
		/// <param name="elements">The collection of elements to generate permutations from.</param>
		/// <param name="k">The number of elements to select for each permutation.</param>
		/// <param name="allowDuplicates">Whether to allow duplicate elements in the permutations.</param>
		/// <returns>Enumerable collection of all permutations of k elements from the given collection.</returns>

		public static IEnumerable<IEnumerable<T>> GeneratePermutations<T>(IEnumerable<T> elements, int k, bool allowDuplicates = false)
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
					var nextElements = allowDuplicates ? elements : elements.Where((e, index) => index != i);
					foreach (var permutation in GeneratePermutations(nextElements, k - 1, allowDuplicates))
					{
						yield return new T[] { element }.Concat(permutation);
					}
					i++;
				}
			}
		}

		/// <summary>
		/// Calculates the number of combinations for selecting k elements from a set of n elements.
		/// </summary>
		/// <remarks>
		/// Combinations represent the number of ways to choose k elements from a set of n elements without considering the order.
		/// Requires numbers to implement <see cref="INumber{T}"/> and <see cref="IBinaryInteger{T}"/> interfaces.
		/// </remarks>
		/// <typeparam name="T">Type of numbers implementing <see cref="INumber{T}"/> and <see cref="IBinaryInteger{T}"/>.</typeparam>
		/// <param name="n">The total number of elements in the set.</param>
		/// <param name="k">The number of elements to select for each combination.</param>
		/// <param name="allowDuplicates">Whether to allow duplicate elements in the combinations.</param>
		/// <returns>The number of combinations for selecting k elements from a set of n elements.</returns>

		public static T Combinations<T>(T n, T k, bool allowDuplicates = false) where T : INumber<T>, IBinaryInteger<T>
		{
			if (allowDuplicates)
				return Factorial(n + k - T.One) / (Factorial(k) * Factorial(n - T.One));
			else
				return Factorial(n) / (Factorial(k) * Factorial(n - k));
		}

		/// <summary>
		/// Calculates the number of combinations for selecting k elements from a collection of distinct elements.
		/// </summary>
		/// <remarks>
		/// Combinations represent the number of ways to choose k elements from a collection without considering the order.
		/// Requires numbers to implement <see cref="INumber{TTarget}"/> and <see cref="IBinaryInteger{TTarget}"/> interfaces.
		/// </remarks>
		/// <typeparam name="TSource">Type of elements in the collection.</typeparam>
		/// <typeparam name="TTarget">Type of the count used for combinations, implementing <see cref="INumber{TTarget}"/> and <see cref="IBinaryInteger{TTarget}"/>.</typeparam>
		/// <param name="elements">The collection of distinct elements.</param>
		/// <param name="k">The number of elements to select for each combination.</param>
		/// <param name="allowDuplicates">Whether to allow duplicate elements in the combinations.</param>
		/// <returns>The number of combinations for selecting k elements from the collection.</returns>

		public static TTarget Combinations<TSource, TTarget>(IEnumerable<TSource> elements, TTarget k, bool allowDuplicates = false) where TTarget : INumber<TTarget>, IBinaryInteger<TTarget>
		{
			if (allowDuplicates)
				return Factorial(Helpers.Count<TTarget, TSource>(elements) + k - TTarget.One) / (Factorial(k) * Factorial(Helpers.Count<TTarget, TSource>(elements) - TTarget.One));
			else
				return Factorial(Helpers.Count<TTarget, TSource>(elements)) / (Factorial(k) * Factorial(Helpers.Count<TTarget, TSource>(elements) - k));
		}

		/// <summary>
		/// Generates all combinations of k elements from a given collection.
		/// </summary>
		/// <typeparam name="T">Type of elements in the collection.</typeparam>
		/// <param name="elements">The collection of elements to generate combinations from.</param>
		/// <param name="k">The number of elements to select for each combination.</param>
		/// <param name="allowDuplicates">Whether to allow duplicate elements in the combinations.</param>
		/// <returns>Enumerable collection of all combinations of k elements from the given collection.</returns>

		public static IEnumerable<IEnumerable<T>> GenerateCombinations<T>(IEnumerable<T> elements, int k, bool allowDuplicates = false)
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
					var nextElements = elements.Where((e, index) => index >= i);

					if (!allowDuplicates)
					{
						nextElements = nextElements.Where(e => !e.Equals(element));
					}
					foreach (var combination in GenerateCombinations(nextElements, k - 1, allowDuplicates))
					{
						yield return new T[] { element }.Concat(combination);
					}
					i++;
				}
			}
		}

		
	}
}
