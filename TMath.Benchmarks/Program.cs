using System.Reflection;
using BenchmarkDotNet.Configs;
using TMath;
using BenchmarkDotNet.Running;


namespace TMath.Benchmarks
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var switcher = new BenchmarkSwitcher(Assembly.GetExecutingAssembly().GetTypes().Where(t => t.Name.Contains("Benchmark")).ToArray());
            switcher.Run(args);
        }
    }
}
