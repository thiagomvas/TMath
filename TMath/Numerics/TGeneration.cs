using System.Numerics;

namespace TMath.Numerics
{
    /// <summary>
    /// A utility class for generating random numbers and sequences of numbers.
    /// </summary>
    /// <remarks>
    /// It uses a seed for the random number generator, so if you want to generate the same numbers every time, use the same seed.
    /// Otherwise, use <see cref="TGeneration.Default"/> for the default instance of this class that always has the same seed.
    /// </remarks>
    public class TGeneration
    {
        private readonly Random random;

        /// <summary>
        /// The default instance of <see cref="TGeneration"/> that always has the same seed.
        /// </summary>
        public static readonly TGeneration Default = new TGeneration(0);
        public TGeneration()
        {
            random = new Random();
        }

        public TGeneration(int seed)
        {
            random = new Random(seed);
        }

        /// <summary>
        /// Generates a random number between <paramref name="min"/> and <paramref name="max"/>.
        /// </summary>
        /// <typeparam name="T">The numeric type implementing the INumber interface.</typeparam>
        /// <param name="min">The minimum value of the range.</param>
        /// <param name="max">The maximum value of the range.</param>
        /// <returns>A random number within the specified range.</returns>
        /// <remarks>
        /// For floating-point types, both the minimum and maximum values are inclusive. <br/>
        /// For integer types, the minimum value is inclusive, and the <strong>maximum value is exclusive.</strong>
        /// </remarks>
        public T RandomNumber<T>(T min, T max) where T : INumber<T>
        {
            // If min is bigger than max, swap them
            if (min > max)
            {
                (min, max) = (max, min);
            }

            T range = max - min;
            double randomValue = random.NextDouble();

            return min + range * T.CreateSaturating(randomValue);
        }

        /// <summary>
        /// Generates a random array of numbers within the specified range.
        /// </summary>
        /// <typeparam name="T">The numeric type implementing the INumber interface.</typeparam>
        /// <param name="length">The length of the array to generate.</param>
        /// <param name="min">The minimum value of the array elements.</param>
        /// <param name="max">The maximum value of the array elements.</param>
        /// <returns>An array of random numbers within the specified range.</returns>
        public T[] RandomArray<T>(int length, T min, T max) where T : INumber<T>
        {
            T[] result = new T[length];
            for (int i = 0; i < length; i++)
            {
                result[i] = RandomNumber(min, max);
            }
            return result;
        }

        /// <summary>
        /// Generates a random 2D array of numbers within the specified range.
        /// </summary>
        /// <typeparam name="T">The numeric type implementing the INumber interface.</typeparam>
        /// <param name="xLength">The length of the array in the X axis</param>
        /// <param name="yLength">The length of the array in the Y axis</param>
        /// <param name="min">The minimum value of the array elements.</param>
        /// <param name="max">The maximum value of the array elements.</param>
        /// <returns>A 2D array of random numbers within the specified range.</returns>
        public T[,] Random2DArray<T>(int xLength, int yLength, T min, T max) where T : INumber<T>
        {
            T[,] result = new T[xLength, yLength];
            for (int x = 0; x < xLength; x++)
            {
                for (int y = 0; y < yLength; y++)
                {
                    result[x, y] = RandomNumber(min, max);
                }
            }
            return result;
        }

        /// <summary>
        /// Generates an array where each element is a sequence of results from the specified function, starting from 0.
        /// </summary>
        /// <typeparam name="T">The numeric type implementing the INumber interface.</typeparam>
        /// <param name="function">The function to apply to generate the sequence.</param>
        /// <param name="length">The length of the resulting array.</param>
        /// <returns>An array representing the sequence of results from the specified function.</returns>
        public T[] FunctionSequence<T>(Func<T,T> function, T length) where T : INumber<T>
        {
            T[] result = new T[int.CreateSaturating(length)];

            for((T value, int index) i = (T.Zero, 0); i.value < length; i = (i.value + T.One, i.index + 1))
            {
                result[i.index] = function(i.value);
            }

            return result;
        }

        /// <summary>
        /// Generates an array where each element is a sequence of results from the specified function.
        /// </summary>
        /// <typeparam name="T">The numeric type implementing the INumber interface.</typeparam>
        /// <param name="function">The function to apply to generate the sequence.</param>
        /// <param name="start">The starting point of the sequence.</param>
        /// <param name="end">The ending point of the sequence.</param>
        /// <returns>An array representing the sequence of results from the specified function.</returns>
        public T[] FunctionSequence<T>(Func<T, T> function, T start, T end) where T : INumber<T>
        {
            // If min is bigger than max, swap them
            if (start > end)
            {
                (start, end) = (end, start);
            }

            T size = TFunctions.Floor(end - start);
            int length = int.CreateSaturating(size) + 1;
            T[] result = new T[length];

            for ((T value, int index) i = (T.Zero, 0); i.index < length; i = (i.value + T.One, i.index + 1))
            {
                result[i.index] = function(start + i.value);
            }
            return result;
        }

        /// <summary>
        /// Generates an array where each element is a sequence of results from the specified function.
        /// </summary>
        /// <typeparam name="T">The numeric type implementing the INumber interface.</typeparam>
        /// <param name="function">The function to apply to generate the sequence.</param>
        /// <param name="start">The starting point of the sequence.</param>
        /// <param name="end">The ending point of the sequence.</param>
        /// <param name="step">The step size between elements in the sequence.</param>
        /// <returns>An array representing the sequence of results from the specified function.</returns>
        public T[] FunctionSequence<T>(Func<T, T> function, T start, T end, T step) where T : INumber<T>
        {
            if (start == end && start == T.Zero) return new T[0];
            // If min is bigger than max, swap them
            if (start > end)
            {
                (start, end) = (end, start);
            }
            T size = TFunctions.Floor((end - start) / step);
            int length = int.CreateSaturating(size) + 1;
            T[] result = new T[length];

            for ((T value, int index) i = (T.Zero, 0); i.index < length; i = (i.value + T.One, i.index + 1))
            {
                result[i.index] = function(start + step * i.value);
            }
            return result;
        }

        
    }
}
