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


    }
}
