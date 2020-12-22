using PhnTnTi.Extensions.Configuration;

namespace PhnTnTi.Connector.Services
{
    public interface IServiceInfoFactory
    {
        /// <summary>
        /// Check if this factory can create <see cref="IServiceInfo"/> from the given binding
        /// </summary>
        /// <param name="binding">A service binding to evaluate</param>
        /// <returns>Gets a value indicating whether or not the binding is compatible with this factory</returns>
        bool Accepts(Service binding);

        /// <summary>
        /// Return service information from a service binding
        /// </summary>
        /// <param name="binding">A service binding</param>
        /// <returns>Relevant <see cref="IServiceInfo"/></returns>
        IServiceInfo Create(Service binding);
    }
}
