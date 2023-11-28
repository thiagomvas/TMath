using System.Numerics;

namespace TMath;

public static partial class TFunctions
{
    /// <summary>
    /// Calculates the hyperbolic sine of a number.
    /// </summary>
    /// <typeparam name="T">An <see cref="INumber{TSelf}"/> that also implements <see cref="IPowerFunctions{TSelf}"/></typeparam>
    /// <param name="num">The number.</param>
    /// <returns>The hyperbolic sine of the number.</returns>
    public static T Sinh<T>(T num) where T : INumber<T>, IPowerFunctions<T>
        => (Pow(TConstants<T>.E, num) - Pow(TConstants<T>.E, -num)) / IntToT<T>(2);

    /// <summary>
    /// Calculates the hyperbolic cosine of a number.
    /// </summary>
    /// <typeparam name="T">An <see cref="INumber{TSelf}"/> that also implements <see cref="IPowerFunctions{TSelf}"/></typeparam>
    /// <param name="num">The number.</param>
    /// <returns>The hyperbolic cosine of the number.</returns>
    public static T Cosh<T>(T num) where T : INumber<T>, IPowerFunctions<T>
        => (Pow(TConstants<T>.E, num) + Pow(TConstants<T>.E, -num)) / IntToT<T>(2);

    /// <summary>
    /// Calculates the hyperbolic tangent of a number.
    /// </summary>
    /// <typeparam name="T">An <see cref="INumber{TSelf}"/> that also implements <see cref="IPowerFunctions{TSelf}"/></typeparam>
    /// <param name="num">The number.</param>
    /// <returns>The hyperbolic tangent of the number.</returns>
    public static T Tanh<T>(T num) where T : INumber<T>, IPowerFunctions<T>
        => Sinh(num) / Cosh(num);

    /// <summary>
    /// Calculates the hyperbolic secant of a number.
    /// </summary>
    /// <typeparam name="T">An <see cref="INumber{TSelf}"/> that also implements <see cref="IPowerFunctions{TSelf}"/></typeparam>
    /// <param name="num">The number.</param>
    /// <returns>The hyperbolic secant of the number.</returns>
    public static T Sech<T>(T num) where T : INumber<T>, IPowerFunctions<T>
        => T.One / Cosh(num);

    /// <summary>
    /// Calculates the hyperbolic cosecant of a number.
    /// </summary>
    /// <typeparam name="T">An <see cref="INumber{TSelf}"/> that also implements <see cref="IPowerFunctions{TSelf}"/></typeparam>
    /// <param name="num">The number.</param>
    /// <returns>The hyperbolic cosecant of the number.</returns>
    public static T Csch<T>(T num) where T : INumber<T>, IPowerFunctions<T>
        => T.One / Sinh(num);

    /// <summary>
    /// Calculates the hyperbolic cotangent of a number.
    /// </summary>
    /// <typeparam name="T">An <see cref="INumber{TSelf}"/> that also implements <see cref="IPowerFunctions{TSelf}"/></typeparam>
    /// <param name="num">The number.</param>
    /// <returns>The hyperbolic cotangent of the number.</returns>
    public static T Coth<T>(T num) where T : INumber<T>, IPowerFunctions<T>
        => Cosh(num) / Sinh(num);

}