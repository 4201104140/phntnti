using System.Threading.Tasks;

namespace PhnTnTi.Common.Lifecycle
{
    /// <summary>
    /// A common interface defining methods for start/stop lifecycle control
    /// </summary>
    public interface ILifecycle
    {
        /// <summary>
        /// Start this component
        /// </summary>
        /// <returns>a task to signal completion</returns>
        Task Start();

        /// <summary>
        /// Stop this component
        /// </summary>
        /// <returns>a task to signal completion</returns>
        Task Stop();

        /// <summary>
        /// Gets a value indicating whether gets a value indicating if its running
        /// </summary>
        bool IsRunning { get; }
    }
}
