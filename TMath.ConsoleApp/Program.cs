using TMath.Numerics;
using TMath.Numerics.AdvancedMath.LinearAlgebra;
using TMath.Numerics.AdvancedMath.NumberTheory;
namespace TMath.ConsoleApp
{
    internal class Program
    {
        static void Main(string[] args)
        {
            ulong[] nums = TGeneration.Default.RandomArray<ulong>(10, 10, 100);
            Console.WriteLine($"GCD of [{string.Join(',', nums)}] = {NumberTheory.GCD(nums)}");
            Console.WriteLine($"LCM of [{string.Join(',', nums)}] = {NumberTheory.LCM(nums)}");
        }
    }
}
