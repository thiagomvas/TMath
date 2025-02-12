using System.Numerics;

namespace TMath;

/// <summary>
/// Generics math class for numeric operations.
/// </summary>
public static class MathT
{
    /// <summary>
    /// Alternate implementation of the MathT class for supporting more numeric types that don't implement the default interfaces.
    /// </summary>
    public static readonly AlternateMathT Alternate = new();

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

    /// <summary>
    /// Returns the smaller of two values.
    /// </summary>
    /// <param name="a">The first value to compare</param>
    /// <param name="b">The second value to compare</param>
    /// <typeparam name="TSelf">The numeric type.</typeparam>
    /// <returns>The smaller of <paramref name="a"/> and <paramref name="b"/></returns>
    public static TSelf Min<TSelf>(TSelf a, TSelf b)
        where TSelf : INumberBase<TSelf>, IComparisonOperators<TSelf, TSelf, bool>
        => a < b ? a : b;

    /// <summary>
    /// Returns the larger of two values.
    /// </summary>
    /// <param name="a">The first value to compare</param>
    /// <param name="b">The second value to compare</param>
    /// <typeparam name="TSelf">The numeric type.</typeparam>
    /// <returns>The larger of <paramref name="a"/> and <paramref name="b"/></returns>
    public static TSelf Max<TSelf>(TSelf a, TSelf b)
        where TSelf : INumberBase<TSelf>, IComparisonOperators<TSelf, TSelf, bool>
        => a > b ? a : b;

    /// <summary>
    /// Clamps a value to be within a specified range.
    /// </summary>
    /// <param name="value">The value to clamp</param>
    /// <param name="min">The minimum value of the range</param>
    /// <param name="max">The maximum value of the range</param>
    /// <typeparam name="TSelf">The numeric type.</typeparam>
    /// <returns>The clamped value of <paramref name="value"/> within the range [<paramref name="min"/>, <paramref name="max"/>]</returns>
    public static TSelf Clamp<TSelf>(TSelf value, TSelf min, TSelf max)
        where TSelf : INumberBase<TSelf>, IComparisonOperators<TSelf, TSelf, bool>
        => value < min ? min : value > max ? max : value;

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

    #region Roots

    /// <summary>
    /// Computes the square root of a number.
    /// </summary>
    /// <param name="n">The value whose square root is to be computed</param>
    /// <typeparam name="TSelf">The numeric type.</typeparam>
    /// <returns>The square root of <paramref name="n"/></returns>
    public static TSelf Sqrt<TSelf>(TSelf n) where TSelf : IRootFunctions<TSelf> => TSelf.Sqrt(n);

    /// <summary>
    /// Computes the cube root of a number.
    /// </summary>
    /// <param name="n">The value whose cube root is to be computed</param>
    /// <typeparam name="TSelf">The numeric type.</typeparam>
    /// <returns>The cube root of <paramref name="n"/></returns>
    public static TSelf Cbrt<TSelf>(TSelf n) where TSelf : IRootFunctions<TSelf> => TSelf.Cbrt(n);

    /// <summary>
    /// Computes the nth root of a number.
    /// </summary>
    /// <param name="n">The value whose nth root is to be computed</param>
    /// <param name="root">The degree of the root</param>
    /// <typeparam name="TSelf">The numeric type.</typeparam>
    /// <returns>The nth root of <paramref name="n"/></returns>
    public static TSelf RootN<TSelf>(TSelf n, int root) where TSelf : IRootFunctions<TSelf> => TSelf.RootN(n, root);

    #endregion

    #region Logarithm

    /// <summary>
    /// Computes the base-2 logarithm of a number.
    /// </summary>
    /// <param name="n">The value whose base-2 logarithm is to be computed</param>
    /// <typeparam name="TSelf">The numeric type.</typeparam>
    /// <returns>The base-2 logarithm of <paramref name="n"/></returns>
    public static TSelf Log2<TSelf>(TSelf n) where TSelf : ILogarithmicFunctions<TSelf> => TSelf.Log2(n);

