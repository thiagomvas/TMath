using TMath.Numerics;

namespace TMath.Tests.Numerics
{
    public class TGenerationTests
    {

        [Test]
        [TestCase(0, 10, 1)]
        [TestCase(0, 10, 0.5)]
        [TestCase(0, 10, 0.1)]
        [TestCase(0, 10, 2)]
        [TestCase(0, 10, 3)]
        [TestCase(0, 100, 4)]
        [TestCase(0, 100, 5)]
        public void FunctionSequenceTest(double start, double end, double step)
        {
            // Arrange
            Func<double, double> function = x => x * x;
            int size = (int)((end - start) / step);
            double[] expected = new double[size];
            for(int i = 0; i < size; i++)
            {
                expected[i] = function(start + step * i);
            }

            // Act
            double[] actual = TGeneration.Default.FunctionSequence(function, start, end, step);

            // Assert
            Assert.That(actual, Is.EqualTo(expected));
        }
    }
}
