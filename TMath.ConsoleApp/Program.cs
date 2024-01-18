
using TMath.Numerics.LinearAlgebra;
namespace TMath.ConsoleApp
{
    internal class Program
    {
        static void Main(string[] args)
		{
			var m = new TMatrix<double>(3, 3, [1, 2, 3, 4, 5, 6, 7, 8, 9]);
			var n = new TMatrix<double>(3, 3, [0, 2, 4, 6, 8, 10, 12, 14, 16]);
			Console.WriteLine("Matrix M:");
			Console.WriteLine(m);
			Console.WriteLine("Matrix N:");
			Console.WriteLine(n);

			Console.WriteLine("=======================================");
			//Console.WriteLine("Matrix M + N:");
			//Console.WriteLine(m + n);
			//Console.WriteLine("Matrix M - N:");
			//Console.WriteLine(m - n);
			//Console.WriteLine("Matrix M * 2:");
			//Console.WriteLine(m * 2);
			//Console.WriteLine("Matrix M / 2:");
			//Console.WriteLine(m / 2);
			//Console.WriteLine("M++");
			//Console.WriteLine(++m);
			//Console.WriteLine("M--");
			//Console.WriteLine(--m);
			//Console.WriteLine("M == N:");
			//Console.WriteLine(m == n);
			//Console.WriteLine("M != N:");
			//Console.WriteLine(m != n);
			//Console.WriteLine("Identity Matrix:");
			//Console.WriteLine(m.Identity());
			//Console.WriteLine("M * N");
			//Console.WriteLine(m * n);
			Console.WriteLine("M Transpose:");
			Console.WriteLine(m.Transpose());


		}
    }
}
