using System.Collections.Generic;

namespace GPPipeline
{
    /// <summary>
    /// A collection of IFilters.
    /// This is a TypeDef for a List.
    /// </summary>
    public class FilterChain<T> : List<IFilter<T>>
    {
        /// <summary>
        /// Processes the data object by calling Process on each step in the step list
        /// passing in the same data object for each call.
        /// </summary>
        /// <param name="data">The data object to process.</param>
        /// <param name="stopOnFailure">A Flag to indicate if the processing should stop if any of the
        /// steps return false.</param>
        /// <returns>True if all the processors returned true, false otherwise.</returns>
        internal bool Process(ref T data, bool stopOnFailure)
        {
            var success = true;
            foreach (var processor in this)
            {
                if (!processor.Process(ref data))
                    success = false;

                if (stopOnFailure && !success)
                    break;
            }
            return success;
        }

        /// <summary>
        /// Processes the data object by calling Process on each processor in the processor list
        /// passing in the same data object for each call.
        /// </summary>
        /// <param name="data">The data object to process.</param>
        /// <returns>True if all the processors returned true, false otherwise.</returns>
        internal bool Process(ref T data)
        {
            return Process(ref data, false);
        }
    }
}
