using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TMath.Numerics.LinearAlgebra;

namespace TMath.Tests.Numerics.LinearAlgebra
{
	public class TVector2Tests
	{
		[Test]
		[TestCase(new double[] {1, 2}, new double[] {4, 5}, new double[] { 5, 7})]
		[TestCase(new double[] { 0, 0 }, new double[] { 0, 0 }, new double[] { 0, 0 })]
		[TestCase(new double[] { 1, 1 }, new double[] { -1, -1 }, new double[] { 0, 0 })]
		[TestCase(new double[] { -3, -4 }, new double[] { 6, 7 }, new double[] { 3, 3 })]
		[TestCase(new double[] { 0.1, 0.2 }, new double[] { 1, 2 }, new double[] { 1.1, 2.2 })]
		[TestCase(new double[] { 9.876, 2.456 }, new double[] { -0.123, 4.56 }, new double[] { 9.753, 7.016 })]
		public void Vector2_Addition(double[] v1, double[] v2, double[] expected)
		{
			// Arrange
			TVector2<double> vector1 = new TVector2<double>(v1);
			TVector2<double> vector2 = new TVector2<double>(v2);
			TVector2<double> expectedResult = new(expected);

			// Act
			TVector2<double> result = vector1 + vector2;

			// Assert
			Assert.That(result.X, Is.EqualTo(expectedResult.X).Within(0.0001));
			Assert.That(result.Y, Is.EqualTo(expectedResult.Y).Within(0.0001));
		}

		[Test]
		[TestCase(new double[] { 1, 2 }, new double[] { 4, 5 }, false)]
		[TestCase(new double[] { 0, 0 }, new double[] { 0, 0 }, true)]
		[TestCase(new double[] { 1, 1 }, new double[] { -1, -1 }, false)]
		[TestCase(new double[] { -3, -4 }, new double[] { 6, 7 }, false)]
		[TestCase(new double[] { 0.1, 0.2 }, new double[] { 1, 2 }, false)]
		[TestCase(new double[] { 0, 0 }, new double[] {-0, -0}, true )]
		[TestCase(new double[] { 9.876, 2.456 }, new double[] { -0.123, 4.56 }, false)]
		public void Vector2_Equality(double[] v1, double[] v2, bool expected)
		{
			// Arrange
			TVector2<double> vector1 = new TVector2<double>(v1);
			TVector2<double> vector2 = new TVector2<double>(v2);

			// Act
			bool result = vector1 == vector2;

			// Assert
			Assert.That(result, Is.EqualTo(expected));
		}

		[Test]
		[TestCase(new double[] { 1, 2 }, new double[] { 4, 5 }, true)]
		[TestCase(new double[] { 0, 0 }, new double[] { 0, 0 }, false)]
		[TestCase(new double[] { 1, 1 }, new double[] { -1, -1 }, true)]
		[TestCase(new double[] { -3, -4 }, new double[] { 6, 7 }, true)]
		[TestCase(new double[] { 0.1, 0.2 }, new double[] { 1, 2 }, true)]
		[TestCase(new double[] { 0, 0 }, new double[] {-0, -0}, false )]
		[TestCase(new double[] { 9.876, 2.456 }, new double[] { -0.123, 4.56 }, true)]
		public void Vector2_Inequality(double[] v1, double[] v2, bool expected)
		{
			// Arrange
			TVector2<double> vector1 = new TVector2<double>(v1);
			TVector2<double> vector2 = new TVector2<double>(v2);

			// Act
			bool result = vector1 != vector2;

			// Assert
			Assert.That(result, Is.EqualTo(expected));
		}

		[Test]
		[TestCase(new double[] { 1, 2 }, 2.23607)]
		[TestCase(new double[] { 0, 0 }, 0)]
		[TestCase(new double[] { 1, 1 }, 1.41421)]
		[TestCase(new double[] { -3, -4 }, 5)]
		[TestCase(new double[] { 0.1, 0.2 }, 0.22361)]
		[TestCase(new double[] { -0, -0 }, 0)]
		[TestCase(new double[] { 9.876, 2.456 }, 10.1768)]

		public void Vector2_Length(double[] v1, double expected)
		{
			// Arrange
			TVector2<double> vector1 = new TVector2<double>(v1);

			// Act
			double result = vector1.Length;

			// Assert
			Assert.That(result, Is.EqualTo(expected).Within(0.0001));
		}


		[Test]
		[TestCase(new double[] { 1, 2 }, 2, new double[] { 2, 4 })]
		[TestCase(new double[] { 0, 0 }, 0, new double[] { 0, 0 })]
		[TestCase(new double[] { 1, 1 }, -1, new double[] { -1, -1 })]
		[TestCase(new double[] { -3, -4 }, 6, new double[] { -18, -24 })]
		[TestCase(new double[] { 0.1, 0.2 }, 1, new double[] { 0.1, 0.2 })]
		[TestCase(new double[] { 0, 0 }, -0, new double[] { 0, 0 })]
		[TestCase(new double[] { 9.876, 2.456 }, 0.123, new double[] {1.21475, 0.302088})]
		public void Vector2_ScalarMultiplication(double[] v1, double scalar, double[] expected)
		{
			// Arrange
			TVector2<double> vector1 = new TVector2<double>(v1);
			TVector2<double> expectedResult = new(expected);

			// Act
			TVector2<double> result = vector1 * scalar;

			// Assert
			Assert.That(result.X, Is.EqualTo(expectedResult.X).Within(0.0001));
			Assert.That(result.Y, Is.EqualTo(expectedResult.Y).Within(0.0001));
		}

