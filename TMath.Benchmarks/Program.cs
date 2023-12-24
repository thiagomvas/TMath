using System.Reflection;
using BenchmarkDotNet.Columns;
using BenchmarkDotNet.Configs;
using BenchmarkDotNet.Diagnosers;
using BenchmarkDotNet.Exporters;
using BenchmarkDotNet.Running;


namespace TMath.Benchmarks
{
    internal class Program
    {
        static void Main(string[] args)
        {
            ManualConfig config = ManualConfig.Create(DefaultConfig.Instance)
                .AddExporter(MarkdownExporter.GitHub)
                .AddColumn(StatisticColumn.OperationsPerSecond)
                .AddDiagnoser(MemoryDiagnoser.Default);

            var switcher = new BenchmarkSwitcher(Assembly.GetExecutingAssembly().GetTypes()
                                                .Where(t => t.Name.Contains("Benchmark"))
                                                .ToArray())
                                                .Run(args, config);

            
        }
    }
}
