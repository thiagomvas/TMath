using System.Numerics;
using TMath.Numerics;
using TMath.Numerics.AdvancedMath;
using TMath.Numerics.AdvancedMath.LinearAlgebra;
namespace TMath.ConsoleApp
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int[] arr = null;
            Console.WriteLine(TNumberTheory.CollatzConjecture(-1).Select(x => $"{x}, ").Aggregate((a, b) => a + b));
        }
    }
}
