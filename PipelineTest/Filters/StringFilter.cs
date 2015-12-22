using System;
using GPPipeline;

namespace PipelineTest.Filters
{
    /// <summary>
    /// A simple IPipelineStep for testing purposes.
    /// </summary>
    class StringFilter : IFilter<string>
    {
        public bool Process(ref string data)
        {
            Console.WriteLine(data);
            data = data + " has been processed.";
            return true;
        }
    }
}
