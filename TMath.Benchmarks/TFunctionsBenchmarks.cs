using BenchmarkDotNet.Attributes;

namespace TMath.Benchmarks
{
    public class TFunctionsBenchmarks
    {
        private const double number = 2345.0;


        [Benchmark]
        public double IntToT() => TFunctions.IntToT<double>(2345);
        [Benchmark]
        public double CreateSaturating() => double.CreateSaturating(2345);

        [Benchmark]
        public double TAbs() => TFunctions.Abs(-number);
        [Benchmark]
        public double MathAbs() => Math.Abs(-number);

        [Benchmark]
        public double TFloor() => TFunctions.Floor(number);
        [Benchmark]
        public double MathFloor() => Math.Floor(number);

        [Benchmark]
        public double TCeil() => TFunctions.Ceil(number);
        [Benchmark]
        public double MathCeil() => Math.Ceiling(number);

        [Benchmark]
        public double TRound() => TFunctions.Round(number);
        [Benchmark]
        public double MathRound() => Math.Round(number);

        [Benchmark]
        public double TToRadians() => TFunctions.ToRadians(number);
        [Benchmark]
        public double MathToRadians() => Math.PI * 2345.0 / 180.0;

        [Benchmark]
        public double TRad2Deg() => TFunctions.Rad2Deg(number);
        [Benchmark]
        public double MathRad2Deg() => 2345.0 * 180.0 / Math.PI;
    }
}
