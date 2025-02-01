using System.Diagnostics.CodeAnalysis;
using TMath.Abstractions;
using TMath.Numerics;

namespace TMath.Tests;

public class VectorTests
{
    [Test]
    public void DotProduct_WhenEqualSize_ShouldComputeCorrectly()
    {
        // Arrange
        var v1 = new Vector<double>([1, 2, 3]);
        var v2 = new Vector<double>([4, 5, 6]);
        var expected = 32;

        // Act
        var actual = v1.Dot(v2);

        // Assert
        Assert.That(actual, Is.EqualTo(expected));
    }

    [Test]
    public void DotProduct_WhenDifferentSizeAndModeIsThrow_ShouldThrowException()
    {
        // Arrange
        var v1 = new Vector<double>([1, 2, 3]);
        var v2 = new Vector<double>([4, 5]);

        // Act
        void Act() => v1.Dot(v2, VectorSizeDifferenceMode.ThrowIfDifferentSize);

        // Assert
        Assert.That(Act, Throws.Exception);
    }
    
    [Test]
    public void DotProduct_WhenDifferentSizeAndModeIsPadLeft_ShouldReturnCorrectValue()
    {
        // Arrange
        var v1 = new Vector<double>([1, 2, 3]);
        var v2 = new Vector<double>([4, 5]);

        // Act
        var actual = v1.Dot(v2, VectorSizeDifferenceMode.PadLeftWithZeros);
        var expected = 23;

        // Assert
        Assert.That(actual, Is.EqualTo(expected));
    }
    
    [Test]
    public void DotProduct_WhenDifferentSizeAndModeIsPadRight_ShouldReturnCorrectValue()
    {
        // Arrange
        var v1 = new Vector<double>([1, 2, 3]);
        var v2 = new Vector<double>([4, 5]);

        // Act
        var actual = v1.Dot(v2, VectorSizeDifferenceMode.PadRightWithZeros);
        var expected = 14d;

        // Assert
        Assert.That(actual, Is.EqualTo(expected));
    }

    [Test]
    public void Normalize_ShouldComputeCorrectly()
    {
        var v = new Vector<double>([1, 1, 1]);
        var root3 = MathT.Sqrt(3d);
        
        // Act
        var actual = v.Normalize();
        var expected = new Vector<double>([1 / root3, 1 / root3, 1 / root3]);
        Assert.Multiple(() =>
        {
            // Assert
            Assert.That(actual[0], Is.EqualTo(expected[0]).Within(1e-5));
            Assert.That(actual[1], Is.EqualTo(expected[1]).Within(1e-5));
            Assert.That(actual[2], Is.EqualTo(expected[2]).Within(1e-5));
        });
    }
    
    [Test]
    public void CrossProduct_WhenEqualSizeAnd3D_ShouldComputeCorrectly()
    {
        // Arrange
        var v1 = new Vector<double>([1, 0, 0]);
        var v2 = new Vector<double>([0, 1, 0]);
        var expected = new Vector<double>([0, 0, 1]);

        // Act
        var actual = v1.Cross(v2);

        // Assert
        Assert.That(actual, Is.EqualTo(expected));
    }
}

