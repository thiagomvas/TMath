using System.Numerics;

namespace TMath
{
    public static partial class TFunctions
    {
        /// <summary>
        /// Calculates the square root of <paramref name="num"/>.
        /// </summary>
        /// <typeparam name="T">An <see cref="INumber{TSelf}"/> that also implements <see cref="IRootFunctions{TSelf}"/></typeparam>
        /// <param name="num">The number to calculate the square root of</param>
        /// <returns>The square root of <paramref name="num"/></returns>
        public static T Sqrt<T>(T num) where T : INumber<T>, IRootFunctions<T> => T.Sqrt(num);


        /// <summary>
        /// Calculates the cubic root of <paramref name="num"/>.
        /// </summary>
        /// <typeparam name="T">An <see cref="INumber{TSelf}"/> that also implements <see cref="IRootFunctions{TSelf}"/></typeparam>
        /// <param name="num">The number to calculate the cubic root of</param>
        /// <returns>The cubic root of <paramref name="num"/></returns>
        public static T Cbrt<T>(T num) where T : INumber<T>, IRootFunctions<T> => T.Cbrt(num);


        /// <summary>
        /// Calculates the Nth root of <paramref name="num"/>.
        /// </summary>
        /// <typeparam name="T">An <see cref="INumber{TSelf}"/> that also implements <see cref="IRootFunctions{TSelf}"/></typeparam>
        /// <param name="num">The number to calculate the Nth root of</param>
        /// <param name="n">The root value</param>
        /// <returns>The Nth root of <paramref name="num"/></returns>
        public static T NRoot<T>(T num, int n) where T : INumber<T>, IRootFunctions<T> => T.RootN(num, n);
    }
}
