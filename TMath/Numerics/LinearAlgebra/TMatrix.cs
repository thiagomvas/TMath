using System.Numerics;
using System.Text;

namespace TMath.Numerics.LinearAlgebra
{
	public class TMatrix<T>
		where T : INumber<T>
	{
		public T[,] Values;
		public int Rows { get; init; }
		public int Columns { get; init; }

		public bool IsSquareMatrix => Rows == Columns;

		public TMatrix(int rows, int columns)
		{
			Values = new T[rows, columns];
			Rows = rows;
			Columns = columns;
		}
		public TMatrix(int rows, int columns, T[] values)
		{
			Values = new T[rows, columns];
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
	}
}
