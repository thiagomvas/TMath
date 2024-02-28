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
            var n = 25;
            Console.WriteLine($"Collatz Conjecture of {n}: {string.Join(',',NumberTheory.CollatzConjecture(n))}");
        }
    }
}
