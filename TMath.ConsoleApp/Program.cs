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
            Print2DArray(matrix);
            Console.WriteLine("");
            Console.WriteLine("L: ");
            Print2DArray(L);
            Console.WriteLine("");
            Console.WriteLine("U: ");
            Print2DArray(U);
        }

        public static void Print2DArray<T>(T[][] matrix)
        {
            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                for (int j = 0; j < matrix[i].Length; j++)
                {
                    Console.Write(matrix[i][j] + "\t");
                }
                Console.WriteLine();
            }
        }
    }
}
