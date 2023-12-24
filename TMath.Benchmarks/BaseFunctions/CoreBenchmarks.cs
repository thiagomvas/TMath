using BenchmarkDotNet.Attributes;

namespace TMath.Benchmarks.BaseFunctions
{
    public class CoreBenchmarks
    {
        [Benchmark]
        public double IntToT() => TFunctions.IntToT<double>(10);
    }
}
