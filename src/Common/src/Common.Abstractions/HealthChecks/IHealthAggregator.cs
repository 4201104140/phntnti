using System.Collections.Generic;

namespace PhnTnTi.Common.HealthChecks
{
    public interface IHealthAggregator
    {
        HealthCheckResult Aggregate(IList<IHealthContributor> contributors);
    }
}
