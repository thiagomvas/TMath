using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TMath.Tests.Numerics
{
    public class HyperbolicTests
    {
        [Test]
        [TestCase(0)]
        [TestCase(1)]
        [TestCase(-1)]
        [TestCase(2)]
        [TestCase(3)]
        [TestCase(-12345)]
        [TestCase(12345)]

        public void SinhTest(double num)
        {
            // Arrange
            var expected = Math.Sinh(num);

            // Act
            var actual = TFunctions.Sinh(num);

            // Assert
            Assert.That(actual, Is.EqualTo(expected).Within(0.0001));
        }

        [Test]
        [TestCase(0)]
        [TestCase(1)]
        [TestCase(-1)]
        [TestCase(2)]
        [TestCase(3)]
        [TestCase(-12345)]
        [TestCase(12345)]
        public void CoshTest(double num)
        {
            // Arrange
            var expected = Math.Cosh(num);

            // Act
            var actual = TFunctions.Cosh(num);

            // Assert
            Assert.That(actual, Is.EqualTo(expected).Within(0.0001));
        }

        [Test]
        [TestCase(0)]
        [TestCase(1)]
        [TestCase(-1)]
        [TestCase(2)]
        [TestCase(3)]
        [TestCase(-12)]
        [TestCase(12)]
        public void TanhTest(double num)
        {
            // Arrange
            var expected = Math.Tanh(num);

            // Act
            var actual = TFunctions.Tanh(num);

            // Assert
            Assert.That(actual, Is.EqualTo(expected).Within(0.0001));
        }

        [Test]
        [TestCase(0)]
        [TestCase(1)]
        [TestCase(-1)]
        [TestCase(2)]
        [TestCase(3)]
        [TestCase(-12345)]
        [TestCase(12345)]
        public void SechTest(double num)
        {
            // Arrange
            var expected = 1 / Math.Cosh(num);

            // Act
            var actual = TFunctions.Sech(num);

            // Assert
            Assert.That(actual, Is.EqualTo(expected).Within(0.0001));
        }

        [Test]
        [TestCase(0)]
        [TestCase(1)]
        [TestCase(-1)]
        [TestCase(2)]
        [TestCase(3)]
        [TestCase(-12345)]
        [TestCase(12345)]
        public void CschTest(double num)
        {
            // Arrange
            var expected = 1 / Math.Sinh(num);

            // Act
            var actual = TFunctions.Csch(num);

            // Assert
            Assert.That(actual, Is.EqualTo(expected).Within(0.0001));
        }

        [Test]
        [TestCase(0)]
        [TestCase(1)]
        [TestCase(-1)]
        [TestCase(2)]
        [TestCase(3)]
        [TestCase(-12345)]
        [TestCase(12345)]
        public void CothTest(double num)
        {
            // Arrange
            var expected = Math.Cosh(num) / Math.Sinh(num);

            // Act
            var actual = TFunctions.Coth(num);

            // Assert
            Assert.That(actual, Is.EqualTo(expected).Within(0.0001));
        }

        [Test]
        [TestCase(0)]
        [TestCase(1)]
        [TestCase(-1)]
        [TestCase(2)]
        [TestCase(3)]
        [TestCase(-12345)]
        [TestCase(12345)]
        public void AsinhTest(double num)
        {
            // Arrange
            var expected = Math.Log(num + Math.Sqrt(num * num + 1));

            // Act
            var actual = TFunctions.Asinh(num);

            // Assert
            Assert.That(actual, Is.EqualTo(expected).Within(0.0001));
        }

        [Test]
        [TestCase(0)]
        [TestCase(1)]
        [TestCase(-1)]
        [TestCase(2)]
        [TestCase(3)]
        [TestCase(-12345)]
        [TestCase(12345)]
        public void AcoshTest(double num)
        {
            // Arrange
            var expected = Math.Log(num + Math.Sqrt(num * num - 1));

            // Act
            var actual = TFunctions.Acosh(num);

            // Assert
            Assert.That(actual, Is.EqualTo(expected).Within(0.0001));
        }

        [Test]
        [TestCase(0)]
        [TestCase(0.1)]
        [TestCase(-0.1)]
        [TestCase(0.5)]
        [TestCase(-0.5)]
        [TestCase(0.9)]
        [TestCase(-0.9)]
        public void AtanhTest(double num)
        {
            // Arrange
            var expected = 0.5 * Math.Log((1 + num) / (1 - num));

            // Act
            var actual = TFunctions.Atanh(num);

            // Assert
            Assert.That(actual, Is.EqualTo(expected).Within(0.0001));
        }
    }
}
