namespace PhnTnTi.Common.HealthChecks
{
    /// <summary>
    /// Implement this interface and add to DI to be included in health checks
    /// </summary>
    public interface IHealthContributor
    {
        /// <summary>
        /// Gets an identifier for the type of check being performed
        /// </summary>
        string Id { get; }

        /// <summary>
        /// Check the health of a resource
        /// </summary>
        /// <returns>The result of checking the health of a resource</returns>
        HealthCheckResult Health();
    }
}
