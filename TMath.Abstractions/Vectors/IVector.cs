using System.Numerics;

namespace TMath.Abstractions.Vectors;

/// <summary>
/// Represents a vector interface that combines base vector operations and additional functionalities.
/// </summary>
/// <typeparam name="T">The type of the vector elements.</typeparam>
public interface IVector<T> : IVectorBase<T>, 
    IVectorOperations<IVector<T>, T>,
    IComparable,
    IConvertible,
    IFormattable
    where T : INumberBase<T>
{
}