using NUnit.Framework.Internal;
using TMath.Numerics.LinearAlgebra;

namespace TMath.Tests.Numerics.LinearAlgebra
{
	public class TMatrixTests
	{
		private TMatrix<T> runOperation<T>(TMatrix<T> m, TMatrix<T> n, Func<TMatrix<T>, TMatrix<T>, TMatrix<T>> operation)
			where T : INumber<T>
		{
			return operation(m, n);
		}
		
		[Test]
		[TestCase(new double[] { 1, 2, 3, 4, 5, 6, 7, 8, 9 }, new double[] { 0, 2, 4, 6, 8, 10, 12, 14, 16 }, new double[] { 1, 4, 7, 10, 13, 16, 19, 22, 25 })]
		public void Matrix_Addition_ExpectCorrectResult(double[] m, double[] n, double[] expected)
		{
			// Arrange
			var matrixM = new TMatrix<double>(3, 3, m);
			var matrixN = new TMatrix<double>(3, 3, n);
			var expectedMatrix = new TMatrix<double>(3, 3, expected);

			// Act
			var result = matrixM + matrixN;

			// Assert
			Assert.That(result[0, 0], Is.EqualTo(expectedMatrix[0, 0]));
			Assert.That(result[0, 1], Is.EqualTo(expectedMatrix[0, 1]));
			Assert.That(result[0, 2], Is.EqualTo(expectedMatrix[0, 2]));
			Assert.That(result[1, 0], Is.EqualTo(expectedMatrix[1, 0]));
			Assert.That(result[1, 1], Is.EqualTo(expectedMatrix[1, 1]));
			Assert.That(result[1, 2], Is.EqualTo(expectedMatrix[1, 2]));
			Assert.That(result[2, 0], Is.EqualTo(expectedMatrix[2, 0]));
			Assert.That(result[2, 1], Is.EqualTo(expectedMatrix[2, 1]));
			Assert.That(result[2, 2], Is.EqualTo(expectedMatrix[2, 2]));

		}

		public void Matrix_Addition_ExpectDifferentSizeException()
		{
			// Arrange
			var matrixM = new TMatrix<double>(3, 3);
			var matrixN = new TMatrix<double>(2, 2);

			// Assert
			Assert.Throws<ArgumentException>(() => runOperation(matrixM, matrixN, (m, n) => m + n));
		}

		[Test]
		[TestCase(new double[] { 1, 2, 3, 4, 5, 6, 7, 8, 9 }, new double[] { 0, 2, 4, 6, 8, 10, 12, 14, 16 }, new double[] { 1, 0, -1, -2, -3, -4, -5, -6, -7 })]
		public void Matrix_Subtraction_ExpectCorrectResult(double[] m, double[] n, double[] expected)
		{
			// Arrange
			var matrixM = new TMatrix<double>(3, 3, m);
			var matrixN = new TMatrix<double>(3, 3, n);
			var expectedMatrix = new TMatrix<double>(3, 3, expected);

			// Act
			var result = matrixM - matrixN;

			// Assert
			Assert.That(result[0, 0], Is.EqualTo(expectedMatrix[0, 0]));
			Assert.That(result[0, 1], Is.EqualTo(expectedMatrix[0, 1]));
			Assert.That(result[0, 2], Is.EqualTo(expectedMatrix[0, 2]));
			Assert.That(result[1, 0], Is.EqualTo(expectedMatrix[1, 0]));
			Assert.That(result[1, 1], Is.EqualTo(expectedMatrix[1, 1]));
			Assert.That(result[1, 2], Is.EqualTo(expectedMatrix[1, 2]));
			Assert.That(result[2, 0], Is.EqualTo(expectedMatrix[2, 0]));
			Assert.That(result[2, 1], Is.EqualTo(expectedMatrix[2, 1]));
			Assert.That(result[2, 2], Is.EqualTo(expectedMatrix[2, 2]));

		}

