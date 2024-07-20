namespace TMath.Tests
{
    internal class TStatisticsTests
    {
        [Test]
        public void Mean()
        {
            // Arrange
            double[] values = [5, 3, 2, 1, 4];
            double sum = 0;
            foreach (double value in values)
            {
                sum += value;
            }
            double expected = sum / values.Length;

            // Act
            double actual = TStatistics.Mean(values);

            // Assert
            Assert.That(actual, Is.EqualTo(expected).Within(1e-9));
        }

        [Test]  
        public void Median()
        {
            // Arrange
            double[] values = [5, 3, 2, 1, 4];
            Array.Sort(values);
            double expected = values[values.Length / 2];

            // Act
            double actual = TStatistics.Median(values);

            // Assert
            Assert.That(actual, Is.EqualTo(expected));
        }

        [Test]
        public void Mode()
        {
            // Arrange
            double[] values = [5, 3, 2, 1, 4, 5, 5];
            Dictionary<double, int> counts = new Dictionary<double, int>();
            foreach (double value in values)
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
            double expected = counts.OrderByDescending(kvp => kvp.Value).First().Key;

            // Act
            double actual = TStatistics.Mode(values);

            // Assert
            Assert.That(actual, Is.EqualTo(expected));
        }

        [Test]
        public void Variance()
        {
            // Arrange
            double[] values = [5, 3, 2, 1, 4];
            double mean = TStatistics.Mean(values);
            double sum = 0;
            foreach (double value in values)
            {
                sum += (value - mean) * (value - mean);
            }
            double expected = sum / values.Length;

            // Act
            double actual = TStatistics.Variance(values);

            // Assert
            Assert.That(actual, Is.EqualTo(expected).Within(1e-9));
        }

        [Test]
        public void StandardDeviation()
        {
            // Arrange
            double[] values = [5, 3, 2, 1, 4];
            double mean = TStatistics.Mean(values);
            double sum = 0;
            foreach (double value in values)
            {
                sum += (value - mean) * (value - mean);
            }
            double variance = sum / values.Length;
            double expected = Math.Sqrt(variance);

            // Act
            double actual = TStatistics.StandardDeviation(values);

            // Assert
            Assert.That(actual, Is.EqualTo(expected).Within(1e-9));
        }


        [Test]
        public void Covariance()
        {
            // Arrange
            double[] x = [5, 3, 2, 1, 4];
            double[] y = [1, 2, 3, 4, 5];
            double meanX = TStatistics.Mean(x);
            double meanY = TStatistics.Mean(y);
            double sum = 0;
            for (int i = 0; i < x.Length; i++)
            {
                sum += (x[i] - meanX) * (y[i] - meanY);
            }
            double expected = sum / x.Length;

            // Act
            double actual = TStatistics.Covariance(x, y);

            // Assert
            Assert.That(actual, Is.EqualTo(expected).Within(1e-9));
        }

        [Test]
        public void Correlation()
        {
            // Arrange
            double[] x = [5, 3, 2, 1, 4];
            double[] y = [1, 2, 3, 4, 5];
            double meanX = TStatistics.Mean(x);
            double meanY = TStatistics.Mean(y);
            double sum = 0;
            for (int i = 0; i < x.Length; i++)
            {
                sum += (x[i] - meanX) * (y[i] - meanY);
            }
            double covariance = sum / x.Length;
            double varianceX = TStatistics.Variance(x);
            double varianceY = TStatistics.Variance(y);
            double expected = covariance / (Math.Sqrt(varianceX) * Math.Sqrt(varianceY));

            // Act
            double actual = TStatistics.Correlation(x, y);

            // Assert
            Assert.That(actual, Is.EqualTo(expected).Within(1e-9));
        }

        [Test]
        public void Percentile()
        {
            // Arrange
            double[] values = [5, 3, 2, 1, 4];
            Array.Sort(values);
            double percentile = 0.5;
            double expected = values[(int)(percentile * values.Length)];

            // Act
            double actual = TStatistics.Percentile(values, percentile);

            // Assert
            Assert.That(actual, Is.EqualTo(expected));
        }

        [Test]
        public void Percentile_WhenOutOfRange_ShouldThrow()
        {
            // Arrange
            double[] values = [5, 3, 2, 1, 4];

            // Act and assert
            Assert.Throws<ArgumentOutOfRangeException>(() => TStatistics.Percentile(values, 1.5));
            Assert.Throws<ArgumentOutOfRangeException>(() => TStatistics.Percentile(values, -0.1));
        }

        [Test]
        public void GeometricMean()
        {
            // Arrange
            double[] values = [5, 3, 2, 1, 4];
            double product = 1;
            foreach (double value in values)
            {
                product *= value;
            }
            double expected = Math.Pow(product, 1.0 / values.Length);

            // Act
            double actual = TStatistics.GeometricMean(values);

            // Assert
            Assert.That(actual, Is.EqualTo(expected).Within(1e-9));
        }

        [Test]
        public void HarmonicMean()
        {
            // Arrange
            double[] values = [5, 3, 2, 1, 4];
            double sum = 0;
            foreach (double value in values)
            {
                sum += 1.0 / value;
            }
            double expected = values.Length / sum;

            // Act
            double actual = TStatistics.HarmonicMean(values);

            // Assert
            Assert.That(actual, Is.EqualTo(expected).Within(1e-9));
        }

        [Test]
        public void Range()
        {
            // Arrange
            double[] values = [5, 3, 2, 1, 4];
            double expected = values.Max() - values.Min();

            // Act
            double actual = TStatistics.Range(values);

            // Assert
            Assert.That(actual, Is.EqualTo(expected));
        }

        [Test]
        public void SampleVariance()
        {
            // Arrange
            double[] values = [5, 3, 2, 1, 4];
            double mean = TStatistics.Mean(values);
            double sum = 0;
            foreach (double value in values)
            {
                sum += (value - mean) * (value - mean);
            }
            double expected = sum / (values.Length - 1);

            // Act
            double actual = TStatistics.SampleVariance(values);

            // Assert
            Assert.That(actual, Is.EqualTo(expected).Within(1e-9));
        }

        [Test]
        public void SampleStandardDeviation()
        {
            // Arrange
            double[] values = [5, 3, 2, 1, 4];
            double mean = TStatistics.Mean(values);
            double sum = 0;
            foreach (double value in values)
            {
                sum += (value - mean) * (value - mean);
            }
            double variance = sum / (values.Length - 1);
            double expected = Math.Sqrt(variance);

            // Act
            double actual = TStatistics.SampleStandardDeviation(values);

            // Assert
            Assert.That(actual, Is.EqualTo(expected).Within(1e-9));
        }
    }
}
