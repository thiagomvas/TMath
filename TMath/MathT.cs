using System.Numerics;
using TMath;

/// <summary>
/// Provides mathematical functions with generic support for exponentiation, roots, trigonometry, hyperbolic functions, and special functions.
/// </summary>
/// <remarks>
/// Some functions require additional interfaces to be implemented by the number type, such as <see cref="IPowerFunctions{T}"/>, <see cref="IRootFunctions{T}"/>, <see cref="ITrigonometricFunctions{T}"/>, <see cref="IHyperbolicFunctions{T}"/>, etc.
/// <br/>
/// In some cases, the class has overloads for the same function that use different interfaces, or using Power Series to allow more flexibility in the implementation of the number type.
/// In the case of Power Series implementation, the number type must implement <see cref="INumberBase{T}"/> and <see cref="IComparisonOperators{TSelf, TOther, TResult}"/> where TResult is <see langword="bool"/>.
/// </remarks>
public static class MathT
{
    #region Exponentiation and Roots

    /// <summary>
    /// Raises a number to the specified integer power.
    /// </summary>
    /// <typeparam name="T">The type of the number.</typeparam>
    /// <param name="x">The number to be raised to the power.</param>
    /// <param name="p">The power to raise the number to.</param>
    /// <returns>The result of raising the number to the power.</returns>
    /// <exception cref="DivideByZeroException">Thrown when the number is zero and the power is zero.</exception>
    public static T Pow<T>(T x, int p) where T : IMultiplyOperators<T, T, T>, IDivisionOperators<T, T, T>
    {
        if (p == 0) return x / x;
        if (p == 1) return x;
        if (p < 0)
        {
            return (x / x) / Pow(x, -p);
        }
        T result = x;
        for (int i = 0; i < p; i++)
        {
            result *= x;
        }
        return result;
    }

    /// <summary>
    /// Raises a number to the specified power.
    /// </summary>
    /// <typeparam name="T">The type of the number.</typeparam>
    /// <param name="x">The number to be raised to the power.</param>
    /// <param name="p">The power to raise the number to.</param>
    /// <returns>The result of raising the number to the power.</returns>
    public static T Pow<T>(T x, T p) where T : IPowerFunctions<T> => T.Pow(x, p);

    /// <summary>
    /// Calculates the square root of a number.
    /// </summary>
    /// <typeparam name="T">The type of the number.</typeparam>
    /// <param name="x">The number to calculate the square root of.</param>
    /// <returns>The square root of the number.</returns>
    public static T Sqrt<T>(T x) where T : IRootFunctions<T> => T.Sqrt(x);

    /// <summary>
    /// Calculates the cube root of a number.
    /// </summary>
    /// <typeparam name="T">The type of the number.</typeparam>
    /// <param name="x">The number to calculate the cube root of.</param>
    /// <returns>The cube root of the number.</returns>
    public static T Cbrt<T>(T x) where T : IRootFunctions<T> => T.Cbrt(x);

    /// <summary>
    /// Calculates the nth root of a number.
    /// </summary>
    /// <typeparam name="T">The type of the number.</typeparam>
    /// <param name="x">The number to calculate the nth root of.</param>
    /// <param name="n">The root to calculate.</param>
    /// <returns>The nth root of the number.</returns>
    public static T RootN<T>(T x, int n) where T : IRootFunctions<T> => T.RootN(x, n);

    /// <summary>
    /// Calculates the exponential of a number.
    /// </summary>
    /// <typeparam name="T">The type of the number.</typeparam>
    /// <param name="x">The number to calculate the exponential of.</param>
    /// <returns>The exponential of the number.</returns>
    public static T Exp<T>(T x) where T : IPowerFunctions<T> => T.Pow(TConstants<T>.E, x);
    /// <summary>
    /// Calculates the exponential of a number using the Power Series.
    /// </summary>
    /// <typeparam name="T">The type of the number.</typeparam>
    /// <param name="x">The number to calculate the exponential of.</param>
    /// <param name="n">The number of fractions in the series. Must be greater than 1</param>
    /// <returns>The exponential of the number.</returns>
    public static T ExpPS<T>(T x, int n) where T : INumberBase<T>, IComparisonOperators<T, T, bool>
    {
        if (n < 1) throw new ArgumentOutOfRangeException(nameof(n));

        T result = T.One;
        T term = T.One;
        for (T i = T.One; i < T.CreateSaturating(n); i++)
        {
            term *= x / i;
            result += term;
        }
        return result;
    }
    /// <summary>
    /// Calculates the natural logarithm of a number.
    /// </summary>
    /// <typeparam name="T">The type of the number.</typeparam>
    /// <param name="x">The number to calculate the natural logarithm of.</param>
    /// <returns>The natural logarithm of the number.</returns>
    public static T Log<T>(T x) where T : ILogarithmicFunctions<T> => T.Log(x);

