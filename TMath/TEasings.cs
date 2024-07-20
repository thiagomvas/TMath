using System.Numerics;

namespace TMath
{
    public static class TEasings
    {
        /// <summary>
        /// Enumeration of easing types.
        /// </summary>
        public enum EasingType { Linear, InQuad, OutQuad, InOutQuad, InCubic, OutCubic, InOutCubic, InQuart, OutQuart, InOutQuart, InQuint, OutQuint, InOutQuint }

        /// <summary>
        /// Gets the easing value based on the specified easing type and input value.
        /// </summary>
        /// <typeparam name="T">The type of the input value.</typeparam>
        /// <param name="type">The easing type.</param>
        /// <param name="t">The input value.</param>
        /// <returns>The easing value.</returns>
        public static T GetEasing<T>(EasingType type, T t) where T : INumber<T>
        {
            switch (type)
            {
                case EasingType.Linear:
                    return Linear(t);
                case EasingType.InQuad:
                    return InQuad(t);
                case EasingType.OutQuad:
                    return OutQuad(t);
                case EasingType.InOutQuad:
                    return InOutQuad(t);
                case EasingType.InCubic:
                    return InCubic(t);
                case EasingType.OutCubic:
                    return OutCubic(t);
                case EasingType.InOutCubic:
                    return InOutCubic(t);
                case EasingType.InQuart:
                    return InQuart(t);
                case EasingType.OutQuart:
                    return OutQuart(t);
                case EasingType.InOutQuart:
                    return InOutQuart(t);
                case EasingType.InQuint:
                    return InQuint(t);
                case EasingType.OutQuint:
                    return OutQuint(t);
                case EasingType.InOutQuint:
                    return InOutQuint(t);
                default:
                    throw new ArgumentOutOfRangeException(nameof(type), type, null);
            }
        }

        /// <summary>
        /// Returns the input value as the easing value.
        /// </summary>
        /// <typeparam name="T">The type of the input value.</typeparam>
        /// <param name="t">The input value.</param>
        /// <returns>The easing value.</returns>
        public static T Linear<T>(T t) where T : INumber<T> => t;

        /// <summary>
        /// Returns the input value squared as the easing value.
        /// </summary>
        /// <typeparam name="T">The type of the input value.</typeparam>
        /// <param name="t">The input value.</param>
        /// <returns>The easing value.</returns>
        public static T InQuad<T>(T t) where T : INumber<T> => t * t;

        /// <summary>
        /// Returns the inverse of the input value squared as the easing value.
        /// </summary>
        /// <typeparam name="T">The type of the input value.</typeparam>
        /// <param name="t">The input value.</param>
        /// <returns>The easing value.</returns>
        public static T OutQuad<T>(T t) where T : INumber<T> => T.One - InQuad(T.One - t);

        /// <summary>
        /// Returns the easing value based on the input value using the quadratic equation.
        /// </summary>
        /// <typeparam name="T">The type of the input value.</typeparam>
        /// <param name="t">The input value.</param>
        /// <returns>The easing value.</returns>
        public static T InOutQuad<T>(T t) where T : INumber<T>
        {
            if (t < T.One / TConstants<T>.Two) return InQuad(t * TConstants<T>.Two) / TConstants<T>.Two;
            return T.One - InQuad((T.One - t) / TConstants<T>.Two) / TConstants<T>.Two;
        }

        /// <summary>
        /// Returns the input value cubed as the easing value.
        /// </summary>
        /// <typeparam name="T">The type of the input value.</typeparam>
        /// <param name="t">The input value.</param>
        /// <returns>The easing value.</returns>
        public static T InCubic<T>(T t) where T : INumber<T> => t * t * t;

        /// <summary>
        /// Returns the inverse of the input value cubed as the easing value.
        /// </summary>
        /// <typeparam name="T">The type of the input value.</typeparam>
        /// <param name="t">The input value.</param>
        /// <returns>The easing value.</returns>
        public static T OutCubic<T>(T t) where T : INumber<T> => T.One - InCubic(T.One - t);

        /// <summary>
        /// Returns the easing value based on the input value using the cubic equation.
        /// </summary>
        /// <typeparam name="T">The type of the input value.</typeparam>
        /// <param name="t">The input value.</param>
        /// <returns>The easing value.</returns>
        public static T InOutCubic<T>(T t) where T : INumber<T>
        {
            if (t < T.One / (TConstants<T>.Two)) return InCubic(t * TConstants<T>.Two) / TConstants<T>.Two;
            return T.One - InCubic((T.One - t) * TConstants<T>.Two) / TConstants<T>.Two;
        }

        /// <summary>
        /// Returns the input value raised to the power of four as the easing value.
        /// </summary>
        /// <typeparam name="T">The type of the input value.</typeparam>
        /// <param name="t">The input value.</param>
        /// <returns>The easing value.</returns>
        public static T InQuart<T>(T t) where T : INumber<T> => t * t * t * t;

        /// <summary>
        /// Returns the inverse of the input value raised to the power of four as the easing value.
        /// </summary>
        /// <typeparam name="T">The type of the input value.</typeparam>
        /// <param name="t">The input value.</param>
        /// <returns>The easing value.</returns>
        public static T OutQuart<T>(T t) where T : INumber<T> => T.One - InQuart(T.One - t);

        /// <summary>
        /// Returns the easing value based on the input value using the quartic equation.
        /// </summary>
        /// <typeparam name="T">The type of the input value.</typeparam>
        /// <param name="t">The input value.</param>
        /// <returns>The easing value.</returns>
        public static T InOutQuart<T>(T t) where T : INumber<T>
        {
            if (t < T.One / (TConstants<T>.Two)) return InQuart(t * TConstants<T>.Two) / TConstants<T>.Two;
            return T.One - InQuart((T.One - t) * TConstants<T>.Two) / TConstants<T>.Two;
        }

        /// <summary>
        /// Returns the input value raised to the power of five as the easing value.
        /// </summary>
        /// <typeparam name="T">The type of the input value.</typeparam>
        /// <param name="t">The input value.</param>
        /// <returns>The easing value.</returns>
        public static T InQuint<T>(T t) where T : INumber<T> => t * t * t * t * t;

        /// <summary>
        /// Returns the inverse of the input value raised to the power of five as the easing value.
        /// </summary>
        /// <typeparam name="T">The type of the input value.</typeparam>
        /// <param name="t">The input value.</param>
        /// <returns>The easing value.</returns>
        public static T OutQuint<T>(T t) where T : INumber<T> => T.One - InQuint(T.One - t);

        /// <summary>
        /// Returns the easing value based on the input value using the quintic equation.
        /// </summary>
        /// <typeparam name="T">The type of the input value.</typeparam>
        /// <param name="t">The input value.</param>
        /// <returns>The easing value.</returns>
        public static T InOutQuint<T>(T t) where T : INumber<T>
        {
            if (t < T.One / (TConstants<T>.Two)) return InQuint(t * TConstants<T>.Two) / TConstants<T>.Two;
            return T.One - InQuint((T.One - t) * TConstants<T>.Two) / TConstants<T>.Two;
        }
    }
}
