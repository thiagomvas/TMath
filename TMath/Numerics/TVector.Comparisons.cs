namespace TMath.Numerics;

public partial class TVector<T>
{
    public int CompareTo(object? obj)
    {
        if (obj is TVector<T> v)
        {
            return CompareTo(v);
        }
        throw new ArgumentException("Object is not a TVector<T>", nameof(obj));
        
    }

    public int CompareTo(TVector<T>? other)
    {
        if (LengthSquared() == other.LengthSquared()) return 0;
        return LengthSquared() > other.LengthSquared() ? 1 : -1;
    }

    public bool Equals(TVector<T>? other)
    {
        foreach (var (x, y) in Values.Zip(other.Values))
        {
            if (!x.Equals(y)) return false;
        }

        return true;
    }

    public static bool IsCanonical(TVector<T> value)
    {
        foreach (var x in value.Values)
        {
            if (!T.IsCanonical(x)) return false;
        }

        return true;
    }

    public static bool IsComplexNumber(TVector<T> value)
    {
        foreach (var x in value.Values)
        {
            if (!T.IsComplexNumber(x)) return false;
        }

        return true;
    }

    public static bool IsEvenInteger(TVector<T> value)
    {
        foreach (var x in value.Values)
        {
            if (!T.IsEvenInteger(x)) return false;
        }

        return true;
    }

    public static bool IsFinite(TVector<T> value)
    {
        throw new NotImplementedException();
    }

    public static bool IsImaginaryNumber(TVector<T> value)
    {
        throw new NotImplementedException();
    }

    public static bool IsInfinity(TVector<T> value)
    {
        throw new NotImplementedException();
    }

    public static bool IsInteger(TVector<T> value)
    {
        throw new NotImplementedException();
    }

    public static bool IsNaN(TVector<T> value)
    {
        throw new NotImplementedException();
    }

    public static bool IsNegative(TVector<T> value)
    {
        throw new NotImplementedException();
    }

    public static bool IsNegativeInfinity(TVector<T> value)
    {
        throw new NotImplementedException();
    }

    public static bool IsNormal(TVector<T> value)
    {
        throw new NotImplementedException();
    }

    public static bool IsOddInteger(TVector<T> value)
    {
        throw new NotImplementedException();
    }

    public static bool IsPositive(TVector<T> value)
    {
        throw new NotImplementedException();
    }

    public static bool IsPositiveInfinity(TVector<T> value)
    {
        throw new NotImplementedException();
    }

    public static bool IsRealNumber(TVector<T> value)
    {
        throw new NotImplementedException();
    }

    public static bool IsSubnormal(TVector<T> value)
    {
        throw new NotImplementedException();
    }

    public static bool IsZero(TVector<T> value)
    {
        throw new NotImplementedException();
    }

    public static TVector<T> MaxMagnitude(TVector<T> x, TVector<T> y)
    {
        throw new NotImplementedException();
    }

    public static TVector<T> MaxMagnitudeNumber(TVector<T> x, TVector<T> y)
    {
        throw new NotImplementedException();
    }

    public static TVector<T> MinMagnitude(TVector<T> x, TVector<T> y)
    {
        throw new NotImplementedException();
    }

    public static TVector<T> MinMagnitudeNumber(TVector<T> x, TVector<T> y)
    {
        throw new NotImplementedException();
    }
}