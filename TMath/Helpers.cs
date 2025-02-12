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
    
    public static IEnumerable<T> NumberSequence<T>(T min, T max) where T : INumber<T>
    {
        if (min > max)
        {
            (min, max) = (max, min);
        }

        T current = min;
        while (current <= max)
        {
            yield return current;
            current += T.One;
        }
    }
    
    public static T GCD<T>(T a, T b) where T : INumber<T>
    {
        while (b != T.Zero)
        {
            (a, b) = (b, a % b);
        }
        return a;
    }
}