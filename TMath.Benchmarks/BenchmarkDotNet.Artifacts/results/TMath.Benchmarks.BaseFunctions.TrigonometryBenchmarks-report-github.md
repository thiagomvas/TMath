```

BenchmarkDotNet v0.13.11, Windows 10 (10.0.19045.4529/22H2/2022Update)
Intel Core i5-7300HQ CPU 2.50GHz (Kaby Lake), 1 CPU, 4 logical and 4 physical cores
.NET SDK 8.0.206
  [Host]     : .NET 8.0.6 (8.0.624.26715), X64 RyuJIT AVX2 [AttachedDebugger]
  DefaultJob : .NET 8.0.6 (8.0.624.26715), X64 RyuJIT AVX2


```
| Method    | Mean      | Error     | StdDev    | Op/s          | Allocated |
|---------- |----------:|----------:|----------:|--------------:|----------:|
| TSin      |  7.392 ns | 0.0617 ns | 0.0547 ns | 135,277,824.9 |         - |
| MathSin   |  7.079 ns | 0.0711 ns | 0.0665 ns | 141,269,250.4 |         - |
| TCos      |  7.249 ns | 0.0804 ns | 0.0713 ns | 137,955,326.0 |         - |
| MathCos   |  7.263 ns | 0.0668 ns | 0.0592 ns | 137,692,161.5 |         - |
| TTan      | 15.342 ns | 0.3347 ns | 0.3287 ns |  65,182,446.5 |         - |
| MathTan   | 14.920 ns | 0.1935 ns | 0.1616 ns |  67,024,028.1 |         - |
| TTanOther | 20.614 ns | 0.3121 ns | 0.2767 ns |  48,511,677.0 |         - |
| TAsin     | 62.236 ns | 0.5422 ns | 0.5071 ns |  16,067,802.4 |         - |
| MathAsin  | 59.211 ns | 0.5031 ns | 0.4201 ns |  16,888,879.4 |         - |
| TAcos     | 60.282 ns | 0.4895 ns | 0.4579 ns |  16,588,568.8 |         - |
| MathAcos  | 60.967 ns | 0.8661 ns | 0.7233 ns |  16,402,354.1 |         - |
| TAtan     |  8.278 ns | 0.1302 ns | 0.1218 ns | 120,806,171.5 |         - |
| MathAtan  |  8.358 ns | 0.1471 ns | 0.1376 ns | 119,641,640.2 |         - |
