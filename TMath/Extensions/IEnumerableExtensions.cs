using System.Numerics;

namespace TMath.Extensions;

public static class IEnumerableExtensions
{
    #region Rounding

    /// <summary>
    /// Computes the absolute value of each element in the sequence.
    /// </summary>
    /// <typeparam name="TSource">The numeric type.</typeparam>
    /// <param name="source">The sequence of values.</param>
    /// <returns>A sequence of absolute values.</returns>
    public static IEnumerable<TSource> Abs<TSource>(this IEnumerable<TSource> source)
        where TSource : INumberBase<TSource>
    {
        ArgumentNullException.ThrowIfNull(source);
        return source.Select(MathT.Abs);
    }

    /// <summary>
    /// Computes the floor of each element in the sequence.
    /// </summary>
    /// <typeparam name="TSource">The floating-point numeric type.</typeparam>
    /// <param name="source">The sequence of values.</param>
    /// <returns>A sequence of floored values.</returns>
    public static IEnumerable<TSource> Floor<TSource>(this IEnumerable<TSource> source)
        where TSource : IFloatingPoint<TSource>
    {
        ArgumentNullException.ThrowIfNull(source);
        return source.Select(MathT.Floor);
    }

    /// <summary>
    /// Computes the ceiling of each element in the sequence.
    /// </summary>
    /// <typeparam name="TSource">The floating-point numeric type.</typeparam>
    /// <param name="source">The sequence of values.</param>
    /// <returns>A sequence of ceiling values.</returns>
    public static IEnumerable<TSource> Ceiling<TSource>(this IEnumerable<TSource> source)
        where TSource : IFloatingPoint<TSource>
    {
        ArgumentNullException.ThrowIfNull(source);
        return source.Select(MathT.Ceiling);
    }

    /// <summary>
    /// Rounds each element in the sequence to the nearest integer.
    /// </summary>
    /// <typeparam name="TSource">The floating-point numeric type.</typeparam>
    /// <param name="source">The sequence of values.</param>
    /// <returns>A sequence of rounded values.</returns>
    public static IEnumerable<TSource> Round<TSource>(this IEnumerable<TSource> source)
        where TSource : IFloatingPoint<TSource>
    {
        ArgumentNullException.ThrowIfNull(source);
        return source.Select(n => MathT.Round(n));
    }

    /// <summary>
    /// Rounds each element in the sequence to a specified number of decimal places.
    /// </summary>
    /// <typeparam name="TSource">The floating-point numeric type.</typeparam>
    /// <param name="source">The sequence of values.</param>
    /// <param name="decimals">The number of decimal places.</param>
    /// <returns>A sequence of rounded values.</returns>
    public static IEnumerable<TSource> Round<TSource>(this IEnumerable<TSource> source, int decimals)
        where TSource : IFloatingPoint<TSource>
    {
        ArgumentNullException.ThrowIfNull(source);
        return source.Select(n => MathT.Round(n, decimals));
    }

