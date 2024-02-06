using System.Numerics;
using TMath.Numerics.Solvers;

namespace TMath.Numerics.AdvancedMath.LinearAlgebra
{
    /// <summary>
    /// Provides a collection of linear algebra operations for matrices.
    /// </summary>
    public static class TLinearAlgebra
    {
        /// <summary>
        /// Computes the determinant of the given square matrix.
        /// </summary>
        /// <typeparam name="T">The numeric type of the matrix elements.</typeparam>
        /// <param name="matrix">The input square matrix.</param>
        /// <returns>The determinant of the matrix.</returns>
        /// <exception cref="ArgumentException">Thrown when the input matrix is not square.</exception>
        /// <remarks>
        /// The method recursively calculates the determinant using the Laplace expansion.
        /// </remarks>
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
            return result;
        }

        /// <summary>
        /// Computes the determinant of the given square matrix.
        /// </summary>
        /// <typeparam name="T">The numeric type of the matrix elements.</typeparam>
        /// <param name="matrix">The input square matrix.</param>
        /// <param name="steps">A list of steps describing the process of determinant calculation.</param>
        /// <returns>The determinant of the matrix.</returns>
        /// <exception cref="ArgumentException">Thrown when the input matrix is not square.</exception>
        /// <remarks>
        /// The method recursively calculates the determinant using the Laplace expansion.
        /// The method also records the steps taken during the decomposition process.
        /// </remarks>
        public static T Determinant<T>(TMatrix<T> matrix, out List<TMatrixStep<T>> steps) where T : INumber<T>
        {
            steps = new List<TMatrixStep<T>>();
            int size = matrix.Rows;
            if (matrix.Rows != matrix.Columns)
                throw new ArgumentException("Matrix must be square", nameof(matrix));
            if (size == 1)
            {
                steps.Add(new TMatrixStep<T>(matrix, "Determinant of a 1x1 matrix is the element itself"));
                return matrix[0, 0];
            }

            T result = T.Zero;

            for (int col = 0; col < size; col++)
            {
                T sign = col % 2 == 0 ? T.One : -T.One;
                TMatrix<T> submatrix = matrix.Submatrix(0, col);
                T subDeterminant = Determinant(submatrix, out List<TMatrixStep<T>> substeps);
                result += matrix[0, col] * sign * subDeterminant;

                steps.Add(new TMatrixStep<T>(new TMatrix<T>(matrix),
                    $"Determinant += {matrix[0, col]} * {sign} * Determinant(Submatrix starting from column {col})"));

                steps.AddRange(substeps);
            }
            return result;
        }

