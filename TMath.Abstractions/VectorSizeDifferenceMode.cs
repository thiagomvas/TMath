using TMath.Abstractions.Vectors;

namespace TMath.Abstractions;

/// <summary>
/// Determines the mode for adding two <see cref="IVector{T}"/>s of different sizes.
/// </summary>
public enum VectorSizeDifferenceMode
{
    /// <summary>
    /// If the vectors are of different sizes, throw an exception.
    /// </summary>
    ThrowIfDifferentSize,
    /// <summary>
    /// If the vectors are of different sizes, fill the missing elements with zeros to the right, preserving the size of the bigger vector.
    /// </summary>
    /// <example>
    /// (1, 2, 3) + (1, 2) = (1, 2, 3) + (1, 2, 0)
    /// </example>
    PadRightWithZeros,
    /// <summary>
    /// If the vectors are of different sizes, fill the missing elements with zeros to the left, preserving the size of the bigger vector.
    /// </summary>
    /// <example>
    /// (1, 2, 3) + (1, 2) = (1, 2, 3) + (0, 1, 2)
    /// </example>
    PadLeftWithZeros,
}