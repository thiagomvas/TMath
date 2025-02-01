using System.Numerics;

namespace TMath.Statistics;

public static class TStatistics
{
    public static TSelf Mean<TSelf>(IEnumerable<TSelf> data) where TSelf : INumberBase<TSelf>
    {
        var sum = TSelf.Zero;
        var count = TSelf.Zero;
        foreach (var item in data)
        {
            sum += item;
            count++;
        }
        return sum / count;
    }
    
    public static TSelf Median<TSelf>(IEnumerable<TSelf> data) where TSelf : INumberBase<TSelf>
    {
        var sortedData = data.OrderBy(x => x).ToArray();
        var n = sortedData.Length;
        if (n % 2 == 0)
            return (sortedData[n / 2 - 1] + sortedData[n / 2]) / Internals<TSelf>.Two;
        
        return sortedData[n / 2];
    }
    
    public static TSelf Variance<TSelf>(IEnumerable<TSelf> data) where TSelf : INumberBase<TSelf>
    {
        var mean = Mean(data);
        var sum = TSelf.Zero;
        var count = TSelf.Zero;
        foreach (var item in data)
        {
            sum += (item - mean) * (item - mean);
            count++;
        }
        return sum / count;
    }
    
    public static TSelf StandardDeviation<TSelf>(IEnumerable<TSelf> data) where TSelf : INumberBase<TSelf>, IRootFunctions<TSelf>
    {
        return TSelf.Sqrt(Variance(data));
    }
    
    public static TSelf Covariance<TSelf>(IEnumerable<TSelf> data1, IEnumerable<TSelf> data2) where TSelf : INumberBase<TSelf>
    {
        var mean1 = Mean(data1);
        var mean2 = Mean(data2);
        var sum = TSelf.Zero;
        var count = TSelf.Zero;
        var enumerator1 = data1.GetEnumerator();
        var enumerator2 = data2.GetEnumerator();
        while (enumerator1.MoveNext() && enumerator2.MoveNext())
        {
            sum += (enumerator1.Current - mean1) * (enumerator2.Current - mean2);
            count++;
        }
        return sum / count;
    }
    
    public static TSelf Correlation<TSelf>(IEnumerable<TSelf> data1, IEnumerable<TSelf> data2) where TSelf : INumberBase<TSelf>, IRootFunctions<TSelf>
    {
        return Covariance(data1, data2) / (StandardDeviation(data1) * StandardDeviation(data2));
    }
    
    public static TSelf Skewness<TSelf>(IEnumerable<TSelf> data) where TSelf : INumberBase<TSelf>, IRootFunctions<TSelf>
    {
        var mean = Mean(data);
        var variance = Variance(data);
        var sum = TSelf.Zero;
        var count = TSelf.Zero;
        foreach (var item in data)
        {
            sum += (item - mean) * (item - mean) * (item - mean);
            count++;
        }
        return sum / (count * variance * StandardDeviation(data));
    }
    
    public static TSelf Kurtosis<TSelf>(IEnumerable<TSelf> data) where TSelf : INumberBase<TSelf>
    {
        var mean = Mean(data);
        var variance = Variance(data);
        var sum = TSelf.Zero;
        var count = TSelf.Zero;
        foreach (var item in data)
        {
            sum += (item - mean) * (item - mean) * (item - mean) * (item - mean);
            count++;
        }
        return sum / (count * variance * variance);
    }
    
    public static TSelf Mode<TSelf>(IEnumerable<TSelf> data) where TSelf : INumberBase<TSelf>
    {
        var groupedData = data.GroupBy(x => x).Select(x => new { Value = x.Key, Count = x.Count() }).ToArray();
        var maxCount = groupedData.Max(x => x.Count);
        return groupedData.First(x => x.Count == maxCount).Value;
    }
    
    public static TSelf Range<TSelf>(IEnumerable<TSelf> data) where TSelf : INumberBase<TSelf>
    {
        var sortedData = data.OrderBy(x => x).ToArray();
        return sortedData[^1] - sortedData[0];
    }
    
    public static TSelf Percentile<TSelf>(IEnumerable<TSelf> data, TSelf percentile) where TSelf : INumberBase<TSelf>
    {
        var sortedData = data.OrderBy(x => x).ToArray();
        var n = sortedData.Length;
        var rank = percentile * TSelf.CreateSaturating(n - 1);
        int iRank = int.CreateSaturating(rank);
        var lower = sortedData[iRank];
        var upper = sortedData[iRank + 1];
        return lower + (upper - lower) * (rank - TSelf.CreateSaturating(iRank));
    }
    
    
}