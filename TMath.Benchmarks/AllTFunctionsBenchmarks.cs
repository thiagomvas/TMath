using BenchmarkDotNet.Attributes;

namespace TMath.Benchmarks
{
    public class AllTFunctionsBenchmarks
    {
        private const double value = 1.23456789d;

        [Benchmark]
        public double TAbs() => TFunctions.Abs(value);

        [Benchmark]
        public double MathAbs() => Math.Abs(value);

        [Benchmark]
        public double TFloor() => TFunctions.Floor(value);

        [Benchmark]
        public double MathFloor() => Math.Floor(value);

        [Benchmark]
        public double TCeil() => TFunctions.Ceil(value);

        [Benchmark]
        public double MathCeil() => Math.Ceiling(value);

        [Benchmark]
        public double TRound() => TFunctions.Round(value);

        [Benchmark]
        public double MathRound() => Math.Round(value);

        [Benchmark]
        public double TToRadians() => TFunctions.ToRadians(value);

        [Benchmark]
        public double MathToRadians() => Math.PI * value / 180.0;

        [Benchmark]
        public double TRad2Deg() => TFunctions.Rad2Deg(value);

        [Benchmark]
        public double MathRad2Deg() => value * 180.0 / Math.PI;

        [Benchmark]
        public double TClamp() => TFunctions.Clamp(value, 0.0, 1.0);

        [Benchmark]
        public double MathClamp() => Math.Clamp(value, 0.0, 1.0);
    }
}
