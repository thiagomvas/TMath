
using TMath.Numerics.AdvancedMath.LinearAlgebra;

namespace TMath.Tests.Numerics.LinearAlgebra
{
	public class TVectorTests
	{

		[Test]
		[TestCase(new double[] {1, 2, 3, 4, 5}, new double[] {2, 4, 6, 8, 10}, new double[] {3, 6, 9, 12, 15})]
		[TestCase(new double[] {0, 0, 0, 0, 0}, new double[] {2, 4, 6, 8, 10}, new double[] {2, 4, 6, 8, 10})]
		public void Vector_Adition(double[] v1, double[] v2, double[] expected)
		{
			// Arrange
			var vector1 = new TVector<double>(v1);
			var vector2 = new TVector<double>(v2);
			var expectedVector = new TVector<double>(expected);

			// Act
			var result = vector1 + vector2;

			// Assert
			Assert.That(result[0], Is.EqualTo(expectedVector[0]));
			Assert.That(result[1], Is.EqualTo(expectedVector[1]));
			Assert.That(result[2], Is.EqualTo(expectedVector[2]));
			Assert.That(result[3], Is.EqualTo(expectedVector[3]));
			Assert.That(result[4], Is.EqualTo(expectedVector[4]));
		}

		[Test]
		[TestCase(new double[] {1, 2, 3, 4, 5}, new double[] {2, 4, 6, 8, 10}, new double[] {-1, -2, -3, -4, -5})]
		[TestCase(new double[] {0, 0, 0, 0, 0}, new double[] {2, 4, 6, 8, 10}, new double[] {-2, -4, -6, -8, -10})]
		public void Vector_Subtraction(double[] v1, double[] v2, double[] expected)
		{
			// Arrange
			var vector1 = new TVector<double>(v1);
			var vector2 = new TVector<double>(v2);
			var expectedVector = new TVector<double>(expected);

			// Act
			var result = vector1 - vector2;

			// Assert
			Assert.That(result[0], Is.EqualTo(expectedVector[0]));
			Assert.That(result[1], Is.EqualTo(expectedVector[1]));
			Assert.That(result[2], Is.EqualTo(expectedVector[2]));
			Assert.That(result[3], Is.EqualTo(expectedVector[3]));
			Assert.That(result[4], Is.EqualTo(expectedVector[4]));
		}

		[Test]
		[TestCase(new double[] {1, 2, 3, 4, 5}, 2, new double[] {2, 4, 6, 8, 10})]
		[TestCase(new double[] {0, 0, 0, 0, 0}, 2, new double[] {0, 0, 0, 0, 0})]
		public void Vector_Multiplication(double[] v1, double scalar, double[] expected)
		{
			// Arrange
			var vector1 = new TVector<double>(v1);
			var expectedVector = new TVector<double>(expected);

			// Act
			var result = vector1 * scalar;

			// Assert
			Assert.That(result[0], Is.EqualTo(expectedVector[0]));
			Assert.That(result[1], Is.EqualTo(expectedVector[1]));
			Assert.That(result[2], Is.EqualTo(expectedVector[2]));
			Assert.That(result[3], Is.EqualTo(expectedVector[3]));
			Assert.That(result[4], Is.EqualTo(expectedVector[4]));
		}

		[Test]
		[TestCase(new double[] {1, 2, 3, 4, 5}, 2, new double[] {0.5, 1, 1.5, 2, 2.5})]
		[TestCase(new double[] {0, 0, 0, 0, 0}, 2, new double[] {0, 0, 0, 0, 0})]
		public void Vector_Division(double[] v1, double scalar, double[] expected)
		{
			// Arrange
			var vector1 = new TVector<double>(v1);
			var expectedVector = new TVector<double>(expected);

			// Act
			var result = vector1 / scalar;

			// Assert
			Assert.That(result[0], Is.EqualTo(expectedVector[0]));
			Assert.That(result[1], Is.EqualTo(expectedVector[1]));
			Assert.That(result[2], Is.EqualTo(expectedVector[2]));
			Assert.That(result[3], Is.EqualTo(expectedVector[3]));
			Assert.That(result[4], Is.EqualTo(expectedVector[4]));
		}

		[Test]
		[TestCase(new double[] {1, 2, 3, 4, 5}, new double[] {1, 2, 3, 4, 5}, true)]
		[TestCase(new double[] {0, 0, 0, 0, 0}, new double[] {1, 2, 3, 4, 5}, false)]
		public void Vector_Equality(double[] v1, double[] v2, bool expected)
		{
			// Arrange
			var vector1 = new TVector<double>(v1);
			var vector2 = new TVector<double>(v2);

			// Act
			var result = vector1 == vector2;

			// Assert
			Assert.That(result, Is.EqualTo(expected));
		}

		[Test]
		[TestCase(new double[] {1, 2, 3, 4, 5}, new double[] {1, 2, 3, 4, 5}, false)]
		[TestCase(new double[] {0, 0, 0, 0, 0}, new double[] {1, 2, 3, 4, 5}, true)]
		public void Vector_Inequality(double[] v1, double[] v2, bool expected)
		{
			// Arrange
			var vector1 = new TVector<double>(v1);
			var vector2 = new TVector<double>(v2);

			// Act
			var result = vector1 != vector2;

			// Assert
			Assert.That(result, Is.EqualTo(expected));
		}

		[Test]
		public void Vector_Constructor_ExpectException()
		{
			Assert.Throws<ArgumentException>(() => new TVector<double>(-1)); 
		}


		[Test]
		[TestCase(new double[] { 1, 2, 3, 4, 5 }, 7.4162)]
		[TestCase(new double[] { 0, 0, 0, 0, 0 }, 0)]
		[TestCase(new double[] { 0, 0, 0, 0, 1 }, 1)]
		public void Vector_Length(double[] v, double expected)
		{
			// Arrange
			var vector = new TVector<double>(v);

			// Act
			var result = vector.Length;

			// Assert
			Assert.That(result, Is.EqualTo(expected).Within(0.0001));
		}
	}
}
