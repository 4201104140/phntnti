namespace PhnTnTi.Common.Lifecycle
{
    /// <summary>
    /// An interface for objects that participate in a phased lifecycle.
    /// </summary>
    public interface IPhased
    {
        /// <summary>
        /// Gets the phase of this object
        /// </summary>
        int Phase { get; }
    }
}
