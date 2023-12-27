namespace TMath.Tests.Numerics
{
    public class LogarithmTests
    {
        [Test]
        [TestCase(0)]
        [TestCase(1)]
        [TestCase(-1)]
        [TestCase(2)]
        [TestCase(3)]
        [TestCase(4)]
        [TestCase(1000)]

        public void Log2Test(double num)
        {
            // Arrange
            double expected = Math.Log(num, 2);

            // Act
            double actual = TFunctions.Log2(num);

            // Assert
            Assert.That(actual, Is.EqualTo(expected).Within(0.0001));
        }

        [Test]
        [TestCase(0)]
        [TestCase(1)]
        [TestCase(-1)]
        [TestCase(2)]
        [TestCase(3)]
        [TestCase(4)]
        [TestCase(1000)]
        public void Log10Test(double num)
        {
            // Arrange
            double expected = Math.Log10(num);

            // Act
            double actual = TFunctions.Log10(num);

            // Assert
            Assert.That(actual, Is.EqualTo(expected).Within(0.0001));
        }

        [Test]
        [TestCase(0)]
        [TestCase(1)]
        [TestCase(-1)]
        [TestCase(2)]
        [TestCase(3)]
        [TestCase(4)]
        [TestCase(1000)]
        public void LnTest(double num)
        {
            // Arrange
            double expected = Math.Log(num);

            // Act
            double actual = TFunctions.Ln(num);

            // Assert
            Assert.That(actual, Is.EqualTo(expected));
        }

        [Test]
        [TestCase(0, 2)]
        [TestCase(1, 2)]
        [TestCase(-1, 2)]
        [TestCase(2, 2)]
        [TestCase(3, 2)]
        [TestCase(4, 2)]
        [TestCase(1000, 2)]
        public void LogNTest(double num, double @base)
        {
            // Arrange
            double expected = Math.Log(num, @base);

            // Act
            double actual = TFunctions.Log(num, @base);

            // Assert
            Assert.That(actual, Is.EqualTo(expected).Within(0.0001));
        }
    }
}
