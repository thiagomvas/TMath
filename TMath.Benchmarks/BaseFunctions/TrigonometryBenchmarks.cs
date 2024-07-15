using BenchmarkDotNet.Attributes;

namespace TMath.Benchmarks.BaseFunctions
{
    public class TrigonometryBenchmarks
    {
        public double Value = 1.5d;

        [Benchmark]
        public double TSin() => MathT.Sin(Value);

        [Benchmark]
        public double MathSin() => Math.Sin(Value);

        [Benchmark]
        public double TCos() => MathT.Cos(Value);
        [Benchmark]
        public double MathCos() => Math.Cos(Value);


        [Benchmark]
        public double TTan() => MathT.Tan(Value);
        [Benchmark]
        public double MathTan() => Math.Tan(Value);


        [Benchmark]
        public double TAsin() => MathT.Asin(Value);
        [Benchmark]
        public double MathAsin() => Math.Asin(Value);

        [Benchmark]
        public double TAcos() => MathT.Acos(Value);
        [Benchmark]
        public double MathAcos() => Math.Acos(Value);
        [Benchmark]
        public double TAtan() => MathT.Atan(Value);
        [Benchmark]
        public double MathAtan() => Math.Atan(Value);


    }
}
