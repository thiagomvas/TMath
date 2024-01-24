﻿using TMath.Numerics.AdvancedMath.LinearAlgebra;

namespace TMath.ConsoleApp
{
    internal class Program
    {
        static void Main(string[] args)
        {
            TMatrix<double> matrix = new(3, 3, [1,2,3,4,5,6,7,8,9]);


            var result = TLinearAlgebra.Rank(matrix, out var steps);

            //Console.WriteLine("========= MATRIX M =========");
            //Console.WriteLine(matrix);
			//Console.WriteLine("========= DETERMINANT =========");
			//Console.WriteLine(TLinearAlgebra.Determinant(matrix));
			//Console.WriteLine("========= RANK =========");
			//Console.WriteLine(TLinearAlgebra.Rank(matrix));
			//Console.WriteLine("========= MATRIX U =========");
            //Console.WriteLine(u);
            //Console.WriteLine("========= MATRIX L =========");
            //Console.WriteLine(l);
            //Console.WriteLine("========= MATRIX P =========");
            //Console.WriteLine(p);
            //Console.WriteLine("========= MATRIX P * L * U = M =========");
            //Console.WriteLine((p * l * u));
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

            foreach(var s in steps)
            {
                Console.WriteLine("=========================");
                Console.WriteLine(s.CurrentState);
                Console.WriteLine(s.NextOperation);
            }
            Console.WriteLine($"Result = {result}");
		}
	}
}
