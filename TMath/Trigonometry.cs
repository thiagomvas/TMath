using System.Numerics;

namespace TMath
{
    public static partial class TMath
    {

        /// <summary>
        /// Calculates the sine of an angle in radians.
        /// </summary>
        /// <typeparam name="T">An <see cref="INumber{TSelf}"/> that also implements <see cref="ITrigonometricFunctions{TSelf}"/></typeparam>
        /// <param name="radians">The angle in radians</param>
        /// <returns>The sine of <paramref name="radians"/></returns>
        public static T Sin<T>(T radians) where T : INumber<T>, ITrigonometricFunctions<T>
            => T.Sin(radians);

        /// <summary>
        /// Calculates the sine of an angle in degrees;
        /// </summary>
        /// <typeparam name="T">An <see cref="INumber{TSelf}"/> that also implements <see cref="ITrigonometricFunctions{TSelf}"/></typeparam>
        /// <param name="degrees">The angle in degrees</param>
        /// <returns>The sine of the angle</returns>
        public static T SinDeg<T>(T degrees) where T : INumber<T>, ITrigonometricFunctions<T>
            => Sin(ToRadians(degrees));

        /// <summary>
        /// Calculates the cosine of an angle in radians.
        /// </summary>
        /// <typeparam name="T">An <see cref="INumber{TSelf}"/> that also implements <see cref="ITrigonometricFunctions{TSelf}"/></typeparam>
        /// <param name="radians">The angle in radians</param>
        /// <returns>The cosine of <paramref name="radians"/></returns>
        public static T Cos<T>(T radians) where T : INumber<T>, ITrigonometricFunctions<T>
            => T.Cos(radians);

        /// <summary>
        /// Calculates the cosine of an angle in degrees.
        /// </summary>
        /// <typeparam name="T">An <see cref="INumber{TSelf}"/> that also implements <see cref="ITrigonometricFunctions{TSelf}"/></typeparam>
        /// <param name="degrees">The angle in degrees</param>
        /// <returns>The cosine of <paramref name="degrees"/></returns>
        public static T CosDeg<T>(T degrees) where T : INumber<T>, ITrigonometricFunctions<T>
            => Cos(ToRadians(degrees));

        /// <summary>
        /// Calculates the tangent of an angle in radians.
        /// </summary>
        /// <typeparam name="T">An <see cref="INumber{TSelf}"/> that also implements <see cref="ITrigonometricFunctions{TSelf}"/></typeparam>
        /// <param name="radians">The angle in radians</param>
        /// <returns>The tangent of <paramref name="radians"/></returns>
        public static T Tan<T>(T radians) where T : INumber<T>, ITrigonometricFunctions<T>
            => T.Tan(radians);

        /// <summary>
        /// Calculates the tangent of an angle in degrees
        /// </summary>
        /// <typeparam name="T">An <see cref="INumber{TSelf}"/> that also implements <see cref="ITrigonometricFunctions{TSelf}"/></typeparam>
        /// <param name="degrees">The angle in degrees</param>
        /// <returns>The tangent of <paramref name="degrees"/></returns>
        public static T TanDeg<T>(T degrees) where T : INumber<T>, ITrigonometricFunctions<T>
            => Tan(ToRadians(degrees));

        /// <summary>
        /// Calculates the arcsine of a number.
        /// </summary>
        /// <typeparam name="T">An <see cref="INumber{TSelf}"/> that also implements <see cref="ITrigonometricFunctions{TSelf}"/></typeparam>
        /// <param name="value">The value to calculate the arcsine of</param>
        /// <returns>The arcsine of <paramref name="value"/></returns>
        public static T Asin<T>(T value) where T : INumber<T>, ITrigonometricFunctions<T>
            => T.Asin(value);

