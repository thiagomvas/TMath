using BenchmarkDotNet.Attributes;

namespace TMath.Benchmarks.BaseFunctions
{
    public class HyperbolicBenchmarks
    {
        public double Value = 1.5d;

        [Benchmark]
        public double TSinh() => TFunctions.Sinh(Value);

        [Benchmark]
        public double TCosh() => TFunctions.Cosh(Value);

        [Benchmark]
        public double TTanh() => TFunctions.Tanh(Value);

        [Benchmark]
        public double TCoth() => TFunctions.Coth(Value);

        [Benchmark]
        public double TSech() => TFunctions.Sech(Value);

        [Benchmark]
        public double TCsch() => TFunctions.Csch(Value);
        [Benchmark]
        public double TAsinh() => TFunctions.Asinh(Value);

        [Benchmark]
        public double TAcosh() => TFunctions.Acosh(Value);

        [Benchmark]
        public double TAtanh() => TFunctions.Atanh(Value);
    }
}
