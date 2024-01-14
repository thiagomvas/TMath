using TMath.Numerics;
using TMath.Numerics.LinearAlgebra;
using TMath.Numerics.Models;
namespace TMath.ConsoleApp
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var v1 = new TVector<double>(5);
            for(int i = 0; i < v1.Size; i++)
            {
                v1[i] = i;
			}   
            var v2 = new TVector<double>(5);
			for(int i = 0; i < v2.Size; i++)
            {
                v2[i] = i + 1;
			}

			var v3 = v1 + v2;
			Console.WriteLine($"{v1} + {v2} = {v3}");
			Console.WriteLine($"{v1} - {v2} = {v1 - v2}");
			Console.WriteLine($"5 * {v1} = {5 * v1}");
			Console.WriteLine($"{v1} * 5 = {v1 * 5}");
			Console.WriteLine($"{v1} / 5 = {v1 / 5}");
			Console.WriteLine($"{v1++}++ = {v1}");
			Console.WriteLine($"{v1--}-- = {v1}");
			Console.WriteLine($"|{v1}| = {v1.Length}");
			Console.WriteLine($"{v1} == {v2} = {v1 == v2}");
			Console.WriteLine($"{v1} != {v2} = {v1 != v2}");
			Console.WriteLine($"{v1} > {v2} = {v1 > v2}");
			Console.WriteLine($"{v1} < {v2} = {v1 < v2}");
			Console.WriteLine($"{v1} >= {v2} = {v1 >= v2}");
			Console.WriteLine($"{v1} <= {v2} = {v1 <= v2}");
			Console.WriteLine($"{v1} + {v2} + {v3} = {v1 + v2 + v3}");
		}
    }
}
