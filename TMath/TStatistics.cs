using System.Numerics;

namespace TMath
{
    /// <summary>
    /// Provides statistical calculations for a collection of values.
    /// </summary>
    public static class TStatistics
    {
        /// <summary>
        /// Calculates the mean (average) of the specified values.
        /// </summary>
        /// <typeparam name="T">The type of the values.</typeparam>
        /// <param name="values">The values to calculate the mean for.</param>
        /// <returns>The mean of the values.</returns>
        /// <exception cref="DivideByZeroException">Thrown when the values collection is empty.</exception>
        public static T Mean<T>(params T[] values) where T : INumberBase<T>
        {
            T sum = values[0];
            foreach (T value in values.Skip(1))
            {
                sum += value;
            }
            return sum / T.CreateSaturating(values.Length);
        }

        /// <summary>
        /// Calculates the median of the specified values.
        /// </summary>
        /// <typeparam name="T">The type of the values.</typeparam>
        /// <param name="values">The values to calculate the median for.</param>
        /// <returns>The median of the values.</returns>
        public static T Median<T>(params T[] values) where T : INumberBase<T>
        {
            Array.Sort(values);
            int n = values.Length;
            if (n % 2 == 0)
            {
                return (values[n / 2 - 1] + values[n / 2]) / TConstants<T>.Two;
            }
            return values[n / 2];
        }

        /// <summary>
        /// Calculates the mode of the specified values.
        /// </summary>
        /// <typeparam name="T">The type of the values.</typeparam>
        /// <param name="values">The values to calculate the mode for.</param>
        /// <returns>The mode of the values.</returns>
        public static T Mode<T>(params T[] values) where T : INumberBase<T>
        {
            Dictionary<T, int> counts = new Dictionary<T, int>();
            foreach (T value in values)
            {
                if (counts.ContainsKey(value))
                {
                    counts[value]++;
                }
                else
                {
                    counts[value] = 1;
                }
            }
            return counts.Aggregate((l, r) => l.Value > r.Value ? l : r).Key;
        }

        /// <summary>
        /// Calculates the variance of the specified values.
        /// </summary>
        /// <typeparam name="T">The type of the values.</typeparam>
        /// <param name="values">The values to calculate the variance for.</param>
        /// <returns>The variance of the values.</returns>
        public static T Variance<T>(params T[] values) where T : INumberBase<T>
        {
            T mean = Mean(values);
            T sum = T.Zero;
            foreach (T value in values)
            {
                sum += (value - mean) * (value - mean);
            }
            return sum / T.CreateSaturating(values.Length);
        }

        /// <summary>
        /// Calculates the standard deviation of the specified values.
        /// </summary>
        /// <typeparam name="T">The type of the values.</typeparam>
        /// <param name="values">The values to calculate the standard deviation for.</param>
        /// <returns>The standard deviation of the values.</returns>
        public static T StandardDeviation<T>(params T[] values) where T : INumberBase<T>, IRootFunctions<T>
        {
            return MathT.Sqrt(Variance(values));
        }

        /// <summary>
        /// Calculates the covariance between two sets of values.
        /// </summary>
        /// <typeparam name="T">The type of the values.</typeparam>
        /// <param name="x">The first set of values.</param>
        /// <param name="y">The second set of values.</param>
        /// <returns>The covariance between the two sets of values.</returns>
        /// <exception cref="ArgumentException">Thrown when the lengths of the arrays are not equal.</exception>
        public static T Covariance<T>(T[] x, T[] y) where T : INumberBase<T>
        {
            if (x.Length != y.Length)
            {
                throw new ArgumentException("The lengths of the arrays must be equal.");
            }
            T meanX = Mean(x);
            T meanY = Mean(y);
            T sum = T.Zero;
            for (int i = 0; i < x.Length; i++)
            {
                sum += (x[i] - meanX) * (y[i] - meanY);
            }
            return sum / T.CreateSaturating(x.Length);
        }

        /// <summary>
        /// Calculates the correlation between two sets of values.
        /// </summary>
        /// <typeparam name="T">The type of the values.</typeparam>
        /// <param name="x">The first set of values.</param>
        /// <param name="y">The second set of values.</param>
        /// <returns>The correlation between the two sets of values.</returns>
        public static T Correlation<T>(T[] x, T[] y) where T : INumberBase<T>, IRootFunctions<T>
        {
            return Covariance(x, y) / (StandardDeviation(x) * StandardDeviation(y));
        }

