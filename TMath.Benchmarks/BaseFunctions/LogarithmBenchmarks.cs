using BenchmarkDotNet.Attributes;

namespace TMath.Benchmarks.BaseFunctions
{
    public class LogarithmBenchmarks
    {
        [Benchmark]
        public double TLog() => TFunctions.Log(10d);

        [Benchmark]
        public double MathLog() => Math.Log(10d);

        [Benchmark]
        public double TLog2() => TFunctions.Log2(10d);
        [Benchmark]
        public double MathLog2() => Math.Log2(10d);
        [Benchmark]
        public double TLog10() => TFunctions.Log10(10d);
        [Benchmark]
        public double MathLog10() => Math.Log10(10d);
        [Benchmark]
        public double TLogN() => TFunctions.Log(10d, 2d);
        [Benchmark]
        public double MathLogN() => Math.Log(10d, 2d);
    }
}
