using TMath.Numerics;

namespace TMath.Tests.Numerics
{
    internal class DataStatsTests
    {
        [Test]
        public void InstanceShouldHaveCorrectValues()
        {
            // Arrange
            var values = new double[] { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10 };
            var dataStats = new DataStats<double>(values);

            // Act
            var mean = dataStats.Mean;
            var median = dataStats.Median;
            var mode = dataStats.Mode;
            var range = dataStats.Range;
            var variance = dataStats.Variance;
            var standardDeviation = dataStats.StandardDeviation;
            var sampleVariance = dataStats.SampleVariance;
            var sampleStandardDeviation = dataStats.SampleStandardDeviation;
            var geometricMean = dataStats.GeometricMean;
            Assert.Multiple(() =>
            {

                // Assert
                Assert.That(mean, Is.EqualTo(TStatistics.Mean(values)).Within(1e-9));
                Assert.That(median, Is.EqualTo(TStatistics.Median(values)).Within(1e-9));
                Assert.That(mode, Is.EqualTo(TStatistics.Mode(values)).Within(1e-9));
                Assert.That(range, Is.EqualTo(TStatistics.Range(values)).Within(1e-9));
                Assert.That(variance, Is.EqualTo(TStatistics.Variance(values)).Within(1e-9));
                Assert.That(standardDeviation, Is.EqualTo(TStatistics.StandardDeviation(values)).Within(1e-9));
                Assert.That(sampleVariance, Is.EqualTo(TStatistics.SampleVariance(values)).Within(1e-9));
                Assert.That(sampleStandardDeviation, Is.EqualTo(TStatistics.SampleStandardDeviation(values)).Within(1e-9));
                Assert.That(geometricMean, Is.EqualTo(TStatistics.GeometricMean(values)).Within(1e-9));
            });
        }

        [Test]
        public void Instance_WhenEmptyValues_ShouldThrow()
        {
            // Arrange
            var values = new double[] { };

            // Act
            TestDelegate testDelegate = () => new DataStats<double>(values);

            // Assert
            Assert.That(testDelegate, Throws.TypeOf<ArgumentException>());
        }
    }
}
