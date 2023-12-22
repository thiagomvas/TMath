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
                typeof(TFunctionsBenchmarks),
            });
            switcher.Run(args);
        }
    }
}
