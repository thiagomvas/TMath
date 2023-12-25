using System.Numerics;
using TMath.Modules;

namespace TMath.Numerics.Models
{
    public class DescriptiveStatistics<T> where T : INumber<T>
    {
        
        public T Mean { get; private set; }
        public T Median { get; private set; }
        public T Variance { get; private set; }
        public T StandardDeviation { get; private set; }
        public T Mode { get; private set; }
        public T[] Data { get; private set; }

        public DescriptiveStatistics(T[] data)
        {
            Mean = TStatistics.Mean(data);
            Median = TStatistics.Median(data);
            Variance = TStatistics.Variance(data);
            StandardDeviation = TStatistics.StandardDeviation(data);
            Mode = TStatistics.Mode(data);
        }

        public T Percentile(int percentile) => TStatistics.Percentile(Data, percentile);

        public override string ToString()
        {
            return $"Data: {string.Join(',', Data)}Mean: {Mean}\nMedian: {Median}\nVariance: {Variance}\nStandard Deviation: {StandardDeviation}\nMode: {Mode}";
        }
    }
}
