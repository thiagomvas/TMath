using BenchmarkDotNet.Attributes;
using TMath.Modules;

namespace TMath.Benchmarks.Modules
{
    public class StatisticsBenchmarks
    {
        private readonly Random random = new Random(1);

        [Params(100, 1000, 10000)]
        public int arraySize;

        private int maxValue = 25;

        private double[] data;
        private int[] dataInt;

        [IterationSetup]
        public void Setup()
        {
            data = Enumerable.Range(0, arraySize).Select(x => (random.NextDouble() * 2 - 1) * maxValue).ToArray();
            dataInt = Enumerable.Range(0, arraySize).Select(x => random.Next(-maxValue, maxValue)).ToArray();
        }

        [Benchmark]
        public double Mean() => TStatistics.Mean(data);

        [Benchmark]
        public double MeanInt() => TStatistics.Mean<double,int>(dataInt);

        [Benchmark]
        public double Median() => TStatistics.Median(data);

        [Benchmark]
        public double MedianInt() => TStatistics.Median<double,int>(dataInt);

        [Benchmark]
        public double Variance() => TStatistics.Variance(data);
        [Benchmark]
        public double VarianceInt() => TStatistics.Variance<double,int>(dataInt);

        [Benchmark]
        public double StandardDeviation() => TStatistics.StandardDeviation(data);
        [Benchmark]
        public double StandardDeviationInt() => TStatistics.StandardDeviation<double,int>(dataInt);

        [Benchmark]
        public double Mode() => TStatistics.Mode(data);

        [Benchmark]
        public double ModeInt() => TStatistics.Mode(dataInt);

        [Benchmark]
        public double Percentile() => TStatistics.Percentile(data, 49);

        [Benchmark]
        public int PercentileInt() => TStatistics.Percentile(dataInt, 49);
    }
}
