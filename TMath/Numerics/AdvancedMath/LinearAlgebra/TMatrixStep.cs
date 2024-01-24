using System.Numerics;
using TMath.Numerics.Interfaces;

namespace TMath.Numerics.AdvancedMath.LinearAlgebra
{
    /// <summary>
    /// Represents a step in a solution process for a matrix operation.
    /// </summary>
    /// <typeparam name="T">The numeric type of the matrix elements.</typeparam>
    /// <param name="matrix">The current state of the matrix at this step.</param>
    /// <param name="nextOperation">The description of the next operation to be performed.</param>
    public class TMatrixStep<T>(TMatrix<T> matrix, string nextOperation) : ISolutionStep<TMatrix<T>> where T : INumber<T>
    {
        /// <summary>
        /// Gets the current state of the matrix at this step.
        /// </summary>
        public TMatrix<T> CurrentState { get; init; } = matrix;

        /// <summary>
        /// Gets the description of the next operation to be performed.
        /// </summary>
        public string NextOperation { get; init; } = nextOperation;
    }
}
