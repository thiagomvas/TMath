```

BenchmarkDotNet v0.13.11, Windows 10 (10.0.19044.3086/21H2/November2021Update)
Intel Core i5-7300HQ CPU 2.50GHz (Kaby Lake), 1 CPU, 4 logical and 4 physical cores
.NET SDK 8.0.100
  [Host]     : .NET 8.0.0 (8.0.23.53103), X64 RyuJIT AVX2 [AttachedDebugger]
  DefaultJob : .NET 8.0.0 (8.0.23.53103), X64 RyuJIT AVX2


```
| Method       | Mean       | Error     | StdDev    | Op/s            | Allocated |
|------------- |-----------:|----------:|----------:|----------------:|----------:|
| TFloor       | 14.6320 ns | 0.2403 ns | 0.2247 ns |    68,343,550.4 |         - |
| MathFloor    |  0.4786 ns | 0.0206 ns | 0.0192 ns | 2,089,353,921.8 |         - |
| TCeil        | 15.0596 ns | 0.3340 ns | 0.4790 ns |    66,403,006.2 |         - |
| MathCeil     |  0.4726 ns | 0.0319 ns | 0.0283 ns | 2,116,112,938.7 |         - |
| TRound       | 14.8313 ns | 0.2544 ns | 0.2379 ns |    67,425,044.3 |         - |
| MathRound    |  0.4659 ns | 0.0381 ns | 0.0356 ns | 2,146,293,513.9 |         - |
| TTruncate    | 19.5857 ns | 0.2465 ns | 0.2305 ns |    51,057,686.3 |         - |
| MathTruncate |  0.3342 ns | 0.0378 ns | 0.0335 ns | 2,992,650,821.0 |         - |
