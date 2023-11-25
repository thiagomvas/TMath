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
        
}