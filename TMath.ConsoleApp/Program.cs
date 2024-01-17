
using TMath.Numerics.LinearAlgebra;
namespace TMath.ConsoleApp
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var v1 = new TVector3<double>(1,2,3);
            var v2 = new TVector3<double>(3, 4, 5);


			var v3 = v1 + v2;
			Console.WriteLine($"{v1} + {v2} = {v3}");
			Console.WriteLine($"{v1} - {v2} = {v1 - v2}");
			Console.WriteLine($"-{v1} = {-v1}");
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