    /// <summary>
    /// Calculates the logarithm of a number with a specified base.
    /// </summary>
    /// <typeparam name="T">The type of the number.</typeparam>
    /// <param name="x">The number to calculate the logarithm of.</param>
    /// <param name="b">The base of the logarithm.</param>
    /// <returns>The logarithm of the number with the specified base.</returns>
    public static T Log<T>(T x, T b) where T : ILogarithmicFunctions<T> => T.Log(x, b);

    /// <summary>
    /// Calculates the base 10 logarithm of a number.
    /// </summary>
    /// <typeparam name="T">The type of the number.</typeparam>
    /// <param name="x">The number to calculate the base 10 logarithm of.</param>
    /// <returns>The base 10 logarithm of the number.</returns>
    public static T Log10<T>(T x) where T : ILogarithmicFunctions<T> => T.Log10(x);

    /// <summary>
    /// Calculates the base 2 logarithm of a number.
    /// </summary>
    /// <typeparam name="T">The type of the number.</typeparam>
    /// <param name="x">The number to calculate the base 2 logarithm of.</param>
    /// <returns>The base 2 logarithm of the number.</returns>
    public static T Log2<T>(T x) where T : ILogarithmicFunctions<T> => T.Log2(x);

    #endregion

    #region Trigonometry

    /// <summary>
    /// Calculates the sine of an angle.
    /// </summary>
    /// <typeparam name="T">The type of the angle.</typeparam>
    /// <param name="x">The angle in radians.</param>
    /// <returns>The sine of the angle.</returns>
    public static T Sin<T>(T x) where T : ITrigonometricFunctions<T> => T.Sin(x);

    /// <summary>
    /// Calculates the cosine of an angle.
    /// </summary>
    /// <typeparam name="T">The type of the angle.</typeparam>
    /// <param name="x">The angle in radians.</param>
    /// <returns>The cosine of the angle.</returns>
    public static T Cos<T>(T x) where T : ITrigonometricFunctions<T> => T.Cos(x);

    /// <summary>
    /// Calculates the tangent of an angle.
    /// </summary>
    /// <typeparam name="T">The type of the angle.</typeparam>
    /// <param name="x">The angle in radians.</param>
    /// <returns>The tangent of the angle.</returns>
    public static T Tan<T>(T x) where T : ITrigonometricFunctions<T> => T.Tan(x);

    /// <summary>
    /// Calculates the secant of an angle.
    /// </summary>
    /// <typeparam name="T">The type of the angle.</typeparam>
    /// <param name="x">The angle in radians.</param>
    /// <returns>The secant of the angle.</returns>
    public static T Sec<T>(T x) where T : ITrigonometricFunctions<T> => T.One / T.Cos(x);

    /// <summary>
    /// Calculates the cosecant of an angle.
    /// </summary>
    /// <typeparam name="T">The type of the angle.</typeparam>
    /// <param name="x">The angle in radians.</param>
    /// <returns>The cosecant of the angle.</returns>
    public static T Csc<T>(T x) where T : ITrigonometricFunctions<T> => T.One / T.Sin(x);

    /// <summary>
    /// Calculates the cotangent of an angle.
    /// </summary>
    /// <typeparam name="T">The type of the angle.</typeparam>
    /// <param name="x">The angle in radians.</param>
    /// <returns>The cotangent of the angle.</returns>
    public static T Cot<T>(T x) where T : ITrigonometricFunctions<T> => T.One / T.Tan(x);

    /// <summary>
    /// Calculates the arcsine of a number.
    /// </summary>
    /// <typeparam name="T">The type of the number.</typeparam>
    /// <param name="x">The number to calculate the arcsine of.</param>
    /// <returns>The arcsine of the number.</returns>
    public static T Asin<T>(T x) where T : ITrigonometricFunctions<T> => T.Asin(x);

    /// <summary>
    /// Calculates the arccosine of a number.
    /// </summary>
    /// <typeparam name="T">The type of the number.</typeparam>
    /// <param name="x">The number to calculate the arccosine of.</param>
    /// <returns>The arccosine of the number.</returns>
    public static T Acos<T>(T x) where T : ITrigonometricFunctions<T> => T.Acos(x);

