using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Linq;

namespace PhnTnTi.Common.Discovery
{
    public class ConfigurationServiceInstanceProvider : IServiceInstanceProvider
    {
        private readonly IOptionsMonitor<List<ConfigurationServiceInstance>> _serviceInstances;

        public ConfigurationServiceInstanceProvider(IOptionsMonitor<List<ConfigurationServiceInstance>> serviceInstances)
        {
            _serviceInstances = serviceInstances;
        }

        public string Description => "A service instance provider that returns services from app configuration";

        public IList<string> Services => GetServices();

        public IList<IServiceInstance> GetInstances(string serviceId)
        {
            return new List<IServiceInstance>(_serviceInstances.CurrentValue.Where(si => si.ServiceId.Equals(serviceId, StringComparison.InvariantCultureIgnoreCase)));
        }

        internal IList<string> GetServices()
        {
            return _serviceInstances.CurrentValue.Select(si => si.ServiceId).Distinct().ToList();
        }
    }
}
