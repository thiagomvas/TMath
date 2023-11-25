using System.Numerics;

namespace TMath;

public static class TMath
{
    /// <summary>
    /// Converts an integer to a type T.
    /// </summary>
    /// <param name="num">The number to convert</param>
    /// <typeparam name="T">The target type</typeparam>
    /// <returns>The converted integer into the type T</returns>
    /// <remarks>Used internally a lot by <see cref="TMath"/> to get a specific number of a type T so operations can be done successfully.</remarks>
    public static T IntToT<T>(int num) where T : INumber<T> => num <= 1 ? T.One : T.One + IntToT<T>(num - 1);

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
    public static T Floor<T>(T n) where T : INumber<T> => n - n % T.One;
    /// <summary>
    /// Rounds the number up to the closest integral form.
    /// </summary>
    /// <param name="n">The number to round up</param>
    /// <returns>The rounded up number.</returns>
    public static T Ceil<T>(T n) where T : INumber<T> => n - n % T.One + T.One;

    /// <summary>
    /// Rounds the number to the closest integral form.
    /// </summary>
    /// <param name="n">The number to rounud</param>
    /// <returns>The rounded number</returns>
    public static T Round<T>(T n) where T : INumber<T> => Ceil(n) - n <= T.One / IntToT<T>(2) ? Ceil(n) : Floor(n);
    
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
    /// <param name="a">The base number.</param>
    /// <param name="b">The power of the base number.</param>
    /// <returns><paramref name="a"/> to the power of <paramref name="b"></paramref></returns>
    public static T Pow<T>(T a, int b) where T : INumber<T>
    {
        if (b < 0) return Pow<T>(T.One / a, Abs(b));
        if (b == 0) return T.One;
        if (b == 1) return a;
        else return a * Pow(a, b - 1);
    }

    /// <summary>
    /// Clamps a value between min and max values
    /// </summary>
    /// <param name="value">The value to clamp</param>
    /// <param name="min">The minimal value</param>
    /// <param name="max">The maximum vvalue</param>
    /// <returns> <paramref name="value"/> clamped to the inclusive range of <paramref name="min"/> and <paramref name="max"/> </returns>
    public static T Clamp<T>(T value, T min, T max) where T : INumber<T> =>
        min > value ? min : (value < max ? value : max);
}

