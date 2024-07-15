using TMath;

double val = 39 * TConstants<double>.Degree;
Console.WriteLine(MathT.Cos(val));   // Normal
Console.WriteLine(MathT.CosPS(val)); // Taylor