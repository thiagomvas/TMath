namespace TMath.Numerics.Interfaces
{
    /// <summary>
    /// Represents a vector of type T.
    /// </summary>
    /// <typeparam name="T">The type of the vector elements.</typeparam>
    public interface ITVector<T>
	{
        /// <summary>
        /// Generates a vector of size 'size' with all elements set to one.
        /// </summary>
        /// <param name="size">The size of the vector.</param>
        /// <returns>A vector of size 'size' with all elements set to one.</returns>
        static abstract T One(int size);

        /// <summary>
        /// Generates a vector of size 'size' with all elements set to zero.
        /// </summary>
        /// <param name="size">The size of the vector.</param>
        /// <returns>A vector of size 'size' with all elements set to zero.</returns>
        static abstract T Zero(int size);
	}
}
