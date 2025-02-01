using System.Numerics;

namespace TMath.Abstractions.Vectors;

/// <summary>
/// Represents a base interface for vector types.
/// </summary>
/// <typeparam name="T">The type of the vector elements.</typeparam>
public interface IVectorBase<T> : IEnumerable<T>
{
    /// <summary>
    /// Gets the length of the vector.
    /// </summary>
    int Length { get; }

    /// <summary>
    /// Gets the magnitude of the vector.
    /// </summary>
    T Magnitude { get; }

    /// <summary>
    /// Gets or sets the element at the specified index.
    /// </summary>
    /// <param name="index">The index of the element.</param>
    /// <returns>The element at the specified index.</returns>
    T this[int index] { get; set; }
}