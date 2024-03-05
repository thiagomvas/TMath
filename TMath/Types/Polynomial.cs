using System.Numerics;
using System.Text;
using TMath.Numerics.Core;

namespace TMath.Types
{
	public partial class Polynomial<T> : INumber<Polynomial<T>>
		where T : INumber<T>
	{

		// From x^0 to x^n
		public T[] Coefficients { get; private set; }
		public string Variable { get; set; } = "x";

		public int Degree => Coefficients.Length - 1;

		#region Constructors
		public Polynomial(IEnumerable<T> coefficients)
		{
			Coefficients = coefficients.ToArray();
		}

		public Polynomial(params T[] coefficients)
		{
			Coefficients = coefficients;
		}
		#endregion

		public Polynomial<T> GetIntegral() => GetIntegral(T.Zero);
		public Polynomial<T> GetIntegral(T integralConstant)
		{
			var integralCoefficients = new T[Coefficients.Length + 1];
			integralCoefficients[0] = integralConstant;

			for (int i = 0; i < Coefficients.Length; i++)
			{
				integralCoefficients[i + 1] = Coefficients[i] / (TFunctions.IntToT<T>(i) + T.One);
			}
			return new Polynomial<T>(integralCoefficients);
		}

		public Polynomial<T> GetDerivative(int order)
		{
			Polynomial<T> result = this;
			for (int i = 0; i < order; i++)
			{
				result = result.GetDerivative();
			}
			return result;
		}

		public Polynomial<T> GetDerivative()
		{
			if (Degree <= 0) return Zero;
			var derivativeCoefficients = new T[Coefficients.Length - 1];
			for (int i = 1; i < Coefficients.Length; i++)
			{
				derivativeCoefficients[i - 1] = Coefficients[i] * TFunctions.IntToT<T>(i);
			}
			return new Polynomial<T>(derivativeCoefficients);
		}

		public Func<T, T> AsFunc() => EvaluateAt;
		public T EvaluateAt(T x)
		{
			T result = Coefficients[0];
			for (int i = 1; i < Coefficients.Length; i++)
			{
				result += Coefficients[i] * x;
				x *= x;
			}
			return result;
		}

		public IEnumerable<T> FindRealRoots()
		{
			throw new NotImplementedException();
		}

		public static Polynomial<T> One => new Polynomial<T>(T.One);

		public static int Radix => 2;

		public static Polynomial<T> Zero => new Polynomial<T>(T.Zero);

		public static Polynomial<T> AdditiveIdentity => Zero;

		public static Polynomial<T> MultiplicativeIdentity => One;

		public static Polynomial<T> Abs(Polynomial<T> value) => new(value.Coefficients.Select(TFunctions.Abs).ToArray());

		public int CompareTo(object? obj)
		{
			if(obj == null)
				return 1;

			if (obj is Polynomial<T> otherPolynomial)
			{
				return CompareTo(otherPolynomial);
			}

			throw new ArgumentException("Object is not a Polynomial<T>");
		}

		public int CompareTo(Polynomial<T>? other)
		{
			if (other == null)
			{
				return 1; // If the other polynomial is null, this polynomial is considered greater.
			}

			return Degree.CompareTo(other.Degree);
		}

		public bool Equals(Polynomial<T>? other)
		{
			if (other == null)
				return false;

			if (ReferenceEquals(this, other))
				return true;

			if (Degree != other.Degree)
				return false;

			return Helpers.EnumerableAreEqual(Coefficients, other.Coefficients);
		}

		public string ToString(string? format, IFormatProvider? formatProvider)
		{
			if(Coefficients.Length == 0)
				return "0";

			StringBuilder sb = new();

            for (int i = Coefficients.Length - 1; i >= 0; i--)
            {
				if(i > 1)
					sb.Append($"{TFunctions.Abs(Coefficients[i])}*{Variable}^{i}");
				else if(i == 1)
					sb.Append($"{TFunctions.Abs(Coefficients[i])}*{Variable}");
				else
					sb.Append($"{TFunctions.Abs(Coefficients[i])}");

				if(i > 0)
				{
					if (Coefficients[i - 1] < T.Zero)
						sb.Append(" - ");
					else
						sb.Append(" + "); 
				}
            }
			return sb.ToString();
        }

		public bool TryFormat(Span<char> destination, out int charsWritten, ReadOnlySpan<char> format, IFormatProvider? provider)
		{
			throw new NotImplementedException();
		}

	}
}
