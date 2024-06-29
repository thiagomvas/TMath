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
            Polynomial<double> p = new Polynomial<double>(-1, 1);

            for (int i = 2; i <= 6; i++)
            {
                p = p * new Polynomial<double>(i * Math.Pow(-1, i), 1);
            }

            Console.WriteLine(p);


        }
    }
}
