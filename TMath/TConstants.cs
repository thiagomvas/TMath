using System.Numerics;

namespace TMath;

/// <summary>
/// Offers a variety of constants with up to 28 decimal places of precision.
/// </summary>
/// <typeparam name="T"></typeparam>
public static class TConstants<T> where T : INumber<T>
{
    /// <summary>
    /// The value of Euler's Number.
    /// </summary>
    public static readonly T E = T.CreateSaturating(2.71828_18284_59045_23536_02874_714m);

    /// <summary>
    /// The value of Pi
    /// </summary>
    public static readonly T Pi = T.CreateSaturating(3.14159_26535_89793_23846_26433_832m);

    /// <summary>
    /// The value of the Golden Ratio, a number that satisfies Phi = 1 + 1 / Phi.
    /// </summary>
    public static readonly T GoldenRatio = T.CreateSaturating(1.61803_39887_49894_84820_45868_344m);

    /// <summary>
    /// The value of the square root of 2.
    /// </summary>
    public static readonly T Sqrt2 = T.CreateSaturating(1.41421_35623_73095_04880_16887_242m);

    /// <summary>
    /// The value of the square root of 3.
    /// </summary>
    public static readonly T Sqrt3 = T.CreateSaturating(1.73205_08075_68877_29352_74463_415m);

}