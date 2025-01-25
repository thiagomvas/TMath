using System.Numerics;
namespace TMath;

/// <summary>
/// Contains alternate implementations of the MathT class for supporting more numeric types that don't implement the default interfaces.
/// </summary>
public class AlternateMathT
{
    internal AlternateMathT()
    {
    }

    #region Hyperbolics

    /// <summary>
    /// Computes the hyperbolic sine of a number using exponential formulas.
    /// </summary>
    /// <param name="n">The value whose hyperbolic sine is to be computed</param>
    /// <typeparam name="TSelf">The numeric type.</typeparam>
    /// <returns>The hyperbolic sine of <paramref name="n"/></returns>
    public static TSelf Sinh<TSelf>(TSelf n) where TSelf : IPowerFunctions<TSelf>
    {
        TSelf expPositive = Exp(n); // e^n
        TSelf expNegative = Exp(-n); // e^(-n)
        return (expPositive - expNegative) / Constants<TSelf>.Two; // (e^n - e^(-n)) / 2
    }

    /// <summary>
    /// Computes the hyperbolic cosine of a number using exponential formulas.
    /// </summary>
    /// <param name="n">The value whose hyperbolic cosine is to be computed</param>
    /// <typeparam name="TSelf">The numeric type.</typeparam>
    /// <returns>The hyperbolic cosine of <paramref name="n"/></returns>
    public static TSelf Cosh<TSelf>(TSelf n) where TSelf : IPowerFunctions<TSelf>
    {
        TSelf expPositive = Exp(n); // e^n
        TSelf expNegative = Exp(-n); // e^(-n)
        return (expPositive + expNegative) / Constants<TSelf>.Two; // (e^n + e^(-n)) / 2
    }

    /// <summary>
    /// Computes the hyperbolic tangent of a number using exponential formulas.
    /// </summary>
    /// <param name="n">The value whose hyperbolic tangent is to be computed</param>
    /// <typeparam name="TSelf">The numeric type.</typeparam>
    /// <returns>The hyperbolic tangent of <paramref name="n"/></returns>
    public static TSelf Tanh<TSelf>(TSelf n) where TSelf : IPowerFunctions<TSelf>
    {
        TSelf expPositive = Exp(n); // e^n
        TSelf expNegative = Exp(-n); // e^(-n)
        return (expPositive - expNegative) / (expPositive + expNegative); // (e^n - e^(-n)) / (e^n + e^(-n))
    }

    /// <summary>
    /// Computes the hyperbolic secant of a number using exponential formulas.
    /// </summary>
    /// <param name="n">The value whose hyperbolic secant is to be computed</param>
    /// <typeparam name="TSelf">The numeric type.</typeparam>
    /// <returns>The hyperbolic secant of <paramref name="n"/></returns>
    public static TSelf Sech<TSelf>(TSelf n) where TSelf : INumberBase<TSelf>, IPowerFunctions<TSelf>
    {
        TSelf expPositive = Exp(n); // e^n
        TSelf expNegative = Exp(-n); // e^(-n)
        return Constants<TSelf>.Two / (expPositive + expNegative); // 2 / (e^n + e^(-n))
    }

    /// <summary>
    /// Computes the hyperbolic cosecant of a number using exponential formulas.
    /// </summary>
    /// <param name="n">The value whose hyperbolic cosecant is to be computed</param>
    /// <typeparam name="TSelf">The numeric type.</typeparam>
    /// <returns>The hyperbolic cosecant of <paramref name="n"/></returns>
    public static TSelf Csch<TSelf>(TSelf n) where TSelf : INumberBase<TSelf>, IPowerFunctions<TSelf>
    {
        TSelf expPositive = Exp(n); // e^n
        TSelf expNegative = Exp(-n); // e^(-n)
        return Constants<TSelf>.Two / (expPositive - expNegative); // 2 / (e^n - e^(-n))
    }

    /// <summary>
    /// Computes the hyperbolic cotangent of a number using exponential formulas.
    /// </summary>
    /// <param name="n">The value whose hyperbolic cotangent is to be computed</param>
    /// <typeparam name="TSelf">The numeric type.</typeparam>
    /// <returns>The hyperbolic cotangent of <paramref name="n"/></returns>
    public static TSelf Coth<TSelf>(TSelf n) where TSelf : INumberBase<TSelf>, IPowerFunctions<TSelf>
    {
        TSelf expPositive = Exp(n); // e^n
        TSelf expNegative = Exp(-n); // e^(-n)
        return (expPositive + expNegative) / (expPositive - expNegative); // (e^n + e^(-n)) / (e^n - e^(-n))
    }

    #endregion


    #region Special & Others

    /// <summary>
    /// Computes the exponential function of a number.
    /// </summary>
    /// <param name="n">The value whose exponential function is to be computed</param>
    /// <typeparam name="TSelf">The numeric type.</typeparam>
    /// <returns>The exponential function of <paramref name="n"/></returns>
    public static TSelf Exp<TSelf>(TSelf n) where TSelf : IPowerFunctions<TSelf> => TSelf.Pow(n, Constants<TSelf>.E);

    #endregion
}