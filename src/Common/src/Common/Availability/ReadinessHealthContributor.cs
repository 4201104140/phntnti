using PhnTnTi.Common.HealthChecks;
using System.Collections.Generic;

namespace PhnTnTi.Common.Availability
{
    public class ReadinessHealthContributor : AvailabilityHealthContributor
    {
        public override string Id => "readiness";

        private readonly ApplicationAvailability _availability;

        public ReadinessHealthContributor(ApplicationAvailability availability)
            : base(new Dictionary<IAvailabilityState, HealthStatus> { { ReadinessState.AcceptingTraffic, HealthStatus.UP }, { ReadinessState.RefusingTraffic, HealthStatus.OUT_OF_SERVICE } })
        {
            _availability = availability;
        }

        protected override IAvailabilityState GetState() => _availability.GetReadinessState();
    }
}