    /// <summary>
    /// Computes the base-10 logarithm of a number.
    /// </summary>
    /// <param name="n">The value whose base-10 logarithm is to be computed</param>
    /// <typeparam name="TSelf">The numeric type.</typeparam>
    /// <returns>The base-10 logarithm of <paramref name="n"/></returns>
    public static TSelf Log10<TSelf>(TSelf n) where TSelf : ILogarithmicFunctions<TSelf> => TSelf.Log10(n);

    /// <summary>
    /// Computes the natural logarithm (base e) of a number.
    /// </summary>
    /// <param name="n">The value whose natural logarithm is to be computed</param>
    /// <typeparam name="TSelf">The numeric type.</typeparam>
    /// <returns>The natural logarithm of <paramref name="n"/></returns>
    public static TSelf Ln<TSelf>(TSelf n) where TSelf : ILogarithmicFunctions<TSelf> => TSelf.Log(n);

    /// <summary>
    /// Computes the logarithm of a number in a specified base.
    /// </summary>
    /// <param name="n">The value whose logarithm is to be computed</param>
    /// <param name="b">The base of the logarithm</param>
    /// <typeparam name="TSelf">The numeric type.</typeparam>
    /// <returns>The logarithm of <paramref name="n"/> in the specified base <paramref name="b"/></returns>
    public static TSelf Log<TSelf>(TSelf n, TSelf b) where TSelf : ILogarithmicFunctions<TSelf> => TSelf.Log(n, b);

    #endregion

    #region Hyperbolics

    /// <summary>
    /// Computes the hyperbolic sine of a number.
    /// </summary>
    /// <param name="n">The value whose hyperbolic sine is to be computed</param>
    /// <typeparam name="TSelf">The numeric type.</typeparam>
    /// <returns>The hyperbolic sine of <paramref name="n"/></returns>
    public static TSelf Sinh<TSelf>(TSelf n) where TSelf : IHyperbolicFunctions<TSelf> => TSelf.Sinh(n);

    /// <summary>
    /// Computes the hyperbolic cosine of a number.
    /// </summary>
    /// <param name="n">The value whose hyperbolic cosine is to be computed</param>
    /// <typeparam name="TSelf">The numeric type.</typeparam>
    /// <returns>The hyperbolic cosine of <paramref name="n"/></returns>
    public static TSelf Cosh<TSelf>(TSelf n) where TSelf : IHyperbolicFunctions<TSelf> => TSelf.Cosh(n);

    /// <summary>
    /// Computes the hyperbolic tangent of a number.
    /// </summary>
    /// <param name="n">The value whose hyperbolic tangent is to be computed</param>
    /// <typeparam name="TSelf">The numeric type.</typeparam>
    /// <returns>The hyperbolic tangent of <paramref name="n"/></returns>
    public static TSelf Tanh<TSelf>(TSelf n) where TSelf : IHyperbolicFunctions<TSelf> => TSelf.Tanh(n);

    /// <summary>
    /// Computes the hyperbolic secant of a number.
    /// </summary>
    /// <param name="n">The value whose hyperbolic secant is to be computed</param>
    /// <typeparam name="TSelf">The numeric type.</typeparam>
    /// <returns>The hyperbolic secant of <paramref name="n"/></returns>
    public static TSelf Sech<TSelf>(TSelf n) where TSelf : INumberBase<TSelf>, IHyperbolicFunctions<TSelf>
        => TSelf.One / Sinh(n);

    /// <summary>
    /// Computes the hyperbolic cosecant of a number.
    /// </summary>
    /// <param name="n">The value whose hyperbolic cosecant is to be computed</param>
    /// <typeparam name="TSelf">The numeric type.</typeparam>
    /// <returns>The hyperbolic cosecant of <paramref name="n"/></returns>
    public static TSelf Csch<TSelf>(TSelf n) where TSelf : INumberBase<TSelf>, IHyperbolicFunctions<TSelf>
        => TSelf.One / Cosh(n);

