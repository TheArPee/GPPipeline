namespace GPPipeline
{
    /// <summary>
    /// Interface for being included as a filter in a FilterPipeline.
    /// The Type specifier is the type of data that the filter can handle.
    /// </summary>
    public interface IFilter<T>
    {
        /// <summary>
        /// Perform the necessary processing on the data provided.
        /// </summary>
        /// <param name="data">The data to process.</param>
        /// <returns>An instance of the same type as the data passed in.</returns>
        bool Process(ref T data);
    }
}