    /// <summary>
    /// Calculates the arctangent of a number.
    /// </summary>
    /// <typeparam name="T">The type of the number.</typeparam>
    /// <param name="x">The number to calculate the arctangent of.</param>
    /// <returns>The arctangent of the number.</returns>
    public static T Atan<T>(T x) where T : ITrigonometricFunctions<T> => T.Atan(x);

    /// <summary>
    /// Converts an angle from radians to degrees.
    /// </summary>
    /// <typeparam name="T">The type of the angle.</typeparam>
    /// <param name="x">The angle in radians.</param>
    /// <returns>The angle in degrees.</returns>
    public static T Rad2Deg<T>(T x) where T : INumberBase<T> => x * TConstants<T>.Rad2Deg;

    /// <summary>
    /// Converts an angle from degrees to radians.
    /// </summary>
    /// <typeparam name="T">The type of the angle.</typeparam>
    /// <param name="x">The angle in degrees.</param>
    /// <returns>The angle in radians.</returns>
    public static T Deg2Rad<T>(T x) where T : INumberBase<T> => x * TConstants<T>.Degree;

    #endregion

    #region Hyperbolic

    /// <summary>
    /// Calculates the hyperbolic sine of a number.
    /// </summary>
    /// <typeparam name="T">The type of the number.</typeparam>
    /// <param name="x">The number to calculate the hyperbolic sine of.</param>
    /// <returns>The hyperbolic sine of the number.</returns>
    public static T Sinh<T>(T x) where T : IHyperbolicFunctions<T> => T.Sinh(x);

    /// <summary>
    /// Calculates the hyperbolic sine of a number.
    /// </summary>
    /// <typeparam name="T">The type of the number.</typeparam>
    /// <param name="x">The number to calculate the hyperbolic sine of.</param>
    /// <returns>The hyperbolic sine of the number.</returns>
    /// <remarks>Uses the formula (e^x - e^-x) / 2 </remarks>
    public static T SinhP<T>(T x) where T : IPowerFunctions<T> => (Exp(x) - Exp(-x)) / (T.One + T.One);

    /// <summary>
    /// Calculates the hyperbolic sine of a number using the power series.
    /// </summary>
    /// <typeparam name="T">The type of the number.</typeparam>
    /// <param name="x">The number to calculate the hyperbolic sine of.</param>
    /// <param name="n">The number of fractions in the series. Must be greater than 1</param>
    /// <returns>The hyperbolic sine of the number.</returns>
    /// <exception cref="ArgumentOutOfRangeException"/>
    public static T SinhPS<T>(T x, int n) where T : INumberBase<T>, IComparisonOperators<T, T, bool>
    {
        if (n < 1) throw new ArgumentOutOfRangeException(nameof(n));

        T result = x;  
        T term = x;    

        T factorial = T.One;
        T two = T.One + T.One;
        for (T i = two + T.One; i <= T.CreateSaturating(2 * n + 1); i += two)
        {
            factorial *= i * (i - T.One);
            term *= x * x;
            result += term / factorial;
        }
        return result;
    }

    /// <summary>
    /// Calculates the hyperbolic cosine of a number.
    /// </summary>
    /// <typeparam name="T">The type of the number.</typeparam>
    /// <param name="x">The number to calculate the hyperbolic cosine of.</param>
    /// <returns>The hyperbolic cosine of the number.</returns>
    public static T Cosh<T>(T x) where T : IHyperbolicFunctions<T> => T.Cosh(x);

    /// <summary>
    /// Calculates the hyperbolic cosine of a number.
    /// </summary>
    /// <typeparam name="T">The type of the number.</typeparam>
    /// <param name="x">The number to calculate the hyperbolic cosine of.</param>
    /// <returns>The hyperbolic cosine of the number.</returns>
    /// <remarks>Uses the formula (e^x + e^-x) / 2 </remarks>
    public static T CoshP<T>(T x) where T : IPowerFunctions<T> => (Exp(x) + Exp(-x)) / (T.One + T.One);

    /// <summary>
    /// Calculates the hyperbolic cos of a number using the power series.
    /// </summary>
    /// <typeparam name="T">The type of the number.</typeparam>
    /// <param name="x">The number to calculate the hyperbolic sine of.</param>
    /// <param name="n">The number of fractions in the series. Must be greater than 1</param>
    /// <returns>The hyperbolic sine of the number.</returns>
    /// <exception cref="ArgumentOutOfRangeException"/>
    public static T CoshPS<T>(T x, int n) where T : INumberBase<T>, IComparisonOperators<T, T, bool>
    {
        if (n < 1) throw new ArgumentOutOfRangeException(nameof(n));

        T result = T.One;  
        T term = T.One;    

        T factorial = T.One;
        T two = T.One + T.One;
        for (T i = two; i <= T.CreateSaturating(2 * n); i += two)
        {
            factorial *= i * (i - T.One);
            term *= x * x;
            result += term / factorial;
        }
        return result;
    }

