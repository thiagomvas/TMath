using System.Numerics;

namespace TMath;

public static class MathT
{
    #region Rounding functions

    /// <summary>
    /// Returns the absolute value of a number.
    /// </summary>
    /// <param name="n">The value of which to get it's absolute</param>
    /// <typeparam name="TSelf">The numeric type.</typeparam>
    /// <returns>The absolute value of the number</returns>
    /// <exception cref="OverflowException">The absolute of value is not representable by <typeparamref name="TSelf"/>.</exception>
    public static TSelf Abs<TSelf>(TSelf n) where TSelf : INumberBase<TSelf> => TSelf.Abs(n);

    /// <summary>
    /// Computes the floor of a number.
    /// </summary>
    /// <param name="n">The value whose floor is to be computed</param>
    /// <typeparam name="TSelf">The numeric type.</typeparam>
    /// <returns>The floor of <paramref name="n"/></returns>
    public static TSelf Floor<TSelf>(TSelf n) where TSelf : IFloatingPoint<TSelf> => TSelf.Floor(n);

    /// <summary>
    /// Computes the ceiling of a number.
    /// </summary>
    /// <param name="n">The value whose ceiling is to be computed</param>
    /// <typeparam name="TSelf">The numeric type.</typeparam>
    /// <returns>The ceiling of <paramref name="n"/></returns>
    public static TSelf Ceiling<TSelf>(TSelf n) where TSelf : IFloatingPoint<TSelf> => TSelf.Ceiling(n);

    /// <summary>
    /// Rounds a number to the nearest integer.
    /// </summary>
    /// <param name="n">The value to be rounded</param>
    /// <typeparam name="TSelf">The numeric type.</typeparam>
    /// <returns>The rounded value of <paramref name="n"/></returns>
    public static TSelf Round<TSelf>(TSelf n) where TSelf : IFloatingPoint<TSelf> => TSelf.Round(n);

    /// <summary>
    /// Rounds a number to the nearest integer using the specified rounding mode.
    /// </summary>
    /// <param name="n">The value to be rounded</param>
    /// <param name="mode">The rounding mode to use</param>
    /// <typeparam name="TSelf">The numeric type.</typeparam>
    /// <returns>The rounded value of <paramref name="n"/> using the specified <paramref name="mode"/></returns>
    public static TSelf Round<TSelf>(TSelf n, MidpointRounding mode) where TSelf : IFloatingPoint<TSelf> =>
        TSelf.Round(n, mode);

    /// <summary>
    /// Rounds a number to a specified number of fractional digits.
    /// </summary>
    /// <param name="n">The value to be rounded</param>
    /// <param name="decimals">The number of fractional digits in the return value</param>
    /// <typeparam name="TSelf">The numeric type.</typeparam>
    /// <returns>The rounded value of <paramref name="n"/> to the specified number of <paramref name="decimals"/></returns>
    public static TSelf Round<TSelf>(TSelf n, int decimals) where TSelf : IFloatingPoint<TSelf> =>
        TSelf.Round(n, decimals);

    /// <summary>
    /// Rounds a number to a specified number of fractional digits using the specified rounding mode.
    /// </summary>
    /// <param name="n">The value to be rounded</param>
    /// <param name="decimals">The number of fractional digits in the return value</param>
    /// <param name="mode">The rounding mode to use</param>
    /// <typeparam name="TSelf">The numeric type.</typeparam>
    /// <returns>The rounded value of <paramref name="n"/> to the specified number of <paramref name="decimals"/> using the specified <paramref name="mode"/></returns>
    public static TSelf Round<TSelf>(TSelf n, int decimals, MidpointRounding mode)
        where TSelf : IFloatingPoint<TSelf> => TSelf.Round(n, decimals, mode);

    /// <summary>
    /// Truncates a number to the integer part by removing any fractional digits.
    /// </summary>
    /// <param name="n">The value to be truncated</param>
    /// <typeparam name="TSelf">The numeric type.</typeparam>
    /// <returns>The truncated value of <paramref name="n"/></returns>
    public static TSelf Truncate<TSelf>(TSelf n) where TSelf : IFloatingPoint<TSelf> => TSelf.Truncate(n);

    #endregion

    #region Trigonometry

    /// <summary>
    /// Computes the sine of an angle specified in radians.
    /// </summary>
    /// <param name="radians">The angle in radians</param>
    /// <typeparam name="TSelf">The numeric type.</typeparam>
    /// <returns>The sine of the angle</returns>
    public static TSelf Sin<TSelf>(TSelf radians) where TSelf : ITrigonometricFunctions<TSelf>
        => TSelf.Sin(radians);

    /// <summary>
    /// Computes the sine of an angle specified in degrees.
    /// </summary>
    /// <param name="degrees">The angle in degrees</param>
    /// <typeparam name="TSelf">The numeric type.</typeparam>
    /// <returns>The sine of the angle</returns>
    public static TSelf SinDeg<TSelf>(TSelf degrees) where TSelf : INumberBase<TSelf>, ITrigonometricFunctions<TSelf>
        => TSelf.Sin(degrees * Constants<TSelf>.Degree);

