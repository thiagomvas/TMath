using System.Collections;
using System.Globalization;
using System.Numerics;
using TMath.Numerics.Interfaces;

namespace TMath.Numerics.LinearAlgebra
{

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
		public int Size => values.Length;
		private int position = -1;

		public T this[int i]
		{
			get { return values[i]; }
			set { values[i] = value; }
		}

		#region Constructors

		public TVector(int size)
		{
			values = new T[size];
		}

		public TVector(T[] values)
		{
			this.values = values;
		}

		#endregion

		public static TVector<T> AdditiveIdentity => new(0);

		public static T MultiplicativeIdentity => T.One;

		public T Length => TFunctions.Sqrt<T,T>(values.Select(x => x * x).Aggregate((x, y) => x + y));

		public static TVector<T> HighestDimension(TVector<T> left, TVector<T> right)
		{
			return left.Size >= right.Size ? left : right;
		}
		public static TVector<T> LowestDimension(TVector<T> left, TVector<T> right)
		{
			return left.Size < right.Size ? left : right;
		}



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

		public static TVector<T> operator ++(TVector<T> value)
		{
			return value + One(value.Size);
		}

		public static TVector<T> operator --(TVector<T> value)
		{
			return value - One(value.Size);
		}

		public static bool operator ==(TVector<T>? left, TVector<T>? right)
		{
			if(left.Size != right.Size)
			{
				return false;
			}
			return left.SequenceEqual(right);
		}

		public static bool operator !=(TVector<T>? left, TVector<T>? right)
		{
			if (left.Size != right.Size)
			{
				return true;
			}
			return !left.values.SequenceEqual(right.values);
		}

		public static bool operator <(TVector<T> left, TVector<T> right) => left.Length < right.Length;

		public static bool operator >(TVector<T> left, TVector<T> right) => left.Length > right.Length;

		public static bool operator <=(TVector<T> left, TVector<T> right) => left.Length <= right.Length;

		public static bool operator >=(TVector<T> left, TVector<T> right) => left.Length >= right.Length;

		public static TVector<T> operator /(TVector<T> left, T right)
		{
			T[] val = left.values.Select(x => x / right).ToArray();
			return new TVector<T>(val);
		}

		public static TVector<T> operator *(TVector<T> left, T right)
		{
			T[] val = left.values.Select(x => x * right).ToArray();
			return new TVector<T>(val);
		}

		public static TVector<T> operator *(T left, TVector<T> right)
		{
			T[] val = right.values.Select(x => x * left).ToArray();
			return new TVector<T>(val);
		}

		public static TVector<T> operator -(TVector<T> value)
		{
			T[] val = value.values.Select(x => -x).ToArray();
			return new TVector<T>(val);
		}

		public override string ToString()
		{
			return $"<{string.Join(", ", values.Select(x => x.ToString("", CultureInfo.InvariantCulture)))}>";
		}

		public static TVector<T> One(int size)
		{
			T[] val = new T[size].Select(x => T.One).ToArray();
			return new TVector<T>(val);
		}

		public static TVector<T> Zero(int size)
		{
			return new TVector<T>(new T[size]);
		}

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
