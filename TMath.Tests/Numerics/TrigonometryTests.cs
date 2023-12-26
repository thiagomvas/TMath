using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TMath.Tests.Numerics
{
    public class TrigonometryTetsts
    {
        [Test]
        [TestCase(0d)]
        [TestCase(1)]
        [TestCase(2)]
        [TestCase(3)]
        [TestCase(3.1415 / 2)]
        [TestCase(3.1415)]
        [TestCase(3.1415 * 2)]
        public void SinTest(double number)
        {
            // Arrange
            var expected = Math.Sin(number);

            // Act
            var actual = TFunctions.Sin(number);

            // Assert
            Assert.That(actual, Is.EqualTo(expected).Within(0.0001));
        }

        [Test]
        [TestCase(0d)]
        [TestCase(30)]
        [TestCase(45)]
        [TestCase(60)]
        [TestCase(90)]
        [TestCase(180)]
        [TestCase(360)]
        public void SinDegTest(double number)
        {
            // Arrange
            var expected = Math.Sin(number * Math.PI / 180);

            // Act
            var actual = TFunctions.SinDeg(number);

            // Assert
            Assert.That(actual, Is.EqualTo(expected).Within(0.0001));
        }

        [Test]
        [TestCase(0d)]
        [TestCase(1)]
        [TestCase(2)]
        [TestCase(3)]
        [TestCase(3.1415 / 2)]
        [TestCase(3.1415)]
        [TestCase(3.1415 * 2)]
        public void CosTest(double number)
        {
            // Arrange
            var expected = Math.Cos(number);

            // Act
            var actual = TFunctions.Cos(number);

            // Assert
            Assert.That(actual, Is.EqualTo(expected).Within(0.0001));
        }

        [Test]
        [TestCase(0d)]
        [TestCase(30)]
        [TestCase(45)]
        [TestCase(60)]
        [TestCase(90)]
        [TestCase(180)]
        [TestCase(360)]
        public void CosDegTest(double number)
        {
            // Arrange
            var expected = Math.Cos(number * Math.PI / 180);

            // Act
            var actual = TFunctions.CosDeg(number);

            // Assert
            Assert.That(actual, Is.EqualTo(expected).Within(0.0001));
        }

        public void TanTest(double number)
        {
            // Arrange
            var expected = Math.Tan(number);

            // Act
            var actual = TFunctions.Tan(number);

            // Assert
            Assert.That(actual, Is.EqualTo(expected).Within(0.0001));
        }

        [Test]
        [TestCase(0d)]
        [TestCase(30)]
        [TestCase(45)]
        [TestCase(60)]
        [TestCase(90)]
        [TestCase(180)]
        [TestCase(360)]
        public void TanDegTest(double number)
        {
            // Arrange
            var expected = Math.Tan(number * Math.PI / 180);

            // Act
            var actual = TFunctions.TanDeg(number);

            // Assert
            Assert.That(actual, Is.EqualTo(expected).Within(0.0001));
        }
        [Test]
        [TestCase(0d)]
        [TestCase(1)]
        [TestCase(-1)]
        [TestCase(2)]
        [TestCase(-2)]
        [TestCase(0.5)]
        [TestCase(-0.5)]

        public void ArcSinTest(double number)
        {
            // Arrange
            var expected = Math.Asin(number);

            // Act
            var actual = TFunctions.Asin(number);

            // Assert
            Assert.That(actual, Is.EqualTo(expected).Within(0.0001));
        }

        [Test]
        [TestCase(0d)]
        [TestCase(1)]
        [TestCase(-1)]
        [TestCase(2)]
        [TestCase(-2)]
        [TestCase(0.5)]
        [TestCase(-0.5)]
        public void ArcCosTest(double number)
        {
            // Arrange
            var expected = Math.Acos(number);

            // Act
            var actual = TFunctions.Acos(number);

            // Assert
            Assert.That(actual, Is.EqualTo(expected).Within(0.0001));
        }

        [Test]
        [TestCase(0d)]
        [TestCase(1)]
        [TestCase(-1)]
        [TestCase(2)]
        [TestCase(-2)]
        [TestCase(0.5)]
        [TestCase(-0.5)]
        public void ArcTanTest(double number)
        {
            // Arrange
            var expected = Math.Atan(number);

            // Act
            var actual = TFunctions.Atan(number);

            // Assert
            Assert.That(actual, Is.EqualTo(expected).Within(0.0001));
        }

        [Test]
        [TestCase(0d)]
        [TestCase(1)]
        [TestCase(2)]
        [TestCase(3)]
        [TestCase(3.1415 / 2)]
        [TestCase(3.1415)]
        [TestCase(3.1415 * 2)]
        public void SecantTest(double number)
        {
            // Arrange
            var expected = 1 / Math.Cos(number);

            // Act
            var actual = TFunctions.Sec(number);

            // Assert
            Assert.That(actual, Is.EqualTo(expected).Within(0.0001));
        }

        [Test]
        [TestCase(0d)]
        [TestCase(30)]
        [TestCase(45)]
        [TestCase(60)]
        [TestCase(90)]
        [TestCase(180)]
        [TestCase(360)]
        public void SecantDegTest(double number)
        {
            // Arrange
            var expected = 1 / Math.Cos(number * Math.PI / 180);

            // Act
            var actual = TFunctions.SecDeg(number);

            // Assert
            Assert.That(actual, Is.EqualTo(expected).Within(0.0001));
        }

        [Test]
        [TestCase(0d)]
        [TestCase(1)]
        [TestCase(2)]
        [TestCase(3)]
        [TestCase(3.1415 / 2)]
        [TestCase(3.1415)]
        [TestCase(3.1415 * 2)]
        public void CosecantTest(double number)
        {
            // Arrange
            var expected = 1 / Math.Sin(number);

            // Act
            var actual = TFunctions.Csc(number);

            // Assert
            Assert.That(actual, Is.EqualTo(expected).Within(0.0001));
        }

        [Test]
        [TestCase(0d)]
        [TestCase(30)]
        [TestCase(45)]
        [TestCase(60)]
        [TestCase(90)]
        [TestCase(180)]
        [TestCase(360)]
        public void CosecantDegTest(double number)
        {
            // Arrange
            var expected = 1 / Math.Sin(number * Math.PI / 180);

            // Act
            var actual = TFunctions.CscDeg(number);

            // Assert
            Assert.That(actual, Is.EqualTo(expected).Within(0.0001));
        }

        [Test]
        [TestCase(0d)]
        [TestCase(1)]
        [TestCase(2)]
        [TestCase(3)]
        [TestCase(3.1415 / 2)]
        [TestCase(3.1415)]
        [TestCase(3.1415 * 2)]
        public void CotangentTest(double number)
        {
            // Arrange
            var expected = 1 / Math.Tan(number);

            // Act
            var actual = TFunctions.Cot(number);

            // Assert
            Assert.That(actual, Is.EqualTo(expected).Within(0.0001));
        }

        [Test]
        [TestCase(0d)]
        [TestCase(30)]
        [TestCase(45)]
        [TestCase(60)]
        [TestCase(90)]
        [TestCase(180)]
        [TestCase(360)]
        public void CotangentDegTest(double number)
        {
            // Arrange
            var expected = 1 / Math.Tan(number * Math.PI / 180);

            // Act
            var actual = TFunctions.CotDeg(number);

            // Assert
            Assert.That(actual, Is.EqualTo(expected).Within(0.0001));
        }
    }
}
