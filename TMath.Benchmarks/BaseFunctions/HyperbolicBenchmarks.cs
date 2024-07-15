using BenchmarkDotNet.Attributes;

namespace TMath.Benchmarks.BaseFunctions
{
    public class HyperbolicBenchmarks
    {
        public double Value = 1.5d;

        [Benchmark]
        public double TSinh() => MathT.Sinh(Value);
        [Benchmark]
        public double TSinhManual() => MathT.SinhManual(Value);

    }
}
