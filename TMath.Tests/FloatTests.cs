namespace TMath.Tests;

[TestFixture]
public class FloatTests
{
    [Test]
    [TestCase(3, ExpectedResult = 3f)]
    [TestCase(8, ExpectedResult = 8f)]
    [TestCase(0, ExpectedResult = 0f)]
    [TestCase(-241, ExpectedResult = -241f)]
    public float IntToTTest(int num) => TMath.IntToT<float>(num);

    [Test]
    [TestCase(29.213f, ExpectedResult = 29.213f)]
    [TestCase(-20f, ExpectedResult = 20f)]
    [TestCase(0f, ExpectedResult = 0f)]
    [TestCase(-0f, ExpectedResult = 0f)]
    public float AbsTest(float num) => TMath.Abs(num);

    [Test]
    [TestCase(29.3921f, ExpectedResult = 29f)]
    [TestCase(0.00001f, ExpectedResult = 0f)]
    [TestCase(-1.5f, ExpectedResult = -2f)]
    [TestCase(0f, ExpectedResult = 0f)]
    public float FloorTest(float num) => TMath.Floor(num);
    [Test]
    [TestCase(29.3921f, ExpectedResult = 30f)]
    [TestCase(0.00001f, ExpectedResult = 1f)]
    [TestCase(-1.5f, ExpectedResult = -1f)]
    [TestCase(0f, ExpectedResult = 0f)]
    public float CeilTest(float num) => TMath.Ceil(num);

    [Test]
    [TestCase(29.3921f, ExpectedResult = 29f)]
    [TestCase(0.00001f, ExpectedResult = 0f)]
    [TestCase(-1.5f, ExpectedResult = -2f)]
    [TestCase(0f, ExpectedResult = 0f)]
    public float RoundTest(float num) => TMath.Round(num);

    [Test]
    [TestCase(0, ExpectedResult = 1f)]
    [TestCase(1, ExpectedResult = 1f)]
    [TestCase(2, ExpectedResult = 2f)]
    [TestCase(3, ExpectedResult = 6f)]
    [TestCase(4, ExpectedResult = 24f)]
    [TestCase(5, ExpectedResult = 120f)]
    [TestCase(6, ExpectedResult = 720f)]
    public float FactorialTest(int num) => TMath.Factorial<float>(num);

    [Test]
    [TestCase(30f, ExpectedResult = 0.5235988f)]
    [TestCase(45f, ExpectedResult = 0.7853982f)]
    [TestCase(60f, ExpectedResult = 1.0471976f)]
    public float ToRadiansTest(float num) => TMath.ToRadians(num);

    [Test]
    [TestCase(0.5235988f, ExpectedResult = 30f)]
    [TestCase(0.7853982f, ExpectedResult = 45f)]
    [TestCase(1.0471976f, ExpectedResult = 60f)]
    public float Rad2DegTest(float num) => TMath.Rad2Deg(num);

    [Test]
    [TestCase(0f, 2f, ExpectedResult = 0f)]
    [TestCase(2f, 4f, ExpectedResult = 16f)]
    [TestCase(3.14f, 3f, ExpectedResult = 30.959146f)]
    [TestCase(-1f, 3f, ExpectedResult = -1f)]
    [TestCase(-1f, 4f, ExpectedResult = 1f)]
    public float PowTest(float a, float b) => TMath.Pow(a, b);

    [Test]
    [TestCase(1f, 2f, 3f, ExpectedResult = 2f)]
    [TestCase(2f, 2f, 3f, ExpectedResult = 2f)]
    [TestCase(2.5f, 2f, 3f, ExpectedResult = 2.5f)]
    [TestCase(3f, 2f, 3f, ExpectedResult = 3f)]
    [TestCase(4f, 2f, 3f, ExpectedResult = 3f)]
    public float ClampTest(float value, float min, float max) => TMath.Clamp(value, min, max);

}