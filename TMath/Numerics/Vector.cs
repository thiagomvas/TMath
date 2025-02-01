using System.Collections;
using System.Numerics;
using TMath.Abstractions;
using TMath.Abstractions.Vectors;

namespace TMath.Numerics;

/// <summary>
/// A class representing a mathematical vector of numbers of type <typeparamref name="T"/>.
/// </summary>
/// <typeparam name="T">The type of number stored in the vector</typeparam>
public class Vector<T> : IVector<T>
    where T : INumberBase<T>
{
    private T[] _values;

    /// <summary>
    /// Initializes a new instance of the <see cref="Vector{T}"/> class.
    /// </summary>
    /// <param name="values">The values stored in the vector</param>
    /// <exception cref="ArgumentNullException">If the values are <see langword="null"/></exception>
    public Vector(T[] values)
    {
        _values = values ?? throw new ArgumentNullException(nameof(values));
        Length = _values.Length;
        Magnitude = AlternateMathT.BoxedSqrt(_values.Select(val => val * val).Aggregate(T.Zero, (acc, val) => acc + val));
    }

    /// <inheritdoc />
    public string ToString(string? format, IFormatProvider? formatProvider)
    {
        FormattableString formattable =
            $"{{{string.Join(", ", _values.Select(v => v.ToString(format, formatProvider)))}}}";
        return formattable.ToString(formatProvider);
    }

    /// <inheritdoc />
    public IEnumerator<T> GetEnumerator()
    {
        return ((IEnumerable<T>)_values).GetEnumerator();
    }

    /// <inheritdoc />
    public override string ToString()
    {
        return $"{{{string.Join(", ", _values)}}}";
    }

    /// <inheritdoc />
    public int CompareTo(object? obj)
    {
        if (obj is Vector<T> other && other.Length == Length)
        {
            double l = double.CreateSaturating(Magnitude);
            double r = double.CreateSaturating(other.Magnitude);
            return l.CompareTo(r);
        }

        throw new ArgumentException("Object is not a valid Vector<T>");
    }

    IEnumerator IEnumerable.GetEnumerator()
    {
        return GetEnumerator();
    }

    /// <inheritdoc />
    public int Length { get; }
    /// <inheritdoc />
    public T Magnitude { get; }

    /// <inheritdoc />
    public T this[int index]
    {
        get => _values[index];
        set => _values[index] = value;
    }

    /// <inheritdoc />
    public T Dot(IVector<T> other,
        VectorSizeDifferenceMode sizeDifferenceMode = VectorSizeDifferenceMode.ThrowIfDifferentSize)
    {
        if (other is not Vector<T> vector || (vector.Length != Length && sizeDifferenceMode == VectorSizeDifferenceMode.ThrowIfDifferentSize))
            throw new ArgumentException("Vectors must have the same length.");

        T[] l = _values, r = vector._values;
        if (l.Length != r.Length)
        {
            int size = MathT.Max(l.Length, r.Length);
            l = PadWithZeros(l, size, sizeDifferenceMode);
            r = PadWithZeros(r, size, sizeDifferenceMode);
        }

        T result = l.Zip(r, (a, b) => a * b)
            .Aggregate(T.Zero, (acc, product) => acc + product);
        return result;

    }

    /// <inheritdoc />
    public IVector<T> Cross(IVector<T> other,
        VectorSizeDifferenceMode sizeDifferenceMode = VectorSizeDifferenceMode.ThrowIfDifferentSize)
    {
        if (other is not Vector<T> vector || vector.Length != 3 || Length != 3)
            throw new ArgumentException("Cross product is only defined for 3D vectors.");
        
        // Cross product logic for 3D vectors
        var x = this[1] * vector[2] - this[2] * vector[1];
        var y = this[2] * vector[0] - this[0] * vector[2];
        var z = this[0] * vector[1] - this[1] * vector[0];
        return new Vector<T>([x, y, z]);

    }

    /// <inheritdoc />
    public IVector<T> Normalize()
    {
        T magnitude = Magnitude;
        if (magnitude.Equals(T.Zero))
            throw new InvalidOperationException("Cannot normalize a zero vector.");

        T[] normalizedValues = _values.Select(val => val / magnitude).ToArray();
        return new Vector<T>(normalizedValues);
    }

    /// <inheritdoc />
    public TypeCode GetTypeCode()
    {
        return TypeCode.Object;
    }

    /// <inheritdoc />
    public bool ToBoolean(IFormatProvider? provider)
    {
        return !T.IsZero(Magnitude);
    }

    /// <inheritdoc />
    public byte ToByte(IFormatProvider? provider)
    {
        return (byte)Convert.ToInt16(Magnitude);
    }

    /// <inheritdoc />
    public char ToChar(IFormatProvider? provider)
    {
        return (char)Convert.ToInt16(Magnitude);
    }

    /// <inheritdoc />
    public DateTime ToDateTime(IFormatProvider? provider)
    {
        throw new InvalidCastException();
    }

    /// <inheritdoc />
    public decimal ToDecimal(IFormatProvider? provider)
    {
        return Convert.ToDecimal(Magnitude);
    }

    /// <inheritdoc />
    public double ToDouble(IFormatProvider? provider)
    {
        return Convert.ToDouble(Magnitude);
    }

    /// <inheritdoc />
    public short ToInt16(IFormatProvider? provider)
    {
        return Convert.ToInt16(Magnitude);
    }

    /// <inheritdoc />
    public int ToInt32(IFormatProvider? provider)
    {
        return Convert.ToInt32(Magnitude);
    }

    /// <inheritdoc />
    public long ToInt64(IFormatProvider? provider)
    {
        return Convert.ToInt64(Magnitude);
    }

    /// <inheritdoc />
    public sbyte ToSByte(IFormatProvider? provider)
    {
        return (sbyte)Convert.ToInt16(Magnitude);
    }

    /// <inheritdoc />
    public float ToSingle(IFormatProvider? provider)
    {
        return Convert.ToSingle(Magnitude);
    }

    /// <inheritdoc />
    public string ToString(IFormatProvider? provider)
    {
        return ToString(null, provider);
    }

    /// <inheritdoc />
    public object ToType(Type conversionType, IFormatProvider? provider)
    {
        if (conversionType == typeof(Vector<T>))
            return this;
        throw new InvalidCastException();
    }

    /// <inheritdoc />
    public ushort ToUInt16(IFormatProvider? provider)
    {
        return (ushort)Convert.ToInt16(Magnitude);
    }

    /// <inheritdoc />
    public uint ToUInt32(IFormatProvider? provider)
    {
        return (uint)Convert.ToInt32(Magnitude);
    }

    /// <inheritdoc />
    public ulong ToUInt64(IFormatProvider? provider)
    {
        return (ulong)Convert.ToInt64(Magnitude);
    }

    private T[] PadWithZeros(T[] toPad, int targetLength, VectorSizeDifferenceMode mode)
    {
        if (toPad.Length == targetLength)
            return toPad;
        if (mode == VectorSizeDifferenceMode.PadLeftWithZeros)
        {
            T[] result = new T[targetLength];
            Array.Copy(toPad, 0, result, targetLength - toPad.Length, toPad.Length);
            return result;
        }
        if (mode == VectorSizeDifferenceMode.PadRightWithZeros)
        {
            T[] result = new T[targetLength];
            Array.Copy(toPad, result, toPad.Length);
            return result;
        }

        throw new ArgumentException("Vector Difference Mode not supported");
    }


    
}