using System.Numerics;

namespace TMath.Statistics;

internal static class Internals<T> where T : INumberBase<T>
{
    public static readonly T Two = T.CreateSaturating(2);
}