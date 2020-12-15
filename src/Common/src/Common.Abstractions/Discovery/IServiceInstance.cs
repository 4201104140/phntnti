﻿using System;
using System.Collections.Generic;

namespace PhnTnTi.Common.Discovery
{
    public interface IServiceInstance
    {
        /// <summary>
        ///  Gets the service id as register by the DiscoveryClient
        /// </summary>
        string ServiceId { get; }

        /// <summary>
        /// Gets the hostname of the registered ServiceInstance
        /// </summary>
        string Host { get; }

        /// <summary>
        /// Gets the port of the registered ServiceInstance
        /// </summary>
        int Port { get; }

        /// <summary>
        /// Gets a value indicating whether if the port of the registered ServiceInstance is https or not
        /// </summary>
        bool IsSecure { get; }

        /// <summary>
        /// Gets the service uri address
        /// </summary>
        Uri Uri { get; }

        /// <summary>
        ///  Gets the key value pair metadata associated with the service instance
        /// </summary>
        IDictionary<string, string> Metadata { get; }

        // TODO: Steeltoe 3.0, add for compat with spring cloud
        // string InstanceId { get; }

        // string Scheme { get; }
    }
}