    /// <summary>
    /// Computes the hyperbolic cotangent of a number.
    /// </summary>
    /// <param name="n">The value whose hyperbolic cotangent is to be computed</param>
    /// <typeparam name="TSelf">The numeric type.</typeparam>
    /// <returns>The hyperbolic cotangent of <paramref name="n"/></returns>
    public static TSelf Coth<TSelf>(TSelf n) where TSelf : INumberBase<TSelf>, IHyperbolicFunctions<TSelf>
        => TSelf.One / Tanh(n);

    #endregion

    #region Number Theory

    /// <summary>
    /// Calculates the Greatest Common Divisor (GCD) of a collection of numbers.
    /// </summary>
    /// <remarks>
    /// The GCD is the largest positive integer that divides each number in the collection without a remainder.
    /// Requires numbers to implement <see cref="INumberBase{T}"/> and <see cref="IBinaryInteger{T}"/> interfaces.
    /// </remarks>
    /// <typeparam name="T">Type of numbers in the collection implementing <see cref="INumberBase{T}"/> and <see cref="IBinaryInteger{T}"/>.</typeparam>
    /// <param name="source">Collection of numbers for GCD calculation.</param>
    /// <returns>The Greatest Common Divisor of the numbers in the collection.</returns>
    /// <exception cref="ArgumentNullException">Thrown when the input collection is null.</exception>
    /// <exception cref="ArgumentException">Thrown when the input collection is empty.</exception>
    public static T GCD<T>(IEnumerable<T> source) where T : INumberBase<T>, IBinaryInteger<T>
    {
        if (source == null)
            throw new ArgumentNullException(nameof(source), "Collection must not be null");

        if (!source.Any())
            throw new ArgumentException("Collection must not be empty", nameof(source));

        return source.Aggregate(Helpers.GCD);
    }

    /// <summary>
    /// Calculates the Greatest Common Divisor (GCD) of a collection of numbers.
    /// </summary>
    /// <remarks>
    /// The GCD is the largest positive integer that divides each number in the collection without a remainder.
    /// Requires numbers to implement <see cref="INumberBase{T}"/> and <see cref="IBinaryInteger{T}"/> interfaces.
    /// </remarks>
    /// <typeparam name="T">Type of numbers in the collection implementing <see cref="INumberBase{T}"/> and <see cref="IBinaryInteger{T}"/>.</typeparam>
    /// <param name="source">Collection of numbers for GCD calculation.</param>
    /// <returns>The Greatest Common Divisor of the numbers in the collection.</returns>
    /// <exception cref="ArgumentNullException">Thrown when the input collection is null.</exception>
    /// <exception cref="ArgumentException">Thrown when the input collection is empty.</exception>
    public static T GCD<T>(params T[] source) where T : INumberBase<T>, IBinaryInteger<T>
    {
        return GCD(source.AsEnumerable());
    }

    /// <summary>
    /// Calculates the Least Common Multiple (LCM) of a collection of numbers.
    /// </summary>
    /// <remarks>
    /// The LCM is the smallest positive integer that is divisible by each number in the collection.
    /// Requires numbers to implement <see cref="INumberBase{T}"/> and <see cref="IBinaryInteger{T}"/> interfaces.
    /// </remarks>
    /// <typeparam name="T">Type of numbers in the collection implementing <see cref="INumberBase{T}"/> and <see cref="IBinaryInteger{T}"/>.</typeparam>
    /// <param name="source">Collection of numbers for LCM calculation.</param>
    /// <returns>The Least Common Multiple of the numbers in the collection.</returns>
    /// <exception cref="ArgumentNullException">Thrown when the input collection is null.</exception>
    /// <exception cref="ArgumentException">Thrown when the input collection is empty.</exception>
    public static T LCM<T>(IEnumerable<T> source) where T : INumberBase<T>, IBinaryInteger<T>
    {
        if (source == null)
            throw new ArgumentNullException(nameof(source), "Collection must not be null");

        if (!source.Any())
            throw new ArgumentException("Collection must not be empty", nameof(source));

        return source.Distinct().Aggregate((a, b) => a * b / Helpers.GCD(a, b));
    }
    