        /// <summary>
        /// Calculates the specified percentile of the values.
        /// </summary>
        /// <typeparam name="T">The type of the values.</typeparam>
        /// <param name="values">The values to calculate the percentile for.</param>
        /// <param name="percentile">The percentile to calculate (between 0 and 1).</param>
        /// <returns>The value at the specified percentile.</returns>
        /// <exception cref="ArgumentOutOfRangeException">Thrown when the percentile is not between 0 and 1.</exception>
        public static T Percentile<T>(T[] values, double percentile) where T : INumberBase<T>
        {
            if(percentile > 1 || percentile < 0)
            {
                throw new ArgumentOutOfRangeException("The percentile must be between 0 and 1.");
            }
            Array.Sort(values);
            double n = values.Length;
            double index = (n - 1) * percentile;
            int lower = (int)index;
            int upper = lower + 1;
            return values[lower] + (values[upper] - values[lower]) * T.CreateSaturating(index - lower);
        }

        /// <summary>
        /// Calculates the geometric mean of the specified values.
        /// </summary>
        /// <typeparam name="T">The type of the values.</typeparam>
        /// <param name="values">The values to calculate the geometric mean for.</param>
        /// <returns>The geometric mean of the values.</returns>
        public static T GeometricMean<T>(params T[] values) where T : INumberBase<T>, IRootFunctions<T>
        {
            T product = values[0];
            foreach (T value in values.Skip(1))
            {
                product *= value;
            }
            return MathT.RootN(product, values.Length);
        }

        /// <summary>
        /// Calculates the harmonic mean of the specified values.
        /// </summary>
        /// <typeparam name="T">The type of the values.</typeparam>
        /// <param name="values">The values to calculate the harmonic mean for.</param>
        /// <returns>The harmonic mean of the values.</returns>
        public static T HarmonicMean<T>(params T[] values) where T : INumberBase<T>, IRootFunctions<T>
        {
            T sum = T.Zero;
            foreach (T value in values)
            {
                sum += T.One / value;
            }
            return T.CreateSaturating(values.Length) / sum;
        }

        /// <summary>
        /// Calculates the range of the specified values.
        /// </summary>
        /// <typeparam name="T">The type of the values.</typeparam>
        /// <param name="values">The values to calculate the range for.</param>
        /// <returns>The range of the values.</returns>
        public static T Range<T>(params T[] values) where T : INumberBase<T>, IComparisonOperators<T, T, bool>
        {
            T min = values[0];
            T max = values[0];
            foreach (T value in values.Skip(1))
            {
                if (value < min)
                {
                    min = value;
                }
                if (value > max)
                {
                    max = value;
                }
            }
            return max - min;
        }

        /// <summary>
        /// Calculates the sample variance of the specified values.
        /// </summary>
        /// <typeparam name="T">The type of the values.</typeparam>
        /// <param name="values">The values to calculate the sample variance for.</param>
        /// <returns>The sample variance of the values.</returns>
        /// <exception cref="DivideByZeroException">Thrown when the values collection has less than 2 elements.</exception>
        public static T SampleVariance<T>(params T[] values) where T : INumberBase<T>
        {
            T mean = Mean(values);
            T sum = T.Zero;
            foreach (T value in values)
            {
                sum += (value - mean) * (value - mean);
            }
            return sum / T.CreateSaturating(values.Length - 1);
        }

        /// <summary>
        /// Calculates the sample standard deviation of the specified values.
        /// </summary>
        /// <typeparam name="T">The type of the values.</typeparam>
        /// <param name="values">The values to calculate the sample standard deviation for.</param>
        /// <returns>The sample standard deviation of the values.</returns>
        /// <exception cref="DivideByZeroException">Thrown when the values collection has less than 2 elements.</exception>
        public static T SampleStandardDeviation<T>(params T[] values) where T : INumberBase<T>, IRootFunctions<T>
        {
            return MathT.Sqrt(SampleVariance(values));
        }
    }
}
