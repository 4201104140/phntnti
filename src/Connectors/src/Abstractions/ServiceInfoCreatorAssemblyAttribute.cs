using PhnTnTi.Common.Attributes;
using System;

namespace PhnTnTi.Connector
{
    /// <summary>
    /// Identify assemblies containing ServiceInfoCreators
    /// </summary>
    [AttributeUsage(AttributeTargets.Assembly)]
    public sealed class ServiceInfoCreatorAssemblyAttribute : AssemblyContainsTypeAttribute
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="ServiceInfoCreatorAssemblyAttribute"/> class.
        /// Used to override the default ServiceInfoCreator
        /// </summary>
        /// <param name="creatorType">The type of your info creator that inherits from PhnTnTi.Connector.ServiceInfoCreator</param>
        public ServiceInfoCreatorAssemblyAttribute(Type creatorType)
            : base(creatorType)
        {
        }
    }
}
