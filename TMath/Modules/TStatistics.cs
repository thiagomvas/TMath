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
        /// <summary>
        /// Calculates the mean of a set of data.
        /// </summary>
        /// <typeparam name="T">A floating point numeric type</typeparam>
        /// <param name="data">An <see cref="IEnumerable{T}"/> containing all the data</param>
        /// <returns>The mean of the data as <typeparamref name="T"/></returns>
        /// <remarks> The mean is the average of a set of data. Due to that, it is recommended to use floating point types as data.
        /// For integer types, the mean will be rounded down to the nearest integer. If more accuracy is needed, use the <see cref="Mean{TTarget,TSource}"/> overload
        /// </remarks>
        public static T Mean<T>(IEnumerable<T> data) where T : INumber<T>
        {
            if(data.Count() == 0) return T.Zero;
            if(data.Count() == 1) return data.First();
            T sum = T.Zero;
            foreach (T d in data)
                sum += d;
            return sum / T.CreateSaturating(data.Count());
        }

        /// <summary>
        /// Calculates the mean of a set of data.
        /// </summary>
        /// <typeparam name="TTarget">The target type to return the mean as</typeparam>
        /// <typeparam name="TSource">The type of the data</typeparam>
        /// <param name="data">An <see cref="IEnumerable{T}"/> containing all the data</param>
        /// <returns>The mean of the data set as a <typeparamref name="TTarget"/></returns>
        /// <remarks>
        /// This overload is slower due to converting types. It is however recommended for accurate results when using
        /// integer types as data, as it will not suffer from rounding errors when dividing integers.
        /// <br/>
        /// For floating point types or when rounding errors isn't an issue, use the <see cref="Mean{T}(IEnumerable{T})"/> overload.
        /// </remarks>
        public static TTarget Mean<TTarget, TSource>(IEnumerable<TSource> data) 
            where TTarget : INumber<TTarget>, IFloatingPoint<TTarget>
            where TSource : INumber<TSource>, IBinaryInteger<TSource>
        {
            if (data.Count() == 0) return TTarget.Zero;
            if (data.Count() == 1) return TTarget.CreateSaturating(data.First());
            TTarget sum = TTarget.Zero;
            foreach (TSource d in data)
                sum += TTarget.CreateSaturating(d);
            return sum / TTarget.CreateSaturating(data.Count());
        }

        /// <summary>
        /// Calculates the median of a set of data.
        /// </summary>
        /// <typeparam name="T">The data type</typeparam>
        /// <param name="data">An <see cref="IEnumerable{T}"/> containing all the data</param>
        /// <returns>The median of a the set of data</returns>
        /// <remarks>
        /// The median is the middle value of a set of data. If the set of data has an even number of values, the median is the average of the two middle values.
        /// For integer types, the median will be rounded down to the nearest integer. If more accuracy is needed, use the <see cref="Median{TTarget,TSource}"/> overload
        /// </remarks>
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

        /// <summary>
        /// Calculates the median of a set of data.
        /// </summary>
        /// <typeparam name="TTarget">The target type to return the median as </typeparam>
        /// <typeparam name="TSource">The source type of the data set</typeparam>
        /// <param name="data">An <see cref="IEnumerable{T}"/> containing all the data</param>
        /// <returns>The median of the set of data as a <typeparamref name="TTarget"/></returns>
        /// <remarks>
        /// The median is the middle value of a set of data. If the set of data has an even number of values, the median is the average of the two middle values.
        /// This overload is slower due to converting types. It is however recommended for accurate results when using integer types as data,
        /// as it will not suffer from rounding errors when dividing integers.
        /// </remarks>
        public static TTarget Median<TTarget, TSource>(IEnumerable<TSource> data) 
            where TTarget : INumber<TTarget>, IFloatingPoint<TTarget>
            where TSource : INumber<TSource>, IBinaryInteger<TSource>
        {
            if (data.Count() == 0) return TTarget.Zero;
            if (data.Count() == 1) return TTarget.CreateSaturating(data.First());
            TSource[] sorted = data.ToArray();
            Array.Sort(sorted);
            if (sorted.Length % 2 == 0)
                return (TTarget.CreateSaturating(sorted[sorted.Length / 2] + sorted[sorted.Length / 2 - 1])) / TFunctions.IntToT<TTarget>(2);
            else return TTarget.CreateSaturating(sorted[sorted.Length / 2]);
        }

        /// <summary>
        /// Calculates the mode of a set of data.
        /// </summary>
        /// <typeparam name="T">The numeric type of the data</typeparam>
        /// <param name="data">An <see cref="IEnumerable{T}"/> containing all the data</param>
        /// <returns>The mode of the set of data</returns>
        /// <remarks>
        /// The mode is the value that occurs most often in a set of data. If there are multiple modes, the first one is returned.
        /// </remarks>
        public static T Mode<T>(IEnumerable<T> data) where T : INumber<T>
        {
            if (data.Count() == 0) return T.Zero;
            if (data.Count() == 1) return data.First();
            Dictionary<T, int> counts = new Dictionary<T, int>();
            foreach (T d in data)
            {
                if (counts.ContainsKey(d))
                    counts[d]++;
                else counts.Add(d, 1);
            }
            int max = 0;
            T mode = T.Zero;
            foreach (KeyValuePair<T, int> pair in counts)
            {
                if (pair.Value > max)
                {
                    max = pair.Value;
                    mode = pair.Key;
                }
            }
            return mode;
        }

        public static T Variance<T>(IEnumerable<T> data) where T : INumber<T>, IFloatingPoint<T>
        {
            if (data.Count() <= 1) return T.Zero;
            T mean = Mean(data);
            T sum = T.Zero;
            foreach (T d in data)
                sum += (d - mean) * (d - mean);
            return sum / T.CreateSaturating(data.Count() - 1);
        }
    }
}
