using System.Numerics;

namespace TMath
{
    public static partial class TFunctions
    {
        /// <summary>
        /// Calculates the base 2 logarithm of <paramref name="num"/>.
        /// </summary>
        /// <typeparam name="T">An <see cref="INumber{TSelf}"/> that also implements <see cref="ILogarithmicFunctions{TSelf}"/></typeparam>
        /// <param name="num">The number to calculate the base 2 logarithm of</param>
        /// <returns>The base 2 logarithm of <paramref name="num"/></returns>
        public static T Log2<T>(T num) where T : INumber<T>, ILogarithmicFunctions<T> => T.Log2(num);

        /// <summary>
        /// Calculates the base 10 logarithm of <paramref name="num"/>.
        /// </summary>
        /// <typeparam name="T">An <see cref="INumber{TSelf}"/> that also implements <see cref="ILogarithmicFunctions{TSelf}"/></typeparam>
        /// <param name="num">The number to calculate the base 10 logarithm of</param>
        /// <returns>The base 10 logarithm of <paramref name="num"/></returns>
        public static T Log10<T>(T num) where T : INumber<T>, ILogarithmicFunctions<T> => T.Log10(num);


        /// <summary>
        /// Calculates the natural logarithm of <paramref name="num"/>.
        /// </summary>
        /// <typeparam name="T">An <see cref="INumber{TSelf}"/> that also implements <see cref="ILogarithmicFunctions{TSelf}"/></typeparam>
        /// <param name="num">The number to calculate the natural logarithm of</param>
        /// <returns>The natural logarithm of <paramref name="num"/></returns>
        public static T Ln<T>(T num) where T : INumber<T>, ILogarithmicFunctions<T> => T.Log(num);

        /// <summary>
        /// Calculates the natural logarithm of <paramref name="num"/>.
        /// </summary>
        /// <typeparam name="T">An <see cref="INumber{TSelf}"/> that also implements <see cref="ILogarithmicFunctions{TSelf}"/></typeparam>
        /// <param name="num">The number to calculate the natural logarithm of</param>
        /// <returns>The natural logarithm of <paramref name="num"/></returns>
        public static T Log<T>(T num) where T : INumber<T>, ILogarithmicFunctions<T> => T.Log(num);


        /// <summary>
        /// Calculates the logarithm of <paramref name="num"/> with the specified base.
        /// </summary>
        /// <typeparam name="T">An <see cref="INumber{TSelf}"/> that also implements <see cref="ILogarithmicFunctions{TSelf}"/></typeparam>
        /// <param name="num">The number to calculate the logarithm of</param>
        /// <param name="base">The base of the logarithm</param>
        /// <returns>The logarithm of <paramref name="num"/> with the specified base</returns>
        public static T Log<T>(T num, T @base) where T : INumber<T>, ILogarithmicFunctions<T> => T.Log(num, @base);
    }
}
