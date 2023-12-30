using TMath.Numerics;
namespace TMath.ConsoleApp
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var data = TGeneration.Default.RandomArray<int>(1000, 0, 10);
            foreach (var item in data)
            {
                Console.WriteLine(item);
            }
        }
    }
}
