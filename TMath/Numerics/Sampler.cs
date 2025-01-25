using System.Numerics;

namespace TMath.Numerics;

/// <summary>
/// A class for generating data samples with noise.
/// </summary>
/// <typeparam name="T">The type of the data being generated.</typeparam>
public class Sampler<T> where T : INumberBase<T>
{
    private readonly Random _random;

    /// <summary>
    /// Gets or sets the mean of the Gaussian noise to be applied to the generated data.
    /// Default is 0 (no mean shift).
    /// </summary>
    public double NoiseMean { get; set; } = 0;

    /// <summary>
    /// Gets or sets the standard deviation of the Gaussian noise to be applied to the generated data.
    /// Default is 0 (no noise).
    /// </summary>
    public double NoiseStdDev { get; set; } = 0;

    /// <summary>
    /// Gets or sets the minimum value for uniform noise to be applied to the generated data.
    /// Default is 0.
    /// </summary>
    public double UniformNoiseMin { get; set; } = 0;

    /// <summary>
    /// Gets or sets the maximum value for uniform noise to be applied to the generated data.
    /// Default is 0.
    /// </summary>
    public double UniformNoiseMax { get; set; } = 0;

    /// <summary>
    /// Initializes a new instance of the <see cref="Sampler{T}"/> class.
    /// </summary>
    public Sampler()
    {
        _random = new Random();
    }

    /// <summary>
    /// Initializes a new instance of the <see cref="Sampler{T}"/> class with a specified seed.
    /// </summary>
    /// <param name="seed">The seed for the random number generator.</param>
    public Sampler(int seed)
    {
        _random = new Random(seed);
    }

    /// <summary>
    /// Generates a sequence of values forming a slope from start to end, with optional noise.
    /// </summary>
    /// <param name="start">The starting value of the slope.</param>
    /// <param name="end">The ending value of the slope.</param>
    /// <param name="count">The number of values to generate.</param>
    /// <returns>An enumerable sequence of values forming a slope.</returns>
    public IEnumerable<T> GenerateSlope(T start, T end, int count)
    {
        var step = (end - start) / T.CreateSaturating(count);
        for (var i = 0; i < count; i++)
        {
            yield return start + (step * T.CreateSaturating(i)) + T.CreateSaturating(ApplyNoise());
        }
    }

    /// <summary>
    /// Generates a sequence of random values within a specified range, with optional noise.
    /// </summary>
    /// <param name="count">The number of values to generate.</param>
    /// <param name="min">The minimum value of the range.</param>
    /// <param name="max">The maximum value of the range.</param>
    /// <returns>An enumerable sequence of random values within the specified range.</returns>
    public IEnumerable<T> GenerateRandomArray(int count, T min, T max)
    {
        var dmin = double.CreateSaturating(min);
        var dmax = double.CreateSaturating(max);
        for (var i = 0; i < count; i++)
        {
            yield return T.CreateSaturating(ApplyUniformNoise(dmin, dmax));
        }
    }

    /// <summary>
    /// Generates a random value following a normal distribution using the Box-Muller transform.
    /// </summary>
    /// <param name="mean">The mean of the normal distribution.</param>
    /// <param name="stdDev">The standard deviation of the normal distribution.</param>
    /// <returns>A random value following the specified normal distribution.</returns>
    private double NormalDistribution(double mean, double stdDev)
    {
        var u1 = 1.0 - _random.NextDouble();
        var u2 = 1.0 - _random.NextDouble();
        var randStdNormal = Math.Sqrt(-2.0 * Math.Log(u1)) * Math.Sin(2.0 * Math.PI * u2);
        return mean + stdDev * randStdNormal;
    }

    /// <summary>
    /// Applies noise to a value based on the configured noise parameters.
    /// </summary>
    /// <returns>A noise value to be added to the generated data.</returns>
    private double ApplyNoise()
    {
        if (NoiseStdDev != 0)
        {
            return NormalDistribution(NoiseMean, NoiseStdDev);
        }
        if (MathT.Abs(UniformNoiseMin - UniformNoiseMax) > 0.001)
        {
            return ApplyUniformNoise(UniformNoiseMin, UniformNoiseMax);
        }
        return 0; // No noise
    }

    /// <summary>
    /// Generates a random value within a specified range using uniform distribution.
    /// </summary>
    /// <param name="min">The minimum value of the range.</param>
    /// <param name="max">The maximum value of the range.</param>
    /// <returns>A random value within the specified range.</returns>
    private double ApplyUniformNoise(double min, double max)
    {
        return min + (_random.NextDouble() * (max - min));
    }
}