    /// <summary>
    /// Calculates the Least Common Multiple (LCM) of a collection of numbers.
    /// </summary>
    /// <remarks>
    /// The LCM is the smallest positive integer that is divisible by each number in the collection.
    /// Requires numbers to implement <see cref="INumberBase{T}"/> and <see cref="IBinaryInteger{T}"/> interfaces.
    /// </remarks>
    /// <typeparam name="T">Type of numbers in the collection implementing <see cref="INumberBase{T}"/> and <see cref="IBinaryInteger{T}"/>.</typeparam>
    /// <param name="source">Collection of numbers for LCM calculation.</param>
    /// <returns>The Least Common Multiple of the numbers in the collection.</returns>
    /// <exception cref="ArgumentNullException">Thrown when the input collection is null.</exception>
    /// <exception cref="ArgumentException">Thrown when the input collection is empty.</exception>
    public static T LCM<T>(params T[] source) where T : INumberBase<T>, IBinaryInteger<T>
    {
        return LCM(source.AsEnumerable());
    }

    /// <summary>
    /// Retrieves the dividers of a given number.
    /// </summary>
    /// <remarks>
    /// The dividers are the positive integers that divide the given number without a remainder.
    /// Requires the number to be greater than 0 and to implement <see cref="INumberBase{T}"/> and <see cref="IBinaryInteger{T}"/> interfaces.
    /// </remarks>
    /// <typeparam name="T">Type of the number implementing <see cref="INumberBase{T}"/> and <see cref="IBinaryInteger{T}"/>.</typeparam>
    /// <param name="number">The number for which to retrieve the dividers.</param>
    /// <returns>Enumerable collection of dividers of the given number.</returns>
    /// <exception cref="ArgumentOutOfRangeException">Thrown when the input number is less than or equal to 0.</exception>
    public static IEnumerable<T> Dividers<T>(T number) where T : INumberBase<T>, IBinaryInteger<T>
    {
        if (number < T.One)
            throw new ArgumentOutOfRangeException(nameof(number), "Number must be greater than 0");

        List<T> dividers = new();
        var limit = number / Constants<T>.Two;
        for (T i = T.One; i <= limit; i++)
        {
            if (number % i == T.Zero)
                dividers.Add(i);
        }

        dividers.Add(number);

        return dividers.AsEnumerable();
    }

    /// <summary>
    /// Calculates Euler's Totient function for a given number.
    /// </summary>
    /// <remarks>
    /// Euler's Totient function, denoted as φ(n), is the count of positive integers less than or equal to n that are coprime to n.
    /// Requires the number to implement <see cref="INumberBase{T}"/> and <see cref="IBinaryInteger{T}"/> interfaces.
    /// </remarks>
    /// <typeparam name="T">Type of the number implementing <see cref="INumberBase{T}"/> and <see cref="IBinaryInteger{T}"/>.</typeparam>
    /// <param name="number">The number for which to calculate Euler's Totient.</param>
    /// <returns>The result of Euler's Totient function for the given number.</returns>
    public static T EulersTotient<T>(T number) where T : INumberBase<T>, IBinaryInteger<T>
    {
        T result = number;
        for (T i = Constants<T>.Two; i * i <= number; i++)
        {
            if (number % i == T.Zero)
            {
                while (number % i == T.Zero)
                {
                    number /= i;
                }

                result -= result / i;
            }
        }

        if (number > T.One)
        {
            result -= result / number;
        }

        return result;
    }

