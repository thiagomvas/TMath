
using TMath.Numerics;
using TMath.Numerics.LinearAlgebra;
using TMath.Numerics.Models;
namespace TMath.ConsoleApp
{
    internal class Program
    {
        static void Main(string[] args)
		{
			double[] data = [1, 2, 3, 4, 5, 6, 7, 8, 9];
			Console.WriteLine(new DescriptiveStatistics<double>(data));
		}
    }
}
