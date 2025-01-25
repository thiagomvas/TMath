using System.Numerics;

namespace TMath.Extensions;

public static class IEnumerableExtensions
{
    /// <summary>
    /// Computes the absolute value of each element in the sequence.
    /// </summary>
    /// <typeparam name="TSource">The numeric type.</typeparam>
    /// <param name="source">The sequence of values.</param>
    /// <returns>A sequence of absolute values.</returns>
    public static IEnumerable<TSource> Abs<TSource>(this IEnumerable<TSource> source) where TSource : INumberBase<TSource>
    {
        return source.Select(MathT.Abs);
    } 
    
    /// <summary>
    /// Computes the floor of each element in the sequence.
    /// </summary>
    /// <typeparam name="TSource">The floating-point numeric type.</typeparam>
    /// <param name="source">The sequence of values.</param>
    /// <returns>A sequence of floored values.</returns>
    public static IEnumerable<TSource> Floor<TSource>(this IEnumerable<TSource> source) where TSource : IFloatingPoint<TSource>
    {
        return source.Select(MathT.Floor);
    }
    
    /// <summary>
    /// Computes the ceiling of each element in the sequence.
    /// </summary>
    /// <typeparam name="TSource">The floating-point numeric type.</typeparam>
    /// <param name="source">The sequence of values.</param>
    /// <returns>A sequence of ceiling values.</returns>
    public static IEnumerable<TSource> Ceiling<TSource>(this IEnumerable<TSource> source) where TSource : IFloatingPoint<TSource>
    {
        return source.Select(MathT.Ceiling);
    }
    
    /// <summary>
    /// Rounds each element in the sequence to the nearest integer.
    /// </summary>
    /// <typeparam name="TSource">The floating-point numeric type.</typeparam>
    /// <param name="source">The sequence of values.</param>
    /// <returns>A sequence of rounded values.</returns>
    public static IEnumerable<TSource> Round<TSource>(this IEnumerable<TSource> source) where TSource : IFloatingPoint<TSource>
    {
        return source.Select(n => MathT.Round(n));
    }
    
    /// <summary>
    /// Rounds each element in the sequence to a specified number of decimal places.
    /// </summary>
    /// <typeparam name="TSource">The floating-point numeric type.</typeparam>
    /// <param name="source">The sequence of values.</param>
    /// <param name="decimals">The number of decimal places.</param>
    /// <returns>A sequence of rounded values.</returns>
    public static IEnumerable<TSource> Round<TSource>(this IEnumerable<TSource> source, int decimals) where TSource : IFloatingPoint<TSource>
    {
        return source.Select(n => MathT.Round(n, decimals));
    }
    
    /// <summary>
    /// Rounds each element in the sequence to the nearest integer, using the specified rounding mode.
    /// </summary>
    /// <typeparam name="TSource">The floating-point numeric type.</typeparam>
    /// <param name="source">The sequence of values.</param>
    /// <param name="mode">The rounding mode to use.</param>
    /// <returns>A sequence of rounded values.</returns>
    public static IEnumerable<TSource> Round<TSource>(this IEnumerable<TSource> source, MidpointRounding mode) where TSource : IFloatingPoint<TSource>
    {
        return source.Select(n => MathT.Round(n, mode));
    }
    
    /// <summary>
    /// Rounds each element in the sequence to a specified number of decimal places, using the specified rounding mode.
    /// </summary>
    /// <typeparam name="TSource">The floating-point numeric type.</typeparam>
    /// <param name="source">The sequence of values.</param>
    /// <param name="decimals">The number of decimal places.</param>
    /// <param name="mode">The rounding mode to use.</param>
    /// <returns>A sequence of rounded values.</returns>
    public static IEnumerable<TSource> Round<TSource>(this IEnumerable<TSource> source, int decimals, MidpointRounding mode) where TSource : IFloatingPoint<TSource>
    {
        return source.Select(n => MathT.Round(n, decimals, mode));
    }
    
    /// <summary>
    /// Truncates each element in the sequence to the nearest integer towards zero.
    /// </summary>
    /// <typeparam name="TSource">The floating-point numeric type.</typeparam>
    /// <param name="source">The sequence of values.</param>
    /// <returns>A sequence of truncated values.</returns>
    public static IEnumerable<TSource> Truncate<TSource>(this IEnumerable<TSource> source) where TSource : IFloatingPoint<TSource>
    {
        return source.Select(MathT.Truncate);
    }
}