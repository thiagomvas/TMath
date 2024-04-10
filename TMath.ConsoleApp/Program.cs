using System.Numerics;
using TMath.Numerics;
using TMath.Numerics.AdvancedMath;
using TMath.Numerics.AdvancedMath.LinearAlgebra;
using TMath.Types;
namespace TMath.ConsoleApp
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var p = Polynomial<int>.Parse("1x^0 + 2x^1 + 3x^2 + 4x^10 + 5x^4 + 6x^5 + 7x^6 + 8x^7 + 9x^8 + 10x^9");
            Console.WriteLine(p);
        }
    }
}
