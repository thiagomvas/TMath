using System.ComponentModel.DataAnnotations;
using TMath.Numerics.AdvancedMath;
namespace TMath.ConsoleApp
{
    internal class Program
    {
        static void Main(string[] args)
        {
            double[][] matrix = 
            {
                [0, 2, 3, 4],
                [5, 6, 7, 8],
                [9, 1, 2, 3],
                [4, 5, 6, 7]
            };

            TLinearAlgebra.LUDecomposition(matrix, out double[][] L, out double[][] U);

            Console.WriteLine("Matrix: ");
            TLinearAlgebra.PrintMatrix(matrix);
            Console.WriteLine("");
            Console.WriteLine("L: ");
            TLinearAlgebra.PrintMatrix(L);
            Console.WriteLine("");
            Console.WriteLine("U: ");
            TLinearAlgebra.PrintMatrix(U, "0.###");
        }

    }
}
