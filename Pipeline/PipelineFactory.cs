using System;
using System.Linq;

namespace GPPipeline
{
    /// <summary>
    /// Provides a factory for creating Pipeline objects.
    /// </summary>
    public static class PipelineFactory
    {
        /// <summary>
        /// Creates a Pipeline based on the data in the configuration file.
        /// </summary>
        /// <typeparam name="T">The type of the data the pipeline will handle.</typeparam>
        /// <param name="sectionName">The name of the configuration section containing the configuration data.</param>
        /// <returns>A Pipeline that handles the specified type.</returns>
        public static PipelineManager<T> CreateFromConfiguration<T>(string sectionName)
        {
            var processors = new FilterChain<T>();
            var section = (PipelineConfigurationSection)System.Configuration.ConfigurationManager.GetSection(sectionName);
            processors.AddRange(from PipelineHandlerConfigurationElement element in section.Processors select (IFilter<T>) ObjectFactory.Create(element.HandlerType));
            return new PipelineManager<T>(processors);
        }
                
        /// <summary>
        /// Internal helper class to instantiate objects from a string type name.
        /// </summary>
        private static class ObjectFactory
        {
            /// <summary>
            /// Creates an object form the specified type name.
            /// </summary>
            /// <param name="typeName">The name of the type to create.</param>
            /// <returns>An instance of the type specified.</returns>
            public static object Create(string typeName)
            {
                var t = Type.GetType(typeName);
                // ReSharper disable once AssignNullToNotNullAttribute
                return Activator.CreateInstance(t);
            }
        }
    }
}
