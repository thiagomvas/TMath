using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TMath.Numerics;

using static TMath.Tests.TestUtils;

namespace TMath.Tests.Numerics
{
	public class TCombinatoricsTest
	{
		[Test]
		[TestCase(5, 5, 120)]
		[TestCase(5, 4, 120)]
		[TestCase(5, 3, 60)]
		[TestCase(5, 2, 20)]
		[TestCase(5, 1, 5)]
		public void PermutationCount_FromValues(int n, int k, int expected)
		{
			// Arrange

			// Act
			int actual = TCombinatorics.Permutations(n, k);

			// Assert
			Assert.That(actual, Is.EqualTo(expected));
		}

		[Test]
		[TestCase(new int[] { 1, 2, 3, 4, 5 }, 5, 120)]
		[TestCase(new int[] { 1, 2, 3, 4, 5 }, 4, 120)]
		[TestCase(new int[] { 1, 2, 3, 4, 5 }, 3, 60)]
		[TestCase(new int[] { 1, 2, 3, 4, 5 }, 2, 20)]
		[TestCase(new int[] { 1, 2, 3, 4, 5 }, 1, 5)]

		public void PermutationCount_FromCollection(int[] elements, int k, int expected)
		{
			// Arrange

			// Act
			int actual = TCombinatorics.Permutations(elements, k);

			// Assert
			Assert.That(actual, Is.EqualTo(expected));
		}

		[Test]
		[TestCase(new int[] { 1, 2, 3, 4, 5 }, 5)]
		[TestCase(new int[] { 1, 2, 3, 4, 5 }, 4)]
		[TestCase(new int[] {1, 2, 3, 4, 5}, 3)]
		[TestCase(new int[] {1, 2, 3, 4, 5}, 2)]
		[TestCase(new int[] {1, 2, 3, 4, 5}, 1)]
		public void GeneratePermutations_LengthShouldBeEqualToFormula(int[] elements, int k)
		{
			// Arrange
			int expected = TCombinatorics.Permutations(elements, k);

			// Act
			int actual = TCombinatorics.GeneratePermutations(elements, k).Count();

			// Assert
			Assert.That(actual, Is.EqualTo(expected));
		}

		[Test]
		public void GeneratePermutations_ShouldHaveCorrectElements()
		{
			// Arrange
			int[] elements = [1, 2, 3, 4, 5];
			int k = 3;
			int[][] expected =
			[
				[1, 2, 3], [1, 2, 4], [1, 2, 5], [1, 3, 2], [1, 3, 4], [1, 3, 5], [1, 4, 2], [1, 4, 3], [1, 4, 5], [1, 5, 2], [1, 5, 3], [1, 5, 4],
				[2, 1, 3], [2, 1, 4], [2, 1, 5], [2, 3, 1], [2, 3, 4], [2, 3, 5], [2, 4, 1], [2, 4, 3], [2, 4, 5], [2, 5, 1], [2, 5, 3], [2, 5, 4],
				[3, 1, 2], [3, 1, 4], [3, 1, 5], [3, 2, 1], [3, 2, 4], [3, 2, 5], [3, 4, 1], [3, 4, 2], [3, 4, 5], [3, 5, 1], [3, 5, 2], [3, 5, 4],
				[4, 1, 2], [4, 1, 3], [4, 1, 5], [4, 2, 1], [4, 2, 3], [4, 2, 5], [4, 3, 1], [4, 3, 2], [4, 3, 5], [4, 5, 1], [4, 5, 2], [4, 5, 3],
				[5, 1, 2], [5, 1, 3], [5, 1, 4], [5, 2, 1], [5, 2, 3], [5, 2, 4], [5, 3, 1], [5, 3, 2], [5, 3, 4], [5, 4, 1], [5, 4, 2], [5, 4, 3]
			];

			// Act
			var actual = TCombinatorics.GeneratePermutations(elements, k);

			// Assert
			for(int i = 0; i < expected.Length; i++)
			{
				Assert.That(EnumerableAreEqual(actual.ElementAt(i), expected[i]), Is.True);
			}
		}

		[Test]
		[TestCase(5, 5, 1)]
		[TestCase(5, 4, 5)]
		[TestCase(5, 3, 10)]
		[TestCase(5, 2, 10)]
		[TestCase(5, 1, 5)]
		public void CombinationCount_FromValues(int n, int k, int expected)
		{
			// Arrange

			// Act
			int actual = TCombinatorics.Combinations(n, k);

			// Assert
			Assert.That(actual, Is.EqualTo(expected));
		}

		[Test]
		[TestCase(new int[] { 1, 2, 3, 4, 5 }, 5, 1)]
		[TestCase(new int[] { 1, 2, 3, 4, 5 }, 4, 5)]
		[TestCase(new int[] { 1, 2, 3, 4, 5 }, 3, 10)]
		[TestCase(new int[] { 1, 2, 3, 4, 5 }, 2, 10)]
		[TestCase(new int[] { 1, 2, 3, 4, 5 }, 1, 5)]
		public void CombinationCount_FromCollection(int[] elements, int k, int expected)
		{
			// Arrange

			// Act
			int actual = TCombinatorics.Combinations(elements, k);

			// Assert
			Assert.That(actual, Is.EqualTo(expected));
		}

		[Test]
		[TestCase(new int[] { 1, 2, 3, 4, 5 }, 5)]
		[TestCase(new int[] { 1, 2, 3, 4, 5 }, 4)]
		[TestCase(new int[] {1, 2, 3, 4, 5}, 3)]
		[TestCase(new int[] {1, 2, 3, 4, 5}, 2)]
		[TestCase(new int[] {1, 2, 3, 4, 5}, 1)]
		public void GenerateCombinations_LengthShouldBeEqualToFormula(int[] elements, int k)
		{
			// Arrange
			int expected = TCombinatorics.Combinations(elements, k);

			// Act
			int actual = TCombinatorics.GenerateCombinations(elements, k).Count();

			// Assert
			Assert.That(actual, Is.EqualTo(expected));
		}

		[Test]
		public void GenerateCombinations_ShouldHaveCorrectElements()
		{
			// Arrange
			int[] elements = [1, 2, 3, 4, 5];
			int k = 3;
			int[][] expected =
			[
				[1, 2, 3], [1, 2, 4], [1, 2, 5], [1, 3, 4], [1, 3, 5], [1, 4, 5], [2, 3, 4], [2, 3, 5], [2, 4, 5], [3, 4, 5]
			];

			// Act
			var actual = TCombinatorics.GenerateCombinations(elements, k);

			// Assert
			for(int i = 0; i < expected.Length; i++)
			{
				Assert.That(EnumerableAreEqual(actual.ElementAt(i), expected[i]), Is.True);
			}
		}
	}
}
