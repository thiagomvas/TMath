using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace TMath.Numerics
{
    public partial class TVector3<T> : INumber<TVector3<T>>
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

        public static TVector3<T> Abs(TVector3<T> value)
        {
            throw new NotImplementedException();
        }

        public static TVector3<T> One { get; }
        public static int Radix { get; }
        public static TVector3<T> Zero { get; }
    }
}
