using TMath.Numerics;
using TMath.Numerics.Models;

namespace TMath.Tests.Numerics
{
    public class TStatisticsTests
    {
        [Test]
        [TestCase(new double[] { }, 0d)]
        [TestCase(new[] { 1d }, 1d)]
        [TestCase(new[] { 0d, 0d, 0d, 0d, 0d, 0d }, 0d)]
        [TestCase(new[] { 1.94, -5.12, 3.14, 4.20, 2.12 }, 1.256d)]
        [TestCase(new[] { 1, 1.1, 0.1, 3, 1, 3, 12, 0.1, 0.2, -3 }, 1.85d)]
        [TestCase(new[] { -1d, -2, -3, -4, -5 }, -3d)]
        [TestCase(new[] { 1845d, 894, 923, 18, 261, -974, -98, 651, -654, -874 }, 199.2d)]
        public void Mean(double[] data, double expected)
        {
            // Arrange

            // Act
            var actual = TStatistics.Mean(data);

            // Assert
            Assert.That(expected, Is.EqualTo(actual).Within(0.0001));
        }

        [Test]
        [TestCase(new int[] { }, 0d)]
        [TestCase(new int[] { 1 }, 1d)]
        [TestCase(new int[] { 0, 0, 0, 0, 0, 0 }, 0d)]
        [TestCase(new int[] { 1, -5, 3, 4, 2 }, 1d)]
        [TestCase(new int[] { 1, 1, 0, 3, 1, 3, 12, 0, 0, -3 }, 1.8d)]
        [TestCase(new int[] { -1, -2, -3, -4, -5 }, -3d)]
        [TestCase(new int[] { 1845, 894, 923, 18, 261, -974, -98, 651, -654, -874 }, 199.2d)]
        public void Mean_WithIntegers(int[] data, double expected)
        {
            // Arrange

            // Act
            var actual = TStatistics.Mean<double, int>(data);

            // Assert
            Assert.That(expected, Is.EqualTo(actual).Within(0.0001));
        }

        [Test]
        [TestCase(new double[] { }, 0d)]
        [TestCase(new[] { 1d }, 1d)]
        [TestCase(new[] { 0d, 0d, 0d, 0d, 0d, 0d }, 0d)]
        [TestCase(new[] { 9d, -5, 2, 3, 1 }, 2d)]
        [TestCase(new[] { 1, 1.1, 0.1, 3, 0.9, -0.1 }, 0.95d)]
        [TestCase(new[] { -1d, -2, -3, -4, -5 }, -3d)]
        [TestCase(new[] { 1845d, 894, 923, 18, 261, -974, -98, 651, -654, -874 }, 139.5d)]
        public void Median(double[] data, double expected)
        {
            // Arrange

            // Act
            var actual = TStatistics.Median(data);

            // Assert
            Assert.That(expected, Is.EqualTo(actual).Within(0.0001));
        }

        [Test]
        [TestCase(new int[] { }, 0d)]
        [TestCase(new int[] { 1 }, 1d)]
        [TestCase(new int[] { 0, 0, 0, 0, 0, 0 }, 0d)]
        [TestCase(new int[] { 1, -5, 3, 4, 2 }, 2d)]
        [TestCase(new int[] { 1, 1, 0, 3, 1, 3, 12, 0, 0, -3 }, 1d)]
        [TestCase(new int[] { -1, -2, -3, -4, -5 }, -3d)]
        [TestCase(new int[] { 1845, 894, 923, 18, 261, -974, -98, 651, -654, -874 }, 139.5d)]
        public void Median_WithIntegers(int[] data, double expected)
        {
            // Arrange

            // Act
            var actual = TStatistics.Median<double, int>(data);

            // Assert
            Assert.That(expected, Is.EqualTo(actual).Within(0.0001));
        }

