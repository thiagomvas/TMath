using System.Numerics;
using System.Text;

namespace TMath.Numerics.LinearAlgebra
{
	/// <summary>
	/// Represents a matrix with generic elements.
	/// </summary>
	/// <typeparam name="T">The type of elements in the matrix.</typeparam>
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

		/// <summary>
		/// Gets the number of elements in this matrix.
		/// </summary>
		public int NumOfElements => Rows * Columns;

		/// <summary>
		/// Gets the number of rows and columns in the matrix.
		/// </summary>
		public int Rows { get; init; }

		/// <summary>
		/// Gets the number of columns in the matrix.
		/// </summary>
		public int Columns { get; init; }

		/// <summary>
		/// Checks whether the matrix is a square matrix or not.
		/// </summary>
		public bool IsSquareMatrix => Rows == Columns;

		/// <inhericdoc/>
		public static T MultiplicativeIdentity => T.One;

		/// <summary>
		/// Creates a new instance of <see cref="TMatrix{T}"/> with the specified number of rows and columns.
		/// </summary>
		/// <param name="rows">The number of rows in the matrix</param>
		/// <param name="columns">The number of columns in the matrix</param>
		/// <exception cref="ArgumentException">If either row or column size is less or equal to 0</exception>
		public TMatrix(int rows, int columns)
		{
			if(rows <= 0 || columns <= 0)
				throw new ArgumentException("Rows and columns must be greater than 0.");
			Values = new T[rows, columns];
			Rows = rows;
			Columns = columns;
		}
		/// <summary>
		/// Creates a new instance of <see cref="TMatrix{T}"/> with the specified number of rows and columns.
		/// </summary>
		/// <param name="rows">The number of rows in the matrix</param>
		/// <param name="columns">The number of columns in the matrix</param>
		/// <param name="values">The values to be assigned to the matrix</param>
		/// <exception cref="ArgumentException">If either row or column size is less or equal to 0</exception>
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

		public TMatrix(TMatrix<T> target)
		{
			Rows = target.Rows;
			Columns = target.Columns;
			Values = new T[Rows, Columns];
			for (int i = 0; i < target.Rows; i++)
			{
				for (int j = 0; j < target.Columns; j++)
				{
					Values[i, j] = target.Values[i, j];
				}
			}
		}

		/// <summary>
		/// Creates an identity matrix with a size of this matrix.
		/// </summary>
		/// <returns>The identity matrix with rows and columns equal to the smallest size between this matrix's <see cref="Rows"/> and <see cref="Columns"/></returns>
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

		public TMatrix<T> Transpose()
		{
			TMatrix<T> result = new(Columns, Rows);
			for(int i = 0; i < Rows; i++)
			{
				for(int j = 0; j < Columns; j++)
				{
					result.Values[j, i] = Values[i, j];
				}
			}
			return result;
		}

		/// <summary>
		/// Creates a submatrix of this matrix by removing the specified row and column.
		/// </summary>
		/// <param name="rowToRemove">The row to remove</param>
		/// <param name="colToRemove">The column to remove</param>
		/// <returns>A matrix with dimensions reduced by one by removing a column and row</returns>
		public TMatrix<T> Submatrix(int rowToRemove, int colToRemove)
		{
			int size = this.Rows;
			TMatrix<T> submatrix = new TMatrix<T>(size - 1, size - 1);

			int subRow = 0;
			for (int row = 0; row < size; row++)
			{
				if (row == rowToRemove)
					continue;

				int subCol = 0;
				for (int col = 0; col < size; col++)
				{
					if (col == colToRemove)
						continue;

					submatrix[subRow, subCol] = this[row, col];
					subCol++;
				}
				subRow++;
			}

			return submatrix;
		}

		public TMatrix<T> SwapRows(int line1, int line2)
		{
			TMatrix<T> result = new(Rows, Columns);
			for(int i = 0; i < Rows; i++)
			{
				for(int j = 0; j < Columns; j++)
				{

					result.Values[i, j] = Values[i, j];
				}
			}

			for(int i = 0; i < Rows; i++)
			{
				T temp = result[line1, i];
				result[line1, i] = result[line2, i];
				result[line2, i] = temp;
			}
			return result;
		}

		/// <summary>
		/// Creates an identity matrix with the specified size.
		/// </summary>
		/// <param name="size">The size <b>n</b> of an identity matrix with dimensions n x n</param>
		/// <returns>An identity matrix of size n x n</returns>
		public static TMatrix<T> Identity(int size)
		{
			TMatrix<T> result = new(size, size);
			for (int i = 0; i < size; i++)
				result.Values[i, i] = T.One;
			return result;
		}


		/// <summary>
		/// Converts the matrix to a formatted text string.
		/// </summary>
		/// <returns></returns>
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

