using System.Collections.Generic;

namespace PhnTnTi.Common.Discovery
{
    public interface IServiceInstanceProvider
    {
        /// <summary>
        /// Gets a human readable description of the implementation
        /// </summary>
        string Description { get; }

        /// <summary>
        /// Gets all known service Ids
        /// </summary>
        IList<string> Services { get; }

        /// <summary>
        /// Get all ServiceInstances associated with a particular serviceId
        /// </summary>
        /// <param name="serviceId">the serviceId to lookup</param>
        /// <returns>List of service instances</returns>
        IList<IServiceInstance> GetInstances(string serviceId);
    }
}
