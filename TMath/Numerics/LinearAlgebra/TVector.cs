using System.Collections;
using System.Globalization;
using System.Numerics;
using TMath.Numerics.Interfaces;

namespace TMath.Numerics.LinearAlgebra
{
	/// <summary>
	/// Represents a generic vector in N-dimensional space with arithmetic and comparison operations.
	/// </summary>
	/// <typeparam name="T">The type of elements in the vector, constrained to <see cref="INumber{T}"/> and <see cref="new"/>.</typeparam>
	public class TVector<T>
		: IAdditionOperators<TVector<T>, TVector<T>, TVector<T>>,
		ISubtractionOperators<TVector<T>, TVector<T>, TVector<T>>,
		IMultiplyOperators<TVector<T>, T, TVector<T>>,
		IDivisionOperators<TVector<T>, T, TVector<T>>,
		IEqualityOperators<TVector<T>, TVector<T>, bool>,
		IComparisonOperators<TVector<T>, TVector<T>, bool>,
		IIncrementOperators<TVector<T>>,
		IDecrementOperators<TVector<T>>,
		IAdditiveIdentity<TVector<T>, TVector<T>>,
		IMultiplicativeIdentity<TVector<T>, T>,
		IUnaryNegationOperators<TVector<T>, TVector<T>>,
		ITVector<TVector<T>>,
		IEnumerable<T>
		where T : INumber<T>, new()
	{

		private T[] values;
		/// <summary>
		/// The number of elements in this vector.
		/// </summary>
		public int Size => values.Length;

		public T this[int i]
		{
			get { return values[i]; }
			set { values[i] = value; }
		}

		#region Constructors

		public TVector(int size)
		{
			if(size <= 0) throw new ArgumentException("Size must be greater than 0", nameof(size));
			values = new T[size];
		}

		public TVector(T[] values)
		{
			this.values = values;
		}

		#endregion

		/// <inheritdoc/>
		public static TVector<T> AdditiveIdentity => new(0);

		/// <inheritdoc/>
		public static T MultiplicativeIdentity => T.One;

		/// <summary>
		/// Calculates the length of this vector.
		/// </summary>
		/// <remarks>
		/// The output of this is the square root of the sum of the squares of the elements of this vector. For example, the length of <c>(1, 1)</c> is <c>sqrt(1^2 + 1^2) = sqrt(2)</c>.
		/// <br/>
		/// For the count of elements in this vector, see <see cref="Size"/>.
		/// </remarks>
		public T Length => TFunctions.Sqrt<T,T>(values.Select(x => x * x).Aggregate((x, y) => x + y));

		/// <summary>
		/// Compares the length of two vectors and returns the one with the most elements.
		/// </summary>
		/// <returns>The vector with the biggest size</returns>
		public static TVector<T> HighestDimension(TVector<T> left, TVector<T> right)
		{
			return left.Size >= right.Size ? left : right;
		}
		/// <summary>
		/// Compares the length of two vectors and returns the one with the least elements.
		/// </summary>
		/// <returns>The vector with the smallest size</returns>
		public static TVector<T> LowestDimension(TVector<T> left, TVector<T> right)
		{
			return left.Size < right.Size ? left : right;
		}


		/// <summary>
		/// Adds two vectors together.
		/// </summary>
		/// <returns>A vector with its respective members added</returns>
		/// <remarks>
		/// For different sized vectors, the result will be the size of the largest vector.
		/// </remarks>
		public static TVector<T> operator +(TVector<T> left, TVector<T> right)
		{
			var largest = HighestDimension(left, right);
			var lowest = LowestDimension(left, right);
			TVector<T> result = new(largest.Size);
			for(int i = 0; i < lowest.values.Length; i++)
			{
				result[i] = largest[i] + lowest[i];
			}

			return result; 
		}

		/// <summary>
		/// Subtracts two vectors together.
		/// </summary>
		/// <returns>A vector with its respective members subtracted</returns>
		/// <remarks>
		/// For different sized vectors, the result will be the size of the largest vector.
		/// </remarks>
		public static TVector<T> operator -(TVector<T> left, TVector<T> right)
		{

			var largest = HighestDimension(left, right);
			var lowest = LowestDimension(left, right);
			TVector<T> result = new(largest.Size);
			for (int i = 0; i < lowest.values.Length; i++)
			{
				result[i] = largest[i] - lowest[i];
			}

			return result;
		}

		/// <summary>
		/// Increments all the elements of this vector by 1.
		/// </summary>
		public static TVector<T> operator ++(TVector<T> value)
		{
			return value + One(value.Size);
		}

		/// <summary>
		/// Decrements all the elements of this vector by 1.
		/// </summary>
		public static TVector<T> operator --(TVector<T> value)
		{
			return value - One(value.Size);
		}

		/// <summary>
		/// Compares two vectors to see if they are equal size and have the same values.
		/// </summary>
		/// <returns>If the two vectors are equal</returns>
		public static bool operator ==(TVector<T>? left, TVector<T>? right)
		{
			if(left.Size != right.Size)
			{
				return false;
			}
			return left.SequenceEqual(right);
		}

		/// <summary>
		/// Compares two vectors to see if they have different sizes or have different values.
		/// </summary>
		/// <returns>If the two vectors are equal</returns>
		public static bool operator !=(TVector<T>? left, TVector<T>? right)
		{
			if (left.Size != right.Size)
			{
				return true;
			}
			return !left.values.SequenceEqual(right.values);
		}

		/// <summary>
		/// Compares the length of two vectors.
		/// </summary>
		/// <returns>If <paramref name="left"/> has a smaller length than <paramref name="right"/></returns>
		public static bool operator <(TVector<T> left, TVector<T> right) => left.Length < right.Length;

		/// <summary>
		/// Compares the length of two vectors.
		/// </summary>
		/// <returns>If <paramref name="left"/> has a bigger length than <paramref name="right"/></returns>
		public static bool operator >(TVector<T> left, TVector<T> right) => left.Length > right.Length;

		/// <summary>
		/// Compares the length of two vectors.
		/// </summary>
		/// <returns>If <paramref name="left"/> has a length smaller or equal to <paramref name="right"/></returns>
		public static bool operator <=(TVector<T> left, TVector<T> right) => left.Length <= right.Length;

		/// <summary>
		/// Compares the length of two vectors.
		/// </summary>
		/// <returns>If <paramref name="left"/> has a length bigger or equal to <paramref name="right"/></returns>
		public static bool operator >=(TVector<T> left, TVector<T> right) => left.Length >= right.Length;

		/// <summary>
		/// Divides a vector by a scalar value.
		/// </summary>
		/// <returns>A vector with all of the elements in <paramref name="left"/> divided by <paramref name="right"/></returns>
		public static TVector<T> operator /(TVector<T> left, T right)
		{
			T[] val = left.values.Select(x => x / right).ToArray();
			return new TVector<T>(val);
		}

		/// <summary>
		/// Multiplies a vector by a scalar value.
		/// </summary>
		/// <returns>A vector with all of the elements in <paramref name="left"/> multiplied by <paramref name="right"/></returns>

		public static TVector<T> operator *(TVector<T> left, T right)
		{
			T[] val = left.values.Select(x => x * right).ToArray();
			return new TVector<T>(val);
		}

		/// <summary>
		/// Multiplies a vector by a scalar value.
		/// </summary>
		/// <returns>A vector with all of the elements in <paramref name="right"/> multiplied by <paramref name="left"/></returns>
		public static TVector<T> operator *(T left, TVector<T> right)
		{
			T[] val = right.values.Select(x => x * left).ToArray();
			return new TVector<T>(val);
		}

		/// <summary>
		/// Negates all of the elements in this vector.
		/// </summary>
		/// <param name="value"></param>
		/// <returns>
		/// A vector with all of the elements in <paramref name="value"/> negated.
		/// </returns>
		public static TVector<T> operator -(TVector<T> value)
		{
			T[] val = value.values.Select(x => -x).ToArray();
			return new TVector<T>(val);
		}

		public override string ToString()
		{
			return $"<{string.Join(", ", values.Select(x => x.ToString("", CultureInfo.InvariantCulture)))}>";
		}

		/// <summary>
		/// Creates a vector with all of the elements equal to 1.
		/// </summary>
		/// <param name="size">The size of the vector</param>
		public static TVector<T> One(int size)
		{
			T[] val = new T[size].Select(x => T.One).ToArray();
			return new TVector<T>(val);
		}

		/// <summary>
		/// Creates a vector with all of the elements equal to 1.
		/// </summary>
		/// <param name="size">The size of the vector</param>
		public static TVector<T> Zero(int size)
		{
			return new TVector<T>(new T[size]);
		}

		/// <summary>
		/// Gets the enumerator of this vector.
		/// </summary>
		public IEnumerator<T> GetEnumerator()
		{
			return new VectorEnumerator<T>(values);
		}

		IEnumerator IEnumerable.GetEnumerator()
		{
			return GetEnumerator();
		}
		private class VectorEnumerator<T> : IEnumerator<T>
		{
			private bool disposedValue;
			int position = -1;
			public T[] _values;

			public VectorEnumerator(T[] list)
			{
				_values = list;
			}

			public T Current
			{
				get
				{
					try
					{
						return _values[position];
					}
					catch(IndexOutOfRangeException)
					{
						throw new InvalidOperationException();
					}
				}
			}

			object IEnumerator.Current
			{
				get
				{
					return Current;
				}
			}

			public bool MoveNext()
			{
				position++;
				return position < _values.Length;
			}

			public void Reset()
			{
				position = -1;
			}

			protected virtual void Dispose(bool disposing)
			{
				if (!disposedValue)
				{
					if (disposing)
					{
						// TODO: dispose managed state (managed objects)
					}

					// TODO: free unmanaged resources (unmanaged objects) and override finalizer
					// TODO: set large fields to null
					disposedValue = true;
				}
			}

			// // TODO: override finalizer only if 'Dispose(bool disposing)' has code to free unmanaged resources
			// ~VectorEnumerator()
			// {
			//     // Do not change this code. Put cleanup code in 'Dispose(bool disposing)' method
			//     Dispose(disposing: false);
			// }

			public void Dispose()
			{
				// Do not change this code. Put cleanup code in 'Dispose(bool disposing)' method
				Dispose(disposing: true);
				GC.SuppressFinalize(this);
			}
		}
	}
}
