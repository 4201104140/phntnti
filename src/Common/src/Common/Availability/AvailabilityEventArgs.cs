using System;

namespace PhnTnTi.Common.Availability
{
    public class AvailabilityEventArgs : EventArgs
    {
        public AvailabilityEventArgs(IAvailabilityState availabilityState) => NewState = availabilityState;

        public IAvailabilityState NewState { get; }
    }
}
