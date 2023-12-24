```

BenchmarkDotNet v0.13.11, Windows 10 (10.0.19044.3086/21H2/November2021Update)
Intel Core i5-7300HQ CPU 2.50GHz (Kaby Lake), 1 CPU, 4 logical and 4 physical cores
.NET SDK 8.0.100
  [Host]     : .NET 8.0.0 (8.0.23.53103), X64 RyuJIT AVX2 [AttachedDebugger]
  DefaultJob : .NET 8.0.0 (8.0.23.53103), X64 RyuJIT AVX2


```
| Method           | Mean       | Error     | StdDev    | Op/s            | Allocated |
|----------------- |-----------:|----------:|----------:|----------------:|----------:|
| TSqrt            |  3.6001 ns | 0.1055 ns | 0.0987 ns |   277,770,883.6 |         - |
| TSqrt_With_NRoot |  0.9118 ns | 0.0466 ns | 0.0436 ns | 1,096,675,263.1 |         - |
| MathSqrt         |  3.6891 ns | 0.0987 ns | 0.1097 ns |   271,068,074.8 |         - |
| TCbrt            | 57.7141 ns | 0.9129 ns | 0.8539 ns |    17,326,788.6 |         - |
| TCbrt_With_NRoot | 59.2883 ns | 0.8999 ns | 0.8417 ns |    16,866,723.1 |         - |
| MathCbrt         | 33.1519 ns | 0.5815 ns | 0.5440 ns |    30,164,153.3 |         - |
