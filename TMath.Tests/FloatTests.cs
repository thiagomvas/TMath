using NUnit.Framework.Constraints;
namespace TMath.Tests;

[TestFixture]
public class FloatTests
{
    [Test]
    [TestCase(3, ExpectedResult = 3f)]
    [TestCase(8, ExpectedResult = 8f)]
    [TestCase(0, ExpectedResult = 0f)]
    [TestCase(-241, ExpectedResult = -241f)]
    public float IntToTTest(int num) => TFunctions.IntToT<float>(num);

    [Test]
    [TestCase(29.213f, ExpectedResult = 29.213f)]
    [TestCase(-20f, ExpectedResult = 20f)]
    [TestCase(0f, ExpectedResult = 0f)]
    [TestCase(-0f, ExpectedResult = 0f)]
    public float AbsTest(float num) => TFunctions.Abs(num);

    [Test]
    [TestCase(29.3921f, ExpectedResult = 29f)]
    [TestCase(0.00001f, ExpectedResult = 0f)]
    [TestCase(-1.5f, ExpectedResult = -2f)]
    [TestCase(0f, ExpectedResult = 0f)]
    public float FloorTest(float num) => TFunctions.Floor(num);
    [Test]
    [TestCase(29.3921f, ExpectedResult = 30f)]
    [TestCase(0.00001f, ExpectedResult = 1f)]
    [TestCase(-1.5f, ExpectedResult = -1f)]
    [TestCase(0f, ExpectedResult = 0f)]
    public float CeilTest(float num) => TFunctions.Ceil(num);

    [Test]
    [TestCase(29.3921f, ExpectedResult = 29f)]
    [TestCase(0.00001f, ExpectedResult = 0f)]
    [TestCase(-1.5f, ExpectedResult = -2f)]
    [TestCase(0f, ExpectedResult = 0f)]
    public float RoundTest(float num) => TFunctions.Round(num);

    [Test]
    [TestCase(0, ExpectedResult = 1f)]
    [TestCase(1, ExpectedResult = 1f)]
    [TestCase(2, ExpectedResult = 2f)]
    [TestCase(3, ExpectedResult = 6f)]
    [TestCase(4, ExpectedResult = 24f)]
    [TestCase(5, ExpectedResult = 120f)]
    [TestCase(6, ExpectedResult = 720f)]
    public float FactorialTest(int num) => TFunctions.Factorial<float>(num);

    [Test]
    [TestCase(30f, ExpectedResult = 0.5235988f)]
    [TestCase(45f, ExpectedResult = 0.7853982f)]
    [TestCase(60f, ExpectedResult = 1.0471976f)]
    public float ToRadiansTest(float num) => TFunctions.ToRadians(num);

    [Test]
    [TestCase(0.5235988f, ExpectedResult = 30f)]
    [TestCase(0.7853982f, ExpectedResult = 45f)]
    [TestCase(1.0471976f, ExpectedResult = 60f)]
    public float Rad2DegTest(float num) => TFunctions.Rad2Deg(num);

    [Test]
    [TestCase(0f, 2f, ExpectedResult = 0f)]
    [TestCase(2f, 4f, ExpectedResult = 16f)]
    [TestCase(3.14f, 3f, ExpectedResult = 30.959146f)]
    [TestCase(-1f, 3f, ExpectedResult = -1f)]
    [TestCase(-1f, 4f, ExpectedResult = 1f)]
    public float PowTest(float a, float b) => TFunctions.Pow(a, b);

    [Test]
    [TestCase(1f, 2f, 3f, ExpectedResult = 2f)]
    [TestCase(2f, 2f, 3f, ExpectedResult = 2f)]
    [TestCase(2.5f, 2f, 3f, ExpectedResult = 2.5f)]
    [TestCase(3f, 2f, 3f, ExpectedResult = 3f)]
    [TestCase(4f, 2f, 3f, ExpectedResult = 3f)]
    public float ClampTest(float value, float min, float max) => TFunctions.Clamp(value, min, max);

    [Test]
    [TestCase(1f, 1f, ExpectedResult = 1f)]
    [TestCase(-1f, 1f, ExpectedResult = 1f)]
    [TestCase(-1f, -1f, ExpectedResult = -1f)]
    [TestCase(1f, -1f, ExpectedResult = -1f)]
    [TestCase(1f, -0f, ExpectedResult = -1f)]
    [TestCase(1f, 0f, ExpectedResult = 1f)]
    public float CopySign(float value, float sign) => TFunctions.CopySign(value, sign);

    [Test]
    [TestCase(2.1f, 0.5f, ExpectedResult = 0.1f)]
    [TestCase(-2.1f, 0.5f, ExpectedResult = -0.1f)]
    public float RemainderTest(float number, float divider) 
        => TFunctions.Round(TFunctions.Remainder(number, divider) * 1000000f) / 1000000f; // Rounding to compensate for float inaccuracy.

    [Test]
    public void SumTest()
    {
        Func<float, float> f1 = x => x * x;
        Func<float, float> f2 = x => 1 / x;

        Assert.That(TFunctions.Sum(f1, 5), Is.EqualTo(55));
        Assert.That(TFunctions.Sum(f1, 3), Is.EqualTo(14));
        Assert.That(TFunctions.Sum(f2, 3), Is.EqualTo(1.83333f).Within(0.00001f));
        Assert.That(TFunctions.Sum(f2, 6), Is.EqualTo(2.45f).Within(0.00001f));
    }

    [Test]
    [TestCase(1.1234567f, 1, ExpectedResult = 1.1f)]
    [TestCase(1.1234567f, 2, ExpectedResult = 1.12f)]
    [TestCase(1.1234567f, 3, ExpectedResult = 1.123f)]
    [TestCase(1.1234567f, 4, ExpectedResult = 1.1234f)]
    [TestCase(1.1234567f, 5, ExpectedResult = 1.12345f)]
    [TestCase(1.1234567f, 6, ExpectedResult = 1.123456f)]
    [TestCase(1.1234567f, 7, ExpectedResult = 1.1234567f)]
    public float TruncateTest(float value, int accuracy) => TFunctions.Truncate(value, accuracy);

}