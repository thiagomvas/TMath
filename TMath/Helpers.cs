using System.Numerics;

namespace TMath;

internal static class Helpers
{
    public static TTarget Count<TTarget, TSource>(IEnumerable<TSource> elements) where TTarget : INumberBase<TTarget>
    {
        TTarget total = TTarget.Zero;
        foreach (var element in elements)
        {
            total++;
        }

        return total;
    }
}