        /// <summary>
        /// Performs LU decomposition on the given square matrix.
        /// </summary>
        /// <typeparam name="T">The numeric type of the matrix elements.</typeparam>
        /// <param name="matrix">The input square matrix.</param>
        /// <param name="U">The upper triangular matrix resulting from the decomposition.</param>
        /// <param name="L">The lower triangular matrix resulting from the decomposition.</param>
        /// <param name="P">The permutation matrix resulting from partial pivoting.</param>
        /// <exception cref="ArgumentException">Thrown when the input matrix is not square.</exception>
        /// <remarks>
        /// LU decomposition factors a square matrix into the product of a lower triangular matrix (L),
        /// an upper triangular matrix (U), and a permutation matrix (P) to facilitate solving linear systems.
        /// </remarks>
        public static void LUDecomposition<T>(TMatrix<T> matrix, out TMatrix<T> U, out TMatrix<T> L, out TMatrix<T> P) where T : INumber<T>
        {

            if (matrix.Rows != matrix.Columns)
                throw new ArgumentException("Matrix must be square", nameof(matrix));

            U = new TMatrix<T>(matrix.Rows, matrix.Columns);

			P = TMatrix<T>.Identity(matrix.Rows);
			L = TMatrix<T>.Identity(matrix.Rows);

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
            while (!TLinearAlgebraSolvers.CheckIfSolved(U.Submatrix(0, 0, U.Rows - 1, U.Rows - 1)) && pivot < matrix.Rows)
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

        /// <summary>
        /// Performs LU decomposition on the given square matrix.
        /// </summary>
        /// <typeparam name="T">The numeric type of the matrix elements.</typeparam>
        /// <param name="matrix">The input square matrix.</param>
        /// <param name="U">The upper triangular matrix resulting from the decomposition.</param>
        /// <param name="L">The lower triangular matrix resulting from the decomposition.</param>
        /// <param name="P">The permutation matrix resulting from partial pivoting.</param>
        /// <param name="steps">A list of steps describing the decomposition process.</param>
        /// <exception cref="ArgumentException">Thrown when the input matrix is not square.</exception>
        /// <remarks>
        /// LU decomposition factors a square matrix into the product of a lower triangular matrix (L),
        /// an upper triangular matrix (U), and a permutation matrix (P) to facilitate solving linear systems.
        /// The method also records the steps taken during the decomposition process.
        /// </remarks>
        public static void LUDecomposition<T>(TMatrix<T> matrix, out TMatrix<T> U, out TMatrix<T> L, out TMatrix<T> P, out List<TMatrixStep<T>> steps) where T : INumber<T>
        {
            steps = new();

            U = new TMatrix<T>(matrix.Rows, matrix.Columns);

            P = TMatrix<T>.Identity(matrix.Rows);
            L = TMatrix<T>.Identity(matrix.Rows);

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
            while (!TLinearAlgebraSolvers.CheckIfSolved(U.Submatrix(0, 0, U.Rows - 1, U.Rows - 1)) && pivot < matrix.Rows)
            {
                if (U[pivot, pivot] == T.Zero)
                {
                    U = U.SwapRows(pivot, pivot + 1);
                    P = P.SwapRows(pivot, pivot + 1);
                    steps.Add(new TMatrixStep<T>(new TMatrix<T>(U), $"Swap rows {pivot} and {pivot + 1}"));
                }

                for (int row = pivot + 1; row < U.Rows; row++)
                {
                    T coef = U[row, pivot] / U[pivot, pivot];
                    L[row, pivot] = coef;

                    steps.Add(new TMatrixStep<T>(new TMatrix<T>(U), 
                        $"l{row} <-- l{row} {(T.IsNegative(coef) ? "+" : "-")} {coef} * l{pivot}"));

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

        /// <summary>
        /// Computes the inverse of the given square and invertible matrix.
        /// </summary>
        /// <typeparam name="T">The numeric type of the matrix elements.</typeparam>
        /// <param name="matrix">The input square and invertible matrix.</param>
        /// <returns>The inverse of the matrix.</returns>
        /// <exception cref="ArgumentException">
        /// Thrown when the input matrix is not square or when it is not invertible (determinant is zero).
        /// </exception>
        /// <remarks>
        /// The method uses the Gauss-Jordan elimination method to find the inverse of the matrix.
        /// </remarks>
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

        // TO-DO: Add Inverse method with steps


        /// <summary>
        /// Computes the row echelon form of the given matrix using LU decomposition.
        /// </summary>
        /// <typeparam name="T">The numeric type of the matrix elements.</typeparam>
        /// <param name="matrix">The input matrix.</param>
        /// <returns>The matrix in row echelon form.</returns>
        public static TMatrix<T> RowEchelon<T>(TMatrix<T> matrix)
            where T : INumber<T>
        {
            LUDecomposition(matrix, out var u, out _, out _);
            return u;
        }

        /// <summary>
        /// Computes the row echelon form of the given matrix using LU decomposition.
        /// </summary>
        /// <typeparam name="T">The numeric type of the matrix elements.</typeparam>
        /// <param name="matrix">The input matrix.</param>
        /// <param name="steps">A list of steps describing the process of row echelon form transformation.</param>
        /// <returns>The matrix in row echelon form.</returns>
        /// <remarks>
        /// The steps parameter records the intermediate steps taken during the transformation.
        /// </remarks>
        public static TMatrix<T> RowEchelon<T>(TMatrix<T> matrix, out List<TMatrixStep<T>> steps)
            where T : INumber<T>
        {
            LUDecomposition(matrix, out var u, out _, out _, out steps);
            return u;
        }

        /// <summary>
        /// Computes the rank of the given matrix.
        /// </summary>
        /// <typeparam name="T">The numeric type of the matrix elements.</typeparam>
        /// <param name="matrix">The input matrix.</param>
        /// <returns>The rank of the matrix.</returns>
        /// <remarks>
        /// The rank is determined by finding the number of non-zero rows in the row echelon form.
        /// </remarks>
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

        /// <summary>
        /// Computes the rank of the given matrix using row echelon form.
        /// </summary>
        /// <typeparam name="T">The numeric type of the matrix elements.</typeparam>
        /// <param name="matrix">The input matrix.</param>
        /// <param name="steps">A list of steps describing the process of computing the rank.</param>
        /// <returns>The rank of the matrix.</returns>
        /// <remarks>
        /// The method uses row echelon form to compute the rank.
        /// The steps parameter records the intermediate steps taken during the computation.
        /// </remarks>
        public static T Rank<T>(TMatrix<T> matrix, out List<TMatrixStep<T>> steps)
    where T : INumber<T>
        {
            TMatrix<T> echelon = RowEchelon(matrix, out var substeps);
            T rank = T.Zero;
            steps = [.. substeps];
            steps.Add(new(new(echelon), "Count all the rows with at least one element different than 0"));
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
