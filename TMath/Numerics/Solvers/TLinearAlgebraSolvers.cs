using System.Numerics;
using TMath.Numerics.AdvancedMath.LinearAlgebra;

namespace TMath.Numerics.Solvers
{
    internal class TLinearAlgebraSolvers
    {
        internal static bool checkIfSolved<T>(T[][] matrix) where T : INumber<T>
        {
            int n = matrix.Length;
            bool solved = true;

            for (int y = 1; y < n; y++)
            {
                for (int x = 0; x < y; x++)
                {
                    if (!matrix[y][x].Equals(T.Zero))
                    {
                        return false;
                    }
                }
            }

            return true;
        }

        internal static bool CheckIfSolved<T>(TMatrix<T> matrix) where T : INumber<T>
        {
            for (int y = 0; y < matrix.Rows; y++)
            {
                for(int x = 0; x < y; x++)
                {
                    if (!matrix[y, x].Equals(T.Zero))
                    {
						return false;
					}
                }
            }

            return true;
        }
    }
}
