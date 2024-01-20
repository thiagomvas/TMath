using System.Security.Cryptography.X509Certificates;
using TMath.Numerics.AdvancedMath;
using TMath.Numerics.LinearAlgebra;
namespace TMath.ConsoleApp
{
    internal class Program
    {
        static void Main(string[] args)
        {
            TMatrix<int> matrix = new(4, 4, [2, 6, 51, 61, 65, 1, 98, 65, 19, 81, 63, 5, 49, 1, 6, 15]);

            TLinearAlgebra.LUDecomposition(matrix, out var u, out var l, out var p);

            Console.WriteLine("========= MATRIX M =========");
            Console.WriteLine(matrix);
            Console.WriteLine("========= MATRIX U =========");
            Console.WriteLine(u);
            Console.WriteLine("========= MATRIX L =========");
            Console.WriteLine(l);
            Console.WriteLine("========= MATRIX P =========");
            Console.WriteLine(p);
            Console.WriteLine("========= MATRIX P * L * U = M =========");
            Console.WriteLine(p * l * u);
			Console.WriteLine("========= DETERMINANT =========");
            Console.WriteLine(TLinearAlgebra.Determinant(matrix));

		}

    static int CalculateDeterminant(int[,] matrix)
    {
        int size = matrix.GetLength(0);

        if (size != matrix.GetLength(1))
        {
            throw new ArgumentException("Matrix must be square.");
        }

        if (size == 1)
        {
            return matrix[0, 0];
        }

        int result = 0;

        for (int col = 0; col < size; col++)
        {
            result += matrix[0, col] * GetSign(0, col) * CalculateDeterminant(GetSubmatrix(matrix, 0, col));
        }

        return result;
    }

    static int[,] GetSubmatrix(int[,] matrix, int rowToRemove, int colToRemove)
    {
        int size = matrix.GetLength(0);
        int[,] submatrix = new int[size - 1, size - 1];

        int rowIndex = 0;
        for (int i = 0; i < size; i++)
        {
            if (i == rowToRemove)
                continue;

            int colIndex = 0;
            for (int j = 0; j < size; j++)
            {
                if (j == colToRemove)
                    continue;

                submatrix[rowIndex, colIndex] = matrix[i, j];
                colIndex++;
            }

            rowIndex++;
        }

        return submatrix;
    }

    static int GetSign(int row, int col)
    {
        return (row + col) % 2 == 0 ? 1 : -1;
    }
	}
}
