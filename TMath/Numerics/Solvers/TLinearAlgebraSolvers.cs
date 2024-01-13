using System.Numerics;

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
                        solved = false;
                        break;
                    }
                }
            }

            return solved;
        }
    }
}
