namespace PhnTnTi.Common.Order
{
    /// <summary>
    /// An interface that can be implemented by objects that should be orderable.
    /// </summary>
    public interface IOrdered
    {
        /// <summary>
        /// Gets the order of this object
        /// </summary>
        int Order { get; }
    }
}
