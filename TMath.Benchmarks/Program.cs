using BenchmarkDotNet.Configs;
using TMath;
using BenchmarkDotNet.Running;


namespace TMath.Benchmarks
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var switcher = new BenchmarkSwitcher(new[]
            {
                typeof(AllTFunctionsBenchmarks),
                typeof(BaseFunctions.RoundingBenchmarks),
            });
            switcher.Run(args);
        }
    }
}