        [Test]
        [TestCase(new int[] { }, 0)]
        [TestCase(new[] { 1 }, 1)]
        [TestCase(new[] { 0, 0, 0, 0, 0, 0 }, 0)]
        [TestCase(new[] { 1, 2, 3 }, 1d)]
        [TestCase(new[] { 4, 3, 3, 4, 5, 7, 2, 1, 7, 3, 4, 9, 4 }, 4)]
        [TestCase(new[] { 1, -3, 2, -6, 2, 1, -3, -3, -4, 0, 0, 1 }, 1)]
        [TestCase(new[] { 1, 2, 1, 2, 1, 2 }, 1)]
        public void Mode(int[] data, double expected)
        {
            // Arrange

            // Act
            var actual = TStatistics.Mode(data);

            // Assert
            Assert.That(expected, Is.EqualTo(actual).Within(0.0001));
        }


        [Test]
        [TestCase(new double[] { }, 0d)]
        [TestCase(new[] { 1d }, 0d)]
        [TestCase(new[] { 0d, 0d, 0d, 0d, 0d, 0d }, 0d)]
        [TestCase(new[] { 1d, 2, 3 }, 1d)]
        [TestCase(new[] { 1, 1.1, 0.1, 3, 0.9, -0.1 }, 1.208d)]
        [TestCase(new[] { -1d, -2, -3, -4, -5 }, 2.5d)]
        [TestCase(new[] { 237d, 589, 412, 765, 321 }, 45226.2d)]

        public void Variance(double[] data, double expected)
        {
            // Arrange

            // Act
            var actual = TStatistics.Variance(data);

            // Assert
            Assert.That(expected, Is.EqualTo(actual).Within(0.0001));
        }

        [Test]
        [TestCase(new int[] { }, 0d)]
        [TestCase(new int[] { 1 }, 0d)]
        [TestCase(new int[] { 0, 0, 0, 0, 0, 0 }, 0d)]
        [TestCase(new int[] { 1, 2, 3 }, 1d)]
        [TestCase(new int[] { 1, 1, 0, 3, 1, 3, 12, 0, 0, -5 }, 274 / 15d)]
        [TestCase(new int[] { -1, -2, -3, -4, -5 }, 2.5d)]
        [TestCase(new int[] { 237, 589, 412, 765, 321 }, 45226.2d)]
        public void Variance_WithIntegers(int[] data, double expected)
        {
            // Arrange

            // Act
            var actual = TStatistics.Variance<double, int>(data);

            // Assert
            Assert.That(expected, Is.EqualTo(actual).Within(0.0001));
        }

        [Test]
        [TestCase(new double[] { }, 0d)]
        [TestCase(new[] { 1d }, 0d)]
        [TestCase(new[] { 0d, 0d, 0d, 0d, 0d, 0d }, 0d)]
        [TestCase(new[] { 1d, 2, 3 }, 1d)]
        [TestCase(new[] { -1d, -2, -3 }, 1d)]
        [TestCase(new[] { -1d, -2, -3, -4, -5 }, 1.5811d)]
        [TestCase(new[] { 237d, 589, 412, 765, 321 }, 212.6645d)]
        public void StandardDeviation(double[] data, double expected)
        {
            // Arrange

            // Act
            var actual = TStatistics.StandardDeviation(data);

            // Assert
            Assert.That(expected, Is.EqualTo(actual).Within(0.0001));
        }

        [Test]
        [TestCase(new int[] { }, 0d)]
        [TestCase(new int[] { 1 }, 0d)]
        [TestCase(new int[] { 0, 0, 0, 0, 0, 0 }, 0d)]
        [TestCase(new int[] { 1, 2, 3 }, 1d)]
        [TestCase(new int[] { -1, -2, -3, -4, -5 }, 1.5811d)]
        [TestCase(new int[] { 237, 589, 412, 765, 321 }, 212.6645d)]
        public void StandardDeviation_WithIntegers(int[] data, double expected)
        {
            // Arrange

            // Act
            var actual = TStatistics.StandardDeviation<double, int>(data);

            // Assert
            Assert.That(expected, Is.EqualTo(actual).Within(0.0001));
        }

