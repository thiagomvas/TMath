using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BenchmarkDotNet.Attributes;

namespace TMath.Benchmarks.BaseFunctions
{
    public class RootBenchmarks
    {
        public double Value = 8d;
        [Benchmark]
        public double TSqrt() => TFunctions.Sqrt(Value);
        [Benchmark]
        public double TSqrt_With_NRoot() => TFunctions.NRoot(Value, 2);
        [Benchmark]
        public double MathSqrt() => Math.Sqrt(Value);

        [Benchmark]
        public double TCbrt() => TFunctions.Cbrt(Value);

        [Benchmark]
        public double TCbrt_With_NRoot() => TFunctions.NRoot(Value, 3);

        [Benchmark]
        public double MathCbrt() => Math.Pow(Value, 1d / 3d);




    }
}
