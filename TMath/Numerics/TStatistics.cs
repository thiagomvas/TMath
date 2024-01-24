using System.Numerics;

namespace TMath.Numerics
{
    /// <summary>
    /// A mathematical utility class providing statistical functions for data analysis, with functions like Mean, Standard deviation, and more.
    /// </summary>
    /// <remarks>
    /// This class supports generic calculations on any <see cref="IEnumerable{T}"/> where T is an <see cref="INumber{TSelf}"/>, encompassing
    /// floats, doubles, decimals, integers, or custom number types that implement the interface.
    /// </remarks>
    public static class TStatistics
    {
        /// <summary>
        /// Calculates the mean of a set of data.
        /// </summary>
        /// <typeparam name="T">The numeric type of the data</typeparam>
        /// <param name="data">An <see cref="IEnumerable{T}"/>> containing all the data</param>
        /// <returns>The mean of the data as <typeparamref name="T"/></returns>
        /// <remarks> The mean is the average of a set of data. Due to that, it is recommended to use floating point types as data.
        /// For integer types, the mean will be rounded down to the nearest integer. If more accuracy is needed, use the <see cref="Mean{TTarget,TSource}"/> overload
        /// </remarks>
        public static T Mean<T>(IEnumerable<T> data) where T : INumber<T>
        {
            if(data.Count() == 0) return T.Zero;
            if(data.Count() == 1) return data.First();
            T sum = T.Zero;
            foreach (T d in data)
                sum += d;
            return sum / T.CreateSaturating(data.Count());
        }

        /// <summary>
        /// Calculates the mean of a set of data.
        /// </summary>
        /// <typeparam name="TTarget">The target type to return as the result</typeparam>
        /// <typeparam name="TSource">The type of the data</typeparam>
        /// <param name="data">An <see cref="IEnumerable{T}"/> containing all the data</param>
        /// <returns>The mean of the data set as a <typeparamref name="TTarget"/></returns>
        /// <remarks>
        /// This overload is slower due to converting types. It is however recommended for accurate results when using
        /// integer types as data, as it will not suffer from rounding errors when dividing integers.
        /// <br/>
        /// For floating point types or when rounding errors isn't an issue, use the <see cref="Mean{T}(IEnumerable{T})"/> overload.
        /// </remarks>
        public static TTarget Mean<TTarget, TSource>(IEnumerable<TSource> data) 
            where TTarget : INumber<TTarget>, IFloatingPoint<TTarget>
            where TSource : INumber<TSource>, IBinaryInteger<TSource>
        {
            if (data.Count() == 0) return TTarget.Zero;
            if (data.Count() == 1) return TTarget.CreateSaturating(data.First());
            TTarget sum = TTarget.Zero;
            foreach (TSource d in data)
                sum += TTarget.CreateSaturating(d);
            return sum / TTarget.CreateSaturating(data.Count());
        }

        /// <summary>
        /// Calculates the median of a set of data.
        /// </summary>
        /// <typeparam name="T">The numeric type of the data</typeparam>
        /// <param name="data">An <see cref="IEnumerable{T}"/>> containing all the data</param>
        /// <returns>The median of a the set of data</returns>
        /// <remarks>
        /// The median is the middle value of a set of data. If the set of data has an even number of values, the median is the average of the two middle values.
        /// For integer types, the median will be rounded down to the nearest integer.
        /// If more accuracy is needed, use the <see cref="Median{TTarget,TSource}"/> overload
        /// </remarks>
        public static T Median<T>(IEnumerable<T> data) where T : INumber<T>
        {
            if (data.Count() == 0) return T.Zero;
            if (data.Count() == 1) return data.First();
            T[] sorted = data.ToArray();
            Array.Sort(sorted);
            if(sorted.Length % 2 == 0)
                return (sorted[sorted.Length / 2] + sorted[sorted.Length / 2 - 1]) / TFunctions.IntToT<T>(2);
            else return sorted[sorted.Length / 2];
        }

