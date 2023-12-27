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

    }
}
