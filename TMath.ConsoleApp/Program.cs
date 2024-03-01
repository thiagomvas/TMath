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
            int[] arr = [1, 2, 3, 4, 5, 6, 7, 8];
            int k = 4;
            bool dup = true;
			Console.WriteLine(TCombinatorics.Permutations(arr, k, dup));
            var perms = TCombinatorics.GeneratePermutations(arr, k, dup);
            Console.WriteLine(perms.Count());
			foreach (var perm in perms)
                Console.WriteLine(string.Join(',', perm));
        }
    }
}
