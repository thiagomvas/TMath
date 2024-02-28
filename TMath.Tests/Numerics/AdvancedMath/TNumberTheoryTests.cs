using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TMath.Numerics.AdvancedMath.NumberTheory;

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
			ulong actual = NumberTheory.GCD(nums);

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
			ulong actual = NumberTheory.LCM(nums);

			//Assert
			Assert.That(actual, Is.EqualTo(expected));
		}
	}
}
