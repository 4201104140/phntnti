using PhnTnTi.Common.Attributes;

namespace PhnTnTi.Connector
{
    /// <summary>
    /// Identifies an assembly that contains one or more <see cref="IConnectionInfo" />
    /// </summary>
    public sealed class ConnectionInfoAssemblyAttribute : AssemblyContainsTypeAttribute
    {
        public ConnectionInfoAssemblyAttribute()
            : base(typeof(IConnectionInfo))
        {
        }
    }
}
