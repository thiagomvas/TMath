using System.Numerics;

namespace TMath.Statistics;

/// <summary>
/// Provides statistical methods for numerical data.
/// </summary>
public static class TStatistics
{
    /// <summary>
    /// Computes the mean of the given data.
    /// </summary>
    /// <typeparam name="TSelf">The type of the data elements.</typeparam>
    /// <param name="data">The data to compute the mean for.</param>
    /// <returns>The mean of the data.</returns>
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
    
    /// <summary>
    /// Computes the median of the given data.
    /// </summary>
    /// <typeparam name="TSelf">The type of the data elements.</typeparam>
    /// <param name="data">The data to compute the median for.</param>
    /// <returns>The median of the data.</returns>
    public static TSelf Median<TSelf>(IEnumerable<TSelf> data) where TSelf : INumberBase<TSelf>
    {
        var sortedData = data.OrderBy(x => x).ToArray();
        var n = sortedData.Length;
        if (n % 2 == 0)
            return (sortedData[n / 2 - 1] + sortedData[n / 2]) / Internals<TSelf>.Two;
        
        return sortedData[n / 2];
    }
    
    /// <summary>
    /// Computes the variance of the given data.
    /// </summary>
    /// <typeparam name="TSelf">The type of the data elements.</typeparam>
    /// <param name="data">The data to compute the variance for.</param>
    /// <returns>The variance of the data.</returns>
    public static TSelf Variance<TSelf>(IEnumerable<TSelf> data) where TSelf : INumberBase<TSelf>
    {
        var arr = data as TSelf[] ?? data.ToArray();
        var mean = Mean(arr);
        var sum = TSelf.Zero;
        var count = TSelf.Zero;
        foreach (var item in arr)
        {
            sum += (item - mean) * (item - mean);
            count++;
        }
        return sum / count;
    }

    /// <summary>
    /// Computes the standard deviation of the given data.
    /// </summary>
    /// <typeparam name="TSelf">The type of the data elements.</typeparam>
    /// <param name="data">The data to compute the standard deviation for.</param>
    /// <returns>The standard deviation of the data.</returns>
    public static TSelf StandardDeviation<TSelf>(IEnumerable<TSelf> data) where TSelf : INumberBase<TSelf>, IRootFunctions<TSelf>
    {
        return TSelf.Sqrt(Variance(data));
    }

    /// <summary>
    /// Computes the standard deviation of the given data using boxed values.
    /// </summary>
    /// <typeparam name="TSelf">The type of the data elements.</typeparam>
    /// <param name="data">The data to compute the standard deviation for.</param>
    /// <returns>The standard deviation of the data.</returns>
    internal static TSelf StandardDeviationBoxed<TSelf>(IEnumerable<TSelf> data) where TSelf : INumberBase<TSelf>
    {
        var doubleData = data.Select(double.CreateSaturating);
        var stdDev = StandardDeviation(doubleData);
        return TSelf.CreateSaturating(stdDev);
    }
    
    /// <summary>
    /// Computes the covariance between two sets of data.
    /// </summary>
    /// <typeparam name="TSelf">The type of the data elements.</typeparam>
    /// <param name="data1">The first set of data.</param>
    /// <param name="data2">The second set of data.</param>
    /// <returns>The covariance between the two sets of data.</returns>
    public static TSelf Covariance<TSelf>(IEnumerable<TSelf> data1, IEnumerable<TSelf> data2) where TSelf : INumberBase<TSelf>
    {
        var arr = data1 as TSelf[] ?? data1.ToArray();
        var arr2 = data2 as TSelf[] ?? data2.ToArray();
        var mean1 = Mean(arr);
        var mean2 = Mean(arr2);
        var sum = TSelf.Zero;
        var count = TSelf.Zero;
        var enumerator1 = arr.GetEnumerator();
        var enumerator2 = arr2.GetEnumerator();
        while (enumerator1.MoveNext() && enumerator2.MoveNext())
        {
            sum += ((TSelf) enumerator1.Current! - mean1) * ((TSelf) enumerator1.Current! - mean2);
            count++;
        }
        return sum / count;
    }
    
    /// <summary>
    /// Computes the correlation between two sets of data.
    /// </summary>
    /// <typeparam name="TSelf">The type of the data elements.</typeparam>
    /// <param name="data1">The first set of data.</param>
    /// <param name="data2">The second set of data.</param>
    /// <returns>The correlation between the two sets of data.</returns>
    public static TSelf Correlation<TSelf>(IEnumerable<TSelf> data1, IEnumerable<TSelf> data2) where TSelf : INumberBase<TSelf>, IRootFunctions<TSelf>
    {
        var arr = data1 as TSelf[] ?? data1.ToArray();
        var arr2 = data2 as TSelf[] ?? data2.ToArray();
        return Covariance(arr, arr2) / (StandardDeviation(arr) * StandardDeviation(arr2));
    }

