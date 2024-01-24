using System.Numerics;

namespace TMath.Numerics.Models
{
    /// <summary>
    /// Provides descriptive statistics for a collection of numeric data.
    /// </summary>
    /// <typeparam name="T">The numeric type of the data, implementing the INumber interface.</typeparam>
    public class DescriptiveStatistics<T> where T : INumber<T>
    {
        /// <summary>
        /// Gets the mean (average) of the data.
        /// </summary>
        public T Mean { get; private set; }

        /// <summary>
        /// Gets the median of the data.
        /// </summary>
        public T Median { get; private set; }

        /// <summary>
        /// Gets the variance of the data.
        /// </summary>
        public T Variance { get; private set; }

        /// <summary>
        /// Gets the standard deviation of the data.
        /// </summary>
        public T StandardDeviation { get; private set; }

        /// <summary>
        /// Gets the mode (most frequently occurring value) of the data.
        /// </summary>
        public T Mode { get; private set; }

        /// <summary>
        /// Gets the sum of the data.
        /// </summary>
        public T Sum { get; private set; }

        /// <summary>
        /// Gets the largest value in the data.
        /// </summary>
        public T Largest { get; private set; }

        /// <summary>
        /// Gets the smallest value in the data.
        /// </summary>
        public T Smallest { get; private set; }

        /// <summary>
        /// Gets the range of the data.
        /// </summary>
        public T Range { get; private set; }

        /// <summary>
        /// Gets the geometric mean of the data.
        /// </summary>
        public T GeometricMean { get; private set; }

        /// <summary>
        /// Gets the sample standard deviation of the data.
        /// </summary>
        public T SampleStandardDeviation { get; private set; }

        /// <summary>
        /// Gets the sample variance of the data.
        /// </summary>
        public T SampleVariance { get; private set; }

        /// <summary>
        /// Gets the raw data provided to calculate statistics.
        /// </summary>
        public IEnumerable<T> Data { get; private set; }

        /// <summary>
        /// Initializes a new instance of the DescriptiveStatistics class with the provided data.
        /// </summary>
        /// <param name="data">The numeric data for which descriptive statistics are calculated.</param>
        public DescriptiveStatistics(IEnumerable<T> data)
        {
            Mean = TStatistics.Mean(data);
            Median = TStatistics.Median(data);
            Variance = TStatistics.Variance(data);
            StandardDeviation = TStatistics.StandardDeviation(data);
            Mode = TStatistics.Mode(data);
            Data = data;
            Sum = TStatistics.Sum(data);
            Largest = TStatistics.Largest(data);
            Smallest = TStatistics.Smallest(data);
            Range = TStatistics.Range(data);
            GeometricMean = TStatistics.GeometricMean(data);
            SampleStandardDeviation = TStatistics.SampleStandardDeviation(data);
            SampleVariance = TStatistics.SampleVariance(data);
        }

        /// <summary>
        /// Calculates and returns the specified percentile of the data.
        /// </summary>
        /// <param name="percentile">The desired percentile (0 to 100).</param>
        /// <returns>The value at the specified percentile in the data.</returns>
        public T Percentile(int percentile) => TStatistics.Percentile(Data, percentile);


        /// <inheritdoc/>
		public override string ToString()
		{
			return $"Mean: {Mean}\nMedian: {Median}\nVariance: {Variance}\nStandard Deviation: {StandardDeviation}\nMode: {Mode}\nSum: {Sum}\nLargest: {Largest}\nSmallest: {Smallest}\nRange: {Range}\nGeometric Mean: {GeometricMean}\nSample Standard Deviation: {SampleStandardDeviation}\nSample Variance: {SampleVariance}";
		}
    }
}
