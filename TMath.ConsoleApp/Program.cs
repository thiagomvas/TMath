using TMath.Numerics.AdvancedMath;
using TMath.Numerics.LinearAlgebra;
namespace TMath.ConsoleApp
{
    internal class Program
    {
        static void Main(string[] args)
        {
            TMatrix<double> matrix = new(4, 4, [1,2,3,4,5,6,7,8,9,1,2,3,4,5,6,6]);

            TLinearAlgebra.LUDecomposition(matrix, out var u, out var l, out var p);

            Console.WriteLine("========= MATRIX M =========");
            Console.WriteLine(matrix);
			Console.WriteLine("========= DETERMINANT =========");
			Console.WriteLine(TLinearAlgebra.Determinant(matrix));
			Console.WriteLine("========= RANK =========");
			Console.WriteLine(TLinearAlgebra.Rank(matrix));
			Console.WriteLine("========= MATRIX U =========");
            Console.WriteLine(u);
            Console.WriteLine("========= MATRIX L =========");
            Console.WriteLine(l);
            Console.WriteLine("========= MATRIX P =========");
            Console.WriteLine(p);
            Console.WriteLine("========= MATRIX P * L * U = M =========");
            Console.WriteLine(p * l * u);
			Console.WriteLine("========= INVERSE =========");
			Console.WriteLine(TLinearAlgebra.Inverse(matrix));
			Console.WriteLine("========= ROW ECHELON =========");
			Console.WriteLine(TLinearAlgebra.RowEchelon(matrix));
            Console.WriteLine("========= MATRIX A * A^-1 ========="); 
			TMatrix<double> inverse = TLinearAlgebra.Inverse(matrix);
			// Act
			TMatrix<double> result = matrix * inverse;
			for (int i = 0; i < result.Rows; i++)
			{
				for (int j = 0; j < result.Columns; j++)
				{
					result[i, j] = TFunctions.Round(result[i, j], 5);

				}
			}
			Console.WriteLine(result);
		}
	}
}
