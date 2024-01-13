using System.Numerics;

namespace TMath.Numerics.AdvancedMath
{
    public static class TLinearAlgebra
    {
        private static bool checkIfSolved<T>(T[][] matrix) where T : INumber<T>
        {
            int n = matrix.Length;
            bool solved = true;

            for (int y = 1; y < n; y++)
            {
                for (int x = 0; x < y; x++)
                {
                    if (!matrix[y][x].Equals(T.Zero))
                    {
                        solved = false;
                        break;
                    }
                }
            }

            return solved;
        }

        // TO-DO: Fix for pivot = 0;
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
                if (checkIfSolved(U))
                    break;
                if (U[i][i].Equals(T.Zero))
                {
                    (U[i], U[i + 1]) = (U[i + 1], U[i]);
                }    

                for (int row = i + 1; row < n; row++)
                {
                    T coef = -U[row][i] / U[i][i];
                    L[row][i] = -coef;

                    for (int column = i; column < n; column++)
                    {
                        U[row][column] = TFunctions.Round(U[row][column] + coef * U[i][column], 10);
                    }
                }
            }
        }
    }
}
