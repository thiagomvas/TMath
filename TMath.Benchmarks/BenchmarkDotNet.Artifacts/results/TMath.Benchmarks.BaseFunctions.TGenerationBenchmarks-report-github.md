```

BenchmarkDotNet v0.13.11, Windows 10 (10.0.19044.3086/21H2/November2021Update)
Intel Core i5-7300HQ CPU 2.50GHz (Kaby Lake), 1 CPU, 4 logical and 4 physical cores
.NET SDK 8.0.100
  [Host]     : .NET 8.0.0 (8.0.23.53103), X64 RyuJIT AVX2 [AttachedDebugger]
  DefaultJob : .NET 8.0.0 (8.0.23.53103), X64 RyuJIT AVX2


```
| Method                        | length | Mean           | Error         | StdDev        | Op/s          | Gen0    | Allocated |
|------------------------------ |------- |---------------:|--------------:|--------------:|--------------:|--------:|----------:|
| **RandomNumber**                  | **100**    |       **6.292 ns** |     **0.1557 ns** |     **0.1456 ns** | **158,941,138.7** |       **-** |         **-** |
| RandomArray                   | 100    |   1,107.546 ns |    21.9224 ns |    24.3667 ns |     902,897.2 |  0.2613 |     824 B |
| FunctionSequence_WithLength   | 100    |     194.233 ns |     2.5820 ns |     2.4152 ns |   5,148,457.0 |  0.2625 |     824 B |
| FunctionSequence_WithStep     | 100    |     231.060 ns |     4.7005 ns |     8.3551 ns |   4,327,873.5 |  0.2651 |     832 B |
| FunctionSequence_WithStartEnd | 100    |     237.503 ns |     4.7730 ns |    10.2744 ns |   4,210,471.0 |  0.2651 |     832 B |
| **RandomNumber**                  | **1000**   |       **6.273 ns** |     **0.1450 ns** |     **0.1356 ns** | **159,422,971.7** |       **-** |         **-** |
| RandomArray                   | 1000   |  10,988.957 ns |   194.7624 ns |   182.1808 ns |      91,000.4 |  2.5482 |    8024 B |
| FunctionSequence_WithLength   | 1000   |   2,083.315 ns |    52.9282 ns |   156.0600 ns |     480,004.3 |  2.5558 |    8024 B |
| FunctionSequence_WithStep     | 1000   |   2,085.708 ns |    27.4870 ns |    24.3665 ns |     479,453.5 |  2.5635 |    8032 B |
| FunctionSequence_WithStartEnd | 1000   |   2,098.111 ns |    41.6713 ns |   100.6409 ns |     476,619.1 |  2.5635 |    8032 B |
| **RandomNumber**                  | **10000**  |       **6.317 ns** |     **0.1236 ns** |     **0.1156 ns** | **158,303,607.0** |       **-** |         **-** |
| RandomArray                   | 10000  | 104,601.152 ns | 1,735.1601 ns | 1,623.0699 ns |       9,560.1 | 24.9023 |   80025 B |
| FunctionSequence_WithLength   | 10000  |  18,421.587 ns |   366.4417 ns |   863.7461 ns |      54,284.1 | 24.9939 |   80024 B |
| FunctionSequence_WithStep     | 10000  |  19,811.010 ns |   395.3931 ns |   692.4992 ns |      50,477.0 | 24.9939 |   80032 B |
| FunctionSequence_WithStartEnd | 10000  |  20,340.770 ns |   244.9785 ns |   217.1670 ns |      49,162.3 | 24.9939 |   80032 B |