    /// <summary>
    /// Checks if a given number is a perfect number.
    /// </summary>
    /// <remarks>
    /// A perfect number is a positive integer that is equal to the sum of its proper divisors (excluding itself).
    /// Requires the number to be greater than 0 and to implement <see cref="INumberBase{T}"/> and <see cref="IBinaryInteger{T}"/> interfaces.
    /// </remarks>
    /// <typeparam name="T">Type of the number implementing <see cref="INumberBase{T}"/> and <see cref="IBinaryInteger{T}"/>.</typeparam>
    /// <param name="number">The number to check for perfection.</param>
    /// <returns>True if the number is a perfect number, otherwise false.</returns>
    public static bool IsPerfectNumber<T>(T number) where T : INumberBase<T>, IBinaryInteger<T>
    {
        if (number < T.One)
            return false;

        return number == Dividers(number).Aggregate((a, b) => a + b) - number;
    }

    /// <summary>
    /// Generates the Collatz Conjecture sequence for a given number.
    /// </summary>
    /// <remarks>
    /// The Collatz Conjecture is a sequence defined for a positive integer:
    /// If the number is even, divide it by 2; if it's odd, multiply it by 3 and add 1.
    /// The sequence continues until the number becomes 1.
    /// Requires the number to be greater than 0 and to implement <see cref="INumberBase{T}"/> and <see cref="IBinaryInteger{T}"/> interfaces.
    /// </remarks>
    /// <typeparam name="T">Type of the number implementing <see cref="INumberBase{T}"/> and <see cref="IBinaryInteger{T}"/>.</typeparam>
    /// <param name="number">The starting number for the Collatz Conjecture sequence.</param>
    /// <returns>Enumerable collection representing the Collatz Conjecture sequence for the given number.</returns>
    /// <exception cref="ArgumentOutOfRangeException">Thrown when the input number is less than or equal to 0.</exception>
    public static IEnumerable<T> CollatzConjecture<T>(T number) where T : INumberBase<T>, IBinaryInteger<T>
    {
        if (number < T.One)
            throw new ArgumentOutOfRangeException(nameof(number), "Number must be greater than 0");

        List<T> vals = new() { number };
        T Two = Constants<T>.Two;
        T Three = Two + T.One;
        while (number != T.One)
        {
            if (number % Two == T.Zero)
                number /= Two;
            else
                number = number * Three + T.One;
            vals.Add(number);
        }

        return vals.AsEnumerable();
    }

    /// <summary>
    /// Checks if a given number is a prime number.
    /// </summary>
    /// <remarks>
    /// A prime number is a positive integer greater than 1 that has no positive divisors other than 1 and itself.
    /// Requires the number to implement <see cref="INumberBase{T}"/> and <see cref="IBinaryInteger{T}"/> interfaces.
    /// </remarks>
    /// <typeparam name="T">Type of the number implementing <see cref="INumberBase{T}"/> and <see cref="IBinaryInteger{T}"/>.</typeparam>
    /// <param name="number">The number to check for primality.</param>
    /// <returns>True if the number is prime, otherwise false.</returns>
    public static bool IsPrime<T>(T number) where T : INumberBase<T>, IBinaryInteger<T>
    {
        T two = Constants<T>.Two;
        if (number < two)
            return false;
        if (number == two)
            return true;
        if (number % two == T.Zero)
            return false;
        for (T i = two + T.One; i * i <= number; i += two)
        {
            if (number % i == T.Zero)
                return false;
        }

        return true;
    }

