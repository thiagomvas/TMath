namespace TMath.Tests.Numerics
{
    public class RootTests
    {
        [Test]
        [TestCase(0d)]
        [TestCase(1d)]
        [TestCase(-1d)]
        [TestCase(2d)]
        [TestCase(2.5d)]
        [TestCase(10d)]
        [TestCase(10000d)]

        public void SqrtTest(double number)
        {
            // Arrange
            var expected = Math.Sqrt(number);

            // Act
            var actual = TFunctions.Sqrt(number);

            // Assert
            Assert.That(expected, Is.EqualTo(actual).Within(0.0001));
        }

        [Test]
        [TestCase(0)]
        [TestCase(1)]
        [TestCase(-1)]
        [TestCase(2)]
        [TestCase(4)]
        [TestCase(10)]
        [TestCase(10000)]
        public void SqrtTest_NonIRootFunctions(int num)
        {
            // Arrange
            var expected = Math.Sqrt(num);

            // Act
            var actual = TFunctions.Sqrt<double, int>(num);

            // Assert
            Assert.That(expected, Is.EqualTo(actual).Within(0.0001));
        }

        [Test]
        [TestCase(0d)]
        [TestCase(1d)]
        [TestCase(-1d)]
        [TestCase(2d)]
        [TestCase(2.5d)]
        [TestCase(10d)]
        [TestCase(10000d)]
        public void CbrtTest(double number)
        {
            // Arrange
            var expected = Math.Cbrt(number);

            // Act
            var actual = TFunctions.Cbrt(number);

            // Assert
            Assert.That(expected, Is.EqualTo(actual).Within(0.0001));
        }

        [Test]
        [TestCase(0, 4)]
        [TestCase(1, 4)]
        [TestCase(-1, 4)]
        [TestCase(2, 4)]
        [TestCase(4, 4)]
        [TestCase(10, 4)]
        [TestCase(10000, 4)]
        public void NthRootTest(double number, int n)
        {
            // Arrange
            var expected = Math.Pow(number, 1d / n);

            // Act
            var actual = TFunctions.NRoot(number, n);

            // Assert
            Assert.That(expected, Is.EqualTo(actual).Within(0.0001));
        }
    }
}
