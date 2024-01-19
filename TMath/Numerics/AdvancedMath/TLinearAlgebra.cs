using System.Numerics;
using TMath.Numerics.LinearAlgebra;
using TMath.Numerics.Solvers;

namespace TMath.Numerics.AdvancedMath
{
    public static class TLinearAlgebra
	{
		public static void LUDecomposition<T>(TMatrix<T> matrix, out TMatrix<T> L, out TMatrix<T> U)
			where T : INumber<T>
		{
			if (matrix.Rows != matrix.Columns)
				throw new ArgumentException("Matrix must be square", nameof(matrix));

			int n = matrix.Rows;
			L = new TMatrix<T>(n, n);
			U = new TMatrix<T>(n, n);
			var P = new TMatrix<T>(n, n);
			for (int i = 0; i < n; i++)
			{
                L[i, i] = T.One;
				P[i,i] = T.One;

				for (int j = 0; j < n; j++)
				{
					U[i,j] = matrix[i,j];
				}
			}

			for (int i = 0; i < n - 1; i++)
			{
				if (TLinearAlgebraSolvers.CheckIfSolved(U))
					break;

				if (U[i,i] == T.Zero)
				{
					U = U.SwapRows(i, i + 1);
				}

				for (int row = i + 1; row < n; row++)
				{
					T coef = -U[row, i] / U[i, i];
					L[row, i] = -coef;

					for (int column = i; column < n; column++)
					{
						U[row, column] = coef != T.Zero ? U[row, column] + coef * U[i, column] : T.Zero;
					}
				}
			}
		}


		public static void LUDecomposition<T>(T[][] matrix, out T[][] L, out T[][] U)
            where T : INumber<T>
        {
            if (matrix.Length != matrix[0].Length)
                throw new ArgumentException("Matrix must be square", nameof(matrix));

            int n = matrix.Length;
            L = new T[n][];
            U = new T[n][];
            T[][] P = new T[n][];
            for (int i = 0; i < n; i++)
            {
                L[i] = new T[n];
                U[i] = new T[n];
                P[i] = new T[n];
                L[i][i] = T.One;
                P[i][i] = T.One;

                for (int j = 0; j < n; j++)
                {
                    U[i][j] = matrix[i][j];
                }
            }

            for (int i = 0; i < n - 1; i++)
            {
                if (TLinearAlgebraSolvers.checkIfSolved(U))
                    break;
                if (U[i][i].Equals(T.Zero))
                {
                    (U[i], U[i + 1]) = (U[i + 1], U[i]);
					Console.WriteLine("Swap");
                }    

                for (int row = i + 1; row < n; row++)
                {
                    T coef = -U[row][i] / U[i][i];
                    L[row][i] = -coef;

                    for (int column = i; column < n; column++)
                    {
                        U[row][column] = coef != T.Zero ? U[row][column] + coef * U[i][column] : T.Zero;
                    }
                }
            }
        }
        public static void PrintMatrix<T>(T[][] matrix, string? format = null)
        {
            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                for (int j = 0; j < matrix[i].Length; j++)
                {
                    if(i == j) Console.ForegroundColor = ConsoleColor.Green;
                    string formatted = string.Format($"{{0:{format}}}", matrix[i][j]) ?? matrix[i][j].ToString();
                    Console.Write($"{formatted}\t");
                    if (i == j) Console.ResetColor();
                }
                Console.WriteLine();
            }
        }

		public static void LUDecomposition<T>(TMatrix<T> matrix, out TMatrix<T> U, out TMatrix<T> L, out TMatrix<T> P) where T : INumber<T>
		{

			if (matrix.Rows != matrix.Columns)
				throw new ArgumentException("Matrix must be square", nameof(matrix));

			U = new TMatrix<T>(matrix.Rows, matrix.Columns);

			L = new TMatrix<T>(matrix.Rows, matrix.Columns);
			P = new TMatrix<T>(matrix.Rows, matrix.Columns);

			for(int i = 0; i < matrix.Rows; i++)
			{
				L[i, i] = T.One;
				P[i, i] = T.One;
				for(int j = 0; j < matrix.Columns; j++)
				{
					U[i, j] = matrix[i, j];
				}
			}

			int pivot = 0;
			while(!TLinearAlgebraSolvers.CheckIfSolved(U) && pivot < matrix.Rows)
			{
				if (U[pivot, pivot] == T.Zero)
				{
					U = U.SwapRows(pivot, pivot + 1);
					P = P.SwapRows(pivot, pivot + 1);
					Console.WriteLine("Swap");
				}

				for(int row = pivot + 1; row < U.Rows; row++)
				{
					T coef = U[row, pivot] / U[pivot, pivot];
					for(int col = 0; col < U.Columns; col++)
					{
						U[row, col] = U[row, col] - coef * U[pivot, col];
						if (U[row, col] < TConstants<T>.Nano && U[row, col] > -TConstants<T>.Nano)
						{
							U[row, col] = T.Zero;
						}
					}
				}
				pivot++;
			}
		}
    }
}
