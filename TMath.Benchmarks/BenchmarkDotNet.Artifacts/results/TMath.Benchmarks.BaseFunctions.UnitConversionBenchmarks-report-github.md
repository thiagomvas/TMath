```

BenchmarkDotNet v0.13.11, Windows 10 (10.0.19044.3086/21H2/November2021Update)
Intel Core i5-7300HQ CPU 2.50GHz (Kaby Lake), 1 CPU, 4 logical and 4 physical cores
.NET SDK 8.0.100
  [Host]     : .NET 8.0.0 (8.0.23.53103), X64 RyuJIT AVX2 [AttachedDebugger]
  DefaultJob : .NET 8.0.0 (8.0.23.53103), X64 RyuJIT AVX2


```
| Method          | Mean      | Error     | StdDev    | Median    | Op/s             | Allocated |
|---------------- |----------:|----------:|----------:|----------:|-----------------:|----------:|
| TRad2Deg        | 2.2309 ns | 0.0570 ns | 0.0533 ns | 2.2421 ns |    448,246,904.8 |         - |
| ManualRad2Deg   | 0.0183 ns | 0.0205 ns | 0.0192 ns | 0.0145 ns | 54,792,810,108.0 |         - |
| TToRadians      | 2.1596 ns | 0.0690 ns | 0.0646 ns | 2.1538 ns |    463,048,700.0 |         - |
| ManualToRadians | 0.0108 ns | 0.0192 ns | 0.0180 ns | 0.0000 ns | 92,738,127,471.6 |         - |
