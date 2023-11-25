namespace TMath.Tests;

public class TMathTests
{
    [SetUp]
    public void Setup()
    {
    }

    [Test]
    public void IntToTTest()
    {
        int target = 10;
        
        float eF = target;
        float f = TMath.IntToT<float>(target);
        double eD = target;
        double d = TMath.IntToT<double>(target);
        decimal eM = target;
        decimal m = TMath.IntToT<decimal>(target);
        
        Assert.That(f, Is.EqualTo(eF));
        Assert.That(d, Is.EqualTo(eD));
        Assert.That(m, Is.EqualTo(eM));
    }

    [Test]
    public void AbsTest()
    {
        int target = 10;
        
        float eF = target;
        float f = TMath.Abs(target);
        double eD = target;
        double d = TMath.Abs(target);
        decimal eM = target;
        decimal m = TMath.Abs(target);
        
        Assert.That(f, Is.EqualTo(eF));
        Assert.That(d, Is.EqualTo(eD));
        Assert.That(m, Is.EqualTo(eM));
        
    }

    [Test]
    public void FloorTest()
    {
        float eF = 10f;
        float f = TMath.Floor(10.1234f);
        double eD = 10d;
        double d = TMath.Floor(10.1234d);
        decimal eM = 10m;
        decimal m = TMath.Floor(10.1234m);
        
        Assert.That(f, Is.EqualTo(eF));
        Assert.That(d, Is.EqualTo(eD));
        Assert.That(m, Is.EqualTo(eM));
    }
    [Test]
    public void CeilTest()
    {
        float eF = 11f;
        float f = TMath.Ceil(10.1234f);
        double eD = 11d;
        double d = TMath.Ceil(10.1234d);
        decimal eM = 11m;
        decimal m = TMath.Ceil(10.1234m);
        
        Assert.That(f, Is.EqualTo(eF));
        Assert.That(d, Is.EqualTo(eD));
        Assert.That(m, Is.EqualTo(eM));
    }

    [Test]
    public void RoundTest()
    {
        // Floats
        float f1 = 123.56f;
        float eF1 = 124f;
        Assert.That(TMath.Round(f1), Is.EqualTo(eF1));
        float f2 = 123.46f;
        float eF2 = 123f;
        Assert.That(TMath.Round(f2), Is.EqualTo(eF2));
        float f3 = 123.5f;
        float eF3 = 124f;
        Assert.That(TMath.Round(f3), Is.EqualTo(eF3));
        
        // Doubles
        double d1 = 123.56;
        double eD1 = 123;
        Assert.That(TMath.Floor(d1), Is.EqualTo(eD1));

        double d2 = 123.46;
        double eD2 = 123;
        Assert.That(TMath.Floor(d2), Is.EqualTo(eD2));

        double d3 = 123.5;
        double eD3 = 123;
        Assert.That(TMath.Floor(d3), Is.EqualTo(eD3));
        
        // Decimals
        decimal dec1 = 123.56m;
        decimal eDec1 = 123m;
        Assert.That(TMath.Floor(dec1), Is.EqualTo(eDec1));

        decimal dec2 = 123.46m;
        decimal eDec2 = 123m;
        Assert.That(TMath.Floor(dec2), Is.EqualTo(eDec2));

        decimal dec3 = 123.5m;
        decimal eDec3 = 123m;
        Assert.That(TMath.Floor(dec3), Is.EqualTo(eDec3));
    }


    [Test]
    public void FactorialTest()
    {
        int[] Factorials = new[] { 1, 1, 2, 6, 24, 120, 720, 5040, 40320, 362880 };
        for (int i = 0; i < Factorials.Length; i++)
        {
            Assert.That(TMath.Factorial<int>(i), Is.EqualTo(Factorials[i]));
            Assert.That(TMath.Factorial<float>(i), Is.EqualTo((float) Factorials[i]));
            Assert.That(TMath.Factorial<double>(i), Is.EqualTo((double) Factorials[i]));
            Assert.That(TMath.Factorial<decimal>(i), Is.EqualTo((decimal) Factorials[i]));
        }
    }
    
    [Test]
    public void ToRadiansTest()
    {
        Assert.That(TMath.ToRadians(30f), Is.EqualTo(0.5235988f));
        Assert.That(TMath.ToRadians(45f), Is.EqualTo(0.7853982f));
        Assert.That(TMath.ToRadians(60f), Is.EqualTo(1.0471976f));
        Assert.That(TMath.ToRadians(30d), Is.EqualTo(0.5235987755982988d));
        Assert.That(TMath.ToRadians(45d), Is.EqualTo(0.7853981633974483d));
        Assert.That(TMath.ToRadians(60d), Is.EqualTo(1.0471975511965976d));
    }
    [Test]
    public void Rad2DegTest()
    {
        Assert.That(TMath.Rad2Deg(TMath.ToRadians(30f)), Is.EqualTo(30f));
        Assert.That(TMath.Rad2Deg(TMath.ToRadians(30d)), Is.EqualTo(30d).Within(0.000000000001d));
        Assert.That(TMath.Rad2Deg(TMath.ToRadians(30m)), Is.EqualTo(30m).Within(0.000000000001m));
        
        Assert.That(TMath.Rad2Deg(TMath.ToRadians(45f)), Is.EqualTo(45f));
        Assert.That(TMath.Rad2Deg(TMath.ToRadians(45d)), Is.EqualTo(45d).Within(0.000000000001d));
        Assert.That(TMath.Rad2Deg(TMath.ToRadians(45m)), Is.EqualTo(45m).Within(0.000000000001m));
        
        Assert.That(TMath.Rad2Deg(TMath.ToRadians(60f)), Is.EqualTo(60f));
        Assert.That(TMath.Rad2Deg(TMath.ToRadians(60d)), Is.EqualTo(60d).Within(0.000000000001d));
        Assert.That(TMath.Rad2Deg(TMath.ToRadians(60m)), Is.EqualTo(60m).Within(0.000000000001m));
    }
}