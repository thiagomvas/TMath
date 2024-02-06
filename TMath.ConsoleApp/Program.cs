using TMath.Numerics.AdvancedMath.LinearAlgebra;
namespace TMath.ConsoleApp
{
    internal class Program
    {
        static void Main(string[] args)
        {
            TMatrix<double> matrix = new(3, 5, [1, 2, -8, 1, -3, 4, -3, 12, 37, -5, 2, 1, 24, -17, 8]);

            TLinearAlgebra.LUDecomposition(matrix, out var u, out var l, out var p, out var steps);


            Console.WriteLine("STEP BY STEP ");

            foreach (var s in steps)
            {
                Console.WriteLine("=========================");
                Console.WriteLine(s.CurrentState);
                Console.WriteLine(s.NextOperation);
            }
            Console.WriteLine(u);
            Console.WriteLine("=========================");

            //Console.Write("\n\n\n");
            Console.WriteLine("========= MATRIX M =========");
            Console.WriteLine(matrix);
            //Console.WriteLine("========= DETERMINANT =========");
            //Console.WriteLine(TLinearAlgebra.Determinant(matrix));
            //Console.WriteLine("========= RANK =========");
            //Console.WriteLine(TLinearAlgebra.Rank(matrix));
            Console.WriteLine("========= MATRIX U =========");
            Console.WriteLine(u);
            Console.WriteLine("========= MATRIX L =========");
            Console.WriteLine(l);
            Console.WriteLine("========= MATRIX P =========");
            Console.WriteLine(p);
            //Console.WriteLine((p * l * u));
            //Console.WriteLine("========= MATRIX P * L * U = M =========");
            //Console.WriteLine("========= INVERSE =========");
            //Console.WriteLine(TLinearAlgebra.Inverse(matrix));
            //Console.WriteLine("========= ROW ECHELON =========");
            //Console.WriteLine(TLinearAlgebra.RowEchelon(matrix));
            //Console.WriteLine("========= MATRIX A * A^-1 =========");
            //Console.WriteLine((matrix * TLinearAlgebra.Inverse(matrix)).RoundValues(5));
            //Console.WriteLine("========= MATRIX IN LATEX =========");
            //Console.WriteLine(matrix.ToLaTeX("vmatrix"));
            //Console.WriteLine("========= SUBMATRIX =========");
            //Console.WriteLine(matrix.Submatrix(1, 1, 3, 2));

        }
    }
}
