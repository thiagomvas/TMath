﻿using System.Numerics;

namespace TMath
{

    /// <summary>
    /// Mathematics class with support for any <see cref="INumber{TSelf}"/>, such as floats, doubles,
    /// decimals, integers, or any custom number type that implements the interface.
    /// </summary>
    /// <remarks>
    /// Some functions require additional implementations for each number, which means not all number types are supported by them.
    /// For example, trigonometric functions require a type that implements <see cref="ITrigonometricFunctions{TSelf}"/>, some exponential
    /// functions require <see cref="IExponentialFunctions{TSelf}"/>, and so on. 
    /// </remarks>
    public static partial class TFunctions
    {
        /// <summary>
        /// Converts an integer to a type T.
        /// </summary>
        /// <param name="num">The number to convert</param>
        /// <typeparam name="T">The target type</typeparam>
        /// <returns>The converted integer into the type T</returns>
        /// <remarks>Used internally a lot by <see cref="TFunctions"/> to get a specific number of a type T so operations can be done successfully.</remarks>
        public static T IntToT<T>(int num) where T : INumber<T> => T.CreateSaturating(num);

        /// <summary>
        /// Returns the absolute value of a number.
        /// </summary>
        /// <param name="n">A number between the type's MinValue and MaxValue</param>
        /// <returns>The absolute value of the number</returns>
        public static T Abs<T>(T n) where T : INumber<T> => T.IsNegative(n) ? -n : n;

        /// <summary>
        /// Rounds the number down to the closest integral form.
        /// </summary>
        /// <param name="n">The number to round down</param>
        /// <returns>The rounded down number.</returns>
        public static T Floor<T>(T n) where T : INumber<T>
        {
            if (T.IsNegative(n))
                return -(Abs(n) - Abs(n % T.One)) - T.One;
            else return n - (n % T.One);
        }

        /// <summary>
        /// Rounds the number up to the closest integral form.
        /// </summary>
        /// <param name="n">The number to round up</param>
        /// <returns>The rounded up number.</returns>
        public static T Ceil<T>(T n) where T : INumber<T>
        {
            if(n % T.One == T.Zero)
                return n;
            if (T.IsNegative(n))
                return Truncate(n);
            return Truncate(n) + T.One;
        }

        /// <summary>
        /// Rounds the number to the closest integral form.
        /// </summary>
        /// <param name="n">The number to round</param>
        /// <returns>The rounded number</returns>
        public static T Round<T>(T n, int precision = 0) where T : INumber<T>
        {
            T pow = precision > 0 ? Pow(IntToT<T>(10), precision) : T.One;
            if(T.IsNegative(n))
            {
                T floating = precision > 0 ? -n * pow % T.One : -n % T.One;
                if (floating > T.One / (T.One + T.One))
                    return pow <= T.One ? Floor(n) : Floor(n * pow) / pow;
                else
                    return pow <= T.One ? Ceil(n) : Ceil(n * pow) / pow;
            }

            else
            {
                T floating = precision > 0 ? n * pow % T.One : n % T.One;

                if (floating > T.One / (T.One + T.One))
                    return pow <= T.One ? Ceil(n) : Ceil(n * pow) / pow;
                else
                    return pow <= T.One ? Floor(n) : Floor(n * pow) / pow;
            }
        }

        /// <summary>
        /// Gets the factorial of an number.
        /// </summary>
        /// <param name="n">The number to obtain its factorial</param>
        /// <typeparam name="T">The number type to return the factorial as</typeparam>
        /// <returns>The factorial of a number as a type T</returns>

        public static T Factorial<T>(T n) where T : INumber<T>, IBinaryInteger<T>
        {
            T result = T.One;
            T value = n;
            while (value > T.One)
            {
                result *= value;
                value--;
                
            }
            return result;
        }



        /// <summary>
        /// Gets the factorial of an number.
        /// </summary>
        /// <param name="n">The number to obtain its factorial</param>
        /// <typeparam name="TSource">The type of N to calculate the factorial, where N is an integer type</typeparam>
        /// <typeparam name="TTarget">The number type to return the factorial as</typeparam>
        /// <returns>The factorial of a number as a type T</returns>

        public static TTarget Factorial<TTarget, TSource>(TSource n) 
            where TSource : INumber<TSource>, IBinaryInteger<TSource>
            where TTarget : INumber<TTarget>
        {
            TTarget result = TTarget.One;
            TTarget value = TTarget.CreateSaturating(n);
            while (value > TTarget.One)
            {
                result *= value;
                value--;

            }
            return result;
        }

        /// <summary>
        /// Converts a number of degrees into radians.
        /// </summary>
        /// <param name="deg">The degree value</param>
        /// <returns>The degrees converted into radians</returns>
        public static T ToRadians<T>(T deg) where T : INumber<T> => deg * TConstants<T>.Pi / IntToT<T>(180);

        /// <summary>
        /// Converts a value in radians into degrees.
        /// </summary>
        /// <param name="radians">The radian value</param>
        /// <returns>The radian value converted into degrees</returns>
        public static T Rad2Deg<T>(T radians) where T : INumber<T> => radians * IntToT<T>(180) / TConstants<T>.Pi;

