# TMath - Generics Math Library for C#
[![NUnit Tests](https://github.com/thiagomvas/TMath/actions/workflows/dotnet.yml/badge.svg)](https://github.com/thiagomvas/TMath/actions/workflows/dotnet.yml) [![Version](https://img.shields.io/nuget/v/tmath
)](https://www.nuget.org/packages/TMath/) ![Downloads](https://img.shields.io/nuget/dt/tmath
) ![Stars](https://img.shields.io/github/stars/thiagomvas/tmath 
) ![License](https://img.shields.io/github/license/thiagomvas/tmath)


TMath is a C# Math library that has function implementations for any number or custom type 
that implements ``INumber<T>``. Some functions require other implementations like 
``ILogarithmicFunctions<T>`` or ``IPowerFunctions<T>``.

## 🌟 • Features
- **Generics Support**: With TFunctions, you can make calculations using all number types with the same
function call, doesn't matter if you're using `float`, `ulong`, `decimal` or your custom 
numeric type, as long as it implements `INumber<T>`
- **Generics Constants:** TMath also has a ``TConstants<T>`` class for getting mathematical
constants as any numeric type, such as **Euler's Number, Pi, Golden Ratio** and common square roots
- **Expanded math functions**: More math functions not supported by the default `Math` class
that also work with generics, such as ``Factorial()``.
- **Generics Easings Class:** ``TEasings`` offers a handful of easing functions for usage in
your projects that support any ``INumber<T>``

## 📙 • Getting Started
### Installation
There are multiple ways of installing TMath on your project:
1. **NuGet Package Manager**: From your IDE, simply open the package manager and search for TMath
2. **.NET CLI**: Open a command line and switch to the directory that contains your project file.
After that, run the following command
```shell 
dotnet add package TMath
```
3. **Forking / Cloning the repository**: Clone the repository into your projects and keep the package 
saved on your project files.
> [!IMPORTANT]
> Downloading the files manually means you will have to update the package manually if you want the
> latest release whenever the package gets updated

## 🔧 • Usage
Using TMath is very simple, simply call the functions like you would with ``Math`` and it'll automatically 
return
the correct type for most functions, with the exception of a handful of them like ``Factorial<T>()``.

For getting any constants using ``TConstants<T>``, specify your type (for example, ``TConstants<float>``).
```csharp
// Calculating the area of a circle arc.
decimal angle = TConstants<decimal>.Pi;
decimal radius = 1;
decimal areaOfArc = (TFunctions.Rad2Deg(angle) / 360) * TConstants<decimal>.Pi * TFunctions.Pow(radius, 2);
Console.WriteLine(areaOfArc);

// Calculating 20!
long factorial = TFunctions.Factorial<long>(20);
Console.WriteLine(factorial);

// Absolute value
sbyte number = -34;
sbyte abs = TFunctions.Abs(number);
Console.WriteLine(abs);
```

## 🤝 • Contributing
If you'd like to contribute in anyways, check out the [Contributing Guidelines](https://github.com/thiagomvas/TMath/blob/master/CONTRIBUTING.md) for info on how you can contribute.

## 📄 • License
TMath is licensed under the [MIT License](https://github.com/thiagomvas/TMath/blob/master/LICENSE).
