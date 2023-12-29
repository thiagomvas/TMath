```

BenchmarkDotNet v0.13.11, Windows 10 (10.0.19044.3086/21H2/November2021Update)
Intel Core i5-7300HQ CPU 2.50GHz (Kaby Lake), 1 CPU, 4 logical and 4 physical cores
.NET SDK 8.0.100
  [Host]     : .NET 8.0.0 (8.0.23.53103), X64 RyuJIT AVX2 [AttachedDebugger]
  DefaultJob : .NET 8.0.0 (8.0.23.53103), X64 RyuJIT AVX2


```
| Method                        | length | Mean               | Error             | StdDev            | Op/s            | Gen0      | Allocated |
|------------------------------ |------- |-------------------:|------------------:|------------------:|----------------:|----------:|----------:|
| **RandomNumber**                  | **100**    |           **6.082 ns** |         **0.0893 ns** |         **0.0835 ns** | **164,428,022.871** |         **-** |         **-** |
| RandomArray                   | 100    |       1,121.196 ns |        19.8734 ns |        17.6172 ns |     891,904.653 |    0.2613 |     824 B |
| FunctionSequence_WithLength   | 100    |         210.841 ns |         4.2720 ns |         8.5317 ns |   4,742,906.806 |    0.2625 |     824 B |
| FunctionSequence_WithStep     | 100    |         245.095 ns |         4.9908 ns |        10.9549 ns |   4,080,050.596 |    0.2651 |     832 B |
| FunctionSequence_WithStartEnd | 100    |         244.316 ns |         4.9773 ns |        10.4987 ns |   4,093,057.153 |    0.2651 |     832 B |
| PrimeSequence                 | 100    |      33,309.796 ns |       659.0583 ns |     1,026.0744 ns |      30,021.199 |    9.4604 |   29712 B |
| **RandomNumber**                  | **1000**   |           **6.426 ns** |         **0.1652 ns** |         **0.2149 ns** | **155,607,351.094** |         **-** |         **-** |
| RandomArray                   | 1000   |      10,949.599 ns |       156.9237 ns |       131.0384 ns |      91,327.549 |    2.5482 |    8024 B |
| FunctionSequence_WithLength   | 1000   |       2,052.426 ns |        40.9228 ns |        99.6118 ns |     487,228.313 |    2.5558 |    8024 B |
| FunctionSequence_WithStep     | 1000   |       2,230.013 ns |        44.5664 ns |       114.2408 ns |     448,427.858 |    2.5635 |    8032 B |
| FunctionSequence_WithStartEnd | 1000   |       2,085.554 ns |        41.5481 ns |        44.4560 ns |     479,488.890 |    2.5635 |    8032 B |
| PrimeSequence                 | 1000   |   2,297,231.842 ns |    45,641.1116 ns |    72,391.6395 ns |         435.307 |  132.8125 |  424210 B |
| **RandomNumber**                  | **10000**  |           **6.434 ns** |         **0.1664 ns** |         **0.2105 ns** | **155,435,637.265** |         **-** |         **-** |
| RandomArray                   | 10000  |     108,649.712 ns |     2,126.8181 ns |     1,775.9895 ns |       9,203.890 |   24.9023 |   80025 B |
| FunctionSequence_WithLength   | 10000  |      17,893.396 ns |       253.4005 ns |       237.0310 ns |      55,886.541 |   24.9939 |   80024 B |
| FunctionSequence_WithStep     | 10000  |      20,134.831 ns |       395.3746 ns |       722.9648 ns |      49,665.180 |   24.9939 |   80032 B |
| FunctionSequence_WithStartEnd | 10000  |      20,465.892 ns |       401.7674 ns |       625.5034 ns |      48,861.784 |   24.9939 |   80032 B |
| PrimeSequence                 | 10000  | 224,631,377.273 ns | 3,791,443.7307 ns | 4,656,233.3943 ns |           4.452 | 1666.6667 | 5619352 B |
