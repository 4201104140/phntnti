namespace PhnTnTi.Common
{
    /// <summary>
    /// A runnable task bundled with the assembly that can be executed on-demand
    /// </summary>
    public interface IApplicationTask
    {
        /// <summary>
        /// Gets globally unique name for the task
        /// </summary>
        string Name { get; }

        /// <summary>
        /// Action which to run
        /// </summary>
        void Run();
    }
}
