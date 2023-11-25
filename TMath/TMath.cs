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
    public static T IntToT<T>(int num) where T : INumber<T> => num == 1 ? T.One : T.One + IntToT<T>(num - 1);

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
}

