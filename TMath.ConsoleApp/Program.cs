using System.Numerics;
using TMath.Numerics;
using TMath.Numerics.AdvancedMath.LinearAlgebra;
using TMath.Numerics.AdvancedMath.NumberTheory;
namespace TMath.ConsoleApp
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine(string.Join(", ", NumberTheory.GeneratePrimesUpTo(542)));
        }
    }
}