		/// <summary>
		/// Calculates a to the power of b.
		/// </summary>
		/// <param name="a">The base</param>
		/// <param name="b">The exponent</param>
		/// <typeparam name="T">A generic type that inherits <see cref="INumber{TSelf}"/> and <see cref="IPowerFunctions{TSelf}"/></typeparam>
		/// <returns>a to the power of b</returns>
		public static T Pow<T>(T a, T b) where T : INumber<T>, IPowerFunctions<T> => T.Pow(a, b);


		/// <summary>
		/// Calculates a to the power of b.
		/// </summary>
		/// <param name="a">The base</param>
		/// <param name="b">The exponent</param>
		/// <typeparam name="TTarget">A generic type that inherits <see cref="INumber{TSelf}"/></typeparam>
		/// <typeparam name="TSource">A generic type that inherits <see cref="INumber{TSelf}"/></typeparam>
		/// <returns>a to the power of b</returns>
		/// <remarks>
		/// This function is slower than <see cref="Pow{T}(T, T)"/> and should only be used when the type T does not implement <see cref="IPowerFunctions{TSelf}"/>.
		/// </remarks>
		public static TTarget Pow<TTarget,TSource>(TSource a, TSource b) 
            where TTarget : INumber<TTarget>
            where TSource : INumber<TSource> => TTarget.CreateSaturating(double.Pow(Convert.ToDouble(a), Convert.ToDouble(b)));


		/// <summary>
		/// Calculates a to the power of b.
		/// </summary>
		/// <param name="a">The base number.</param>
		/// <param name="b">The power of the base number.</param>
		/// <returns><paramref name="a"/> to the power of <paramref name="b"></paramref></returns>
		/// <remarks>
		/// When using integer types, do keep in mind that it will also return an integer type by casting it.
		/// </remarks>
		public static T Pow<T>(T a, int b) where T : INumber<T>
        {
            if (b < 0) return T.One / Pow(a, Abs(b));
            if (b == 0) return T.One; 
            if (b == 1) return a;
            T result = a;
            for(int i = 2; i <= b; i++)
                result *= a;
            return result;
        }

        /// <summary>
        /// Clamps a value between min and max values
        /// </summary>
        /// <param name="value">The value to clamp</param>
        /// <param name="min">The minimal value</param>
        /// <param name="max">The maximum value</param>
        /// <returns> <paramref name="value"/> clamped to the inclusive range of <paramref name="min"/> and <paramref name="max"/> </returns>
        public static T Clamp<T>(T value, T min, T max) where T : INumber<T> =>
            min > value ? min : (value < max ? value : max);


        /// <summary>
        /// Copies the sign from one variable to the other.
        /// </summary>
        /// <param name="value">The value of the result</param>
        /// <param name="sign">The sign of the result</param>
        /// <returns>A number with the magnitude of <paramref name="value"/> and the sign of <paramref name="sign"/></returns>
        public static T CopySign<T>(T value, T sign) where T : INumber<T> => T.CopySign(value, sign);

        /// <summary>
        /// Returns the remainder of the division of 2 numbers
        /// </summary>
        /// <param name="number">The number to divide</param>
        /// <param name="divider">The divider</param>
        /// <returns>The remainder of <paramref name="number"/>/<paramref name="divider"/></returns>
        public static T Remainder<T>(T n, T d) where T : INumber<T> => n % d;

        /// <summary>
        /// Calculates the summation of a function.
        /// </summary>
        /// <param name="func">The function to calculate the sum of</param>
        /// <param name="n">The upper limit of summation</param>
        /// <param name="i">The index of summation</param>
        /// <returns>The sum of f(i) + f(i + 1) + ... + f(n)</returns>
        public static T Sum<T>(Func<T, T> func, int n, int i = 1) where T : INumber<T>
        {
            T sum = T.Zero;
            for (int x = i; x <= n; x++)
                sum += func(IntToT<T>(x));
            return sum;
        }

        /// <summary>
        /// Truncates the number by removing decimal places on the number
        /// </summary>
        /// <param name="value">The value to truncate</param>
        /// <param name="accuracy">The amount of decimal places to have.</param>
        /// <returns>The truncated number</returns>
        public static T Truncate<T>(T value)
            where T : INumber<T>
        {
            T n = value % T.One;
            return value - n;
        }

        /// <summary>
        /// Returns the smallest value of 2 numbers.
        /// </summary>
        /// <param name="a">The first number</param>
        /// <param name="b">The second number</param>
        /// <returns>The smallest value between <paramref name="a"/> and <paramref name="b"/></returns>
        public static T Min<T>(T a, T b) where T : INumber<T> => a < b ? a : b;

		/// <summary>
		/// Returns the biggest value of 2 numbers.
		/// </summary>
		/// <param name="a">The first number</param>
		/// <param name="b">The second number</param>
		/// <returns>The biggest value between <paramref name="a"/> and <paramref name="b"/></returns>
		public static T Max<T>(T a, T b) where T : INumber<T> => a > b ? a : b;
    }
}