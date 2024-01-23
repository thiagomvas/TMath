using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TMath.Numerics.AdvancedMath.LinearAlgebra;

namespace TMath.Tests.Numerics.LinearAlgebra
{
    public class TVector3Tests
	{
		[Test]
		[TestCase(new double[] {1, 2, 3}, new double[] {4, 5, 6}, new double[] { 5, 7, 9})]
		[TestCase(new double[] { 0, 0, 0 }, new double[] { 0, 0, 0 }, new double[] { 0, 0, 0 })]
		[TestCase(new double[] { 1, 1, 1 }, new double[] { -1, -1, -1 }, new double[] { 0, 0, 0 })]
		[TestCase(new double[] { -3, -4, -5 }, new double[] { 6, 7, 8 }, new double[] { 3, 3, 3 })]
		[TestCase(new double[] { 0.1, 0.2, 0.3 }, new double[] { 1, 2, 1 }, new double[] { 1.1, 2.2, 1.3 })]
		[TestCase(new double[] { 9.876, 2.456, 7.123 }, new double[] { -0.123, 4.56, 7.8901 }, new double[] { 9.753, 7.016, 15.0131 })]
		public void Vector3_Addition(double[] v1, double[] v2, double[] expected)
		{
			// Arrange
			TVector3<double> vector1 = new TVector3<double>(v1);
			TVector3<double> vector2 = new TVector3<double>(v2);
			TVector3<double> expectedResult = new(expected);

			// Act
			TVector3<double> result = vector1 + vector2;

			// Assert
			Assert.That(result.X, Is.EqualTo(expectedResult.X).Within(0.0001));
			Assert.That(result.Y, Is.EqualTo(expectedResult.Y).Within(0.0001));
			Assert.That(result.Z, Is.EqualTo(expectedResult.Z).Within(0.0001));
		}

		[Test]
		[TestCase(new double[] { 1, 2, 3 }, new double[] { 4, 5, 6 }, false)]
		[TestCase(new double[] { 0, 0, 0 }, new double[] { 0, 0, 0 }, true)]
		[TestCase(new double[] { 1, 1, 1 }, new double[] { -1, -1, -1 }, false)]
		[TestCase(new double[] { -3, -4, -5 }, new double[] { 6, 7, 8 }, false)]
		[TestCase(new double[] { 0.1, 0.2, 0.3 }, new double[] { 1, 2, 1 }, false)]
		[TestCase(new double[] { 0, 0, 0 }, new double[] {-0, -0, -0}, true )]
		[TestCase(new double[] { 9.876, 2.456, 7.123 }, new double[] { -0.123, 4.56, 7.8901 }, false)]
		public void Vector3_Equality(double[] v1, double[] v2, bool expected)
		{
			// Arrange
			TVector3<double> vector1 = new TVector3<double>(v1);
			TVector3<double> vector2 = new TVector3<double>(v2);

			// Act
			bool result = vector1 == vector2;

			// Assert
			Assert.That(result, Is.EqualTo(expected));
		}

		[Test]
		[TestCase(new double[] { 1, 2, 3 }, new double[] { 4, 5, 6 }, true)]
		[TestCase(new double[] { 0, 0, 0 }, new double[] { 0, 0, 0 }, false)]
		[TestCase(new double[] { 1, 1, 1 }, new double[] { -1, -1, -1 }, true)]
		[TestCase(new double[] { -3, -4, -5 }, new double[] { 6, 7, 8 }, true)]
		[TestCase(new double[] { 0.1, 0.2, 0.3 }, new double[] { 1, 2, 1 }, true)]
		[TestCase(new double[] { 0, 0, 0 }, new double[] { -0, -0, -0 }, false)]
		[TestCase(new double[] { 9.876, 2.456, 7.123 }, new double[] { -0.123, 4.56, 7.8901 }, true)]
		public void Vector3_Inequality(double[] v1, double[] v2, bool expected)
		{
			// Arrange
			TVector3<double> vector1 = new TVector3<double>(v1);
			TVector3<double> vector2 = new TVector3<double>(v2);

			// Act
			bool result = vector1 != vector2;

			// Assert
			Assert.That(result, Is.EqualTo(expected));
		}

