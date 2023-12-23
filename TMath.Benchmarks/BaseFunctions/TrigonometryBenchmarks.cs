using BenchmarkDotNet.Attributes;

namespace TMath.Benchmarks.BaseFunctions
{
    public class TrigonometryBenchmarks
    {
        public double Value = 1.5d;

        [Benchmark]
        public double TSin() => TFunctions.Sin(Value);

        [Benchmark]
        public double MathSin() => Math.Sin(Value);

        [Benchmark]
        public double TCos() => TFunctions.Cos(Value);
        [Benchmark]
        public double MathCos() => Math.Cos(Value);


        [Benchmark]
        public double TTan() => TFunctions.Tan(Value);
        [Benchmark]
        public double MathTan() => Math.Tan(Value);


        [Benchmark]
        public double TAsin() => TFunctions.Asin(Value);
        [Benchmark]
        public double MathAsin() => Math.Asin(Value);

        [Benchmark]
        public double TAcos() => TFunctions.Acos(Value);
        [Benchmark]
        public double MathAcos() => Math.Acos(Value);
        [Benchmark]
        public double TAtan() => TFunctions.Atan(Value);
        [Benchmark]
        public double MathAtan() => Math.Atan(Value);


    }
}
