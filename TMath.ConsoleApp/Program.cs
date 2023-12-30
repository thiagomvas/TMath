using TMath.Numerics;
using TMath.Numerics.Models;
namespace TMath.ConsoleApp
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var data = TGeneration.Default.RandomArray<int>(1000, 0, 1);
            DescriptiveStatistics<int> stats = new(data);
            Console.WriteLine(stats);
        }
    }
}
