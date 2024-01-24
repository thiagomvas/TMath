using TMath.Numerics.AdvancedMath.LinearAlgebra;

namespace TMath.Tests.Numerics.LinearAlgebra
{
    public class TLinearAlgebraTests
	{
		[Test]
		public void PLU_ShouldEqual_OriginalMatrix()
		{
			// Arrange
			TMatrix<double> matrix = new(4, 4, [1,2,3,4,5,6,7,8,9,1,2,3,4,5,6,6]);

			// Act
			TLinearAlgebra.LUDecomposition(matrix, out var u, out var l, out var p);

			// Assert
			Assert.That(p * l * u == matrix, Is.True);
		}

		[Test]
		public void RowEchelon_ShouldEqual_U()
		{
			// Arrange
			TMatrix<double> matrix = new(4, 4, [1,2,3,4,5,6,7,8,9,1,2,3,4,5,6,6]);

			// Act
			TLinearAlgebra.LUDecomposition(matrix, out var u, out _, out _);

			// Assert
			Assert.That(TLinearAlgebra.RowEchelon(matrix) == u, Is.True);
		}

		[Test]
		public void InverseTimesMatrix_ShouldEqual_Identity()
		{
			// Arrange
			TMatrix<double> matrix = new(4, 4, [1,2,3,4,5,6,7,8,9,1,2,3,4,5,6,6]);
			TMatrix<double> inverse = TLinearAlgebra.Inverse(matrix);

			// Act
			TMatrix<double> result = matrix * inverse;
			for(int i = 0; i < result.Rows; i++)
			{
				for(int j = 0; j < result.Columns; j++)
				{
					result[i, j] = TFunctions.Round(result[i, j], 5);
				}
			}

			// Assert
			Assert.That(result == TMatrix<double>.Identity(4), Is.True);
		}
	}
}