    /// <summary>
    /// Calculates the hyperbolic tangent of a number.
    /// </summary>
    /// <typeparam name="T">The type of the number.</typeparam>
    /// <param name="x">The number to calculate the hyperbolic tangent of.</param>
    /// <returns>The hyperbolic tangent of the number.</returns>
    public static T Tanh<T>(T x) where T : IHyperbolicFunctions<T> => T.Tanh(x);

    /// <summary>
    /// Calculates the hyperbolic tangent of a number.
    /// </summary>
    /// <typeparam name="T">The type of the number.</typeparam>
    /// <param name="x">The number to calculate the hyperbolic tangent of.</param>
    /// <returns>The hyperbolic tangent of the number.</returns>
    /// <remarks>Uses the formula (e^x - e^-x) / (e^x + e^-x) </remarks>
    public static T TanhP<T>(T x) where T : IPowerFunctions<T> => (Exp(x) - Exp(-x)) / (Exp(x) + Exp(-x));

    /// <summary>
    /// Calculates the hyperbolic tangent of a number using the power series.
    /// </summary>
    /// <typeparam name="T">The type of the number.</typeparam>
    /// <param name="x">The number to calculate the hyperbolic tangent of.</param>
    /// <param name="n">The number of fractions in the series. Must be greater than 1.</param>
    /// <returns>The hyperbolic tangent of the number.</returns>
    /// <exception cref="ArgumentOutOfRangeException">Thrown if n is less than 1.</exception>
    public static T TanhPS<T>(T x, int n) where T : INumberBase<T>, IComparisonOperators<T, T, bool> => SinhPS(x, n) / CoshPS(x, n);

    /// <summary>
    /// Calculates the hyperbolic secant of a number.
    /// </summary>
    /// <typeparam name="T">The type of the number.</typeparam>
    /// <param name="x">The number to calculate the hyperbolic secant of.</param>
    /// <returns>The hyperbolic secant of the number.</returns>
    /// <remarks>Uses the formula 1 / Cosh(x).</remarks>
    public static T Sech<T>(T x) where T : IHyperbolicFunctions<T> => T.One / T.Cosh(x);

    /// <summary>
    /// Calculates the hyperbolic secant of a number.
    /// </summary>
    /// <typeparam name="T">The type of the number.</typeparam>
    /// <param name="x">The number to calculate the hyperbolic secant of.</param>
    /// <returns>The hyperbolic secant of the number.</returns>
    /// <remarks>Uses the formula 1 / Cosh(x).</remarks>
    /// <returns>The hyperbolic secant of the number.</returns>
    /// <exception cref="ArgumentOutOfRangeException">Thrown if n is less than 1.</exception>
    public static T SechP<T>(T x) where T : IPowerFunctions<T> => T.One / CoshP(x);

    /// <summary>
    /// Calculates the hyperbolic secant of a number using the power series.
    /// </summary>
    /// <typeparam name="T">The type of the number.</typeparam>
    /// <param name="x">The number to calculate the hyperbolic secant of.</param>
    /// <param name="n">The number of fractions in the series. Must be greater than 1.</param>
    /// <returns>The hyperbolic secant of the number.</returns>
    /// <remarks>Uses the formula 1 / Cosh(x).</remarks>
    /// <exception cref="ArgumentOutOfRangeException">Thrown if n is less than 1.</exception>
    public static T SechPS<T>(T x, int n) where T : INumberBase<T>, IComparisonOperators<T, T, bool> => T.One / CoshPS(x, n);

    /// <summary>
    /// Calculates the hyperbolic cosecant of a number.
    /// </summary>
    /// <typeparam name="T">The type of the number.</typeparam>
    /// <param name="x">The number to calculate the hyperbolic cosecant of.</param>
    /// <returns>The hyperbolic cosecant of the number.</returns>
    /// <remarks>Uses the formula 1 / Sinh(x).</remarks>
    public static T Csch<T>(T x) where T : IHyperbolicFunctions<T> => T.One / T.Sinh(x);

    /// <summary>
    /// Calculates the hyperbolic cosecant of a number using the power series.
    /// </summary>
    /// <typeparam name="T">The type of the number.</typeparam>
    /// <param name="x">The number to calculate the hyperbolic cosecant of.</param>
    /// <returns>The hyperbolic cosecant of the number.</returns>
    /// <remarks>Uses the formula 1 / Sinh(x).</remarks>
    /// <returns>The hyperbolic cosecant of the number.</returns>
    /// <exception cref="ArgumentOutOfRangeException">Thrown if n is less than 1.</exception>
    public static T CschP<T>(T x) where T : IPowerFunctions<T> => T.One / SinhP(x);

