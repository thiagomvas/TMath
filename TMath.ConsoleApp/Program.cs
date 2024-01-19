using System.ComponentModel.DataAnnotations;
using TMath.Numerics.AdvancedMath;
using TMath.Numerics.LinearAlgebra;
namespace TMath.ConsoleApp
{
    internal class Program
    {
        static void Main(string[] args)
        {
            TMatrix<double> matrix = new(4, 4, [0, 2, 3, 4, 5, 6, 7, 8, 9, 0, 1, 2, 3, 4, 5, 6]);

            TLinearAlgebra.LUDecomposition(matrix, out var u, out var l, out var p);

            Console.WriteLine("========= MATRIX U =========");
            Console.WriteLine(u);
            Console.WriteLine("========= MATRIX L =========");
            Console.WriteLine(l);
            Console.WriteLine("========= MATRIX P =========");
            Console.WriteLine(p);

        }

    }
}
