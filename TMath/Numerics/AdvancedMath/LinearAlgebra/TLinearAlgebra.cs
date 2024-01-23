using System.Numerics;
using TMath.Numerics.Solvers;

namespace TMath.Numerics.AdvancedMath.LinearAlgebra
{
    public static class TLinearAlgebra
    {
        public static T Determinant<T>(TMatrix<T> matrix) where T : INumber<T>
        {
            int size = matrix.Rows;
            if (matrix.Rows != matrix.Columns)
                throw new ArgumentException("Matrix must be square", nameof(matrix));
            if (size == 1)
            {
                return matrix[0, 0];
            }

            T result = T.Zero;

            for (int col = 0; col < size; col++)
            {
                T sign = col % 2 == 0 ? T.One : -T.One;
                result += matrix[0, col] * sign * Determinant(matrix.Submatrix(0, col));
            }
            return result; ;
        }

        public static void LUDecomposition<T>(TMatrix<T> matrix, out TMatrix<T> U, out TMatrix<T> L, out TMatrix<T> P) where T : INumber<T>
        {

            if (matrix.Rows != matrix.Columns)
                throw new ArgumentException("Matrix must be square", nameof(matrix));

            U = new TMatrix<T>(matrix.Rows, matrix.Columns);

            L = new TMatrix<T>(matrix.Rows, matrix.Columns);
            P = new TMatrix<T>(matrix.Rows, matrix.Columns);

            for (int i = 0; i < matrix.Rows; i++)
            {
                L[i, i] = T.One;
                P[i, i] = T.One;
                for (int j = 0; j < matrix.Columns; j++)
                {
                    U[i, j] = matrix[i, j];
                }
            }

            int pivot = 0;
            while (!TLinearAlgebraSolvers.CheckIfSolved(U) && pivot < matrix.Rows)
            {
                if (U[pivot, pivot] == T.Zero)
                {
                    U = U.SwapRows(pivot, pivot + 1);
                    P = P.SwapRows(pivot, pivot + 1);
                }

                for (int row = pivot + 1; row < U.Rows; row++)
                {
                    T coef = U[row, pivot] / U[pivot, pivot];
                    L[row, pivot] = coef;
                    for (int col = 0; col < U.Columns; col++)
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
        public static TMatrix<T> Inverse<T>(TMatrix<T> matrix) where T : INumber<T>
        {
            if (matrix.Rows != matrix.Columns)
                throw new ArgumentException("Matrix must be square", nameof(matrix));
            if (Determinant(matrix) == T.Zero)
                throw new ArgumentException("Matrix must be invertible", nameof(matrix));

            int n = matrix.Rows;
            TMatrix<T> result = TMatrix<T>.Identity(n);

            TMatrix<T> tempMatrix = new TMatrix<T>(n, n);

            for (int i = 0; i < matrix.Rows; i++)
            {
                for (int j = 0; j < matrix.Columns; j++)
                {
                    tempMatrix[i, j] = matrix[i, j];
                }
            }


            for (int i = 0; i < n; i++)
            {
                int pivotRow = i;
                for (int j = i + 1; j < n; j++)
                {
                    if (T.Abs(tempMatrix[j, i]) > T.Abs(tempMatrix[pivotRow, i]))
                    {
                        pivotRow = j;
                    }
                }

                if (pivotRow != i)
                {
                    tempMatrix = tempMatrix.SwapRows(i, pivotRow);
                    result = result.SwapRows(i, pivotRow);
                }

                T pivotElement = tempMatrix[i, i];

                for (int j = 0; j < n; j++)
                {
                    tempMatrix[i, j] /= pivotElement;
                    result[i, j] /= pivotElement;
                }

                for (int k = 0; k < n; k++)
                {
                    if (k != i)
                    {
                        T factor = tempMatrix[k, i];

                        for (int j = 0; j < n; j++)
                        {
                            tempMatrix[k, j] -= factor * tempMatrix[i, j];
                            result[k, j] -= factor * result[i, j];
                        }
                    }
                }
            }

            return result;
        }

        public static TMatrix<T> RowEchelon<T>(TMatrix<T> matrix)
            where T : INumber<T>
        {
            LUDecomposition(matrix, out var u, out _, out _);
            return u;
        }

        public static T Rank<T>(TMatrix<T> matrix)
            where T : INumber<T>
        {
            TMatrix<T> echelon = RowEchelon(matrix);
            T rank = T.Zero;

            for (int i = 0; i < echelon.Rows; i++)
            {
                for (int j = 0; j < echelon.Columns; j++)
                {
                    if (echelon[i, j] != T.Zero)
                    {
                        rank++;
                        break;
                    }
                }
            }

            return rank;
        }
    }
}
