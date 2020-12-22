using PhnTnTi.Common;
using System;

namespace PhnTnTi.Connector.Services
{
    public abstract class ServiceInfo : IServiceInfo
    {
        public ServiceInfo(string id)
            : this(id, null)
        {
        }

        public ServiceInfo(string id, IApplicationInstanceInfo info)
        {
            if (string.IsNullOrEmpty(id))
            {
                throw new ArgumentNullException(nameof(id));
            }

            Id = id;
            ApplicationInfo = info;
        }

        public string Id { get; protected set; }

        public IApplicationInstanceInfo ApplicationInfo { get; set; }
    }
}
