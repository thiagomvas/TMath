using BenchmarkDotNet.Running;
using TMath;

namespace TMath.Benchmarks
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var summary = BenchmarkRunner.Run<TFunctionsBenchmarks>();
        }
    }
}