		public void Matrix_Subtraction_ExpectDifferentSizeException()
		{
			// Arrange
			var matrixM = new TMatrix<double>(3, 3);
			var matrixN = new TMatrix<double>(2, 2);

			// Assert
			Assert.Throws<ArgumentException>(() => runOperation(matrixM, matrixN, (m, n) => m - n));
		}

		[Test]
		[TestCase(new double[] { 1, 2, 3, 4, 5, 6, 7, 8, 9 }, 2, new double[] { 2, 4, 6, 8, 10, 12, 14, 16, 18 })]
		public void Matrix_ScalarMultiplication_ExpectCorrectResult(double[] m, double n, double[] expected)
		{
			// Arrange
			var matrixM = new TMatrix<double>(3, 3, m);
			var expectedMatrix = new TMatrix<double>(3, 3, expected);

			// Act
			var result = matrixM * n;

			// Assert
			Assert.That(result[0, 0], Is.EqualTo(expectedMatrix[0, 0]));
			Assert.That(result[0, 1], Is.EqualTo(expectedMatrix[0, 1]));
			Assert.That(result[0, 2], Is.EqualTo(expectedMatrix[0, 2]));
			Assert.That(result[1, 0], Is.EqualTo(expectedMatrix[1, 0]));
			Assert.That(result[1, 1], Is.EqualTo(expectedMatrix[1, 1]));
			Assert.That(result[1, 2], Is.EqualTo(expectedMatrix[1, 2]));
			Assert.That(result[2, 0], Is.EqualTo(expectedMatrix[2, 0]));
			Assert.That(result[2, 1], Is.EqualTo(expectedMatrix[2, 1]));
			Assert.That(result[2, 2], Is.EqualTo(expectedMatrix[2, 2]));

		}

		[Test]
		[TestCase(new double[] { 1, 2, 3, 4, 5, 6, 7, 8, 9 }, 2, new double[] { 0.5, 1, 1.5, 2, 2.5, 3, 3.5, 4, 4.5 })]
		public void Matrix_Division_ExpectCorrectResult(double[] m, double n, double[] expected)
		{
			// Arrange
			var matrixM = new TMatrix<double>(3, 3, m);
			var expectedMatrix = new TMatrix<double>(3, 3, expected);

			// Act
			var result = matrixM / n;

			// Assert
			Assert.That(result[0, 0], Is.EqualTo(expectedMatrix[0, 0]));
			Assert.That(result[0, 1], Is.EqualTo(expectedMatrix[0, 1]));
			Assert.That(result[0, 2], Is.EqualTo(expectedMatrix[0, 2]));
			Assert.That(result[1, 0], Is.EqualTo(expectedMatrix[1, 0]));
			Assert.That(result[1, 1], Is.EqualTo(expectedMatrix[1, 1]));
			Assert.That(result[1, 2], Is.EqualTo(expectedMatrix[1, 2]));
			Assert.That(result[2, 0], Is.EqualTo(expectedMatrix[2, 0]));
			Assert.That(result[2, 1], Is.EqualTo(expectedMatrix[2, 1]));
			Assert.That(result[2, 2], Is.EqualTo(expectedMatrix[2, 2]));

		}

		[Test]
		[TestCase(new double[] { 1, 2, 3, 4, 5, 6, 7, 8, 9 }, new double[] { 0, 2, 4, 6, 8, 10, 12, 14, 16 }, new double[] { 48, 60, 72, 102, 132, 162, 156, 204, 252 })]
		public void Matrix_Multiplication_ExpectCorrectResult(double[] m, double[] n, double[] expected)
		{
			// Arrange
			var matrixM = new TMatrix<double>(3, 3, m);
			var matrixN = new TMatrix<double>(3, 3, n);
			var expectedMatrix = new TMatrix<double>(3, 3, expected);

			// Act
			var result = matrixM * matrixN;

			// Assert
			Assert.That(result[0, 0], Is.EqualTo(expectedMatrix[0, 0]));
			Assert.That(result[0, 1], Is.EqualTo(expectedMatrix[0, 1]));
			Assert.That(result[0, 2], Is.EqualTo(expectedMatrix[0, 2]));
			Assert.That(result[1, 0], Is.EqualTo(expectedMatrix[1, 0]));
			Assert.That(result[1, 1], Is.EqualTo(expectedMatrix[1, 1]));
			Assert.That(result[1, 2], Is.EqualTo(expectedMatrix[1, 2]));
			Assert.That(result[2, 0], Is.EqualTo(expectedMatrix[2, 0]));
			Assert.That(result[2, 1], Is.EqualTo(expectedMatrix[2, 1]));
			Assert.That(result[2, 2], Is.EqualTo(expectedMatrix[2, 2]));

		}

