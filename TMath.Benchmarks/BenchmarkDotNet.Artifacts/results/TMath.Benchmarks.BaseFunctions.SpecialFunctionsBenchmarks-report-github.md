```

BenchmarkDotNet v0.13.11, Windows 10 (10.0.19044.3086/21H2/November2021Update)
Intel Core i5-7300HQ CPU 2.50GHz (Kaby Lake), 1 CPU, 4 logical and 4 physical cores
.NET SDK 8.0.100
  [Host]     : .NET 8.0.0 (8.0.23.53103), X64 RyuJIT AVX2 [AttachedDebugger]
  DefaultJob : .NET 8.0.0 (8.0.23.53103), X64 RyuJIT AVX2


```
| Method     | Mean       | Error     | StdDev    | Median     | Op/s                | Allocated |
|----------- |-----------:|----------:|----------:|-----------:|--------------------:|----------:|
| TFactorial |  4.3765 ns | 0.1004 ns | 0.0890 ns |  4.3618 ns |       228,494,808.3 |         - |
| TSum       | 19.2691 ns | 0.2299 ns | 0.2151 ns | 19.2402 ns |        51,896,477.3 |         - |
| TRemainder |  0.0217 ns | 0.0214 ns | 0.0200 ns |  0.0209 ns |    46,107,614,194.6 |         - |
| TTruncate  | 34.4521 ns | 0.5706 ns | 0.5337 ns | 34.5895 ns |        29,025,804.3 |         - |
| TClamp     |  0.0108 ns | 0.0167 ns | 0.0156 ns |  0.0000 ns |    92,298,300,982.0 |         - |
| TCopySign  |  0.0004 ns | 0.0018 ns | 0.0015 ns |  0.0000 ns | 2,461,668,261,851.0 |         - |
