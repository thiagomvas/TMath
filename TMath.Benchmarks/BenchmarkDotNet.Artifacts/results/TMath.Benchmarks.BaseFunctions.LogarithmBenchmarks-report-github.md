```

BenchmarkDotNet v0.13.11, Windows 10 (10.0.19044.3086/21H2/November2021Update)
Intel Core i5-7300HQ CPU 2.50GHz (Kaby Lake), 1 CPU, 4 logical and 4 physical cores
.NET SDK 8.0.100
  [Host]     : .NET 8.0.0 (8.0.23.53103), X64 RyuJIT AVX2 [AttachedDebugger]
  DefaultJob : .NET 8.0.0 (8.0.23.53103), X64 RyuJIT AVX2


```
| Method    | Mean       | Error     | StdDev    | Median     | Op/s              | Allocated |
|---------- |-----------:|----------:|----------:|-----------:|------------------:|----------:|
| TLog      |  5.4583 ns | 0.1218 ns | 0.1140 ns |  5.4843 ns |     183,206,905.1 |         - |
| MathLog   |  5.4360 ns | 0.1291 ns | 0.1208 ns |  5.4458 ns |     183,960,063.0 |         - |
| TLog2     | 11.3666 ns | 0.1316 ns | 0.1231 ns | 11.3986 ns |      87,977,111.0 |         - |
| MathLog2  | 11.3637 ns | 0.1868 ns | 0.1747 ns | 11.4133 ns |      87,999,148.5 |         - |
| TLog10    |  5.9154 ns | 0.1192 ns | 0.1115 ns |  5.9339 ns |     169,051,192.9 |         - |
| MathLog10 |  5.8536 ns | 0.1085 ns | 0.1015 ns |  5.8311 ns |     170,835,145.9 |         - |
| TLogN     |  0.0041 ns | 0.0073 ns | 0.0068 ns |  0.0000 ns | 243,342,026,252.8 |         - |
| MathLogN  |  0.0080 ns | 0.0133 ns | 0.0124 ns |  0.0000 ns | 125,238,152,468.0 |         - |
