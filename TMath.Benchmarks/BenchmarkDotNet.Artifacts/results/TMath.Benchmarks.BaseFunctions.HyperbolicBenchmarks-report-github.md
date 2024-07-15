```

BenchmarkDotNet v0.13.11, Windows 10 (10.0.19045.4529/22H2/2022Update)
Intel Core i5-7300HQ CPU 2.50GHz (Kaby Lake), 1 CPU, 4 logical and 4 physical cores
.NET SDK 8.0.206
  [Host]     : .NET 8.0.6 (8.0.624.26715), X64 RyuJIT AVX2 [AttachedDebugger]
  DefaultJob : .NET 8.0.6 (8.0.624.26715), X64 RyuJIT AVX2


```
| Method      | Mean     | Error    | StdDev   | Op/s         | Allocated |
|------------ |---------:|---------:|---------:|-------------:|----------:|
| TSinh       | 13.97 ns | 0.131 ns | 0.123 ns | 71,603,574.1 |         - |
| TSinhManual | 75.93 ns | 1.317 ns | 1.618 ns | 13,169,740.0 |         - |
