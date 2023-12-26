using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TMath.Tests.Numerics
{
    public class RoundingTests
    {
        [Test]
        [TestCase(0)]
        [TestCase(1)]
        [TestCase(1.1)]
        [TestCase(-1.1)]
        [TestCase(0.123456789)]
        [TestCase(3.1)]
        [TestCase(-3.1)]
        public void FloorTest(double num)
        {
            // Arrange
            var expected = Math.Floor(num);

            // Act
            var actual = TFunctions.Floor(num);

            // Assert
            Assert.That(actual, Is.EqualTo(expected));
        }

        [Test]
        [TestCase(0)]
        [TestCase(1)]
        [TestCase(1.1)]
        [TestCase(-1.1)]
        [TestCase(0.123456789)]
        [TestCase(3.1)]
        [TestCase(-3.1)]
        public void CeilingTest(double num)
        {
            // Arrange
            var expected = Math.Ceiling(num);

            // Act
            var actual = TFunctions.Ceil(num);

            // Assert
            Assert.That(actual, Is.EqualTo(expected));
        }

        [Test]
        [TestCase(0)]
        [TestCase(1)]
        [TestCase(1.1)]
        [TestCase(-1.1)]
        [TestCase(0.123456789)]
        [TestCase(3.1)]
        [TestCase(-3.1)]
        public void RoundTest(double num)
        {
            // Arrange
            var expected = Math.Round(num);

            // Act
            var actual = TFunctions.Round(num);

            // Assert
            Assert.That(actual, Is.EqualTo(expected));
        }

        [Test]
        [TestCase(0)]
        [TestCase(0.1)]
        [TestCase(0.12)]
        [TestCase(0.123)]
        [TestCase(0.1234)]
        [TestCase(0.12345)]
        [TestCase(0.123456)]
        public void TruncateTest(double num)
        {
            // Arrange
            var expected = Math.Truncate(num);

            // Act
            var actual = TFunctions.Truncate(num, 0);

            // Assert
            Assert.That(actual, Is.EqualTo(expected));
        }

    }
}
