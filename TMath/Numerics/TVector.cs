using System.Numerics;
using System.Text;

namespace TMath.Numerics
{

    public partial class TVector<T> : INumber<TVector<T>>
    where T : INumber<T>
    {
        public T[] Values { get; set; }

        public string ToString(string? format, IFormatProvider? formatProvider)
        {
            StringBuilder sb = new StringBuilder();
            sb.Append("<");
            for (int i = 0; i < Values.Length; i++)
            {
                sb.Append(Values[i].ToString(format, formatProvider));
                if (i < Values.Length - 1)
                {
                    sb.Append(", ");
                }
            }
            sb.Append(">");
            return sb.ToString();

        }

        public bool TryFormat(Span<char> destination, out int charsWritten, ReadOnlySpan<char> format, IFormatProvider? provider)
        {
            string result = string.Join(", ", Values);
            charsWritten = result.Length;
            return result.AsSpan().TryCopyTo(destination);
        }

        public static TVector<T> Abs(TVector<T> value)
        {
            TVector<T> v = new TVector<T>();
            v.Values = value.Values.Select(x => T.Abs(x)).ToArray();
            return v;
        }

        public T LengthSquared() => Values.Select(x => x * x).Aggregate((acc, x) => acc + x);


        public static TVector<T> One => new TVector<T>();

        public static int Radix => 10;
        public static TVector<T> Zero => new TVector<T>();
    }
}
