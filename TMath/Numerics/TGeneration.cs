using System.Numerics;

namespace TMath.Numerics
{
    public class TGeneration
    {
        private readonly Random random;
        public static readonly TGeneration Default = new TGeneration(0);
        public TGeneration()
        {
            random = new Random();
        }

        public TGeneration(int seed)
        {
            random = new Random(seed);
        }

        // FOR INTS: min is inclusive, max is exclusive
        // FOR FLOATS: min and max are inclusive
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

        public T[] RandomArray<T>(int length, T min, T max) where T : INumber<T>
        {
            T[] result = new T[length];
            for (int i = 0; i < length; i++)
            {
                result[i] = RandomNumber(min, max);
            }
            return result;
        }

        public T[] FunctionSequence<T>(Func<T,T> function, T length) where T : INumber<T>
        {
            T[] result = new T[int.CreateSaturating(length)];

            for((T value, int index) i = (T.Zero, 0); i.value < length; i = (i.value + T.One, i.index + 1))
            {
                result[i.index] = function(i.value);
            }

            return result;
        }

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
