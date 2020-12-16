using System;
using System.Threading.Tasks;

namespace PhnTnTi.Common.Lifecycle
{
    /// <summary>
    /// An extension of the Lifecycle interface that provides auto startup and a call back
    /// stop action
    /// </summary>
    public interface ISmartLifecycle : ILifecycle, IPhased
    {
        /// <summary>
        /// Gets a value indicating whether the auto startup is set for this object
        /// </summary>
        bool IsAutoStartup { get; }

        /// <summary>
        /// Stop the component and issue the callback when complete
        /// </summary>
        /// <param name="callback">the callback action to invoke when complete</param>
        /// <returns>a task for completion</returns>
        Task Stop(Action callback);
    }
}
