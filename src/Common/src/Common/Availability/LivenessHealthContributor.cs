using PhnTnTi.Common.HealthChecks;
using System.Collections.Generic;

namespace PhnTnTi.Common.Availability
{
    public class LivenessHealthContributor : AvailabilityHealthContributor
    {
        public override string Id => "liveness";

        private readonly ApplicationAvailability _availability;

        public LivenessHealthContributor(ApplicationAvailability availability)
            : base(new Dictionary<IAvailabilityState, HealthStatus> { { LivenessState.Correct, HealthStatus.UP }, { LivenessState.Broken, HealthStatus.DOWN } })
        {
            _availability = availability;
        }

        protected override IAvailabilityState GetState() => _availability.GetLivenessState();
    }
}
