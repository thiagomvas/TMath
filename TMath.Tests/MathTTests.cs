namespace TMath.Tests
{
    [TestFixture]
    public class MathTTests
    {
        [Test]
        [TestCase(0d, 1, 0)]
        [TestCase(-1d, 3, -1)]
        [TestCase(2d, 3, 8)]
        [TestCase(10, -1, 0.1d)]
        [TestCase(10, -2, 0.01d)]
        public void Pow_IntT(double x, int p, double expected)
            => Assert.That(MathT.Pow(x, p), Is.EqualTo(expected).Within(1e-6));

        [Test]
        [TestCase(0d, 1, 0)]
        [TestCase(-1d, 3, -1)]
        [TestCase(2d, 3, 8)]
        [TestCase(10, -1, 0.1d)]
        [TestCase(10, -2, 0.01d)]
        public void Pow_TT(double x, double p, double expected)
            => Assert.That(MathT.Pow(x, p), Is.EqualTo(expected).Within(1e-6));

        [Test]
        [TestCase(0)]
        [TestCase(1)]
        [TestCase(2)]
        [TestCase(3)]
        [TestCase(4)]
        [TestCase(5)]
        public void Sqrt_TT(double x)
            => Assert.That(MathT.Sqrt(x), Is.EqualTo(Math.Sqrt(x)).Within(1e-9));

        [Test]
        public void Sqrt_TT_ShouldThrow_WhenXIsNegative()
            => Assert.Throws<ArgumentException>(() => MathT.Sqrt(-1d));

        [Test]
        [TestCase(0)]
        [TestCase(-1)]
        [TestCase(-2)]
        [TestCase(3)]
        [TestCase(4)]
        public void Cbrt_TT(double x)
            => Assert.That(MathT.Cbrt(x), Is.EqualTo(Math.Cbrt(x)).Within(1e-9));

        [Test]
        [TestCase(0, 2)]
        [TestCase(4, 2)]
        [TestCase(8, 3)]
        public void NRoot_TT(double x, int n)
            => Assert.That(MathT.RootN(x, n), Is.EqualTo(double.RootN(x, n)).Within(1e-9));

        [Test]
        [TestCase(0)]
        [TestCase(1)]
        [TestCase(2)]
        [TestCase(3)]
        public void Exp_T(double x)
            => Assert.That(MathT.Exp(x), Is.EqualTo(Math.Exp(x)).Within(1e-9));

        [Test]
        [TestCase(2)]
        [TestCase(4)]
        [TestCase(8)]
        [TestCase(16)]
        public void ExpPS_ShouldBeEqualTo_Exp(double x)
            => Assert.That(MathT.ExpPS(x, 200), Is.EqualTo(Math.Exp(x)).Within(1e-7));

        [Test]
        [TestCase(1)]
        [TestCase(2)]
        [TestCase(4)]
        [TestCase(8)]
        public void Log_T(double x)
            => Assert.That(MathT.Log(x), Is.EqualTo(Math.Log(x)).Within(1e-9));

        [Test]
        [TestCase(1, 10)]
        [TestCase(4, 2)]
        [TestCase(10, 3)]
        [TestCase(20, 4)]
        public void Log_TT(double x, double b)
            => Assert.That(MathT.Log(x, b), Is.EqualTo(Math.Log(x, b)).Within(1e-9));

        [Test]
        [TestCase(10)]
        [TestCase(12)]
        [TestCase(100)]
        [TestCase(120)]
        public void Log10_T(double x)
            => Assert.That(MathT.Log10(x), Is.EqualTo(Math.Log10(x)).Within(1e-9));

        [Test]
        [TestCase(2)]
        [TestCase(4)]
        [TestCase(5)]
        [TestCase(8)]
        [TestCase(21)]
        public void Log2_T(double x)
            => Assert.That(MathT.Log2(x), Is.EqualTo(Math.Log2(x)).Within(1e-9));

        [Test]
        [TestCase(0)]
        [TestCase(1)]
        [TestCase(-1)]
        [TestCase(3)]
        public void Sin(double x)
            => Assert.That(MathT.Sin(x), Is.EqualTo(Math.Sin(x)).Within(1e-9));

        [Test]
        [TestCase(0)]
        [TestCase(1)]
        [TestCase(-1)]
        [TestCase(3)]
        public void SinPS_ShouldBeEqualTo_Sin(double x)
            => Assert.That(MathT.SinPS(x, 200), Is.EqualTo(Math.Sin(x)).Within(1e-9));


        [Test]
        [TestCase(0)]
        [TestCase(1)]
        [TestCase(-1)]
        [TestCase(3)]
        public void Cos(double x)
            => Assert.That(MathT.Cos(x), Is.EqualTo(Math.Cos(x)).Within(1e-9));

        [Test]
        [TestCase(0)]
        [TestCase(1)]
        [TestCase(-1)]
        [TestCase(3)]
        public void CosPS_ShouldBeEqualTo_Cos(double x)
            => Assert.That(MathT.CosPS(x, 200), Is.EqualTo(Math.Cos(x)).Within(1e-9));


        [Test]
        [TestCase(0)]
        [TestCase(1)]
        [TestCase(-1)]
        [TestCase(3)]
        public void Tan(double x)
            => Assert.That(MathT.Tan(x), Is.EqualTo(Math.Tan(x)).Within(1e-9));

        [Test]
        [TestCase(0)]
        [TestCase(1)]
        [TestCase(-1)]
        [TestCase(3)]
        public void TanPS_ShouldBeEqualTo_Tan(double x)
            => Assert.That(MathT.TanPS(x, 200), Is.EqualTo(Math.Tan(x)).Within(1e-9));


        [Test]
        [TestCase(0)]
        [TestCase(1)]
        [TestCase(-1)]
        [TestCase(3)]
        public void Sec(double x)
            => Assert.That(MathT.Sec(x), Is.EqualTo(1d / Math.Cos(x)).Within(1e-9));

        [Test]
        [TestCase(0)]
        [TestCase(1)]
        [TestCase(-1)]
        [TestCase(3)]
        public void SecPS_ShouldBeEqualTo_Sec(double x)
            => Assert.That(MathT.SecPS(x, 200), Is.EqualTo(1d / Math.Cos(x)).Within(1e-9));


        [Test]
        [TestCase(0)]
        [TestCase(1)]
        [TestCase(-1)]
        [TestCase(3)]
        public void Csc(double x)
            => Assert.That(MathT.Csc(x), Is.EqualTo(1d / Math.Sin(x)).Within(1e-9));

        [Test]
        [TestCase(0)]
        [TestCase(1)]
        [TestCase(-1)]
        [TestCase(3)]
        public void CscPS_ShouldBeEqualTo_Csc(double x)
            => Assert.That(MathT.CscPS(x, 200), Is.EqualTo(1d / Math.Sin(x)).Within(1e-9));


        [Test]
        [TestCase(0)]
        [TestCase(1)]
        [TestCase(-1)]
        [TestCase(3)]
        public void Cot(double x)
            => Assert.That(MathT.Cot(x), Is.EqualTo(Math.Cos(x) / Math.Sin(x)).Within(1e-9));

        [Test]
        [TestCase(0)]
        [TestCase(1)]
        [TestCase(-1)]
        [TestCase(3)]
        public void CotPS_ShouldBeEqualTo_Cot(double x)
            => Assert.That(MathT.CotPS(x, 200), Is.EqualTo(Math.Cos(x) / Math.Sin(x)).Within(1e-9));

        [Test]
        [TestCase(0)]
        [TestCase(1)]
        [TestCase(-1)]
        public void Asin(double x)
            => Assert.That(MathT.Asin(x), Is.EqualTo(Math.Asin(x)).Within(1e-9));

        [Test]
        public void Asin_WhenAbsGreaterThan1_ShouldReturnNaN()
            => Assert.That(MathT.Asin(2d), Is.EqualTo(double.NaN));

        [Test]
        [TestCase(0)]
        [TestCase(1)]
        [TestCase(-1)]
        public void Acos(double x)
            => Assert.That(MathT.Acos(x), Is.EqualTo(Math.Acos(x)).Within(1e-9));

        [Test]
        public void Acos_WhenAbsGreaterThan1_ShouldReturnNaN()
            => Assert.That(MathT.Acos(2d), Is.EqualTo(double.NaN));

        [Test]
        [TestCase(0)]
        [TestCase(1)]
        [TestCase(-1)]
        public void Atan(double x)
            => Assert.That(MathT.Atan(x), Is.EqualTo(Math.Atan(x)).Within(1e-9));

        [Test]
        [TestCase(3.1415)]
        [TestCase(-3.1415)]
        [TestCase(1)]
        public void Rad2Deg(double x)
            => Assert.That(MathT.Rad2Deg(x), Is.EqualTo(x * 180 / Math.PI).Within(1e-6));

        [Test]
        [TestCase(0)]
        [TestCase(90)]
        [TestCase(-90)]
        [TestCase(180)]
        public void Deg2Rad(double x)
            => Assert.That(MathT.Deg2Rad(x), Is.EqualTo(x * Math.PI / 180));


        [Test]
        [TestCase(0)]
        [TestCase(1)]
        [TestCase(2)]
        [TestCase(4)]
        [TestCase(8)]
        public void Factorial(double x)
        {
            double expected = 1;
            for (int i = 1; i <= x; i++)
                expected *= i;

            Assert.That(MathT.Factorial(x), Is.EqualTo(expected));
        }

        [Test]
        public void Factorial_WhenNonIntegerInput_ShouldThrow()
            => Assert.Throws<ArgumentException>(() => MathT.Factorial(1.1));

        [Test]
        [TestCase(10, 2)]
        [TestCase(4, 3)]
        [TestCase(-1, 1)]
        [TestCase(3, -2)]
        [TestCase(3, -5)]
        [TestCase(-2, 3)]
        [TestCase(-5, 3)]
        [TestCase(9, -2)]
        [TestCase(1.1, 0.2)]

        public void Modulus(double a, double b)
            => Assert.That(MathT.Modulus(a, b), Is.EqualTo(a % b).Within(1e-6));

        [Test]
        public void Modulus_WhenModZero_ShouldThrowDivideByZero()
            => Assert.Throws<DivideByZeroException>(() => MathT.Modulus(3, 0));

        [Test]
        [TestCase(1)]
        [TestCase(-1)]
        [TestCase(0)]
        [TestCase(100)]
        [TestCase(-100)]
        public void Sinh(double x)
            => Assert.That(MathT.Sinh(x), Is.EqualTo(Math.Sinh(x)).Within(1e-6));

        [Test]
        [TestCase(1)]
        [TestCase(-1)]
        [TestCase(0)]
        [TestCase(10)]
        [TestCase(-10)]

        public void SinhP_ShouldBeEqualTo_Sinh(double x)
            => Assert.That(MathT.SinhP(x), Is.EqualTo(Math.Sinh(x)).Within(1e-6));


        [Test]
        [TestCase(1)]
        [TestCase(-1)]
        [TestCase(0)]
        [TestCase(10)]
        [TestCase(-10)]
        public void SinhPS_ShouldBeEqualTo_Sinh(double x)
            => Assert.That(MathT.SinhPS(x, 200), Is.EqualTo(Math.Sinh(x)).Within(1e-6));


        [Test]
        [TestCase(1)]
        [TestCase(-1)]
        [TestCase(0)]
        [TestCase(100)]
        [TestCase(-100)]
        public void Cosh(double x)
            => Assert.That(MathT.Cosh(x), Is.EqualTo(Math.Cosh(x)).Within(1e-6));

        [Test]
        [TestCase(1)]
        [TestCase(-1)]
        [TestCase(0)]
        [TestCase(10)]
        [TestCase(-10)]

        public void CoshP_ShouldBeEqualTo_Cosh(double x)
            => Assert.That(MathT.CoshP(x), Is.EqualTo(Math.Cosh(x)).Within(1e-6));


        [Test]
        [TestCase(1)]
        [TestCase(-1)]
        [TestCase(0)]
        [TestCase(10)]
        [TestCase(-10)]
        public void CoshPS_ShouldBeEqualTo_Cosh(double x)
            => Assert.That(MathT.CoshPS(x, 200), Is.EqualTo(Math.Cosh(x)).Within(1e-6));


        [Test]
        [TestCase(1)]
        [TestCase(-1)]
        [TestCase(0)]
        [TestCase(100)]
        [TestCase(-100)]
        public void Tanh(double x)
            => Assert.That(MathT.Tanh(x), Is.EqualTo(Math.Tanh(x)).Within(1e-6));

        [Test]
        [TestCase(1)]
        [TestCase(-1)]
        [TestCase(0)]
        [TestCase(10)]
        [TestCase(-10)]

        public void TanhP_ShouldBeEqualTo_Tanh(double x)
            => Assert.That(MathT.TanhP(x), Is.EqualTo(Math.Tanh(x)).Within(1e-6));


        [Test]
        [TestCase(1)]
        [TestCase(-1)]
        [TestCase(0)]
        [TestCase(10)]
        [TestCase(-10)]
        public void TanhPS_ShouldBeEqualTo_Tanh(double x)
            => Assert.That(MathT.TanhPS(x, 200), Is.EqualTo(Math.Tanh(x)).Within(1e-6));


        [Test]
        [TestCase(1)]
        [TestCase(-1)]
        [TestCase(0)]
        [TestCase(100)]
        [TestCase(-100)]
        public void Sech(double x)
            => Assert.That(MathT.Sech(x), Is.EqualTo(1 / Math.Cosh(x)).Within(1e-6));

        [Test]
        [TestCase(1)]
        [TestCase(-1)]
        [TestCase(0)]
        [TestCase(10)]
        [TestCase(-10)]
        public void SechP_ShouldBeEqualTo_Sech(double x)
            => Assert.That(MathT.SechP(x), Is.EqualTo(1 / Math.Cosh(x)).Within(1e-6));

        [Test]
        [TestCase(1)]
        [TestCase(-1)]
        [TestCase(0)]
        [TestCase(10)]
        [TestCase(-10)]
        public void SechPS_ShouldBeEqualTo_Sech(double x)
            => Assert.That(MathT.SechPS(x, 200), Is.EqualTo(1 / Math.Cosh(x)).Within(1e-6));

        [Test]
        [TestCase(1)]
        [TestCase(-1)]
        [TestCase(100)]
        [TestCase(-100)]
        public void Csch(double x)
            => Assert.That(MathT.Csch(x), Is.EqualTo(1 / Math.Sinh(x)).Within(1e-6));

        [Test]
        [TestCase(1)]
        [TestCase(-1)]
        [TestCase(10)]
        [TestCase(-10)]
        public void CschP_ShouldBeEqualTo_Csch(double x)
            => Assert.That(MathT.CschP(x), Is.EqualTo(1 / Math.Sinh(x)).Within(1e-6));

        [Test]
        [TestCase(1)]
        [TestCase(-1)]
        [TestCase(10)]
        [TestCase(-10)]
        public void CschPS_ShouldBeEqualTo_Csch(double x)
            => Assert.That(MathT.CschPS(x, 200), Is.EqualTo(1 / Math.Sinh(x)).Within(1e-6));

        [Test]
        [TestCase(1)]
        [TestCase(-1)]
        [TestCase(100)]
        [TestCase(-100)]
        public void Coth(double x)
            => Assert.That(MathT.Coth(x), Is.EqualTo(Math.Cosh(x) / Math.Sinh(x)).Within(1e-6));

        [Test]
        [TestCase(1)]
        [TestCase(-1)]
        [TestCase(10)]
        [TestCase(-10)]
        public void CothP_ShouldBeEqualTo_Coth(double x)
            => Assert.That(MathT.CothP(x), Is.EqualTo(Math.Cosh(x) / Math.Sinh(x)).Within(1e-6));

        [Test]
        [TestCase(1)]
        [TestCase(-1)]
        [TestCase(10)]
        [TestCase(-10)]
        public void CothPS_ShouldBeEqualTo_Coth(double x)
            => Assert.That(MathT.CothPS(x, 200), Is.EqualTo(Math.Cosh(x) / Math.Sinh(x)).Within(1e-6));

        [Test]
        [TestCase(1)]
        [TestCase(-1)]
        [TestCase(10)]
        [TestCase(-10)]
        public void Asinh(double x)
            => Assert.That(MathT.Asinh(x), Is.EqualTo(Math.Asinh(x)).Within(1e-6));

        [Test]
        [TestCase(1)]
        [TestCase(-1)]
        [TestCase(10)]
        [TestCase(-10)]
        public void Acosh(double x)
            => Assert.That(MathT.Acosh(x), Is.EqualTo(Math.Acosh(x)).Within(1e-6));

        [Test]
        [TestCase(1)]
        [TestCase(-1)]
        [TestCase(10)]
        [TestCase(-10)]
        public void Atanh(double x)
            => Assert.That(MathT.Atanh(x), Is.EqualTo(Math.Atanh(x)).Within(1e-6));

        [Test]
        [TestCase(48.0, 18.0, 6.0)]
        [TestCase(56.0, 98.0, 14.0)]
        [TestCase(101.0, 103.0, 1.0)]
        [TestCase(0.0, 5.0, 5.0)]
        [TestCase(5.0, 0.0, 5.0)]
        [TestCase(0.0, 0.0, 0.0)]
        public void GCD(double a, double b, double expected)
            => Assert.That(MathT.GCD(a, b), Is.EqualTo(expected));

        [Test]
        [TestCase(48.0, 18.0, 30.0, 12.0, 6.0)]
        [TestCase(56.0, 98.0, 42.0, 14.0, 14.0)]
        [TestCase(101.0, 103.0, 107.0, 109.0, 1.0)]
        [TestCase(0.0, 5.0, 10.0, 15.0, 5.0)]
        [TestCase(5.0, 0.0, 5.0, 10.0, 5.0)]
        [TestCase(0.0, 0.0, 0.0, 0.0, 0.0)]
        public void GCD_WithParams(double a, double b, double c, double d, double expected)
            => Assert.That(MathT.GCD(a, b, c, d), Is.EqualTo(expected));
    }
}