        /// <summary>
        /// Calculates the median of a set of data.
        /// </summary>
        /// <typeparam name="TTarget">The target type to return as the result</typeparam>
        /// <typeparam name="TSource">The type of the data</typeparam>
        /// <param name="data">An <see cref="IEnumerable{T}"/> containing all the data</param>
        /// <returns>The median of the set of data as a <typeparamref name="TTarget"/></returns>
        /// <remarks>
        /// The median is the middle value of a set of data. If the set of data has an even number of values, the median is the average of the two middle values.
        /// This overload is slower due to converting types. It is however recommended for accurate results when using integer types as data,
        /// as it will not suffer from rounding errors when dividing integers.
        /// </remarks>
        public static TTarget Median<TTarget, TSource>(IEnumerable<TSource> data) 
            where TTarget : INumber<TTarget>, IFloatingPoint<TTarget>
            where TSource : INumber<TSource>, IBinaryInteger<TSource>
        {
            if (data.Count() == 0) return TTarget.Zero;
            if (data.Count() == 1) return TTarget.CreateSaturating(data.First());
            TSource[] sorted = data.ToArray();
            Array.Sort(sorted);
            if (sorted.Length % 2 == 0)
                return (TTarget.CreateSaturating(sorted[sorted.Length / 2] + sorted[sorted.Length / 2 - 1])) / TFunctions.IntToT<TTarget>(2);
            else return TTarget.CreateSaturating(sorted[sorted.Length / 2]);
        }

        /// <summary>
        /// Calculates the mode of a set of data.
        /// </summary>
        /// <typeparam name="T">The numeric type of the data</typeparam>
        /// <param name="data">An <see cref="IEnumerable{T}"/> containing all the data</param>
        /// <returns>The mode of the set of data</returns>
        /// <remarks>
        /// The mode is the value that occurs most often in a set of data. If there are multiple modes, the first one is returned.
        /// </remarks>
        public static T Mode<T>(IEnumerable<T> data) where T : INumber<T>
        {
            if (data.Count() == 0) return T.Zero;
            if (data.Count() == 1) return data.First();
            Dictionary<T, int> counts = new Dictionary<T, int>();
            foreach (T d in data)
            {
                if (counts.ContainsKey(d))
                    counts[d]++;
                else counts.Add(d, 1);
            }
            int max = 0;
            T mode = T.Zero;
            foreach (KeyValuePair<T, int> pair in counts)
            {
                if (pair.Value > max)
                {
                    max = pair.Value;
                    mode = pair.Key;
                }
            }
            return mode;
        }

        /// <summary>
        /// Calculates the variance of a set of data.
        /// </summary>
        /// <typeparam name="T">The numeric type of the data</typeparam>
        /// <param name="data">An <see cref="IEnumerable{T}"/>> containing all the data</param>
        /// <returns>The variance of the data set</returns>
        /// <remarks>
        /// The variance is the average of the squared differences from the mean. It is a measure of how spread out the data is.
        /// For integer types, the variance will be rounded down to the nearest integer.
        /// If more accuracy is needed for integer types, use the <see cref="Variance{TTarget,TSource}"/> overload
        /// </remarks>
        public static T Variance<T>(IEnumerable<T> data) 
            where T : INumber<T>
        {
            if (data.Count() <= 1) return T.Zero;
            T mean = Mean(data);
            T sum = T.Zero;
            foreach (T d in data)
                sum += (d - mean) * (d - mean);
            return sum / T.CreateSaturating(data.Count());
        }

