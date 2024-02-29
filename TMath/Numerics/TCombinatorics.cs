﻿using System.Numerics;
using TMath.Numerics.Core;
using static TMath.TFunctions;
namespace TMath.Numerics
{
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
		/// <returns>The number of permutations for selecting k elements from a set of n elements.</returns>

		public static T Permutations<T>(T n, T k) where T : INumber<T>, IBinaryInteger<T>
			=> Factorial(n) / Factorial(n - k);

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
		/// <returns>The number of permutations for selecting k elements from the collection.</returns>

		public static TTarget Permutations<TSource, TTarget>(IEnumerable<TSource> elements, TTarget k) where TTarget : INumber<TTarget>, IBinaryInteger<TTarget>
			=> Factorial(Helpers.Count<TTarget, TSource>(elements)) / Factorial(Helpers.Count<TTarget, TSource>(elements) - k);

		/// <summary>
		/// Generates all permutations of k elements from a given collection.
		/// </summary>
		/// <typeparam name="T">Type of elements in the collection.</typeparam>
		/// <param name="elements">The collection of elements to generate permutations from.</param>
		/// <param name="k">The number of elements to select for each permutation.</param>
		/// <returns>Enumerable collection of all permutations of k elements from the given collection.</returns>

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
		/// <returns>The number of combinations for selecting k elements from a set of n elements.</returns>

		public static T Combinations<T>(T n, T k) where T : INumber<T>, IBinaryInteger<T>
			=> Factorial(n) / (Factorial(k) * Factorial(n - k));

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
		/// <returns>The number of combinations for selecting k elements from the collection.</returns>

		public static TTarget Combinations<TSource, TTarget>(IEnumerable<TSource> elements, TTarget k) where TTarget : INumber<TTarget>, IBinaryInteger<TTarget>
			=> Factorial(Helpers.Count<TTarget, TSource>(elements)) / (Factorial(k) * Factorial(Helpers.Count<TTarget, TSource>(elements) - k));

		/// <summary>
		/// Generates all combinations of k elements from a given collection.
		/// </summary>
		/// <typeparam name="T">Type of elements in the collection.</typeparam>
		/// <param name="elements">The collection of elements to generate combinations from.</param>
		/// <param name="k">The number of elements to select for each combination.</param>
		/// <returns>Enumerable collection of all combinations of k elements from the given collection.</returns>

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
