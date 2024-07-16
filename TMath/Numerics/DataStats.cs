using System.Numerics;

namespace TMath.Numerics
{
    /// <summary>
    /// Represents a class for calculating statistical measures on a collection of values.
    /// </summary>
    /// <typeparam name="T">The type of the values.</typeparam>
    public class DataStats<T> where T : INumberBase<T>, IRootFunctions<T>, IComparisonOperators<T, T, bool>
    {
        /// <summary>
        /// Gets the array of values.
        /// </summary>
        public readonly T[] Values;

        /// <summary>
        /// Gets the mean value of the collection.
        /// </summary>
        public T Mean { get; init; }

        /// <summary>
        /// Gets the median value of the collection.
        /// </summary>
        public T Median { get; init; }

        /// <summary>
        /// Gets the mode value of the collection.
        /// </summary>
        public T Mode { get; init; }

        /// <summary>
        /// Gets the range of the collection.
        /// </summary>
        public T Range { get; init; }

        /// <summary>
        /// Gets the variance of the collection.
        /// </summary>
        public T Variance { get; init; }

        /// <summary>
        /// Gets the standard deviation of the collection.
        /// </summary>
        public T StandardDeviation { get; init; }

        /// <summary>
        /// Gets the sample variance of the collection.
        /// </summary>
        public T SampleVariance { get; init; }

        /// <summary>
        /// Gets the sample standard deviation of the collection.
        /// </summary>
        public T SampleStandardDeviation { get; init; }

        /// <summary>
        /// Gets the geometric mean of the collection.
        /// </summary>
        public T GeometricMean { get; init; }

        /// <summary>
        /// Gets the harmonic mean of the collection.
        /// </summary>
        public T HarmonicMean { get; init; }

        /// <summary>
        /// Initializes a new instance of the <see cref="DataStats{T}"/> class.
        /// </summary>
        /// <param name="values">The values to calculate the statistics on.</param>
        public DataStats(params T[] values)
        {
            Values = values;
            Mean = TStatistics.Mean(values);
            Median = TStatistics.Median(values);
            Mode = TStatistics.Mode(values);
            Range = TStatistics.Range(values);
            Variance = TStatistics.Variance(values);
            StandardDeviation = TStatistics.StandardDeviation(values);
            SampleVariance = TStatistics.SampleVariance(values);
            SampleStandardDeviation = TStatistics.SampleStandardDeviation(values);
            GeometricMean = TStatistics.GeometricMean(values);
            HarmonicMean = TStatistics.HarmonicMean(values);
        }
    }
}