		[Test]
		public void Matrix_Multiplication_ExpectException()
		{
			// Arrange
			var matrixM = new TMatrix<double>(3, 3);
			var matrixN = new TMatrix<double>(2, 2);

			// Assert
			Assert.Throws<ArgumentException>(() => runOperation(matrixM, matrixN, (m, n) => m * n));

		}

		[Test]
		[TestCase(new double[] { 1, 2, 3, 4, 5, 6, 7, 8, 9 }, new double[] { 1, 2, 3, 4, 5, 6, 7, 8, 9 })]
		public void Matrix_Equality_ExpectTrue(double[] m, double[] n)
		{
			// Arrange
			var matrixM = new TMatrix<double>(3, 3, m);
			var matrixN = new TMatrix<double>(3, 3, n);

			// Act
			var result = matrixM == matrixN;

			// Assert
			Assert.That(result, Is.True);
		}

		[Test]
		[TestCase(new double[] { 1, 2, 3, 4, 5, 6, 7, 8, 9 }, new double[] { 0, 2, 4, 6, 8, 10, 12, 14, 16 })]
		public void Matrix_Equality_ExpectFalse(double[] m, double[] n)
		{
			// Arrange
			var matrixM = new TMatrix<double>(3, 3, m);
			var matrixN = new TMatrix<double>(3, 3, n);

			// Act
			var result = matrixM == matrixN;

			// Assert
			Assert.That(result, Is.False);
		}

		[Test]
		[TestCase(new double[] { 1, 2, 3, 4, 5, 6, 7, 8, 9 }, new double[] { 1, 2, 3, 4, 5, 6, 7, 8, 9 })]
		public void Matrix_Inequality_ExpectFalse(double[] m, double[] n)
		{
			// Arrange
			var matrixM = new TMatrix<double>(3, 3, m);
			var matrixN = new TMatrix<double>(3, 3, n);

			// Act
			var result = matrixM != matrixN;

			// Assert
			Assert.That(result, Is.False);
		}
		[Test]
		[TestCase(new double[] { 1, 2, 3, 4, 5, 6, 7, 8, 9 }, new double[] { 0, 2, 4, 6, 8, 10, 12, 14, 16 })]
		public void Matrix_Inequality_ExpectTrue(double[] m, double[] n)
		{
			// Arrange
			var matrixM = new TMatrix<double>(3, 3, m);
			var matrixN = new TMatrix<double>(3, 3, n);

			// Act
			var result = matrixM != matrixN;

			// Assert
			Assert.That(result, Is.True);
		}
		[Test]
		[TestCase(new double[] { 1, 2, 3, 4, 5, 6 }, new double[] { 1, 0, 0, 1})]
		public void Matrix_Identity_2x2(double[] m, double[] expected)
		{
			// Arrange
			var matrixM = new TMatrix<double>(2, 3, m);
			var expectedMatrix = new TMatrix<double>(2, 2, expected);

			// Act
			var result = matrixM.Identity();

			// Assert
			Assert.That(result[0, 0], Is.EqualTo(expectedMatrix[0, 0]));
			Assert.That(result[0, 1], Is.EqualTo(expectedMatrix[0, 1]));
			Assert.That(result[1, 0], Is.EqualTo(expectedMatrix[1, 0]));
			Assert.That(result[1, 1], Is.EqualTo(expectedMatrix[1, 1]));
		}