    /// <summary>
    /// Rounds each element in the sequence to the nearest integer, using the specified rounding mode.
    /// </summary>
    /// <typeparam name="TSource">The floating-point numeric type.</typeparam>
    /// <param name="source">The sequence of values.</param>
    /// <param name="mode">The rounding mode to use.</param>
    /// <returns>A sequence of rounded values.</returns>
    public static IEnumerable<TSource> Round<TSource>(this IEnumerable<TSource> source, MidpointRounding mode)
        where TSource : IFloatingPoint<TSource>
    {
        ArgumentNullException.ThrowIfNull(source);
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
    public static IEnumerable<TSource> Round<TSource>(this IEnumerable<TSource> source, int decimals,
        MidpointRounding mode) where TSource : IFloatingPoint<TSource>
    {
        ArgumentNullException.ThrowIfNull(source);
        return source.Select(n => MathT.Round(n, decimals, mode));
    }

    /// <summary>
    /// Truncates each element in the sequence to the nearest integer towards zero.
    /// </summary>
    /// <typeparam name="TSource">The floating-point numeric type.</typeparam>
    /// <param name="source">The sequence of values.</param>
    /// <returns>A sequence of truncated values.</returns>
    public static IEnumerable<TSource> Truncate<TSource>(this IEnumerable<TSource> source)
        where TSource : IFloatingPoint<TSource>
    {
        ArgumentNullException.ThrowIfNull(source);
        return source.Select(MathT.Truncate);
    }


    /// <summary>
    /// Clamps each value in the sequence to be within a specified range.
    /// </summary>
    /// <typeparam name="TSource">The numeric type.</typeparam>
    /// <param name="source">The sequence of values to clamp.</param>
    /// <param name="min">The minimum value of the range.</param>
    /// <param name="max">The maximum value of the range.</param>
    /// <returns>A sequence of clamped values.</returns>
    /// <exception cref="ArgumentNullException"><paramref name="source"/> is <see langword="null"/>.</exception>
    public static IEnumerable<TSource> Clamp<TSource>(this IEnumerable<TSource> source, TSource min, TSource max)
        where TSource : INumberBase<TSource>, IComparisonOperators<TSource, TSource, bool>
    {
        ArgumentNullException.ThrowIfNull(source);

        return source.Select(value => MathT.Clamp(value, min, max));
    }

    /// <summary>
    /// Computes the minimum value between each element in the sequence and a specified value.
    /// </summary>
    /// <typeparam name="TSource">The numeric type.</typeparam>
    /// <param name="source">The sequence of values.</param>
    /// <param name="value">The value to compare against.</param>
    /// <returns>A sequence of minimum values.</returns>
    public static IEnumerable<TSource> Min<TSource>(this IEnumerable<TSource> source, TSource value)
        where TSource : INumberBase<TSource>, IComparisonOperators<TSource, TSource, bool>
    {
        ArgumentNullException.ThrowIfNull(source);
        return source.Select(n => MathT.Min(n, value));
    }

    /// <summary>
    /// Computes the maximum value between each element in the sequence and a specified value.
    /// </summary>
    /// <typeparam name="TSource">The numeric type.</typeparam>
    /// <param name="source">The sequence of values.</param>
    /// <param name="value">The value to compare against.</param>
    /// <returns>A sequence of maximum values.</returns>
    public static IEnumerable<TSource> Max<TSource>(this IEnumerable<TSource> source, TSource value)
        where TSource : INumberBase<TSource>, IComparisonOperators<TSource, TSource, bool>
    {
        ArgumentNullException.ThrowIfNull(source);
        return source.Select(n => MathT.Max(n, value));
    }

    #endregion

    #region Trigonometry

    /// <summary>
    /// Computes the sine of each angle in the sequence, specified in radians.
    /// </summary>
    /// <typeparam name="TSource">The numeric type.</typeparam>
    /// <param name="source">The sequence of angles in radians.</param>
    /// <returns>A sequence of sine values.</returns>
    /// <exception cref="ArgumentNullException"><paramref name="source"/> is <see langword="null"/>.</exception>
    public static IEnumerable<TSource> Sin<TSource>(this IEnumerable<TSource> source)
        where TSource : ITrigonometricFunctions<TSource>
    {
        ArgumentNullException.ThrowIfNull(source);
        return source.Select(TSource.Sin);
    }

    /// <summary>
    /// Computes the sine of each angle in the sequence, specified in degrees.
    /// </summary>
    /// <typeparam name="TSource">The numeric type.</typeparam>
    /// <param name="source">The sequence of angles in degrees.</param>
    /// <returns>A sequence of sine values.</returns>
    /// <exception cref="ArgumentNullException"><paramref name="source"/> is <see langword="null"/>.</exception>
    public static IEnumerable<TSource> SinDeg<TSource>(this IEnumerable<TSource> source)
        where TSource : INumberBase<TSource>, ITrigonometricFunctions<TSource>
    {
        ArgumentNullException.ThrowIfNull(source);
        return source.Select(MathT.SinDeg);
    }

    /// <summary>
    /// Computes the cosine of each angle in the sequence, specified in radians.
    /// </summary>
    /// <typeparam name="TSource">The numeric type.</typeparam>
    /// <param name="source">The sequence of angles in radians.</param>
    /// <returns>A sequence of cosine values.</returns>
    /// <exception cref="ArgumentNullException"><paramref name="source"/> is <see langword="null"/>.</exception>
    public static IEnumerable<TSource> Cos<TSource>(this IEnumerable<TSource> source)
        where TSource : ITrigonometricFunctions<TSource>
    {
        ArgumentNullException.ThrowIfNull(source);
        return source.Select(TSource.Cos);
    }

    /// <summary>
    /// Computes the cosine of each angle in the sequence, specified in degrees.
    /// </summary>
    /// <typeparam name="TSource">The numeric type.</typeparam>
    /// <param name="source">The sequence of angles in degrees.</param>
    /// <returns>A sequence of cosine values.</returns>
    /// <exception cref="ArgumentNullException"><paramref name="source"/> is <see langword="null"/>.</exception>
    public static IEnumerable<TSource> CosDeg<TSource>(this IEnumerable<TSource> source)
        where TSource : INumberBase<TSource>, ITrigonometricFunctions<TSource>
    {
        ArgumentNullException.ThrowIfNull(source);
        return source.Select(MathT.CosDeg);
    }

    /// <summary>
    /// Computes the tangent of each angle in the sequence, specified in radians.
    /// </summary>
    /// <typeparam name="TSource">The numeric type.</typeparam>
    /// <param name="source">The sequence of angles in radians.</param>
    /// <returns>A sequence of tangent values.</returns>
    /// <exception cref="ArgumentNullException"><paramref name="source"/> is <see langword="null"/>.</exception>
    public static IEnumerable<TSource> Tan<TSource>(this IEnumerable<TSource> source)
        where TSource : ITrigonometricFunctions<TSource>
    {
        ArgumentNullException.ThrowIfNull(source);
        return source.Select(TSource.Tan);
    }

    /// <summary>
    /// Computes the tangent of each angle in the sequence, specified in degrees.
    /// </summary>
    /// <typeparam name="TSource">The numeric type.</typeparam>
    /// <param name="source">The sequence of angles in degrees.</param>
    /// <returns>A sequence of tangent values.</returns>
    /// <exception cref="ArgumentNullException"><paramref name="source"/> is <see langword="null"/>.</exception>
    public static IEnumerable<TSource> TanDeg<TSource>(this IEnumerable<TSource> source)
        where TSource : INumberBase<TSource>, ITrigonometricFunctions<TSource>
    {
        ArgumentNullException.ThrowIfNull(source);
        return source.Select(MathT.TanDeg);
    }

    /// <summary>
    /// Computes the secant of each angle in the sequence, specified in radians.
    /// </summary>
    /// <typeparam name="TSource">The numeric type.</typeparam>
    /// <param name="source">The sequence of angles in radians.</param>
    /// <returns>A sequence of secant values.</returns>
    /// <exception cref="ArgumentNullException"><paramref name="source"/> is <see langword="null"/>.</exception>
    public static IEnumerable<TSource> Sec<TSource>(this IEnumerable<TSource> source)
        where TSource : INumberBase<TSource>, ITrigonometricFunctions<TSource>
    {
        ArgumentNullException.ThrowIfNull(source);
        return source.Select(MathT.Sec);
    }

    /// <summary>
    /// Computes the secant of each angle in the sequence, specified in degrees.
    /// </summary>
    /// <typeparam name="TSource">The numeric type.</typeparam>
    /// <param name="source">The sequence of angles in degrees.</param>
    /// <returns>A sequence of secant values.</returns>
    /// <exception cref="ArgumentNullException"><paramref name="source"/> is <see langword="null"/>.</exception>
    public static IEnumerable<TSource> SecDeg<TSource>(this IEnumerable<TSource> source)
        where TSource : INumberBase<TSource>, ITrigonometricFunctions<TSource>
    {
        ArgumentNullException.ThrowIfNull(source);
        return source.Select(MathT.SecDeg);
    }

    /// <summary>
    /// Computes the cosecant of each angle in the sequence, specified in radians.
    /// </summary>
    /// <typeparam name="TSource">The numeric type.</typeparam>
    /// <param name="source">The sequence of angles in radians.</param>
    /// <returns>A sequence of cosecant values.</returns>
    /// <exception cref="ArgumentNullException"><paramref name="source"/> is <see langword="null"/>.</exception>
    public static IEnumerable<TSource> Csc<TSource>(this IEnumerable<TSource> source)
        where TSource : INumberBase<TSource>, ITrigonometricFunctions<TSource>
    {
        ArgumentNullException.ThrowIfNull(source);
        return source.Select(MathT.Csc);
    }

    /// <summary>
    /// Computes the cosecant of each angle in the sequence, specified in degrees.
    /// </summary>
    /// <typeparam name="TSource">The numeric type.</typeparam>
    /// <param name="source">The sequence of angles in degrees.</param>
    /// <returns>A sequence of cosecant values.</returns>
    /// <exception cref="ArgumentNullException"><paramref name="source"/> is <see langword="null"/>.</exception>
    public static IEnumerable<TSource> CscDeg<TSource>(this IEnumerable<TSource> source)
        where TSource : INumberBase<TSource>, ITrigonometricFunctions<TSource>
    {
        ArgumentNullException.ThrowIfNull(source);
        return source.Select(MathT.CscDeg);
    }

    /// <summary>
    /// Computes the cotangent of each angle in the sequence, specified in radians.
    /// </summary>
    /// <typeparam name="TSource">The numeric type.</typeparam>
    /// <param name="source">The sequence of angles in radians.</param>
    /// <returns>A sequence of cotangent values.</returns>
    /// <exception cref="ArgumentNullException"><paramref name="source"/> is <see langword="null"/>.</exception>
    public static IEnumerable<TSource> Cot<TSource>(this IEnumerable<TSource> source)
        where TSource : INumberBase<TSource>, ITrigonometricFunctions<TSource>
    {
        ArgumentNullException.ThrowIfNull(source);
        return source.Select(MathT.Cot);
    }

    /// <summary>
    /// Computes the cotangent of each angle in the sequence, specified in degrees.
    /// </summary>
    /// <typeparam name="TSource">The numeric type.</typeparam>
    /// <param name="source">The sequence of angles in degrees.</param>
    /// <returns>A sequence of cotangent values.</returns>
    /// <exception cref="ArgumentNullException"><paramref name="source"/> is <see langword="null"/>.</exception>
    public static IEnumerable<TSource> CotDeg<TSource>(this IEnumerable<TSource> source)
        where TSource : INumberBase<TSource>, ITrigonometricFunctions<TSource>
    {
        ArgumentNullException.ThrowIfNull(source);
        return source.Select(MathT.CotDeg);
    }

    #endregion

    #region Hyperbolic

    /// <summary>
    /// Computes the hyperbolic sine of each element in the sequence.
    /// </summary>
    /// <typeparam name="TSource">The numeric type.</typeparam>
    /// <param name="source">The sequence of values.</param>
    /// <returns>A sequence of hyperbolic sine values.</returns>
    public static IEnumerable<TSource> Sinh<TSource>(this IEnumerable<TSource> source)
        where TSource : IHyperbolicFunctions<TSource>
    {
        ArgumentNullException.ThrowIfNull(source);
        return source.Select(TSource.Sinh);
    }

    /// <summary>
    /// Computes the hyperbolic cosine of each element in the sequence.
    /// </summary>
    /// <typeparam name="TSource">The numeric type.</typeparam>
    /// <param name="source">The sequence of values.</param>
    /// <returns>A sequence of hyperbolic cosine values.</returns>
    public static IEnumerable<TSource> Cosh<TSource>(this IEnumerable<TSource> source)
        where TSource : IHyperbolicFunctions<TSource>
    {
        ArgumentNullException.ThrowIfNull(source);
        return source.Select(TSource.Cosh);
    }

    /// <summary>
    /// Computes the hyperbolic tangent of each element in the sequence.
    /// </summary>
    /// <typeparam name="TSource">The numeric type.</typeparam>
    /// <param name="source">The sequence of values.</param>
    /// <returns>A sequence of hyperbolic tangent values.</returns>
    public static IEnumerable<TSource> Tanh<TSource>(this IEnumerable<TSource> source)
        where TSource : IHyperbolicFunctions<TSource>
    {
        ArgumentNullException.ThrowIfNull(source);
        return source.Select(TSource.Tanh);
    }

    /// <summary>
    /// Computes the hyperbolic secant of each element in the sequence.
    /// </summary>
    /// <typeparam name="TSource">The numeric type.</typeparam>
    /// <param name="source">The sequence of values.</param>
    /// <returns>A sequence of hyperbolic secant values.</returns>
    public static IEnumerable<TSource> Sech<TSource>(this IEnumerable<TSource> source)
        where TSource : INumberBase<TSource>, IHyperbolicFunctions<TSource>
    {
        ArgumentNullException.ThrowIfNull(source);
        return source.Select(n => TSource.One / TSource.Cosh(n));
    }

    /// <summary>
    /// Computes the hyperbolic cosecant of each element in the sequence.
    /// </summary>
    /// <typeparam name="TSource">The numeric type.</typeparam>
    /// <param name="source">The sequence of values.</param>
    /// <returns>A sequence of hyperbolic cosecant values.</returns>
    public static IEnumerable<TSource> Csch<TSource>(this IEnumerable<TSource> source)
        where TSource : INumberBase<TSource>, IHyperbolicFunctions<TSource>
    {
        ArgumentNullException.ThrowIfNull(source);
        return source.Select(n => TSource.One / TSource.Sinh(n));
    }

    /// <summary>
    /// Computes the hyperbolic cotangent of each element in the sequence.
    /// </summary>
    /// <typeparam name="TSource">The numeric type.</typeparam>
    /// <param name="source">The sequence of values.</param>
    /// <returns>A sequence of hyperbolic cotangent values.</returns>
    public static IEnumerable<TSource> Coth<TSource>(this IEnumerable<TSource> source)
        where TSource : INumberBase<TSource>, IHyperbolicFunctions<TSource>
    {
        ArgumentNullException.ThrowIfNull(source);
        return source.Select(n => TSource.One / TSource.Tanh(n));
    }

    #endregion

    #region Roots

    /// <summary>
    /// Computes the square root of each element in the sequence.
    /// </summary>
    /// <typeparam name="TSource">The numeric type.</typeparam>
    /// <param name="source">The sequence of values.</param>
    /// <returns>A sequence of square root values.</returns>
    public static IEnumerable<TSource> Sqrt<TSource>(this IEnumerable<TSource> source)
        where TSource : IRootFunctions<TSource>
    {
        ArgumentNullException.ThrowIfNull(source);
        return source.Select(TSource.Sqrt);
    }

    /// <summary>
    /// Computes the cube root of each element in the sequence.
    /// </summary>
    /// <typeparam name="TSource">The numeric type.</typeparam>
    /// <param name="source">The sequence of values.</param>
    /// <returns>A sequence of cube root values.</returns>
    public static IEnumerable<TSource> Cbrt<TSource>(this IEnumerable<TSource> source)
        where TSource : IRootFunctions<TSource>
    {
        ArgumentNullException.ThrowIfNull(source);
        return source.Select(TSource.Cbrt);
    }

    /// <summary>
    /// Computes the n-th root of each element in the sequence.
    /// </summary>
    /// <typeparam name="TSource">The numeric type.</typeparam>
    /// <param name="source">The sequence of values.</param>
    /// <param name="n">The degree of the root.</param>
    /// <returns>A sequence of n-th root values.</returns>
    public static IEnumerable<TSource> RootN<TSource>(this IEnumerable<TSource> source, int n)
        where TSource : IRootFunctions<TSource>
    {
        ArgumentNullException.ThrowIfNull(source);
        return source.Select(value => TSource.RootN(value, n));
    }

    #endregion

    #region Logarithm

    /// <summary>
    /// Computes the natural logarithm of each element in the sequence.
    /// </summary>
    /// <typeparam name="TSource">The numeric type.</typeparam>
    /// <param name="source">The sequence of values.</param>
    /// <returns>A sequence of natural logarithm values.</returns>
    public static IEnumerable<TSource> Ln<TSource>(this IEnumerable<TSource> source)
        where TSource : ILogarithmicFunctions<TSource>
    {
        ArgumentNullException.ThrowIfNull(source);
        return source.Select(TSource.Log);
    }

    /// <summary>
    /// Computes the logarithm of each element in the sequence in a specified base.
    /// </summary>
    /// <typeparam name="TSource">The numeric type.</typeparam>
    /// <param name="source">The sequence of values.</param>
    /// <param name="b">The base of the logarithm.</param>
    /// <returns>A sequence of logarithm values in the specified base.</returns>
    public static IEnumerable<TSource> Log<TSource>(this IEnumerable<TSource> source, TSource b)
        where TSource : ILogarithmicFunctions<TSource>
    {
        ArgumentNullException.ThrowIfNull(source);
        return source.Select(value => TSource.Log(value, b));
    }

    /// <summary>
    /// Computes the base-2 logarithm of each element in the sequence.
    /// </summary>
    /// <typeparam name="TSource">The numeric type.</typeparam>
    /// <param name="source">The sequence of values.</param>
    /// <returns>A sequence of base-2 logarithm values.</returns>
    public static IEnumerable<TSource> Log2<TSource>(this IEnumerable<TSource> source)
        where TSource : ILogarithmicFunctions<TSource>
    {
        ArgumentNullException.ThrowIfNull(source);
        return source.Select(TSource.Log2);
    }

    /// <summary>
    /// Computes the base-10 logarithm of each element in the sequence.
    /// </summary>
    /// <typeparam name="TSource">The numeric type.</typeparam>
    /// <param name="source">The sequence of values.</param>
    /// <returns>A sequence of base-10 logarithm values.</returns>
    public static IEnumerable<TSource> Log10<TSource>(this IEnumerable<TSource> source)
        where TSource : ILogarithmicFunctions<TSource>
    {
        ArgumentNullException.ThrowIfNull(source);
        return source.Select(TSource.Log10);
    }

    #endregion

    #region Special Functions & Others

    /// <summary>
    /// Computes the power of each base value in the sequence raised to a specified exponent.
    /// </summary>
    /// <typeparam name="TSource">The numeric type.</typeparam>
    /// <param name="source">The sequence of base values.</param>
    /// <param name="exponent">The exponent to which each base value is raised.</param>
    /// <returns>A sequence of computed power values.</returns>
    /// <exception cref="ArgumentNullException"><paramref name="source"/> is <see langword="null"/>.</exception>
    public static IEnumerable<TSource> Pow<TSource>(this IEnumerable<TSource> source, TSource exponent)
        where TSource : IPowerFunctions<TSource>
    {
        ArgumentNullException.ThrowIfNull(source);
        return source.Select(baseValue => TSource.Pow(baseValue, exponent));
    }

    /// <summary>
    /// Computes the power of each base value in the sequence raised to a specified integer exponent.
    /// </summary>
    /// <typeparam name="TSource">The numeric type.</typeparam>
    /// <param name="source">The sequence of base values.</param>
    /// <param name="exponent">The integer exponent to which each base value is raised.</param>
    /// <returns>A sequence of computed power values.</returns>
    /// <exception cref="ArgumentNullException"><paramref name="source"/> is <see langword="null"/>.</exception>
    public static IEnumerable<TSource> Pow<TSource>(this IEnumerable<TSource> source, int exponent)
        where TSource : INumberBase<TSource>
    {
        ArgumentNullException.ThrowIfNull(source);
        return source.Select(baseValue => MathT.Pow(baseValue, exponent));
    }

    /// <summary>
    /// Computes the exponential function of each value in the sequence.
    /// </summary>
    /// <typeparam name="TSource">The numeric type.</typeparam>
    /// <param name="source">The sequence of values.</param>
    /// <returns>A sequence of computed exponential values.</returns>
    /// <exception cref="ArgumentNullException"><paramref name="source"/> is <see langword="null"/>.</exception>
    public static IEnumerable<TSource> Exp<TSource>(this IEnumerable<TSource> source)
        where TSource : IExponentialFunctions<TSource>
    {
        ArgumentNullException.ThrowIfNull(source);
        return source.Select(TSource.Exp);
    }

    /// <summary>
    /// Calculates the factorial of each value in the sequence.
    /// </summary>
    /// <typeparam name="TSource">The numeric type.</typeparam>
    /// <param name="source">The sequence of values.</param>
    /// <returns>A sequence of factorial values.</returns>
    /// <exception cref="ArgumentOutOfRangeException">When any value in <paramref name="source"/> is negative.</exception>
    public static IEnumerable<TSource> Factorial<TSource>(this IEnumerable<TSource> source)
        where TSource : INumberBase<TSource>
    {
        ArgumentNullException.ThrowIfNull(source);
        return source.Select(MathT.Factorial);
    }

    #endregion
}