		[Test]
		[TestCase(new double[] { 1, 2, 3 }, 3.74165738677394)]
		[TestCase(new double[] { 0, 0, 0 }, 0)]
		[TestCase(new double[] { 1, 1, 1 }, 1.73205080756888)]
		[TestCase(new double[] { -3, -4, -5 }, 7.07106781186548)]
		[TestCase(new double[] { 0.1, 0.2, 0.3 }, 0.374165738677394)]
		[TestCase(new double[] { -0, -0, -0 }, 0)]
		[TestCase(new double[] { 9.876, 2.456, 7.123 }, 12.4219)]

		public void Vector3_Length(double[] v1, double expected)
		{
			// Arrange
			TVector3<double> vector1 = new TVector3<double>(v1);

			// Act
			double result = vector1.Length;

			// Assert
			Assert.That(result, Is.EqualTo(expected).Within(0.0001));
		}

		[Test]
		[TestCase(new double[] { 1, 2, 3 }, 2, new double[] {2, 4, 6})]
		[TestCase(new double[] { 0, 0, 0 }, 0, new double[] { 0, 0, 0 })]
		[TestCase(new double[] { 1, 1, 1 }, 1, new double[] { 1, 1, 1 })]
		[TestCase(new double[] { -3, -4, -5 }, 3, new double[] { -9, -12, -15 })]
		[TestCase(new double[] { 0.1, 0.2, 0.3 }, 0.1, new double[] { 0.01, 0.02, 0.03 })]
		[TestCase(new double[] { -0, -0, -0 }, -0, new double[] { 0, 0, 0 })]
		[TestCase(new double[] { 9.876, -2.456, 7.123 }, -9.876, new double[] {-97.5354, 24.2555, -70.3467})]
		public void Vector3_ScalarMultiplication(double[] v1, double scalar, double[] expected)
		{
			// Arrange
			TVector3<double> vector1 = new TVector3<double>(v1);
			TVector3<double> expectedResult = new(expected);

			// Act
			TVector3<double> result = vector1 * scalar;

			// Assert
			Assert.That(result.X, Is.EqualTo(expectedResult.X).Within(0.0001d)); 
			Assert.That(result.Y, Is.EqualTo(expectedResult.Y).Within(0.0001d)); 
			Assert.That(result.Z, Is.EqualTo(expectedResult.Z).Within(0.0001d)); 
		}



		[Test]
		[TestCase(new double[] { 1, 2, 3 }, 2, new double[] { 0.5, 1, 1.5 })]
		[TestCase(new double[] { 0, 0, 0 }, 10, new double[] { 0, 0, 0 })]
		[TestCase(new double[] { 1, 1, 1 }, 1, new double[] { 1, 1, 1 })]
		[TestCase(new double[] { -3, -4, -5 }, 3, new double[] { -1, -1.33333333333333, -1.66666666666667 })]
		[TestCase(new double[] { 0.1, 0.2, 0.3 }, 0.1, new double[] { 1, 2, 3 })]
		[TestCase(new double[] { -0, -0, -0 }, -1, new double[] { 0, 0, 0 })]
		[TestCase(new double[] { 9.876, -2.456, 7.123 }, -9.876, new double[] { -1, 0.248684, -0.721243 })]
		public void Vector3_ScalarDivision(double[] v1, double scalar, double[] expected)
		{
			// Arrange
			TVector3<double> vector1 = new TVector3<double>(v1);
			TVector3<double> expectedResult = new(expected);

			// Act
			TVector3<double> result = vector1 / scalar;

			// Assert
			Assert.That(result.X, Is.EqualTo(expectedResult.X).Within(0.0001));
			Assert.That(result.Y, Is.EqualTo(expectedResult.Y).Within(0.0001));
			Assert.That(result.Z, Is.EqualTo(expectedResult.Z).Within(0.0001));
		}

