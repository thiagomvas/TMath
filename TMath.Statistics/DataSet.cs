using System.Numerics;

namespace TMath.Statistics;

public class DataSet<T> where T : INumberBase<T>
{
    public T Mean { get; init; }
    public T Median { get; init; }
    public T Variance { get; init; }
    public T StandardDeviation { get; init; }
    public T Covariance { get; init; }
    public T Kurtosis { get; init; }
    public T? Min { get; init; }
    public T? Max { get; init; }
    public T Range { get; init; }
    public T Sum { get; init; }
    public T? Mode { get; init; }

    public DataSet(IEnumerable<T> set)
    {
        var arr = set as T[] ?? set.ToArray();
        Mean = TStatistics.Mean(arr);
        Median = TStatistics.Median(arr);
        Variance = TStatistics.Variance(arr);
        StandardDeviation = TStatistics.StandardDeviationBoxed(arr);
        Covariance = TStatistics.Covariance(arr, arr);
        Kurtosis = TStatistics.Kurtosis(arr);
        Min = arr.Min();
        Max = arr.Max();
        Range = Max - Min;
        Sum = arr.Aggregate((a, b) => a + b);
        Mode = TStatistics.Mode(arr);
    }

    public override string ToString()
    {
        return $"Mean: {Mean}, Median: {Median}, Variance: {Variance}, Standard Deviation: {StandardDeviation}, Covariance: {Covariance}, Kurtosis: {Kurtosis}, Min: {Min}, Max: {Max}, Range: {Range}, Sum: {Sum}, Mode: {Mode}";
    }
}