		[Test]
		[TestCase(new double[] { 1, 2 }, 2, new double[] { 0.5, 1 })]
		[TestCase(new double[] { 0, 0 }, 1, new double[] { 0, 0 })]
		[TestCase(new double[] { 1, 1 }, -1, new double[] { -1, -1 })]
		[TestCase(new double[] { -3, -4 }, 6, new double[] { -0.5, -0.66667 })]
		[TestCase(new double[] { 0.1, 0.2 }, 1, new double[] { 0.1, 0.2 })]
		[TestCase(new double[] { 0, 0 }, -1, new double[] { 0, 0 })]
		[TestCase(new double[] { 9.876, 2.456 }, 0.123, new double[] { 80.2927, 19.9675 })]
		public void Vector2_ScalarDivision(double[] v1, double scalar, double[] expected)
		{
			// Arrange
			TVector2<double> vector1 = new TVector2<double>(v1);
			TVector2<double> expectedResult = new(expected);

			// Act
			TVector2<double> result = vector1 / scalar;

			// Assert
			Assert.That(result.X, Is.EqualTo(expectedResult.X).Within(0.0001));
			Assert.That(result.Y, Is.EqualTo(expectedResult.Y).Within(0.0001));
		}

		[Test]
		[TestCase(new double[] {1, 2}, new double[] {3, 4}, 11)]
		[TestCase(new double[] {0, 0}, new double[] {0, 0}, 0)]
		[TestCase(new double[] {1, 1}, new double[] {-1, -1}, -2)]
		[TestCase(new double[] {-3, -4}, new double[] {6, 7}, -46)]
		[TestCase(new double[] {0.1, 0.2}, new double[] {1, 2}, 0.5)]
		[TestCase(new double[] {0, 0}, new double[] {-0, -0}, 0)]
		[TestCase(new double[] {9.876, 2.456}, new double[] {-0.123, 4.56}, 9.984612)]
		public void Vector2_DotProduct(double[] v1, double[] v2, double expected)
		{
			// Arrange
			TVector2<double> vector1 = new TVector2<double>(v1);
			TVector2<double> vector2 = new TVector2<double>(v2);

			// Act
			double result = vector1.DotProduct(vector2);

			// Assert
			Assert.That(result, Is.EqualTo(expected).Within(0.0001));
		}

		[TestCase(new double[] { 1, 2 }, new double[] { 3, 4 }, -2)]
		[TestCase(new double[] { 0, 0 }, new double[] { 0, 0 }, 0)]
		[TestCase(new double[] { 1, 1 }, new double[] { -1, -1 }, 0)]
		[TestCase(new double[] { -3, -4 }, new double[] { 6, 7 }, 3)]
		[TestCase(new double[] { 0.1, 0.2 }, new double[] { 1, 2 }, 0)]
		[TestCase(new double[] { 0, 0 }, new double[] { -0, -0 }, 0)]
		[TestCase(new double[] { 9.876, 2.456 }, new double[] { -0.123, 4.56 }, 45.33664)]
		public void Vector2_CrossProduct(double[] v1, double[] v2, double expected)
		{
			// Arrange
			TVector2<double> vector1 = new TVector2<double>(v1);
			TVector2<double> vector2 = new TVector2<double>(v2);

			// Act
			double result = vector1.CrossProduct(vector2);

			// Assert
			Assert.That(result, Is.EqualTo(expected).Within(0.0001));
		}



		[Test]
		[TestCase(new double[] { 1, 2 }, new double[] { 0.44721, 0.89442 })]
		[TestCase(new double[] { 0, 0 }, new double[] { 0, 0 })]
		[TestCase(new double[] { 1, 1 }, new double[] { 0.70711, 0.70711 })]
		[TestCase(new double[] { -3, -4 }, new double[] { -0.6, -0.8 })]
		[TestCase(new double[] { 0.1, 0.2 }, new double[] { 0.44721, 0.89442 })]
		[TestCase(new double[] { 0, 0 }, new double[] { 0, 0 })]
		[TestCase(new double[] { 9.876, 2.456 }, new double[] { 0.970442, 0.241333 })]
		public void Vector2_Normalize(double[] v1, double[] expected)
		{
			// Arrange
			TVector2<double> vector1 = new TVector2<double>(v1);
			TVector2<double> expectedResult = new(expected);

			// Act
			TVector2<double> result = vector1.Normalize;

			// Assert
			Assert.That(result.X, Is.EqualTo(expectedResult.X).Within(0.0001));
			Assert.That(result.Y, Is.EqualTo(expectedResult.Y).Within(0.0001));
		}
	}
}
