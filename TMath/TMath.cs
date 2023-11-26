using System.Numerics;

namespace TMath;

/// <summary>
/// Mathematics class with support for any <see cref="INumber{TSelf}"/>, such as floats, doubles,
/// decimals, integers, or any custom number type that implements the interface.
/// </summary>
/// <remarks>
/// Some functions require additional implementations for each number, which means not all number types are supported by them.
/// For example, trigonometric functions require a type that implements <see cref="ITrigonometricFunctions{TSelf}"/>, some exponential
/// functions require <see cref="IExponentialFunctions{TSelf}"/>, and so on. 
/// </remarks>
public static partial class TMath
{
    /// <summary>
    /// Converts an integer to a type T.
    /// </summary>
    /// <param name="num">The number to convert</param>
    /// <typeparam name="T">The target type</typeparam>
    /// <returns>The converted integer into the type T</returns>
    /// <remarks>Used internally a lot by <see cref="TMath"/> to get a specific number of a type T so operations can be done successfully.</remarks>
    public static T IntToT<T>(int num) where T : INumber<T>
    {
        if (num < 0) return IntToT<T>(num + 1) - T.One;
        if (num == 0) return T.Zero;
        if (num == 1) return T.One;
        return T.One + IntToT<T>(num - 1);
    }

    /// <summary>
    /// Returns the absolute value of a number.
    /// </summary>
    /// <param name="n">A number between the type's MinValue and MaxValue</param>
    /// <returns>The absolute value of the number</returns>
    public static T Abs<T>(T n) where T : INumber<T> => T.IsNegative(n) ? -n : n;

    /// <summary>
    /// Rounds the number down to the closest integral form.
    /// </summary>
    /// <param name="n">The number to round down</param>
    /// <returns>The rounded down number.</returns>
    public static T Floor<T>(T n) where T : INumber<T>
    {
        if (T.IsNegative(n))
            return -(Abs(n) - Abs(n % T.One)) - T.One;
        else return n - (n % T.One);
    }
    /// <summary>
    /// Rounds the number up to the closest integral form.
    /// </summary>
    /// <param name="n">The number to round up</param>
    /// <returns>The rounded up number.</returns>
    public static T Ceil<T>(T n) where T : INumber<T> => n % T.One == T.Zero ? n : n + (T.One - Abs(n % T.One));

    /// <summary>
    /// Rounds the number to the closest integral form.
    /// </summary>
    /// <param name="n">The number to round</param>
    /// <returns>The rounded number</returns>
    public static T Round<T>(T n) where T : INumber<T>
    {
        if (n % T.One >= T.One / IntToT<T>(2)) return Ceil(n);
        return Floor(n);
    }
    
    /// <summary>
    /// Gets the factorial of an number.
    /// </summary>
    /// <param name="n">The number to obtain its factorial</param>
    /// <typeparam name="T">The number type to return the factorial as</typeparam>
    /// <returns>The factorial of a number as a type T</returns>
    public static T Factorial<T>(int n) where T : INumber<T> => n <= 1 ? T.One : IntToT<T>(n) * Factorial<T>(n - 1);

    /// <summary>
    /// Converts a number of degrees into radians.
    /// </summary>
    /// <param name="deg">The degree value</param>
    /// <returns>The degrees converted into radians</returns>
    public static T ToRadians<T>(T deg) where T : INumber<T> => deg * TConstants<T>.Pi / IntToT<T>(180);

    /// <summary>
    /// Converts a value in radians into degrees.
    /// </summary>
    /// <param name="radians">The radian value</param>
    /// <returns>The radian value converted into degrees</returns>
    public static T Rad2Deg<T>(T radians) where T : INumber<T> => radians * IntToT<T>(180) / TConstants<T>.Pi;

    /// <summary>
    /// Calculates a to the power of b.
    /// </summary>
    /// <param name="a">The base</param>
    /// <param name="b">The exponent</param>
    /// <typeparam name="T">A generic type that inherits <see cref="INumber{TSelf}"/> and <see cref="IPowerFunctions{TSelf}"/></typeparam>
    /// <returns>a to the power of b</returns>
    public static T Pow<T>(T a, T b) where T : INumber<T>, IPowerFunctions<T> => T.Pow(a, b);


    /// <summary>
    /// Calculates a to the power of b.
    /// </summary>
    /// <param name="a">The base number.</param>
    /// <param name="b">The power of the base number.</param>
    /// <returns><paramref name="a"/> to the power of <paramref name="b"></paramref></returns>
    public static T Pow<T>(T a, int b) where T : INumber<T>
    {
        if (b < 0) return Pow(T.One / a, Abs(b));
        if (b == 0) return T.One;
        if (b == 1) return a;
        else return a * Pow(a, b - 1);
    }

    /// <summary>
    /// Clamps a value between min and max values
    /// </summary>
    /// <param name="value">The value to clamp</param>
    /// <param name="min">The minimal value</param>
    /// <param name="max">The maximum value</param>
    /// <returns> <paramref name="value"/> clamped to the inclusive range of <paramref name="min"/> and <paramref name="max"/> </returns>
    public static T Clamp<T>(T value, T min, T max) where T : INumber<T> =>
        min > value ? min : (value < max ? value : max);


    /// <summary>
    /// Copies the sign from one variable to the other.
    /// </summary>
    /// <param name="value">The value of the result</param>
    /// <param name="sign">The sign of the result</param>
    /// <returns>A number with the magnitude of <paramref name="value"/> and the sign of <paramref name="sign"/></returns>
    public static T CopySign<T>(T value, T sign) where T : INumber<T> => T.CopySign(value, sign);

    /// <summary>
    /// Returns the remainder of the division of 2 numbers
    /// </summary>
    /// <param name="number">The number to divide</param>
    /// <param name="divider">The divider</param>
    /// <returns>The remainder of <paramref name="number"/>/<paramref name="divider"/></returns>
    public static T Remainder<T>(T number, T divider) where T : INumber<T>
    {
        if (number > divider) return Remainder(number - divider, divider);
        return number; 
    }
}

