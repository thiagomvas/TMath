using System.Numerics;

namespace TMath;

public static class TMath
{
    /// <summary>
    /// Converts an integer to a type T.
    /// </summary>
    /// <param name="num">The number to convert</param>
    /// <typeparam name="T">The target type</typeparam
    /// <returns>The converted integer into the type T</returns>
    /// <remarks>Used internally a lot by <see cref="TMath"/> to get a specific number of a type T so operations can be done successfully.</remarks>
    public static T IntToT<T>(int num) where T : INumber<T> => num == T.One as int? ? T.One : T.One + IntToT<T>(num - 1);
}