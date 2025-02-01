using System.Numerics;

namespace TMath.Abstractions.Vectors;

/// <summary>
/// Defines operations for vector types.
/// </summary>
/// <typeparam name="TSelf">The type of the vector implementing this interface.</typeparam>
/// <typeparam name="TBase">The base type of the vector elements.</typeparam>
public interface IVectorOperations<TSelf, TBase> where TSelf : IVectorBase<TBase>
{
    /// <summary>
    /// Computes the dot product of this vector and another vector.
    /// </summary>
    /// <param name="other">The other vector.</param>
    /// <param name="sizeDifferenceMode">The mode to handle size differences between vectors.</param>
    /// <returns>The dot product of the two vectors.</returns>
    public TBase Dot(TSelf other,
        VectorSizeDifferenceMode sizeDifferenceMode = VectorSizeDifferenceMode.ThrowIfDifferentSize);

    /// <summary>
    /// Computes the cross product of this vector and another vector.
    /// </summary>
    /// <param name="other">The other vector.</param>
    /// <param name="sizeDifferenceMode">The mode to handle size differences between vectors.</param>
    /// <returns>The cross product of the two vectors.</returns>
    public TSelf Cross(TSelf other,
        VectorSizeDifferenceMode sizeDifferenceMode = VectorSizeDifferenceMode.ThrowIfDifferentSize);

    /// <summary>
    /// Normalizes this vector.
    /// </summary>
    /// <returns>The normalized vector.</returns>
    public TSelf Normalize();
}