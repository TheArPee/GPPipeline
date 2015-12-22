namespace GPPipeline
{
    /// <summary>
	/// Represents a series of processing step to perform
	/// on a data object. Each step implements the IStep
	/// interface.
	/// </summary>
	public class PipelineManager<T>
	{
        private FilterChain<T> _filters;
        private ICoreProcessor<T> _processor;

        /// <summary>
        /// Creates and instance of the class.
        /// </summary>
        public PipelineManager()
        {
            _filters = new FilterChain<T>();
        }

        /// <summary>
        /// Creates an instance of the class using the specified ISteps.
        /// </summary>
        public PipelineManager(FilterChain<T> filters)
		{
            // ReSharper disable once ArrangeThisQualifier
			this._filters = filters;
		}

        /// <summary>
        /// Readonly property exposing the steps used by
        /// the Pipeline.
        /// </summary>
        public FilterChain<T> Filters
        {
            get { return _filters; }
        }

        /// <summary>
        /// Gets or sets the processor associated with the pipeline.
        /// </summary>
        public ICoreProcessor<T> Processor
        {
            get { return _processor; }
            set { _processor = value; }
        }

        /// <summary>
        /// Processes the data object by calling Execute on each step in the step list
        /// passing in the same data object for each call.
        /// </summary>
        /// <param name="data">The data object to process.</param>
        /// <param name="stopOnFailure">A Flag to indicate if the processing should stop if any of the
        /// steps return false.</param>
        /// <returns>True if all the processors returned true, false otherwise.</returns>
		public bool ProcessFilter(ref T data, bool stopOnFailure)
		{
            bool success = _filters.Process(ref data, stopOnFailure);
            if (!stopOnFailure && success && _processor != null)
                _processor.Execute(data);
            
            return success;
		}

        /// <summary>
        /// Processes the data object by calling Process on each processor in the processor list
        /// passing in the same data object for each call.
        /// </summary>
        /// <param name="data">The data object to process.</param>
        /// <returns>True if all the processors returned true, false otherwise.</returns>
        public bool ProcessFilter(ref T data)
        {
            return ProcessFilter(ref data, false);
        }

	}
}
