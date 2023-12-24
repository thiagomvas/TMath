using BenchmarkDotNet.Attributes;

namespace TMath.Benchmarks.BaseFunctions
{
    public class UnitConversionBenchmarks
    {
        public double Value = 1.5d;

        [Benchmark]
        public double TRad2Deg() => TFunctions.Rad2Deg(Value);

        [Benchmark]
        public double ManualRad2Deg() => Value * 180d / Math.PI;

        [Benchmark]
        public double TToRadians() => TFunctions.ToRadians(Value);
        [Benchmark]
        public double ManualToRadians() => Value * Math.PI / 180d;
    }
}