    /// <summary>
    /// Generates a sequence of prime numbers up to a given limit.
    /// </summary>
    /// <remarks>
    /// Generates all prime numbers up to the specified limit using the Sieve of Eratosthenes algorithm.
    /// Requires the number to be greater than 0 and to implement <see cref="INumberBase{T}"/> and <see cref="IBinaryInteger{T}"/> interfaces.
    /// </remarks>
    /// <typeparam name="T">Type of the number implementing <see cref="INumberBase{T}"/> and <see cref="IBinaryInteger{T}"/>.</typeparam>
    /// <param name="number">The limit up to which to generate prime numbers.</param>
    /// <returns>Enumerable collection of prime numbers up to the specified limit.</returns>
    /// <exception cref="ArgumentOutOfRangeException">Thrown when the input number is less than or equal to 0.</exception>
    public static IEnumerable<T> GeneratePrimesUpTo<T>(T number) where T : INumberBase<T>, IBinaryInteger<T>
    {
        if (number < T.One)
            throw new ArgumentOutOfRangeException(nameof(number), "Number must be greater than 0");

        T[] nums = Helpers.NumberSequence(T.One, number).ToArray();

        T p = Constants<T>.Two;

        int index = 1;

        while (p * p <= number)
        {
            p = nums[index];
            for (T i = Constants<T>.Two; i * p <= number; i++)
            {
                nums[int.CreateSaturating(i * p - T.One)] = T.Zero;
            }

            index++;
            while (nums[index] == T.Zero)
            {
                index++;
            }
        }

        return nums.Where(x => x > T.One);
    }

    #endregion

    #region Special & Others

    /// <summary>
    /// Computes the power of a number raised to another number.
    /// </summary>
    /// <param name="x">The base value</param>
    /// <param name="y">The exponent value</param>
    /// <typeparam name="TSelf">The numeric type.</typeparam>
    /// <returns>The result of raising <paramref name="x"/> to the power of <paramref name="y"/></returns>
    public static TSelf Pow<TSelf>(TSelf x, TSelf y) where TSelf : IPowerFunctions<TSelf> => TSelf.Pow(x, y);

    /// <summary>
    /// Computes the power of a number raised to an integer exponent.
    /// </summary>
    /// <param name="x">The base value</param>
    /// <param name="y">The integer exponent value</param>
    /// <typeparam name="TSelf">The numeric type.</typeparam>
    /// <returns>The result of raising <paramref name="x"/> to the power of <paramref name="y"/></returns>
    public static TSelf Pow<TSelf>(TSelf x, int y) where TSelf : INumberBase<TSelf>
    {
        if (y == 0)
            return TSelf.One;
        if (y == 1)
            return x;
        if (y < 0)
            return TSelf.One / Pow(x, -y);

        TSelf result = TSelf.One;
        while (y > 0)
        {
            result *= x;
            y--;
        }

        return result;
    }

    /// <summary>
    /// Computes the exponential function of a number.
    /// </summary>
    /// <param name="n">The value whose exponential function is to be computed</param>
    /// <typeparam name="TSelf">The numeric type.</typeparam>
    /// <returns>The exponential function of <paramref name="n"/></returns>
    public static TSelf Exp<TSelf>(TSelf n) where TSelf : IExponentialFunctions<TSelf> => TSelf.Exp(n);

    /// <summary>
    /// Calculates the factorial of a number.
    /// </summary>
    /// <param name="n">The value to compute the factorial of.</param>
    /// <typeparam name="TSelf">The numeric type.</typeparam>
    /// <returns>The value of <paramref name="n"/>!</returns>
    /// <exception cref="ArgumentOutOfRangeException">When <paramref name="n"/> is negative.</exception>
    /// <remarks>
    /// For floating point types, the result is the factorial of ceiling of <paramref name="n"/>.
    /// </remarks>
    public static TSelf Factorial<TSelf>(TSelf n) where TSelf : INumberBase<TSelf>
    {
        // TODO: Alternate implementation for negative factorials using the gamma function
        if (TSelf.IsNegative(n))
            throw new ArgumentOutOfRangeException(nameof(n), "Cannot compute factorial of a negative number");
        if (TSelf.IsZero(n) || n == TSelf.One)
            return TSelf.One;

        TSelf result = TSelf.One;
        while (TSelf.IsPositive(n))
        {
            result *= n;
            n -= TSelf.One;
        }

        return result;
    }

    #endregion
}