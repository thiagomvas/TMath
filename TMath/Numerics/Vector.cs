using System;
using System.Collections;
using System.Linq;
using System.Numerics;
using TMath.Abstractions;
using TMath.Abstractions.Vectors;

namespace TMath.Numerics;

public class Vector<T> : IVector<T>
    where T : INumberBase<T>
{
    private T[] _values;

    public Vector(T[] values)
    {
        _values = values ?? throw new ArgumentNullException(nameof(values));
        Length = _values.Length;
        Magnitude = _values.Select(val => val * val).Aggregate(T.Zero, (acc, val) => acc + val);
    }

    public string ToString(string? format, IFormatProvider? formatProvider)
    {
        FormattableString formattable =
            $"{{{string.Join(", ", _values.Select(v => v.ToString(format, formatProvider)))}}}";
        return formattable.ToString(formatProvider);
    }

    public IEnumerator<T> GetEnumerator()
    {
        return ((IEnumerable<T>)_values).GetEnumerator();
    }

    public override string ToString()
    {
        return $"{{{string.Join(", ", _values)}}}";
    }

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

    public int Length { get; }
    public T Magnitude { get; }

    public T this[int index]
    {
        get => _values[index];
        set => _values[index] = value;
    }

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

    public IVector<T> Cross(IVector<T> other,
        VectorSizeDifferenceMode sizeDifferenceMode = VectorSizeDifferenceMode.ThrowIfDifferentSize)
    {
        if (other is Vector<T> vector && vector.Length == 3 && Length == 3)
        {
            // Cross product logic for 3D vectors
            var x = this[1] * vector[2] - this[2] * vector[1];
            var y = this[2] * vector[0] - this[0] * vector[2];
            var z = this[0] * vector[1] - this[1] * vector[0];
            return new Vector<T>(new T[] { x, y, z });
        }

        throw new ArgumentException("Cross product is only defined for 3D vectors.");
    }

    public IVector<T> Normalize()
    {
        T magnitude = Magnitude;
        if (magnitude.Equals(T.Zero))
            throw new InvalidOperationException("Cannot normalize a zero vector.");

        T[] normalizedValues = _values.Select(val => val / magnitude).ToArray();
        return new Vector<T>(normalizedValues);
    }

    public TypeCode GetTypeCode()
    {
        return TypeCode.Object;
    }

    public bool ToBoolean(IFormatProvider? provider)
    {
        return !T.IsZero(Magnitude);
    }

    public byte ToByte(IFormatProvider? provider)
    {
        return (byte)Convert.ToInt16(Magnitude);
    }

    public char ToChar(IFormatProvider? provider)
    {
        return (char)Convert.ToInt16(Magnitude);
    }

    public DateTime ToDateTime(IFormatProvider? provider)
    {
        throw new InvalidCastException();
    }

    public decimal ToDecimal(IFormatProvider? provider)
    {
        return (decimal)Convert.ToDecimal(Magnitude);
    }

    public double ToDouble(IFormatProvider? provider)
    {
        return (double)Convert.ToDouble(Magnitude);
    }

    public short ToInt16(IFormatProvider? provider)
    {
        return (short)Convert.ToInt16(Magnitude);
    }

    public int ToInt32(IFormatProvider? provider)
    {
        return (int)Convert.ToInt32(Magnitude);
    }

    public long ToInt64(IFormatProvider? provider)
    {
        return (long)Convert.ToInt64(Magnitude);
    }

    public sbyte ToSByte(IFormatProvider? provider)
    {
        return (sbyte)Convert.ToInt16(Magnitude);
    }

    public float ToSingle(IFormatProvider? provider)
    {
        return (float)Convert.ToSingle(Magnitude);
    }

    public string ToString(IFormatProvider? provider)
    {
        return ToString(null, provider);
    }

    public object ToType(Type conversionType, IFormatProvider? provider)
    {
        if (conversionType == typeof(Vector<T>))
            return this;
        throw new InvalidCastException();
    }

    public ushort ToUInt16(IFormatProvider? provider)
    {
        return (ushort)Convert.ToInt16(Magnitude);
    }

    public uint ToUInt32(IFormatProvider? provider)
    {
        return (uint)Convert.ToInt32(Magnitude);
    }

    public ulong ToUInt64(IFormatProvider? provider)
    {
        return (ulong)Convert.ToInt64(Magnitude);
    }

    private T[] PadWithZeros(T[] toPad, int targetLength, VectorSizeDifferenceMode mode)
    {
        if (toPad.Length == targetLength)
            return toPad;

        T zero = T.Zero;

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