		/// <summary>
		/// Creates a new matrix with  all the values in the matrix rounded to a specified number of decimal places
		/// </summary>
		/// <param name="decimals">The amount of decimals in each value</param>
		/// <returns>
		/// A matrix with all the values rounded to the specified number of decimal places.
		/// /returns>
		public TMatrix<T> RoundValues(int decimals = 5)
		{
			TMatrix<T> result = new(this);
			for (int i = 0; i < Rows; i++)
			{
				for (int j = 0; j < Columns; j++)
					result.Values[i, j] = TFunctions.Round(Values[i, j], decimals);
			}
			return result;
		}

		/// <summary>
		/// Converts the matrix to a LaTeX string.
		/// </summary>
		/// <param name="matrixtype">The type of latex matrix (pmatrix, bmatrix, vmatrix, etc) </param>
		/// <returns>A string representing this matrix in LaTeX form</returns>
		public string ToLaTeX(string matrixtype = "pmatrix")
		{
			StringBuilder sb = new();
			var matrix = this;
			sb.Append($@"\begin{{{matrixtype}}}");
			for (int i = 0; i < Rows; i++)
			{
				for (int j = 0; j < Columns - 1; j++)
				{
					sb.Append($"{matrix[i, j]} &");
				}
				sb.Append($@"{matrix[i, Columns - 1]} \\");
			}
			sb.Append($@"\end{{{matrixtype}}}");
			return sb.ToString();
		}

		/// <summary>
		/// Adds two matrices together.
		/// </summary>
		/// <param name="left">The left matrix</param>
		/// <param name="right">The right matrix</param>
		/// <returns>The matrix addition operation of <paramref name="left"/> + <paramref name="right"/></returns>
		/// <exception cref="ArgumentException">If the matrices are not of the same size</exception>
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

		/// <summary>
		/// Subtracts two matrices.
		/// </summary>
		/// <param name="left">The left matrix</param>
		/// <param name="right">The right matrix</param>
		/// <returns>The matrix addition operation of <paramref name="left"/> - <paramref name="right"/></returns>
		/// <exception cref="ArgumentException">If the matrices are not of the same size</exception>
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

		/// <summary>
		/// Multiplies a matrix by a scalar value.
		/// </summary>
		/// <param name="left">The matrix to multiply</param>
		/// <param name="right">The scalar to multiply the matrix</param>
		/// <returns>A matrix with all the elements of <paramref name="left"/> multiplied by <paramref name="right"/> </returns>
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
		/// <summary>
		/// Multiplies a matrix by a scalar value.
		/// </summary>
		/// <param name="right">The matrix to multiply</param>
		/// <param name="left">The scalar to multiply the matrix</param>
		/// <returns>A matrix with all the elements of <paramref name="right"/> multiplied by <paramref name="left"/> </returns>
		public static TMatrix<T> operator *(T left, TMatrix<T> right)
		{
			TMatrix<T> result = new(right.Rows, right.Columns);

			for (int i = 0; i < right.Rows; i++)
			{
				for (int j = 0; j < right.Columns; j++)
				{
					result.Values[i, j] = right.Values[i, j] * left;
				}
			}

			return result;
		}

		/// <summary>
		/// Divides a matrix by a scalar value.
		/// </summary>
		/// <param name="left">The matrix to divide</param>
		/// <param name="right">The scalar to divide the matrix</param>
		/// <returns>A matrix with all the elements of <paramref name="left"/> divided by <paramref name="right"/> </returns>
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

		/// <summary>
		/// Compares two matrices' sizes and values to see if they are equal
		/// </summary>
		/// <returns>If both matrices have the same sizes and values, in the same order</returns>
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

		/// <summary>
		/// Compares two matrices' sizes and values to see if they are different
		/// </summary>
		/// <returns>If both matrices have the different sizes or values</returns>
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

		/// <summary>
		/// Increments all elements of a matrix by 1.
		/// </summary>
		/// <param name="matrix">The matrix to increment</param>
		/// <returns>The original matrix with all the values added by 1</returns>
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

		/// <summary>
		/// Decrements all elements of a matrix by 1.
		/// </summary>
		/// <param name="matrix">The matrix to decrement</param>
		/// <returns>The original matrix with all the values subtracted 1</returns>
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

		/// <summary>
		/// Negates all values of this matrix.
		/// </summary>
		/// <param name="matrix">The matrix to negate all values</param>
		/// <returns>A matrix where all the values have their sign negated</returns>
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

		/// <summary>
		/// Multiplies two matrices together.
		/// </summary>
		/// <returns>The result of the matrix multiplication of <paramref name="left"/> * <paramref name="right"/></returns>
		/// <exception cref="ArgumentException">If the number of columns in the left matrix is different than the number of rows in the right matrix</exception>
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