		[Test]
		[TestCase(new double[] { 1, 2, 3 }, new double[] { 4, 5, 6 }, 32)]
		[TestCase(new double[] { 0, 0, 0 }, new double[] { 0, 0, 0 }, 0)]
		[TestCase(new double[] { 1, 1, 1 }, new double[] { -1, -1, -1 }, -3)]
		[TestCase(new double[] { -3, -4, -5 }, new double[] { 6, 7, 8 }, -86)]
		[TestCase(new double[] { 0.1, 0.2, 0.3 }, new double[] { 1, 2, 1 }, 0.8)]
		[TestCase(new double[] { 0, 0, 0 }, new double[] { -0, -0, -0 }, 0)]
		[TestCase(new double[] { 9.876, 2.456, 7.123 }, new double[] { -0.123, 4.56, 7.8901 }, 66.1857943)]
		public void Vector3_DotProduct(double[] v1, double[] v2, double expected)
		{
			// Arrange
			TVector3<double> vector1 = new TVector3<double>(v1);
			TVector3<double> vector2 = new TVector3<double>(v2);

			// Act
			double result = vector1.DotProduct(vector2);

			// Assert
			Assert.That(result, Is.EqualTo(expected).Within(0.0001));
		}


		[Test]
		[TestCase(new double[] { 1, 2, 3 }, new double[] { 4, 5, 6 }, new double[] { -3, 6, -3 })]
		[TestCase(new double[] { 0, 0, 0 }, new double[] { 0, 0, 0 }, new double[] { 0, 0, 0 })]
		[TestCase(new double[] { 1, 1, 1 }, new double[] { -1, -1, -1 }, new double[] { 0, 0, 0 })]
		[TestCase(new double[] { -3, -4, -5 }, new double[] { 6, 7, 8 }, new double[] { 3, -6, 3 })]
		[TestCase(new double[] { 0.1, 0.2, 0.3 }, new double[] { 1, 2, 1 }, new double[] { -0.4, 0.2, 0 })]
		[TestCase(new double[] { 0, 0, 0 }, new double[] { -0, -0, -0 }, new double[] { 0, 0, 0 })]
		[TestCase(new double[] { 9.876, 2.456, 7.123 }, new double[] { -0.123, 4.56, 7.8901 }, new double[] { -13.1028, -78.7988, 45.3366 })]
		public void Vector3_CrossProduct(double[] v1, double[] v2, double[] expected)
		{
			// Arrange
			TVector3<double> vector1 = new TVector3<double>(v1);
			TVector3<double> vector2 = new TVector3<double>(v2);
			TVector3<double> expectedResult = new(expected);

			// Act
			TVector3<double> result = vector1.CrossProduct(vector2);

			// Assert
			Assert.That(result.X, Is.EqualTo(expectedResult.X).Within(0.0001));
			Assert.That(result.Y, Is.EqualTo(expectedResult.Y).Within(0.0001));
			Assert.That(result.Z, Is.EqualTo(expectedResult.Z).Within(0.0001));
		}

		[Test]
		[TestCase(new double[] { 1, 2, 3 }, new double[] { 0.267261241912424, 0.534522483824849, 0.801783725737273 })]
		[TestCase(new double[] { 0, 0, 0 }, new double[] { 0, 0, 0 })]
		[TestCase(new double[] { 1, 1, 1 }, new double[] { 0.577350269189626, 0.577350269189626, 0.577350269189626 })]
		[TestCase(new double[] { -3, -4, -5 }, new double[] { -0.424264068711929, -0.565685424949238, -0.707106781186547 })]
		[TestCase(new double[] { 0.1, 0.2, 0.3 }, new double[] { 0.267261241912424, 0.534522483824849, 0.801783725737273 })]
		[TestCase(new double[] { 0, 0, 0 }, new double[] { 0, 0, 0 })]
		[TestCase(new double[] { 9.876, 2.456, 7.123 }, new double[] { 0.795045, 0.197715, 0.573421 })]
		public void Vector3_Normalize(double[] v1, double[] expected)
		{
			// Arrange
			TVector3<double> vector1 = new TVector3<double>(v1);
			TVector3<double> expectedResult = new(expected);

			// Act
			TVector3<double> result = vector1.Normalize;

			// Assert
			Assert.That(result.X, Is.EqualTo(expectedResult.X).Within(0.0001));
			Assert.That(result.Y, Is.EqualTo(expectedResult.Y).Within(0.0001));
			Assert.That(result.Z, Is.EqualTo(expectedResult.Z).Within(0.0001));
		}
	}
}