        /// <summary>
        /// Calculates the variance of a set of data.
        /// </summary>
        /// <typeparam name="TTarget">The target type to return as the result</typeparam>
        /// <typeparam name="TSource">The type of the data</typeparam>
        /// <param name="data">An <see cref="IEnumerable{T}"/> containing all the data</param>
        /// <returns>The variance of the set of data as a <typeparamref name="TTarget"/></returns>
        /// <remarks>
        /// This overload is slower due to converting types. It is however recommended for accurate results when using integer types as data,
        /// as it will not suffer from rounding errors when dividing integers. For floating point types or when rounding errors isn't an issue,
        /// use the <see cref="Variance{T}(IEnumerable{T})"/> overload.
        /// </remarks>
        public static TTarget Variance<TTarget, TSource>(IEnumerable<TSource> data) 
            where TTarget : INumber<TTarget>, IFloatingPoint<TTarget>
            where TSource : INumber<TSource>, IBinaryInteger<TSource>
        {
            if (data.Count() <= 1) return TTarget.Zero;
            TTarget mean = Mean<TTarget, TSource>(data);
            TTarget sum = TTarget.Zero;
            foreach (TSource d in data)
            {
                TTarget elem = TTarget.CreateSaturating(d);
                sum += (elem - mean) * (elem - mean);
            }
                
            return sum / TTarget.CreateSaturating(data.Count() - 1);
        }

        /// <summary>
        /// Calculates the standard deviation of a set of data.
        /// </summary>
        /// <typeparam name="T">The numeric type of the data</typeparam>
        /// <param name="data">An <see cref="IEnumerable{T}"/>> containing all the data</param>
        /// <returns>The standard deviation of a data set</returns>
        /// <remarks>
        /// The standard deviation is the square root of the variance. It is a measure of how spread out the data is.
        /// For integer types, the standard deviation will be rounded down to the nearest integer.
        /// If more accuracy is needed for integer types, use the <see cref="StandardDeviation{TTarget,TSource}"/> overload
        /// </remarks>
        public static T StandardDeviation<T>(IEnumerable<T> data) 
            where T : INumber<T>
            => TFunctions.Sqrt<T, T>(Variance(data));

        /// <summary>
        /// Calculates the standard deviation of a set of data.
        /// </summary>
        /// <typeparam name="TTarget">The target type to return as the result</typeparam>
        /// <typeparam name="TSource">The type of the data</typeparam>
        /// <param name="data">An <see cref="IEnumerable{T}"/>> containing all the data</param>
        /// <returns>The standard deviation of the set of data as a <typeparamref name="TTarget"/></returns>
        /// <remarks>
        /// This overload is slower due to converting types. It is however recommended for accurate results when using integer types as data,
        /// as it will not suffer from rounding errors when dividing integers. for floating point types or when rounding errors isn't an issue,
        /// use the <see cref="StandardDeviation{T}(IEnumerable{T})"/> overload.
        /// </remarks>
        public static TTarget StandardDeviation<TTarget, TSource>(IEnumerable<TSource> data)
            where TTarget : INumber<TTarget>, IFloatingPoint<TTarget>
            where TSource : INumber<TSource>, IBinaryInteger<TSource>
            => TFunctions.Sqrt<TTarget, TTarget>(Variance<TTarget, TSource>(data));

        /// <summary>
        /// Gets the nth percentile of a set of data.
        /// </summary>
        /// <typeparam name="T">The numeric type of the data</typeparam>
        /// <param name="data">An <see cref="IEnumerable{T}"/>> containing all the data</param>
        /// <param name="percentile">The percentile to return from 0 to 100</param>
        /// <returns>The nth percentile of a data set</returns>
        /// <remarks>
        /// The percentile is the value below which a percentage of data falls. For example, the 50th percentile is the median. <br/>
        /// - If the percentile is greater than 100, the maximum value is returned. <br/>
        /// - If the percentile is less than 0, the minimum value is returned. <br/>
        /// - If the data set is empty, 0 is returned.<br/>
        /// - If the data set has only one value, that value is returned.<br/>
        /// </remarks>
        public static T Percentile<T>(IEnumerable<T> data, double percentile) where T : INumber<T>
        {
            
            if (data.Count() == 0) return T.Zero;
            if (data.Count() == 1 || percentile <= 0) return data.First();
            if (percentile >= 100) return data.Last();
            if (percentile == 50) return Median(data);
            T[] sorted = data.ToArray();
            Array.Sort(sorted);
            int index = (int)TFunctions.Ceil(percentile / 100 * data.Count());
            return sorted[index - 1];
        }

