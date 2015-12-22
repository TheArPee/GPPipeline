namespace GPPipeline
{
    /// <summary>
    /// An interface representing the actually processing target
    /// to be called after all the filters have been called.
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public interface ICoreProcessor<T>
    {
        /// <summary>
        /// Executes the processor on the data provided.
        /// </summary>
        /// <param name="data">The data to use for the execution.</param>
        void Execute(T data);
    }
}
