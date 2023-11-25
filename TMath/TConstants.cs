using System.Numerics;

namespace TMath;

public static class TConstants<T> where T : INumber<T>
{
    public static readonly T E = T.CreateSaturating(2.71828_18284_59045_23536_02874_714m);
    public static readonly T Pi = T.CreateSaturating(3.14159_26535_89793_23846_26433_832m);
    public static readonly T GoldenRatio = T.CreateSaturating(1.61803_39887_49894_84820_45868_344m);
    public static readonly T Sqrt2 = T.CreateSaturating(1.41421_35623_73095_04880_16887_242m);
    public static readonly T Sqrt3 = T.CreateSaturating(1.73205_08075_68877_29352_74463_415m);
}