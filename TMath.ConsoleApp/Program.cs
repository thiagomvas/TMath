using System.Reflection;
using TMath;
using TMath.Numerics;

// Num of functions in MathT
int numOfFunctions = typeof(MathT).GetMethods().Length;
Console.WriteLine($"Number of functions in MathT: {numOfFunctions}");

// Num of constants in TConstants
int numOfConstants = typeof(TConstants<double>).GetFields().Length + typeof(TConstants<double>).GetProperties(BindingFlags.Public).Length;
Console.WriteLine($"Number of constants in TConstants: {numOfConstants}");

Fraction<int> a = new(3, 2), b = new(5, 3);
Console.WriteLine($"{a} + {b} = {a + b}");
Console.WriteLine($"{a} - {b} = {a - b}");
Console.WriteLine($"{a} * {b} = {a * b}");
Console.WriteLine($"{a} / {b} = {a / b}");