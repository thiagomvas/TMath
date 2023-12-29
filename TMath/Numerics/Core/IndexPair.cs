using System.Numerics;
namespace TMath.Numerics.Core
{
    /// <summary>
    /// A pair of a value and an index.
    /// </summary>
    /// <remarks>The main use is to pair up an <see cref="int"/> and a <see cref="INumber{TSelf}"/> to be used in for loops</remarks>
    /// <typeparam name="T"></typeparam>
    internal struct IndexPair<T> where T : INumber<T>
    {
        public T Value;
        public int Index;

        public IndexPair(int start)
        {
            Value = T.CreateSaturating(start);
            Index = start;
        }
        public IndexPair(T value, int index)
        {
            Value = value;
            Index = index;
        }

        public static IndexPair<T> operator ++(IndexPair<T> pair)
        {
            return new IndexPair<T>(pair.Value + T.One, pair.Index + 1);
        }
        public static bool operator <(IndexPair<T> a, int b)
        {
            return a.Index < b;
        }
        public static bool operator >(IndexPair<T> a, int b)
        {
            return a.Index > b;
        }
    }
}
