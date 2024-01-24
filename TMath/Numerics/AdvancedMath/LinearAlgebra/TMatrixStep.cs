using System.Numerics;
using TMath.Numerics.Interfaces;

namespace TMath.Numerics.AdvancedMath.LinearAlgebra
{
    public class TMatrixStep<T> : ISolutionStep<TMatrix<T>> where T : INumber<T>
    {
        public TMatrix<T> CurrentState { get; init; }
        public string NextOperation { get; init; }

        public TMatrixStep(TMatrix<T> matrix, string nextOperation)
        {
            CurrentState = matrix;
            NextOperation = nextOperation;
        }
    }
}
