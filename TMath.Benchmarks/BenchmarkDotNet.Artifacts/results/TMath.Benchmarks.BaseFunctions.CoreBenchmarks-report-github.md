```

BenchmarkDotNet v0.13.11, Windows 10 (10.0.19044.3086/21H2/November2021Update)
Intel Core i5-7300HQ CPU 2.50GHz (Kaby Lake), 1 CPU, 4 logical and 4 physical cores
.NET SDK 8.0.100
  [Host]     : .NET 8.0.0 (8.0.23.53103), X64 RyuJIT AVX2 [AttachedDebugger]
  DefaultJob : .NET 8.0.0 (8.0.23.53103), X64 RyuJIT AVX2


```
| Method | Mean     | Error     | StdDev    | Op/s          | Allocated |
|------- |---------:|----------:|----------:|--------------:|----------:|
| IntToT | 1.611 ns | 0.0624 ns | 0.0584 ns | 620,628,654.8 |         - |
