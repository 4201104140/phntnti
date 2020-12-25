using Microsoft.Extensions.Logging;

namespace PhnTnTi.Extensions.Logging
{
    public interface ILoggerConfiguration
    {
        string Name { get; }

        LogLevel? ConfiguredLevel { get; }

        LogLevel EffectiveLevel { get; }
    }
}