        /// <summary>
        /// Calculates the arccosine of a number.
        /// </summary>
        /// <typeparam name="T">An <see cref="INumber{TSelf}"/> that also implements <see cref="ITrigonometricFunctions{TSelf}"/></typeparam>
        /// <param name="value">The value to calculate the arccosine of</param>
        /// <returns>The arccosine of <paramref name="value"/></returns>
        public static T Acos<T>(T value) where T : INumber<T>, ITrigonometricFunctions<T>
            => T.Acos(value);

        /// <summary>
        /// Calculates the arctangent of a number.
        /// </summary>
        /// <typeparam name="T">An <see cref="INumber{TSelf}"/> that also implements <see cref="ITrigonometricFunctions{TSelf}"/></typeparam>
        /// <param name="value">The value to calculate the arctangent of</param>
        /// <returns>The arctangent of <paramref name="value"/></returns>
        public static T Atan<T>(T value) where T : INumber<T>, ITrigonometricFunctions<T>
            => T.Atan(value);

        /// <summary>
        /// Calculates the cosecant of an angle in radians.
        /// </summary>
        /// <typeparam name="T">An <see cref="INumber{TSelf}"/> that also implements <see cref="ITrigonometricFunctions{TSelf}"/></typeparam>
        /// <param name="radians">The angle in radians</param>
        /// <returns>The cosecant of <paramref name="radians"/></returns>
        public static T Csc<T>(T radians) where T : INumber<T>, ITrigonometricFunctions<T>
            => T.One / Sin(radians);


        /// <summary>
        /// Calculates the cosecant of an angle in degrees.
        /// </summary>
        /// <typeparam name="T">An <see cref="INumber{TSelf}"/> that also implements <see cref="ITrigonometricFunctions{TSelf}"/></typeparam>
        /// <param name="degrees">The angle in radians</param>
        /// <returns>The cosecant of <paramref name="degrees"/></returns>
        public static T CscDeg<T>(T degrees) where T : INumber<T>, ITrigonometricFunctions<T>
            => T.One / SinDeg(degrees);

        /// <summary>
        /// Calculates the secant of an angle in radians.
        /// </summary>
        /// <typeparam name="T">An <see cref="INumber{TSelf}"/> that also implements <see cref="ITrigonometricFunctions{TSelf}"/></typeparam>
        /// <param name="radians">The angle in radians</param>
        /// <returns>The secant  of <paramref name="radians"/></returns>
        public static T Sec<T>(T radians) where T : INumber<T>, ITrigonometricFunctions<T>
            => T.One / Cos(radians);

        /// <summary>
        /// Calculates the secant of an angle in degrees.
        /// </summary>
        /// <typeparam name="T">An <see cref="INumber{TSelf}"/> that also implements <see cref="ITrigonometricFunctions{TSelf}"/></typeparam>
        /// <param name="degrees">The angle in degrees</param>
        /// <returns>The secant  of <paramref name="degrees"/></returns>
        public static T SecDeg<T>(T degrees) where T : INumber<T>, ITrigonometricFunctions<T>
            => T.One / CosDeg(degrees);

        /// <summary>
        /// Calculates the cotangent of an angle in radians.
        /// </summary>
        /// <typeparam name="T">An <see cref="INumber{TSelf}"/> that also implements <see cref="ITrigonometricFunctions{TSelf}"/></typeparam>
        /// <param name="radians">The angle in radians</param>
        /// <returns>The cotangent of <paramref name="radians"/></returns>
        public static T Cot<T>(T radians) where T : INumber<T>, ITrigonometricFunctions<T>
            => T.One / Tan(radians);


        /// <summary>
        /// Calculates the cotangent of an angle in degrees.
        /// </summary>
        /// <typeparam name="T">An <see cref="INumber{TSelf}"/> that also implements <see cref="ITrigonometricFunctions{TSelf}"/></typeparam>
        /// <param name="degrees">The angle in radians</param>
        /// <returns>The cotangent of <paramref name="degrees"/></returns>
        public static T CotDeg<T>(T degrees) where T : INumber<T>, ITrigonometricFunctions<T>
            => T.One / TanDeg(degrees);


    }
}