        [Test]
        [TestCase(new double[] { }, 95d, 0d)]
        [TestCase(new[] { 1d }, 50d, 1d)]
        [TestCase(new[] { 0d, 0d, 0d, 0d, 0d, 0d }, 50d, 0d)]
        [TestCase(new[] { 1d, 2, 3 }, 50d, 2d)]
        [TestCase(new[] { 1d, 2, 3 }, 95d, 3d)]
        [TestCase(new[] { -1d, -2, -3 }, 30d, -3d)]
        [TestCase(new[] { -1d, -2, -3 }, 95d, -1d)]
        [TestCase(new[] { -1d, -2, -3, -4 }, 50d, -2.5d)]
        public void Percentile(double[] data, double percentile, double expected)
        {
            // Arrange

            // Act
            var actual = TStatistics.Percentile(data, percentile);

            // Assert
            Assert.That(expected, Is.EqualTo(actual).Within(0.0001));
        }

        [Test]
        [TestCase(new double[] { })]
        [TestCase(new[] { 1d })]
        [TestCase(new[] { 0d, 0d, 0d, 0d, 0d, 0d })]
        [TestCase(new[] { 1d, 2, 3 })]
        [TestCase(new[] { -1d, -2, -3 })]
        [TestCase(new[] { 1, 0.93, 12, 3, -2, -1.2 })]
        [TestCase(new[] { 1, 0.93, 12, 3, -2, -1.2, 1, 0.93, 12, 3, -2, -1.2, 1, 0.93, 12, 3, -2, -1.2, 1, 0.93, 12, 3, -2, -1.2, 1, 0.93, 12, 3, -2, -1.2 })]

        public void DescriptiveStatistics_CreateAndCompute(double[] data)
        {
            // Arrange
            var expectedMean = TStatistics.Mean(data);
            var expectedMedian = TStatistics.Median(data);
            var expectedVariance = TStatistics.Variance(data);
            var expectedStandardDeviation = TStatistics.StandardDeviation(data);
            var expectedMode = TStatistics.Mode(data);

            // Act
            var actual = new DescriptiveStatistics<double>(data);

            // Assert
            Assert.That(expectedMean, Is.EqualTo(actual.Mean).Within(0.0001));
            Assert.That(expectedMedian, Is.EqualTo(actual.Median).Within(0.0001));
            Assert.That(expectedVariance, Is.EqualTo(actual.Variance).Within(0.0001));
            Assert.That(expectedStandardDeviation, Is.EqualTo(actual.StandardDeviation).Within(0.0001));
            Assert.That(expectedMode, Is.EqualTo(actual.Mode).Within(0.0001));
        }

        [Test]
        [TestCase(new int[] { })]
        [TestCase(new[] { 1 })]
        [TestCase(new[] { 0, 0, 0, 0, 0, 0 })]
        [TestCase(new[] { 1, 2, 3 })]
        [TestCase(new[] { -1, -2, -3 })]
        [TestCase(new[] { 1, 0, 12, 3, -2, -1 })]
        [TestCase(new[] { 1, 0, 12, 3, -2, -1, 1, 0, 12, 3, -2, -1, 1, 0, 12, 3, -2, -1, 1, 0, 12, 3, -2, -1, 1, 0, 12, 3, -2, -1 })]
        public void DescriptiveStatistics_CreateAndCompute_WithIntegers(int[] data)
        {
            // Arrange
            var expectedMean = TStatistics.Mean(data);
            var expectedMedian = TStatistics.Median(data);
            var expectedVariance = TStatistics.Variance(data);
            var expectedStandardDeviation = TStatistics.StandardDeviation(data);
            var expectedMode = TStatistics.Mode(data);

            // Act
            var actual = new DescriptiveStatistics<int>(data);

            // Assert
            Assert.That(expectedMean, Is.EqualTo(actual.Mean).Within(1));
            Assert.That(expectedMedian, Is.EqualTo(actual.Median).Within(1));
            Assert.That(expectedVariance, Is.EqualTo(actual.Variance).Within(1));
            Assert.That(expectedStandardDeviation, Is.EqualTo(actual.StandardDeviation).Within(1));
            Assert.That(expectedMode, Is.EqualTo(actual.Mode).Within(1));
        }

    }
}
