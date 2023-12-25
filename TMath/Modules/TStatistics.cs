using System.Numerics;

namespace TMath.Modules
{
    /// <summary>
    /// A mathematical utility class providing statistical functions for data analysis, with functions like Mean, Standard deviation, and more.
    /// </summary>
    /// <remarks>
    /// This class supports generic calculations on any <see cref="IEnumerable{T}"/> where T is an <see cref="INumber{TSelf}"/>, encompassing
    /// floats, doubles, decimals, integers, or custom number types that implement the interface.
    /// </remarks>
    public static class TStatistics
    {
        public static T Mean<T>(IEnumerable<T> data) where T : INumber<T>
        {
            if(data.Count() == 0) return T.Zero;
            if(data.Count() == 1) return data.First();
            T sum = T.Zero;
            foreach (T d in data)
                sum += d;
            return sum / T.CreateSaturating(data.Count());
        }

        public static T Median<T>(IEnumerable<T> data) where T : INumber<T>
        {
            if (data.Count() == 0) return T.Zero;
            if (data.Count() == 1) return data.First();
            T[] sorted = data.ToArray();
            Array.Sort(sorted);
            if(sorted.Length % 2 == 0)
                return (sorted[sorted.Length / 2] + sorted[sorted.Length / 2 - 1]) / TFunctions.IntToT<T>(2);
            else return sorted[sorted.Length / 2];
        }
    }
}
