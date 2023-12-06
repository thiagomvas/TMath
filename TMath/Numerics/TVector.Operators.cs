namespace TMath.Numerics;

public partial class TVector<T>
{
    public static TVector<T> AdditiveIdentity { get; } = new();
    public static TVector<T> MultiplicativeIdentity { get; } = new(new T[] { T.One });
    public static TVector<T> operator +(TVector<T> left, TVector<T> right)
    {
        TVector<T> target, toAdd;
        if (left.Size >= right.Size)
        {
            target = left;
            toAdd = right;
        }
        else
        {
            target = right;
            toAdd = left;
        }

        T[] result = target.Values;
        for (int i = 0; i < toAdd.Size; i++)
        {
            result[i] += toAdd.Values[i];
        }

        return new TVector<T>(result);

    }


    public static bool operator ==(TVector<T>? left, TVector<T>? right)
    {
        return left.Size == right.Size && left.Values.SequenceEqual(right.Values);
    }

    public static bool operator !=(TVector<T>? left, TVector<T>? right)
    {
        return left.Size != right.Size || !left.Values.SequenceEqual(right.Values);
    }

    public static bool operator >(TVector<T> left, TVector<T> right)
    {
        TVector<T> lowerSize = left.Size < right.Size ? left : right;
        for (int i = 0; i < lowerSize.Size; i++)
        {
            if (left.Values[i] <= right.Values[i])
            {
                return false;
            }
        }
        return true;
    }

    public static bool operator >=(TVector<T> left, TVector<T> right)
    {
        TVector<T> lowerSize = left.Size < right.Size ? left : right;
        for (int i = 0; i < lowerSize.Size; i++)
        {
            if (left.Values[i] < right.Values[i])
            {
                return false;
            }
        }

        return true;
    }

    public static bool operator <(TVector<T> left, TVector<T> right)
    {
        TVector<T> lowerSize = left.Size < right.Size ? left : right;
        for (int i = 0; i < lowerSize.Size; i++)
        {
            if (left.Values[i] >= right.Values[i])
            {
                return false;
            }
        }

        return true;
    }

    public static bool operator <=(TVector<T> left, TVector<T> right)
    {
        TVector<T> lowerSize = left.Size < right.Size ? left : right;
        for (int i = 0; i < lowerSize.Size; i++)
        {
            if (left.Values[i] > right.Values[i])
            {
                return false;
            }
        }
        return true;
    }

    public static TVector<T> operator --(TVector<T> value)
    {
        return new(value.Values.Select(x => x - T.One).ToArray());
    }

    public static TVector<T> operator ++(TVector<T> value)
    {
        throw new NotImplementedException();
    }

    public static TVector<T> operator %(TVector<T> left, TVector<T> right)
    {
        throw new NotImplementedException();
    }


    public static TVector<T> operator *(TVector<T> left, TVector<T> right)
    {
        throw new NotImplementedException();
    }

    public static TVector<T> operator -(TVector<T> left, TVector<T> right)
    {
        throw new NotImplementedException();
    }

    public static TVector<T> operator -(TVector<T> value)
    {
        throw new NotImplementedException();
    }

    public static TVector<T> operator +(TVector<T> value)
    {
        throw new NotImplementedException();
    }
}