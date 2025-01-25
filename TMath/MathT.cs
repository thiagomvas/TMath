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
}