using PhnTnTi.Common.Attributes;
using PhnTnTi.Connector.Services;

namespace PhnTnTi.Connector
{
    /// <summary>
    /// Identifies an assembly that contains one or more <see cref="IServiceInfoFactory" />
    /// </summary>
    public sealed class ServiceInfoFactoryAssemblyAttribute : AssemblyContainsTypeAttribute
    {
        public ServiceInfoFactoryAssemblyAttribute()
            : base(typeof(IServiceInfoFactory))
        {
        }
    }
}
