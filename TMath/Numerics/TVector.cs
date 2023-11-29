using System.Globalization;
using System.Numerics;
using System.Text;

namespace TMath.Numerics
{

    public partial class TVector<T> : INumber<TVector<T>>
    where T : INumber<T>
    {
        public string ToString(string? format, IFormatProvider? formatProvider)
        {
            throw new NotImplementedException();
        }

        public bool TryFormat(Span<char> destination, out int charsWritten, ReadOnlySpan<char> format, IFormatProvider? provider)
        {
            throw new NotImplementedException();
        }

        public static TVector<T> Abs(TVector<T> value)
        {
            throw new NotImplementedException();
        }

        public static TVector<T> One { get; }
        public static int Radix { get; }
        public static TVector<T> Zero { get; }
    }
}
