using System;
using System.Collections.Generic;

namespace PhnTnTi.Common.Discovery
{
    [Serializable]
    public class SerializableIServiceInstance : IServiceInstance
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="SerializableIServiceInstance"/> class.
        /// For use with JsonSerializer
        /// </summary>
        public SerializableIServiceInstance()
        {
        }

        public SerializableIServiceInstance(IServiceInstance instance)
        {
            ServiceId = instance.ServiceId;
            Host = instance.Host;
            Port = instance.Port;
            IsSecure = instance.IsSecure;
            Uri = instance.Uri;
            Metadata = instance.Metadata;
        }

        public string ServiceId { get; set; }

        public string Host { get; set; }

        public int Port { get; set; }

        public bool IsSecure { get; set; }

        public Uri Uri { get; set; }

        public IDictionary<string, string> Metadata { get; set; }
    }
}
