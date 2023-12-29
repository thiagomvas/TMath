using TMath.Numerics;

namespace TMath.Tests.Numerics
{
    public class TGenerationTests
    {

        [Test]
        [TestCase(0, 10, 1)]
        [TestCase(3, 10, 0.5)]
        [TestCase(10, 10, 1)]
        [TestCase(2, 25, 2)]
        [TestCase(0, 10, 3)]
        [TestCase(0, 0, 1)]
        [TestCase(3, 1, 1)]
        public void FunctionSequenceTest(double start, double end, double step)
        {
            // Arrange

            if (start > end)
                (start, end) = (end, start);


            Func<double, double> function = x => x * x;
            int size = (int)((end - start) / step) + 1;
            double[] expected = new double[size];
            for(int i = 0; i < size; i++)
            {
                expected[i] = function(start + step * i);
            }

            if(start == end && start == 0)
                expected = new double[0];

            // Act
            double[] actual = TGeneration.Default.FunctionSequence(function, start, end, step);

            // Assert
            Assert.That(actual, Is.EqualTo(expected));
        }

        [Test]
        [TestCase(0)]
        [TestCase(1)]
        [TestCase(2)]
        [TestCase(3)]
        [TestCase(10)]
        [TestCase(100)]
        [TestCase(1000)]
        public void FunctionSequence_WithLength(double length)
        {

            // Arrange
            Func<double, double> function = x => x * x;
            double[] expected = new double[(int)length];
            for (int i = 0; i < length; i++)
            {
                expected[i] = function(i);
            }

            // Act
            double[] actual = TGeneration.Default.FunctionSequence(function, length);

            // Assert
            Assert.That(actual, Is.EqualTo(expected));
        }

        [Test]
        [TestCase(0, 10)]
        [TestCase(3, 10)]
        [TestCase(10, 10)]
        [TestCase(2, 25)]
        [TestCase(0, 10)]
        [TestCase(0, 0)]
        [TestCase(3, 1)]

        public void FunctionSequence_WithStartEnd(double start, double end)
        {
            if (start > end)
                (start, end) = (end, start);
            // Arrange
            Func<double, double> function = x => x * x;
            double length = end - start + 1;
            double[] expected = new double[(int)length];
            for (int i = 0; i < length; i++)
            {
                expected[i] = function(start + i);
            }

            // Act
            double[] actual = TGeneration.Default.FunctionSequence(function, start, end);

            // Assert
            Assert.That(actual, Is.EqualTo(expected));
        }

        [Test]
        public void RandomArray_NegativeLengthException()
        {
            Assert.Throws<ArgumentOutOfRangeException>(() => TGeneration.Default.RandomArray<double>(-1, 0, 1));
        }

        [Test]
        public void FunctionSequence_NegativeLengthException()
        {
            // Arrange
            Func<double, double> function = x => x * x;
            double length = -1;

            // Act

            // Assert
            Assert.Throws<ArgumentOutOfRangeException>(() => TGeneration.Default.FunctionSequence(function, length));
        }

        [Test]
        [TestCase(0)]
        [TestCase(1)]
        [TestCase(2)]
        [TestCase(3)]
        [TestCase(4)]
        [TestCase(10)]
        [TestCase(15)]
        public void Primes(int length)
        {
            // Arrange
            List<int> primes = new() { 2 };
            int current = 3;
            while (primes.Count < length)
            {
                if (!primes.Any(x => current % x == 0))
                    primes.Add(current);
                current += 2;
            }
            int[] expected = length == 0 ? new int[0] : primes.ToArray();

            // Act
            int[] actual = TGeneration.Default.PrimeSequence<int>(length);

            // Assert
            Assert.That(actual, Is.EqualTo(expected));

        }

        [Test]
        public void PrimeSequence_WithNegativeLength() => Assert.Throws<ArgumentOutOfRangeException>(() => TGeneration.Default.PrimeSequence<int>(-1));
    }
}