    /// <summary>
    /// Computes the correlation between two sets of data using boxed values.
    /// </summary>
    /// <typeparam name="TSelf">The type of the data elements.</typeparam>
    /// <param name="data1">The first set of data.</param>
    /// <param name="data2">The second set of data.</param>
    /// <returns>The correlation between the two sets of data.</returns>
    internal static TSelf CorrelationBoxed<TSelf>(IEnumerable<TSelf> data1, IEnumerable<TSelf> data2) where TSelf : INumberBase<TSelf>
    {
        var doubleData1 = data1.Select(double.CreateSaturating);
        var doubleData2 = data2.Select(double.CreateSaturating);
        var correlation = Correlation(doubleData1, doubleData2);
        return TSelf.CreateSaturating(correlation);
    }

    /// <summary>
    /// Computes the skewness of the given data.
    /// </summary>
    /// <typeparam name="TSelf">The type of the data elements.</typeparam>
    /// <param name="data">The data to compute the skewness for.</param>
    /// <returns>The skewness of the data.</returns>
    public static TSelf Skewness<TSelf>(IEnumerable<TSelf> data) where TSelf : INumberBase<TSelf>, IRootFunctions<TSelf>
    {
        var arr = data as TSelf[] ?? data.ToArray();
        var mean = Mean(arr);
        var variance = Variance(arr);
        var sum = TSelf.Zero;
        var count = TSelf.Zero;
        foreach (var item in arr)
        {
            sum += (item - mean) * (item - mean) * (item - mean);
            count++;
        }
        return sum / (count * variance * StandardDeviation(arr));
    }

    /// <summary>
    /// Computes the skewness of the given data using boxed values.
    /// </summary>
    /// <typeparam name="TSelf">The type of the data elements.</typeparam>
    /// <param name="data">The data to compute the skewness for.</param>
    /// <returns>The skewness of the data.</returns>
    internal static TSelf SkewnessBoxed<TSelf>(IEnumerable<TSelf> data) where TSelf : INumberBase<TSelf>
    {
        var doubleData = data.Select(double.CreateSaturating);
        var skewness = Skewness(doubleData);
        return TSelf.CreateSaturating(skewness);
    }
    
    /// <summary>
    /// Computes the kurtosis of the given data.
    /// </summary>
    /// <typeparam name="TSelf">The type of the data elements.</typeparam>
    /// <param name="data">The data to compute the kurtosis for.</param>
    /// <returns>The kurtosis of the data.</returns>
    public static TSelf Kurtosis<TSelf>(IEnumerable<TSelf> data) where TSelf : INumberBase<TSelf>
    {
        var arr = data as TSelf[] ?? data.ToArray();
        var mean = Mean(arr);
        var variance = Variance(arr);
        var sum = TSelf.Zero;
        var count = TSelf.Zero;
        foreach (var item in arr)
        {
            sum += (item - mean) * (item - mean) * (item - mean) * (item - mean);
            count++;
        }
        return sum / (count * variance * variance);
    }
    
    /// <summary>
    /// Computes the mode of the given data.
    /// </summary>
    /// <typeparam name="TSelf">The type of the data elements.</typeparam>
    /// <param name="data">The data to compute the mode for.</param>
    /// <returns>The mode of the data.</returns>
    public static TSelf Mode<TSelf>(IEnumerable<TSelf> data) where TSelf : INumberBase<TSelf>
    {
        var groupedData = data.GroupBy(x => x).Select(x => new { Value = x.Key, Count = x.Count() }).ToArray();
        var maxCount = groupedData.Max(x => x.Count);
        return groupedData.First(x => x.Count == maxCount).Value;
    }
    
    /// <summary>
    /// Computes the range of the given data.
    /// </summary>
    /// <typeparam name="TSelf">The type of the data elements.</typeparam>
    /// <param name="data">The data to compute the range for.</param>
    /// <returns>The range of the data.</returns>
    public static TSelf Range<TSelf>(IEnumerable<TSelf> data) where TSelf : INumberBase<TSelf>
    {
        var sortedData = data.OrderBy(x => x).ToArray();
        return sortedData[^1] - sortedData[0];
    }
    
    /// <summary>
    /// Computes the percentile of the given data.
    /// </summary>
    /// <typeparam name="TSelf">The type of the data elements.</typeparam>
    /// <param name="data">The data to compute the percentile for.</param>
    /// <param name="percentile">The percentile to compute.</param>
    /// <returns>The computed percentile value.</returns>
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