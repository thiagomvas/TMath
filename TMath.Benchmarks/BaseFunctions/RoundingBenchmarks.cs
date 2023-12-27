using BenchmarkDotNet.Attributes;

namespace TMath.Benchmarks.BaseFunctions
{
    public class RoundingBenchmarks
    {
        public double Value = 1.5d;
        [Benchmark]
        public double TFloor() => TFunctions.Floor(Value);

        [Benchmark]
        public double MathFloor() => Math.Floor(Value);

        [Benchmark]
        public double TCeil() => TFunctions.Ceil(Value);

        [Benchmark]
        public double MathCeil() => Math.Ceiling(Value);

        [Benchmark]
        public double TRound() => TFunctions.Round(Value);

        [Benchmark]
        public double MathRound() => Math.Round(Value);
        [Benchmark]
        public double TTruncate() => TFunctions.Truncate(Value);

        [Benchmark]
        public double MathTruncate() => Math.Truncate(Value);
    }
}
