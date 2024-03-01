using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TMath.Numerics.AdvancedMath;
using static TMath.Tests.TestUtils;

namespace TMath.Tests.Numerics.AdvancedMath
{
    public class TNumberTheoryTests
	{
		[Test]
		[TestCase(new ulong[] {1, 2, 3}, 1ul)]
		[TestCase(new ulong[] {24, 36, 48, 60}, 12ul)]
		[TestCase(new ulong[] {10941, 5853, 9876}, 3ul)]
		[TestCase(new ulong[] {2, 4, 6, 0}, 2ul)]
		public void GCD(ulong[] nums, ulong expected)
		{
			// Arrange

			// Act
			ulong actual = TNumberTheory.GCD(nums);

			// Assert
			Assert.That(actual, Is.EqualTo(expected));
		}


		[Test]
		[TestCase(new ulong[] {1, 2, 3}, 6ul)]
		[TestCase(new ulong[] {24, 36, 48, 60}, 720ul)]
		[TestCase(new ulong[] {10941, 5857, 9876}, 210956090604ul)]
		[TestCase(new ulong[] {2, 4, 6, 0}, 0ul)]
		public void LCM(ulong[] nums, ulong expected)
		{
			// Arrange

			// Act
			ulong actual = TNumberTheory.LCM(nums);

			//Assert
			Assert.That(actual, Is.EqualTo(expected));
		}

		[Test]
		[TestCase(10ul, new ulong[] {1, 2, 5, 10})]
		[TestCase(12ul, new ulong[] {1, 2, 3, 4, 6, 12})]
		[TestCase(15ul, new ulong[] {1, 3, 5, 15})]
		[TestCase(20ul, new ulong[] {1, 2, 4, 5, 10, 20})]
		[TestCase(2520ul, new ulong[] { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 12, 14, 15, 18, 20, 21, 24, 28, 30, 35, 36, 40, 42, 45, 56, 60, 63, 70, 72, 84, 90, 105, 120, 126, 140, 168, 180, 210, 252, 280, 315, 360, 420, 504, 630, 840, 1260, 2520 })]
		public void Dividers(ulong number, ulong[] expected)
		{
			// Arrange

			// Act
			ulong[] actual = TNumberTheory.Dividers(number).ToArray();

			// Assert
			Assert.That(EnumerableAreEqual(actual, expected), Is.True);
		}

		[Test]
		[TestCase(10ul, 4ul)]
		[TestCase(12ul, 4ul)]
		[TestCase(15ul, 8ul)]
		[TestCase(20ul, 8ul)]
		[TestCase(2520ul, 576ul)]
		public void EulerTotient(ulong number, ulong expected)
		{
			// Arrange

			// Act
			ulong actual = TNumberTheory.EulersTotient(number);

			// Assert
			Assert.That(actual, Is.EqualTo(expected));
		}

		[Test]
		[TestCase(6ul, true)]
		[TestCase(28ul, true)]
		[TestCase(496ul, true)]
		[TestCase(8128ul, true)]
		[TestCase(1ul, false)]
		[TestCase(2ul, false)]
		public void IsPerfectNumber(ulong number, bool expected)
		{
			// Arrange

			// Act
			bool actual = TNumberTheory.IsPerfectNumber(number);

			// Assert
			Assert.That(actual, Is.EqualTo(expected));
		}

		[Test]
		[TestCase(1, new int[] {1})]
		[TestCase(2, new int[] {2, 1})]
		[TestCase(3, new int[] {3, 10, 5, 16, 8, 4, 2, 1})]
		[TestCase(4, new int[] {4, 2, 1})]
		[TestCase(5, new int[] {5, 16, 8, 4, 2, 1})]
		[TestCase(6, new int[] {6, 3, 10, 5, 16, 8, 4, 2, 1})]
		[TestCase(7, new int[] {7, 22, 11, 34, 17, 52, 26, 13, 40, 20, 10, 5, 16, 8, 4, 2, 1})]
		public void CollatzConjecture(int number, int[] expected)
		{
			// Arrange

			// Act
			int[] actual = TNumberTheory.CollatzConjecture(number).ToArray();

			// Assert
			Assert.That(EnumerableAreEqual(actual, expected), Is.True);
		}

		[Test]
		[TestCase(1ul, false)]
		[TestCase(2ul, true)]
		[TestCase(3ul, true)]
		[TestCase(4ul, false)]
		[TestCase(5ul, true)]
		[TestCase(6ul, false)]
		[TestCase(7ul, true)]
		[TestCase(1153ul, true)]
		public void IsPrime(ulong number, bool expected)
		{
			// Arrange

			// Act
			bool actual = TNumberTheory.IsPrime(number);

			// Assert
			Assert.That(actual, Is.EqualTo(expected));
		}

		[Test]
		public void GeneratePrimesUpTo()
		{
			// Arrange
			int[] expected = [ // First 100 primes
				2, 3, 5, 7, 11, 13, 17, 19, 23, 29,
				31, 37, 41, 43, 47, 53, 59, 61, 67, 71,
				73, 79, 83, 89, 97, 101, 103, 107, 109, 113,
				127, 131, 137, 139, 149, 151, 157, 163, 167, 173,
				179, 181, 191, 193, 197, 199, 211, 223, 227, 229,
				233, 239, 241, 251, 257, 263, 269, 271, 277, 281,
				283, 293, 307, 311, 313, 317, 331, 337, 347, 349,
				353, 359, 367, 373, 379, 383, 389, 397, 401, 409,
				419, 421, 431, 433, 439, 443, 449, 457, 461, 463,
				467, 479, 487, 491, 499, 503, 509, 521, 523, 541];

			// Act
			int[] actual = TNumberTheory.GeneratePrimesUpTo(542).ToArray();

			// Assert
			Assert.That(EnumerableAreEqual(actual, expected), Is.True);
		}

	}
}
