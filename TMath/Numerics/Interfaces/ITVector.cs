using TMath.Numerics.LinearAlgebra;

namespace TMath.Numerics.Interfaces
{
	public interface ITVector<T>
	{
		public ITVector<T> One { get; }
		public ITVector<T> Zero { get; }
	}
}
