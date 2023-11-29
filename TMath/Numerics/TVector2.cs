using System.Globalization;
using System.Numerics;

namespace TMath.Numerics
{
    public partial class TVector2<T> : INumber<TVector2<T>> 
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

        public static TVector2<T> Abs(TVector2<T> value)
        {
            throw new NotImplementedException();
        }

        public static TVector2<T> One { get; }
        public static int Radix { get; }
        public static TVector2<T> Zero { get; }
    }
}
