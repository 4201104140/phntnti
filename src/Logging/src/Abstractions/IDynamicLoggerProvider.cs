using Microsoft.Extensions.Logging;
using System.Collections.Generic;

namespace PhnTnTi.Extensions.Logging
{
    public interface IDynamicLoggerProvider : ILoggerProvider
    {
        /// <summary>
        /// Get a list of all known namespaces and loggers
        /// </summary>
        /// <returns>A collection of all known namespaces and loggers with their configurations</returns>
        ICollection<ILoggerConfiguration> GetLoggerConfigurations();

        /// <summary>
        /// Set the logging threshold for a logger
        /// </summary>
        /// <param name="category">A namespace or fully qualified logger name to adjust</param>
        /// <param name="level">The minimum level that should be logged</param>
        void SetLogLevel(string category, LogLevel? level);
    }
}