		[Test]
		[TestCase(new double[] { 1, 2, 3, 4, 5, 6, 7, 8, 9 }, new double[] { 1, 0, 0, 0, 1, 0, 0, 0, 1 })]
		public void Matrix_Identity_3x3(double[] m, double[] expected)
		{
			// Arrange
			var matrixM = new TMatrix<double>(3, 3, m);
			var expectedMatrix = new TMatrix<double>(3, 3, expected);

			// Act
			var result = matrixM.Identity();

			// Assert
			Assert.That(result[0, 0], Is.EqualTo(expectedMatrix[0, 0]));
			Assert.That(result[0, 1], Is.EqualTo(expectedMatrix[0, 1]));
			Assert.That(result[0, 2], Is.EqualTo(expectedMatrix[0, 2]));
			Assert.That(result[1, 0], Is.EqualTo(expectedMatrix[1, 0]));
			Assert.That(result[1, 1], Is.EqualTo(expectedMatrix[1, 1]));
			Assert.That(result[1, 2], Is.EqualTo(expectedMatrix[1, 2]));
			Assert.That(result[2, 0], Is.EqualTo(expectedMatrix[2, 0]));
			Assert.That(result[2, 1], Is.EqualTo(expectedMatrix[2, 1]));
			Assert.That(result[2, 2], Is.EqualTo(expectedMatrix[2, 2]));
		}

		[Test]
		[TestCase(1, 1)]
		[TestCase(2, 2)]
		[TestCase(3, 3)]
		[TestCase(4, 4)]
		[TestCase(5, 5)]

		public void Matrix_IsSquare_ExpectTrue(int row, int column)
		{
			// Arrange
			var matrix = new TMatrix<double>(row, column);

			// Act
			var result = matrix.IsSquareMatrix;

			// Assert
			Assert.That(result, Is.True);
		}

		[Test]
		[TestCase(1, 2)]
		[TestCase(2, 1)]
		[TestCase(3, 2)]
		public void Matrix_IsSquare_ExpectFalse(int row, int column)
		{
			// Arrange
			var matrix = new TMatrix<double>(row, column);

			// Act
			var result = matrix.IsSquareMatrix;

			// Assert
			Assert.That(result, Is.False);
		}

		[Test]
		public void Matrix_ConstructorWithNegSize_ExpectException()
		{
			// Assert
			Assert.Throws<ArgumentException>(() => new TMatrix<double>(-1, -1));
		}

		[Test]
		public void Matrix_ConstructorWithSize0_ExpectException()
		{
			// Assert
			Assert.Throws<ArgumentException>(() => new TMatrix<double>(0, 0));
		}

		[Test]
		[TestCase(new int[] {1, 2, 3, 4, 5, 6, 7, 8, 9}, new int[] {1, 4, 7, 2, 5, 8, 3, 6, 9 })]
		public void Matrix_Transpose(int[] m, int[] expected)
		{
			// Arrange
			var matrixM = new TMatrix<int>(3, 3, m);
			var expectedMatrix = new TMatrix<int>(3, 3, expected);

			// Act
			var result = matrixM.Transpose();

			// Assert
			Assert.That(result[0, 0], Is.EqualTo(expectedMatrix[0, 0]));
			Assert.That(result[0, 1], Is.EqualTo(expectedMatrix[0, 1]));
			Assert.That(result[0, 2], Is.EqualTo(expectedMatrix[0, 2]));
			Assert.That(result[1, 0], Is.EqualTo(expectedMatrix[1, 0]));
			Assert.That(result[1, 1], Is.EqualTo(expectedMatrix[1, 1]));
			Assert.That(result[1, 2], Is.EqualTo(expectedMatrix[1, 2]));
			Assert.That(result[2, 0], Is.EqualTo(expectedMatrix[2, 0]));
			Assert.That(result[2, 1], Is.EqualTo(expectedMatrix[2, 1]));
			Assert.That(result[2, 2], Is.EqualTo(expectedMatrix[2, 2]));
		}
	}
}
