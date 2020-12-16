using Microsoft.Extensions.Logging;
using PhnTnTi.Common.HealthChecks;
using System;
using System.Collections.Generic;

namespace PhnTnTi.Common.Availability
{
    public abstract class AvailabilityHealthContributor : IHealthContributor
    {
        public virtual string Id => throw new NotImplementedException();

        private readonly Dictionary<IAvailabilityState, HealthStatus> _stateMappings;
        private readonly ILogger _logger;

        protected AvailabilityHealthContributor(Dictionary<IAvailabilityState, HealthStatus> stateMappings, ILogger logger = null)
        {
            if (stateMappings is null)
            {
                throw new ArgumentNullException(nameof(stateMappings));
            }

            _stateMappings = stateMappings;
            _logger = logger;
        }

        public HealthCheckResult Health()
        {
            var health = new HealthCheckResult();
            var currentHealth = GetState();

            if (currentHealth == null)
            {
                _logger?.LogCritical("Failed to get current availability state");
                health.Description = "Failed to get current availability state";
            }
            else
            {
                try
                {
                    health.Status = _stateMappings[currentHealth];
                    health.Details.Add(currentHealth.GetType().Name, currentHealth.ToString());
                }
                catch (Exception e)
                {
                    _logger?.LogCritical(e, "Failed to map current availability state");
                    health.Description = "Failed to map current availability state";
                }
            }

            return health;
        }

        protected virtual IAvailabilityState GetState() => throw new NotImplementedException();
    }
}
