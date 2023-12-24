```

BenchmarkDotNet v0.13.11, Windows 10 (10.0.19044.3086/21H2/November2021Update)
Intel Core i5-7300HQ CPU 2.50GHz (Kaby Lake), 1 CPU, 4 logical and 4 physical cores
.NET SDK 8.0.100
  [Host]     : .NET 8.0.0 (8.0.23.53103), X64 RyuJIT AVX2 [AttachedDebugger]
  DefaultJob : .NET 8.0.0 (8.0.23.53103), X64 RyuJIT AVX2


```
| Method | Mean      | Error    | StdDev   | Op/s         | Allocated |
|------- |----------:|---------:|---------:|-------------:|----------:|
| TSinh  |  73.11 ns | 0.829 ns | 0.692 ns | 13,678,005.8 |         - |
| TCosh  |  72.28 ns | 0.732 ns | 0.685 ns | 13,835,493.3 |         - |
| TTanh  | 150.36 ns | 1.922 ns | 1.798 ns |  6,650,629.8 |         - |
| TCoth  | 152.21 ns | 2.843 ns | 2.659 ns |  6,569,992.2 |         - |
| TSech  |  74.45 ns | 1.311 ns | 1.226 ns | 13,430,948.8 |         - |
| TCsch  |  75.11 ns | 1.134 ns | 1.005 ns | 13,313,116.2 |         - |
| TAsinh |  58.72 ns | 0.730 ns | 0.683 ns | 17,031,181.1 |         - |
| TAcosh |  58.39 ns | 0.776 ns | 0.726 ns | 17,126,598.4 |         - |
| TAtanh |        NA |       NA |       NA |           NA |        NA |

Benchmarks with issues:
  HyperbolicBenchmarks.TAtanh: DefaultJob