    /// <summary>
    /// Calculates the hyperbolic cosecant of a number using the power series.
    /// </summary>
    /// <typeparam name="T">The type of the number.</typeparam>
    /// <param name="x">The number to calculate the hyperbolic cosecant of.</param>
    /// <param name="n">The number of fractions in the series. Must be greater than 1.</param>
    /// <returns>The hyperbolic cosecant of the number.</returns>
    /// <exception cref="ArgumentOutOfRangeException">Thrown if n is less than 1.</exception>
    public static T CschPS<T>(T x, int n) where T : INumberBase<T>, IComparisonOperators<T, T, bool> => T.One / SinhPS(x, n);

    /// <summary>
    /// Calculates the hyperbolic cotangent of a number.
    /// </summary>
    /// <typeparam name="T">The type of the number.</typeparam>
    /// <param name="x">The number to calculate the hyperbolic cotangent of.</param>
    /// <returns>The hyperbolic cotangent of the number.</returns>
    public static T Coth<T>(T x) where T : IHyperbolicFunctions<T> => T.One / T.Tanh(x);

    /// <summary>
    /// Calculates the hyperbolic cotangent of a number using the power series.
    /// </summary>
    /// <typeparam name="T">The type of the number.</typeparam>
    /// <param name="x">The number to calculate the hyperbolic cotangent of.</param>
    /// <returns>The hyperbolic cotangent of the number.</returns>
    /// <remarks>Uses the formula 1 / Tanh(x).</remarks>
    /// <returns>The hyperbolic cotangent of the number.</returns>
    /// <exception cref="ArgumentOutOfRangeException">Thrown if n is less than 1.</exception>
    public static T CothP<T>(T x) where T : IPowerFunctions<T> => T.One / TanhP(x);

    /// <summary>
    /// Calculates the hyperbolic cotangent of a number using the power series.
    /// </summary>
    /// <typeparam name="T">The type of the number.</typeparam>
    /// <param name="x">The number to calculate the hyperbolic cotangent of.</param>
    /// <param name="n">The number of fractions in the series. Must be greater than 1.</param>
    /// <returns>The hyperbolic cotangent of the number.</returns>
    /// <exception cref="ArgumentOutOfRangeException">Thrown if n is less than 1.</exception>
    public static T CothPS<T>(T x, int n) where T : INumberBase<T>, IComparisonOperators<T, T, bool> => T.One / TanhPS(x, n);


    /// <summary>
    /// Calculates the inverse hyperbolic sine of a number.
    /// </summary>
    /// <typeparam name="T">The type of the number.</typeparam>
    /// <param name="x">The number to calculate the inverse hyperbolic sine of.</param>
    /// <returns>The inverse hyperbolic sine of the number.</returns>
    public static T Asinh<T>(T x) where T : IHyperbolicFunctions<T> => T.Asinh(x);

    /// <summary>
    /// Calculates the inverse hyperbolic cosine of a number.
    /// </summary>
    /// <typeparam name="T">The type of the number.</typeparam>
    /// <param name="x">The number to calculate the inverse hyperbolic cosine of.</param>
    /// <returns>The inverse hyperbolic cosine of the number.</returns>
    public static T Acosh<T>(T x) where T : IHyperbolicFunctions<T> => T.Acosh(x);

    /// <summary>
    /// Calculates the inverse hyperbolic tangent of a number.
    /// </summary>
    /// <typeparam name="T">The type of the number.</typeparam>
    /// <param name="x">The number to calculate the inverse hyperbolic tangent of.</param>
    /// <returns>The inverse hyperbolic tangent of the number.</returns>
    public static T Atanh<T>(T x) where T : IHyperbolicFunctions<T> => T.Atanh(x);

    #endregion

    #region Special Functions

    /// <summary>
    /// Calculates the factorial of a number.
    /// </summary>
    /// <typeparam name="T">The type of the number.</typeparam>
    /// <param name="x">The number to calculate the factorial of.</param>
    /// <returns>The factorial of the number.</returns>
    /// <exception cref="ArgumentOutOfRangeException">Thrown when the number is negative.</exception>
    public static T Factorial<T>(T x) where T : INumberBase<T>
    {
        if (T.IsNegative(x) || T.IsZero(x)) return T.One;

        T result = T.One;
        for(T i = x; !T.IsZero(i); i--)
        {
            result *= i;
        }
        return result;
    }

    #endregion
}