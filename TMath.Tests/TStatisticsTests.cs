using TMath.Modules;

namespace TMath.Tests
{
    public class TStatisticsTests
    {
        [Test]
        [TestCase(new double[] { }, ExpectedResult = 0d)]
        [TestCase(new[] {1d}, ExpectedResult = 1d)]
        [TestCase(new[] {0d, 0d, 0d, 0d, 0d, 0d}, ExpectedResult = 0d)]
        [TestCase(new[] {1.94, -5.12, 3.14, 4.20, 2.12}, ExpectedResult = 1.256d)]
        [TestCase(new[] {1, 1.1, 0.1, 3, 1, 3, 12, 0.1, 0.2, -3}, ExpectedResult = 1.85d)]
        [TestCase(new[] { -1d, -2, -3, -4, -5 }, ExpectedResult = -3d)]
        [TestCase(new[] { 1845d, 894, 923, 18, 261, -974, -98, 651, -654, -874}, ExpectedResult = 199.2d)]

        public double Mean(double[] data) => TStatistics.Mean(data);

        [Test]
        [TestCase(new double[] { }, ExpectedResult = 0d)]
        [TestCase(new[] {1d}, ExpectedResult = 1d)]
        [TestCase(new[] {0d, 0d, 0d, 0d, 0d, 0d}, ExpectedResult = 0d)]
        [TestCase(new[] {9d, -5, 2, 3, 1}, ExpectedResult = 2d)]
        [TestCase(new[] {1, 1.1, 0.1, 3, 0.9, -0.1}, ExpectedResult = 0.95d)]
        [TestCase(new[] {-1d, -2, -3, -4, -5}, ExpectedResult = -3d)]
        [TestCase(new[] { 1845d, 894, 923, 18, 261, -974, -98, 651, -654, -874 }, ExpectedResult = 139.5d)]
        public double Median(double[] data) => TStatistics.Median(data);

        [Test]
        [TestCase(new double[] { }, ExpectedResult = 0d)]
        [TestCase(new[] {1d}, ExpectedResult = 0d)]
        [TestCase(new[] {0d, 0d, 0d, 0d, 0d, 0d}, ExpectedResult = 0d)]
        [TestCase(new[] {1d, 2, 3}, ExpectedResult = 1d)]
        [TestCase(new[] {1, 1.1, 0.1, 3, 0.9, -0.1}, ExpectedResult = 1.208d)]
        [TestCase(new[] {-1d, -2, -3, -4, -5}, ExpectedResult = 2.5d)]
        [TestCase(new[] { 237d, 589, 412, 765, 321 }, ExpectedResult = 45226.2d)]

        public double Variance(double[] data) => TStatistics.Variance(data);
    }
}
