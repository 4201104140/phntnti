using System;
using System.Collections.Generic;

namespace PhnTnTi.Common.Discovery
{
    public class ConfigurationServiceInstance : IServiceInstance
    {
        public string ServiceId { get; set; }

        public string Host { get; set; }

        public int Port { get; set; }

        public bool IsSecure { get; set; }

        public Uri Uri => new Uri((IsSecure ? Uri.UriSchemeHttps : Uri.UriSchemeHttp) + Uri.SchemeDelimiter + Host + ':' + Port);

        public IDictionary<string, string> Metadata { get; set; }
    }
}