		/// <summary>
		/// Calculates the geometric mean of a set of data.
		/// </summary>
		/// <typeparam name="T">The target type to return as the result</typeparam>
		/// <param name="data"></param>
		/// <returns></returns>
		public static T GeometricMean<T>(IEnumerable<T> data) where T : INumber<T>
        {
			if (data.Count() == 0) return T.Zero;
			if (data.Count() == 1) return data.First();
			T product = T.One;
			foreach (T d in data)
				product *= d;
			return TFunctions.Pow<T,double>(Convert.ToDouble(product), 1d / data.Count());
		}

		/// <summary>
		/// Calculates the largest value in a set of data.
		/// </summary>
		/// <typeparam name="T">The numeric type of the data</typeparam>
		/// <param name="data">An <see cref="IEnumerable{T}"/>> containing all the data</param>
		/// <returns>The largest value in the data set</returns>
		public static T Largest<T>(IEnumerable<T> data) where T : INumber<T>
        {
			if (data.Count() == 0) return T.Zero;
			if (data.Count() == 1) return data.First();
			T largest = data.First();
			foreach (T d in data)
				if (d > largest) largest = d;
			return largest;
		}

		/// <summary>
		/// Calculates the smallest value in a set of data.
		/// </summary>
		/// <typeparam name="T">The numeric type of the data</typeparam>
		/// <param name="data">An <see cref="IEnumerable{T}"/>> containing all the data</param>
		/// <returns>
        /// Returns the smallest value in the data set
        /// </returns>
		public static T Smallest<T>(IEnumerable<T> data) where T : INumber<T>
        {
			if (data.Count() == 0) return T.Zero;
			if (data.Count() == 1) return data.First();
			T largest = data.First();
			foreach (T d in data)
				if (d < largest) largest = d;
			return largest;
		}

		/// <summary>
		/// Calculates the range of a set of data.
		/// </summary>
		/// <typeparam name="T">The numeric type of the data</typeparam>
		/// <param name="data">An <see cref="IEnumerable{T}"/>> containing all the data</param>
		/// <returns>
        /// Returns the range of the data set
        /// </returns>
		public static T Range<T>(IEnumerable<T> data) where T : INumber<T>
        {
            if(data.Count() == 0) return T.Zero;
            if(data.Count() == 1) return T.Zero;
            return Largest(data) - Smallest(data);
        }

		/// <summary>
		/// Calculates the sum of a set of data.
		/// </summary>
		/// <typeparam name="T">The numeric type of the data</typeparam>
		/// <param name="data">An <see cref="IEnumerable{T}"/>> containing all the data</param>
		/// <returns>The sum of the data set</returns>
		public static T Sum<T>(IEnumerable<T> data) where T : INumber<T>
        {
			if (data.Count() == 0) return T.Zero;
			if (data.Count() == 1) return data.First();
			T sum = T.Zero;
			foreach (T d in data)
				sum += d;
			return sum;
		}

		/// <summary>
		/// Calculates the sample standard deviation of a set of data.
		/// </summary>
		/// <typeparam name="T">The numeric type of the data</typeparam>
		/// <param name="data">An <see cref="IEnumerable{T}"/>> containing all the data</param>
		/// <returns>The sample standard deviation of the data set</returns>
		public static T SampleStandardDeviation<T>(IEnumerable<T> data) where T : INumber<T>
        {
            return TFunctions.Sqrt<T, T>(SampleVariance(data));
		}

		/// <summary>
		/// Calculates the sample variance of a set of data.
		/// </summary>
		/// <typeparam name="T">The numeric type of the data</typeparam>
		/// <param name="data">An <see cref="IEnumerable{T}"/>> containing all the data</param>
		/// <returns>The sample variance of the data set</returns>
		public static T SampleVariance<T>(IEnumerable<T> data) where T : INumber<T>
        {
            if(data.Count() <= 1) return T.Zero;
            T mean = Mean(data);
            T sum = T.Zero;
            foreach (T d in data)
				sum += (d - mean) * (d - mean);
            return sum / T.CreateSaturating(data.Count() - 1);
        }
    }
}
