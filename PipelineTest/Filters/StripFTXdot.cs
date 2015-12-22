﻿using System;
using GPPipeline;

namespace PipelineTest.Filters
{
    /// <summary>
    /// A simple IPipelineStep for testing purposes.
    /// </summary>

    class StripFTXdot : IFilter<string>
    {
        public bool Process(ref string data)
        {
            Console.WriteLine(data);
            data = data + " FTX has been dedotted.";
            return true;
        }
    }
}
