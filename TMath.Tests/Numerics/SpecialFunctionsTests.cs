namespace TMath.Tests.Numerics
{
    public class SpecialFunctionsTests
    {
        [Test]
        [TestCase(0l)]
        [TestCase(1)]
        [TestCase(2)]
        [TestCase(5)]
        [TestCase(10)]
        [TestCase(15)]
        [TestCase(20)]
        public void FactorialTest(long num)
        {
            // Arrange
            long expected = 1;
            for (long i = 1; i <= num; i++)
            {
                expected *= i;
            }
            // Act
            var actual = TFunctions.Factorial(num);
            // Assert
            Assert.That(actual, Is.EqualTo(expected));
        }
        [Test]
        [TestCase(0)]
        [TestCase(1)]
        [TestCase(2)]
        [TestCase(5)]
        [TestCase(10)]
        [TestCase(15)]
        [TestCase(20)]
        public void Factorial_ToAnotherType(long num)
        {
            // Arrange
            ulong expected = 1;
            for (ulong i = 1; i <= (ulong)num; i++)
            {
                expected *= i;
            }
            // Act
            var actual = TFunctions.Factorial<ulong, long>(num);
            // Assert
            Assert.That(actual, Is.EqualTo(expected));
        }

        [Test]
        [TestCase(0, 0)]
        [TestCase(1, 1)]
        [TestCase(1, -1)]
        [TestCase(-1, -1)]
        [TestCase(-1, 1)]
        public void CopySignTest(int num, int sign)
        {
            // Arrange
            double expected = Math.CopySign(num, sign);

            // Act
            var actual = TFunctions.CopySign(num, sign);

            // Assert
            Assert.That(actual, Is.EqualTo(expected));
        }

        [Test]
        [TestCase(0, 10)]
        [TestCase(1, 10)]
        [TestCase(2, 10)]
        [TestCase(3, 10)]

        public void SumTest(int funcIndex, int n, int i = 1)
        {
            // Arrange
            Func<double, double>[] funcs =
            {
                x => x,
                x => x * x,
                x => TFunctions.Sin(TFunctions.ToRadians(x)),
                x => (x + 1) / (x - 1)
            };
            Func<double, double> func = funcs[funcIndex];
            double expected = 0;
            for (int x = i; x <= n; x++)
                expected += func(x);

            // Act
            var actual = TFunctions.Sum(func, n, i);

            // Assert
            Assert.That(actual, Is.EqualTo(expected));
        }

        [Test]
        [TestCase(2, 3)]
        [TestCase(5, 2)]
        [TestCase(-2, 4)]
        [TestCase(3, 0)]
        [TestCase(4, -1)]
        [TestCase(2, 2)]
        [TestCase(-3, 3)]

        public void PowTest(int num, int pow)
        {
            // Arrange
            int expected = (int) Math.Pow(num, pow);

            // Act
            var actual = TFunctions.Pow(num, pow);

            // Assert
            Assert.That(actual, Is.EqualTo(expected));
        }

        [Test]
        [TestCase(2, 3)]
        [TestCase(5, 2)]
        [TestCase(-2, 4)]
        [TestCase(3, 0)]
        [TestCase(4, -1)]
        [TestCase(2.5, 2)]
        [TestCase(-3, 3)]

        public void Pow_WithInterface(double num, double pow)
        {
            // Arrange
            double expected = Math.Pow(num, pow);

            // Act
            var actual = TFunctions.Pow(num, pow);

            // Assert
            Assert.That(actual, Is.EqualTo(expected));
        }

        [Test]
        [TestCase(0, 1)]
        [TestCase(15, 7)]
        [TestCase(25, 4)]
        [TestCase(8, 2)]
        [TestCase(17, 5)]
        [TestCase(30, 6)]
        [TestCase(-11, 3)]
        public void Remainder(int num, int divider)
        {
            // Arrange
            int expected = num % divider;

            // Act
            var actual = TFunctions.Remainder(num, divider);

            // Assert
            Assert.That(actual, Is.EqualTo(expected));
        }
    }
}