    /// <summary>
    /// Computes the cosine of an angle specified in radians.
    /// </summary>
    /// <param name="radians">The angle in radians</param>
    /// <typeparam name="TSelf">The numeric type.</typeparam>
    /// <returns>The cosine of the angle</returns>
    public static TSelf Cos<TSelf>(TSelf radians) where TSelf : ITrigonometricFunctions<TSelf>
        => TSelf.Cos(radians);

    /// <summary>
    /// Computes the cosine of an angle specified in degrees.
    /// </summary>
    /// <param name="degrees">The angle in degrees</param>
    /// <typeparam name="TSelf">The numeric type.</typeparam>
    /// <returns>The cosine of the angle</returns>
    public static TSelf CosDeg<TSelf>(TSelf degrees) where TSelf : INumberBase<TSelf>, ITrigonometricFunctions<TSelf>
        => TSelf.Cos(degrees * Constants<TSelf>.Degree);

    /// <summary>
    /// Computes the tangent of an angle specified in radians.
    /// </summary>
    /// <param name="radians">The angle in radians</param>
    /// <typeparam name="TSelf">The numeric type.</typeparam>
    /// <returns>The tangent of the angle</returns>
    public static TSelf Tan<TSelf>(TSelf radians) where TSelf : ITrigonometricFunctions<TSelf>
        => TSelf.Tan(radians);

    /// <summary>
    /// Computes the tangent of an angle specified in degrees.
    /// </summary>
    /// <param name="degrees">The angle in degrees</param>
    /// <typeparam name="TSelf">The numeric type.</typeparam>
    /// <returns>The tangent of the angle</returns>
    public static TSelf TanDeg<TSelf>(TSelf degrees) where TSelf : INumberBase<TSelf>, ITrigonometricFunctions<TSelf>
        => TSelf.Tan(degrees * Constants<TSelf>.Degree);

    /// <summary>
    /// Computes the secant of an angle specified in radians.
    /// </summary>
    /// <param name="radians">The angle in radians</param>
    /// <typeparam name="TSelf">The numeric type.</typeparam>
    /// <returns>The secant of the angle</returns>
    public static TSelf Sec<TSelf>(TSelf radians) where TSelf : ITrigonometricFunctions<TSelf>
        => TSelf.One / TSelf.Cos(radians);

    /// <summary>
    /// Computes the secant of an angle specified in degrees.
    /// </summary>
    /// <param name="degrees">The angle in degrees</param>
    /// <typeparam name="TSelf">The numeric type.</typeparam>
    /// <returns>The secant of the angle</returns>
    public static TSelf SecDeg<TSelf>(TSelf degrees) where TSelf : INumberBase<TSelf>, ITrigonometricFunctions<TSelf>
        => TSelf.One / TSelf.Cos(degrees * Constants<TSelf>.Degree);

    /// <summary>
    /// Computes the cosecant of an angle specified in radians.
    /// </summary>
    /// <param name="radians">The angle in radians</param>
    /// <typeparam name="TSelf">The numeric type.</typeparam>
    /// <returns>The cosecant of the angle</returns>
    public static TSelf Csc<TSelf>(TSelf radians) where TSelf : ITrigonometricFunctions<TSelf>
        => TSelf.One / TSelf.Sin(radians);

    /// <summary>
    /// Computes the cosecant of an angle specified in degrees.
    /// </summary>
    /// <param name="degrees">The angle in degrees</param>
    /// <typeparam name="TSelf">The numeric type.</typeparam>
    /// <returns>The cosecant of the angle</returns>
    public static TSelf CscDeg<TSelf>(TSelf degrees) where TSelf : INumberBase<TSelf>, ITrigonometricFunctions<TSelf>
        => TSelf.One / TSelf.Sin(degrees * Constants<TSelf>.Degree);

    /// <summary>
    /// Computes the cotangent of an angle specified in radians.
    /// </summary>
    /// <param name="radians">The angle in radians</param>
    /// <typeparam name="TSelf">The numeric type.</typeparam>
    /// <returns>The cotangent of the angle</returns>
    public static TSelf Cot<TSelf>(TSelf radians) where TSelf : ITrigonometricFunctions<TSelf>
        => TSelf.One / TSelf.Tan(radians);

    /// <summary>
    /// Computes the cotangent of an angle specified in degrees.
    /// </summary>
    /// <param name="degrees">The angle in degrees</param>
    /// <typeparam name="TSelf">The numeric type.</typeparam>
    /// <returns>The cotangent of the angle</returns>
    public static TSelf CotDeg<TSelf>(TSelf degrees) where TSelf : INumberBase<TSelf>, ITrigonometricFunctions<TSelf>
        => TSelf.One / TSelf.Tan(degrees * Constants<TSelf>.Degree);

    #endregion
}