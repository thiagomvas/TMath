using BenchmarkDotNet.Attributes;
using TMath.Numerics;

namespace TMath.Benchmarks.Numerics
{
    public class TGenerationBenchmarks
    {
        [Params(100, 1000, 10000)]
        public int length;

        [Benchmark]
        public double RandomNumber() => TGeneration.Default.RandomNumber(0, 1);

        [Benchmark]
        public double[] RandomArray() => TGeneration.Default.RandomArray<double>(length, 0, 1);

        [Benchmark]
        public double[] FunctionSequence_WithLength() => TGeneration.FunctionSequence<double>(x => x * x, length);

        [Benchmark]
        public double[] FunctionSequence_WithStep() => TGeneration.FunctionSequence<double>(x => x * x, 0, length, 1);

        [Benchmark]
        public double[] FunctionSequence_WithStartEnd() => TGeneration.FunctionSequence<double>(x => x * x, 0, length);

        [Benchmark]
        public int[] PrimeSequence() => TGeneration.PrimeSequence<int>(length);




    }
}
