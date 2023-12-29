using System.Numerics;

namespace TMath;

/// <summary>
/// Offers a variety of constants with up to 28 decimal places of precision.
/// </summary>
/// <typeparam name="T"></typeparam>
public static class TConstants<T> where T : INumber<T>
{
    #region Mathematics

    /// <summary>
    /// The value of Euler's Number.
    /// </summary>
    public static readonly T E = T.CreateSaturating(2.71828_18284_59045_23536_02874_714m);

    /// <summary>
    /// The value of 1 / e, the inverse of Euler's Number.
    /// </summary>
    public static readonly T InvE = T.CreateSaturating(0.36787_94411_71442_32159_55258_287m);

    /// <summary>
    /// The value of Pi
    /// </summary>
    public static readonly T Pi = T.CreateSaturating(3.14159_26535_89793_23846_26433_832m);

    /// <summary>
    /// The value of 2 * Pi
    /// </summary>
    public static readonly T TwoPi = T.CreateSaturating(6.28318_53071_79586_47692_52867_666);

    /// <summary>
    /// The value of Pi^2
    /// </summary>
    public static readonly T PiSquared = T.CreateSaturating(9.86960_44010_89358_61883_44909_999);

    /// <summary>
    /// The value of Pi/2 (90 degrees in radians)
    /// </summary>
    public static readonly T PiOver2 = T.CreateSaturating(1.57079_63267_94896_61923_13216_916);

    /// <summary>
    /// The value of Pi/3 (60 degrees in radians)
    /// </summary>
    public static readonly T PiOver3 = T.CreateSaturating(1.04719_75511_96597_74615_42144_611);

    /// <summary>
    /// The value of Pi/4 (45 degrees in radians)
    /// </summary>
    public static readonly T PiOver4 = T.CreateSaturating(0.78539_81633_97448_30961_56608_458);

    /// <summary>
    /// The value of Pi/6 (30 degrees in radians)
    /// </summary>
    public static readonly T PiOver6 = T.CreateSaturating(0.52359_87755_98298_87307_71072_305);

    /// <summary>
    /// The value of 1 degree in radians
    /// </summary>
    /// <seealso cref="TFunctions.Rad2Deg{T}(T)"/>
    /// <seealso cref="TFunctions.ToRadians{T}(T)"/>
    public static readonly T Degree = T.CreateSaturating(0.01745_32925_19943_29576_92369_077);

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

    /// <summary>
    /// The value of the square root of 5.
    /// </summary>
    public static readonly T Sqrt5 = T.CreateSaturating(2.23606_79774_99789_69640_91736_687m);

    /// <summary>
    /// The value of the natural logarithm of 2.
    /// </summary>
    public static readonly T Ln2 = T.CreateSaturating(0.69314_71805_59945_30941_72321_214m);

    /// <summary>
    /// The value of the natural logarithm of 10.
    /// </summary>
    public static readonly T Ln10 = T.CreateSaturating(2.30258_50929_94045_68401_79914_547m);

    #endregion Mathematics

}