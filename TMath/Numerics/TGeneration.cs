using System.Numerics;
using TMath.Numerics.Core;

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
            if (length < 0) throw new ArgumentOutOfRangeException(nameof(length), "Length must be greater than 0.");
            if(length == 0) return new T[0];

            if (min > max)
            {
                (min, max) = (max, min);
            }
            
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
            if(xLength < 0 || yLength < 0) throw new ArgumentOutOfRangeException("Length must be greater than 0.");
            if(xLength == 0 || yLength == 0) return new T[0,0];

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
            if (length < T.Zero) throw new ArgumentOutOfRangeException(nameof(length), "Length must be greater than 0.");
            if (length == T.Zero) return new T[0];
            int len = int.CreateSaturating(length);
            T[] result = new T[len];

            for(IndexPair<T> i = new(T.Zero, 0); i < len; i++)
            {
                result[i.Index] = function(i.Value);
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

            for (IndexPair<T> i = new(T.Zero, 0); i < length; i++)
            {
                result[i.Index] = function(start + i.Value);
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

            for (IndexPair<T> i = new(T.Zero, 0); i < length; i++)
            {
                result[i.Index] = function(start + step * i.Value);
            }
            return result;
        }

        public T[] PrimeSequence<T>(int length) where T : INumber<T>
        {
            if(length < 0) throw new ArgumentOutOfRangeException("Length must be greater than 0.");
            if(length == 0) return new T[0];
            T two = T.One + T.One;
            T current = two + T.One;
            List<T> primes = new() { two };
            while(primes.Count < length)
            {
                if(!primes.Any(x => current % x == T.Zero))
                {
                    primes.Add(current);
                }
                current += two;
            }
            return primes.ToArray();

        }
    }
}
