```

BenchmarkDotNet v0.13.11, Windows 10 (10.0.19044.3086/21H2/November2021Update)
Intel Core i5-7300HQ CPU 2.50GHz (Kaby Lake), 1 CPU, 4 logical and 4 physical cores
.NET SDK 8.0.100
  [Host]     : .NET 8.0.0 (8.0.23.53103), X64 RyuJIT AVX2 [AttachedDebugger]
  DefaultJob : .NET 8.0.0 (8.0.23.53103), X64 RyuJIT AVX2


```
| Method                        | length | Mean          | Error       | StdDev      | Op/s          | Gen0    | Allocated |
|------------------------------ |------- |--------------:|------------:|------------:|--------------:|--------:|----------:|
| **RandomNumber**                  | **100**    |      **6.043 ns** |   **0.0507 ns** |   **0.0449 ns** | **165,494,069.1** |       **-** |         **-** |
| RandomArray                   | 100    |    527.835 ns |   7.9904 ns |   7.0833 ns |   1,894,533.2 |  0.2623 |     824 B |
| FunctionSequence_WithLength   | 100    |    237.397 ns |   4.6652 ns |   6.5400 ns |   4,212,350.3 |  0.2625 |     824 B |
| FunctionSequence_WithStep     | 100    |    227.666 ns |   3.5216 ns |   3.2941 ns |   4,392,390.5 |  0.2651 |     832 B |
| FunctionSequence_WithStartEnd | 100    |    225.333 ns |   3.8510 ns |   3.6023 ns |   4,437,873.9 |  0.2651 |     832 B |
| **RandomNumber**                  | **1000**   |      **5.893 ns** |   **0.1148 ns** |   **0.1074 ns** | **169,683,863.7** |       **-** |         **-** |
| RandomArray                   | 1000   |  5,062.349 ns | 100.2618 ns | 102.9615 ns |     197,536.8 |  2.5558 |    8024 B |
| FunctionSequence_WithLength   | 1000   |  2,190.990 ns |  32.7066 ns |  28.9936 ns |     456,414.7 |  2.5558 |    8024 B |
| FunctionSequence_WithStep     | 1000   |  2,051.673 ns |  28.8719 ns |  27.0068 ns |     487,407.2 |  2.5635 |    8032 B |
| FunctionSequence_WithStartEnd | 1000   |  2,088.399 ns |  39.6885 ns |  38.9794 ns |     478,835.8 |  2.5635 |    8032 B |
| **RandomNumber**                  | **10000**  |      **5.894 ns** |   **0.1138 ns** |   **0.1064 ns** | **169,674,819.9** |       **-** |         **-** |
| RandomArray                   | 10000  | 48,373.420 ns | 612.0248 ns | 542.5440 ns |      20,672.5 | 24.9634 |   80024 B |
| FunctionSequence_WithLength   | 10000  | 20,290.566 ns | 192.2449 ns | 179.8260 ns |      49,284.0 | 24.9939 |   80024 B |
| FunctionSequence_WithStep     | 10000  | 19,080.594 ns | 262.4291 ns | 219.1402 ns |      52,409.3 | 24.9939 |   80032 B |
| FunctionSequence_WithStartEnd | 10000  | 19,377.131 ns | 363.9956 ns | 340.4817 ns |      51,607.2 | 24.9939 |   80032 B |
