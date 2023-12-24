```

BenchmarkDotNet v0.13.11, Windows 10 (10.0.19044.3086/21H2/November2021Update)
Intel Core i5-7300HQ CPU 2.50GHz (Kaby Lake), 1 CPU, 4 logical and 4 physical cores
.NET SDK 8.0.100
  [Host]     : .NET 8.0.0 (8.0.23.53103), X64 RyuJIT AVX2 [AttachedDebugger]
  DefaultJob : .NET 8.0.0 (8.0.23.53103), X64 RyuJIT AVX2


```
| Method   | Mean      | Error     | StdDev    | Op/s          | Allocated |
|--------- |----------:|----------:|----------:|--------------:|----------:|
| TSin     |  7.114 ns | 0.1679 ns | 0.1488 ns | 140,575,001.5 |         - |
| MathSin  |  6.732 ns | 0.1309 ns | 0.1225 ns | 148,549,469.9 |         - |
| TCos     |  6.922 ns | 0.1673 ns | 0.1565 ns | 144,468,386.0 |         - |
| MathCos  |  6.931 ns | 0.1292 ns | 0.1208 ns | 144,277,415.0 |         - |
| TTan     | 14.436 ns | 0.2340 ns | 0.2075 ns |  69,271,448.4 |         - |
| MathTan  | 14.318 ns | 0.3021 ns | 0.2826 ns |  69,843,174.0 |         - |
| TAsin    | 57.921 ns | 0.4341 ns | 0.4061 ns |  17,264,900.0 |         - |
| MathAsin | 56.864 ns | 0.5783 ns | 0.5410 ns |  17,585,908.2 |         - |
| TAcos    | 55.769 ns | 0.6573 ns | 0.6148 ns |  17,931,154.0 |         - |
| MathAcos | 57.533 ns | 0.4521 ns | 0.4229 ns |  17,381,395.3 |         - |
| TAtan    |  7.770 ns | 0.1330 ns | 0.1244 ns | 128,695,536.4 |         - |
| MathAtan |  8.899 ns | 0.1302 ns | 0.1218 ns | 112,371,461.8 |         - |
