using System.Reflection;
using TMath;

// Num of functions in MathT
int numOfFunctions = typeof(MathT).GetMethods().Length;
Console.WriteLine($"Number of functions in MathT: {numOfFunctions}");

// Num of constants in TConstants
int numOfConstants = typeof(TConstants<double>).GetFields().Length + typeof(TConstants<double>).GetProperties(BindingFlags.Public).Length;
Console.WriteLine($"Number of constants in TConstants: {numOfConstants}");
Console.WriteLine(Math.Tan(Math.PI / 2));


