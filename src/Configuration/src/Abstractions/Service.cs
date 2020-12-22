using System;
using System.Collections.Generic;

namespace PhnTnTi.Extensions.Configuration
{
    /// <summary>
    /// Represents a service instance bound to an application
    /// </summary>
    public class Service : AbstractServiceOptions
    {
        /// <summary>
        /// Gets or sets the connection information and credentials for using the service
        /// </summary>
        public Dictionary<string, Credential> Credentials { get; set; } = new Dictionary<string, Credential>(StringComparer.InvariantCultureIgnoreCase);
    }
}
