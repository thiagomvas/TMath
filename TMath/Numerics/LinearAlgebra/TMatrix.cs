using System.Numerics;
using System.Text;

namespace TMath.Numerics.LinearAlgebra
{
	public class TMatrix<T> :
		IAdditionOperators<TMatrix<T>, TMatrix<T>, TMatrix<T>>,
		ISubtractionOperators<TMatrix<T>, TMatrix<T>, TMatrix<T>>,
		IMultiplyOperators<TMatrix<T>, T, TMatrix<T>>,
		IMultiplyOperators<TMatrix<T>, TMatrix<T>, TMatrix<T>>,
		IDivisionOperators<TMatrix<T>, T, TMatrix<T>>,
		IEqualityOperators<TMatrix<T>, TMatrix<T>, bool>,
		IIncrementOperators<TMatrix<T>>,
		IDecrementOperators<TMatrix<T>>,
		IMultiplicativeIdentity<TMatrix<T>, T>,
		IUnaryNegationOperators<TMatrix<T>, TMatrix<T>>

		where T : INumber<T>
	{
		public T[,] Values;
		public T this[int i, int j]
		{
			get { return Values[i, j]; }
			set { Values[i, j] = value; }
		}

		public int NumOfElements => Rows * Columns;

		public int Rows { get; init; }
		public int Columns { get; init; }

		public bool IsSquareMatrix => Rows == Columns;

		public static T MultiplicativeIdentity => T.One;

		public TMatrix(int rows, int columns)
		{
			if(rows <= 0 || columns <= 0)
				throw new ArgumentException("Rows and columns must be greater than 0.");
			Values = new T[rows, columns];
			Rows = rows;
			Columns = columns;
		}
		public TMatrix(int rows, int columns, T[] values)
		{
			Values = new T[rows, columns];
			if (rows <= 0 || columns <= 0)
				throw new ArgumentException("Rows and columns must be greater than 0.");
			for (int i = 0; i < values.Length; i++)
			{
				Values[i / columns, i % columns] = values[i];
			}

			Rows = rows;
			Columns = columns;
		}

		public TMatrix<T> Identity()
		{
			int size = 0;
			if(!IsSquareMatrix)
				size = TFunctions.Min(Rows, Columns);
            else
				size = Rows;

			TMatrix<T> result = new(size, size);
			for(int i = 0; i < size; i++)
				result.Values[i, i] = T.One;

			return result;
        }

		public static TMatrix<T> Identity(int size)
		{
			TMatrix<T> result = new(size, size);
			for (int i = 0; i < size; i++)
				result.Values[i, i] = T.One;
			return result;
		}

		public override string ToString()
		{
			StringBuilder builder = new();
			for (int i = 0; i < Rows; i++)
			{
				for (int j = 0; j < Columns; j++)
				{
					builder.Append($"{Values[i, j]}\t");
				}
				builder.Append("\n");
			}
			return builder.ToString();
		}

		public static TMatrix<T> operator +(TMatrix<T> left, TMatrix<T> right)
		{
			if (left.Rows != right.Rows || left.Columns != right.Columns)
				throw new ArgumentException("Matrices must be of the same size.");

			TMatrix<T> result = new(left.Rows, left.Columns);

			for(int i = 0; i < left.Rows; i++)
			{
				for(int j = 0; j < left.Columns; j++)
				{
					result.Values[i, j] = left.Values[i, j] + right.Values[i, j];
				}
			}

			return result;
		}

		public static TMatrix<T> operator -(TMatrix<T> left, TMatrix<T> right)
		{
			if(left.Rows != right.Rows || left.Columns != right.Columns)
				throw new ArgumentException("Matrices must be of the same size.");

			TMatrix<T> result = new(left.Rows, left.Columns);

			for (int i = 0; i < left.Rows; i++)
			{
				for (int j = 0; j < left.Columns; j++)
				{
					result.Values[i, j] = left.Values[i, j] - right.Values[i, j];
				}
			}

			return result;
		}

		public static TMatrix<T> operator *(TMatrix<T> left, T right)
		{
			TMatrix<T> result = new(left.Rows, left.Columns);

			for (int i = 0; i < left.Rows; i++)
			{
				for (int j = 0; j < left.Columns; j++)
				{
					result.Values[i, j] = left.Values[i, j] * right;
				}
			}

			return result;
		}

		public static TMatrix<T> operator /(TMatrix<T> left, T right)
		{
			TMatrix<T> result = new(left.Rows, left.Columns);

			for (int i = 0; i < left.Rows; i++)
			{
				for (int j = 0; j < left.Columns; j++)
				{
					result.Values[i, j] = left.Values[i, j] / right;
				}
			}

			return result;
		}

		public static bool operator ==(TMatrix<T>? left, TMatrix<T>? right)
		{
			if(left.Rows != right.Rows || left.Columns != right.Columns)
				return false;

			for(int i = 0; i < left.Rows; i++)
			{
				for(int j = 0; j < left.Columns; j++)
				{
					if (left.Values[i, j] != right.Values[i, j])
						return false;
				}
			}
			return true; 
		}

		public static bool operator !=(TMatrix<T>? left, TMatrix<T>? right)
		{
			if (left.Rows != right.Rows || left.Columns != right.Columns)
				return true;

			for (int i = 0; i < left.Rows; i++)
			{
				for (int j = 0; j < left.Columns; j++)
				{
					if (left.Values[i, j] != right.Values[i, j])
						return true;
				}
			}
			return false;
		}

		public static TMatrix<T> operator ++(TMatrix<T> matrix)
		{
			TMatrix<T> result = new(matrix.Rows, matrix.Columns);

			for (int i = 0; i < matrix.Rows; i++)
			{
				for (int j = 0; j < matrix.Columns; j++)
				{
					result.Values[i, j] = matrix.Values[i, j] + T.One;
				}
			}
			return result;
			
		}

		public static TMatrix<T> operator --(TMatrix<T> matrix)
		{
			TMatrix<T> result = new(matrix.Rows, matrix.Columns);

			for (int i = 0; i < matrix.Rows; i++)
			{
				for (int j = 0; j < matrix.Columns; j++)
				{
					result.Values[i, j] = matrix.Values[i, j] - T.One;
				}
			}

			return result;
		}

		public static TMatrix<T> operator -(TMatrix<T> matrix)
		{
			TMatrix<T> result = new(matrix.Rows, matrix.Columns);

			for (int i = 0; i < matrix.Rows; i++)
			{
				for (int j = 0; j < matrix.Columns; j++)
				{
					result.Values[i, j] = -matrix.Values[i, j];
				}
			}

			return result;
		}

		public static TMatrix<T> operator *(TMatrix<T> left, TMatrix<T> right)
		{

			if (left.Columns != right.Rows)
				throw new ArgumentException("The number of columns in the left matrix must be equal to the number of rows in the right matrix.");

			TMatrix<T> result = new(left.Rows, right.Columns);

			for (int i = 0; i < left.Rows; i++)
			{
				for (int j = 0; j < right.Columns; j++)
				{
					for (int k = 0; k < left.Columns; k++)
					{
						result.Values[i, j] += left.Values[i, k] * right.Values[k, j];
					}
				}
			}

			return result;
		}
	}
}
