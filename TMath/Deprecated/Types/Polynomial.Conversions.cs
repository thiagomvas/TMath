using System.Numerics;

namespace TMath.Types
{
    public partial class Polynomial<T> : INumber<Polynomial<T>>
        where T : INumber<T>
    {


        static bool INumberBase<Polynomial<T>>.TryConvertFromChecked<TOther>(TOther value, out Polynomial<T> result)
        {
            if (value is Polynomial<T> p)
            {
                result = p;
                return true;
            }
            try
            {
                var num = T.CreateChecked(value);
                result = new Polynomial<T>(num);
                return true;
            }
            catch
            {
                result = Polynomial<T>.Zero;
                return false;
            }
        }

        static bool INumberBase<Polynomial<T>>.TryConvertFromSaturating<TOther>(TOther value, out Polynomial<T> result)
        {
            if (value is Polynomial<T> p)
            {
                result = p;
                return true;
            }
            try
            {
                var num = T.CreateSaturating(value);
                result = new Polynomial<T>(num);
                return true;
            }
            catch
            {
                result = Polynomial<T>.Zero;
                return false;
            }
        }

        static bool INumberBase<Polynomial<T>>.TryConvertFromTruncating<TOther>(TOther value, out Polynomial<T> result)
        {
            if (value is Polynomial<T> p)
            {
                result = p;
                return true;
            }
            try
            {
                var num = T.CreateTruncating(value);
                result = new Polynomial<T>(num);
                return true;
            }
            catch
            {
                result = Polynomial<T>.Zero;
                return false;
            }
        }

        static bool INumberBase<Polynomial<T>>.TryConvertToChecked<TOther>(Polynomial<T> value, out TOther result)
        {
            try
            {
                result = TOther.CreateChecked(value.EvaluateAt(T.Zero));
                return true;
            }
            catch
            {
                result = default;
                return false;
            }
        }

        static bool INumberBase<Polynomial<T>>.TryConvertToSaturating<TOther>(Polynomial<T> value, out TOther result)
        {
            try
            {
                result = TOther.CreateSaturating(value.EvaluateAt(T.Zero));
                return true;
            }
            catch
            {
                result = default;
                return false;
            }
        }

        static bool INumberBase<Polynomial<T>>.TryConvertToTruncating<TOther>(Polynomial<T> value, out TOther result)
        {
            try
            {
                result = TOther.CreateTruncating(value.EvaluateAt(T.Zero));
                return true;
            }
            catch
            {
                result = default;
                return false;
            }
        }
    }
}
