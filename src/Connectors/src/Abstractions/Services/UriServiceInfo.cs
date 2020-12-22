using System.Net;

namespace PhnTnTi.Connector.Services
{
    public abstract class UriServiceInfo : ServiceInfo
    {
        public UriServiceInfo(string id, string scheme, string host, int port, string username, string password, string path)
            : base(id)
        {
            Info = new UriInfo(scheme, host, port, username, password, path);
        }

        public UriServiceInfo(string id, string uriString, string username, string password)
            : base(id)
        {
            Info = new UriInfo(uriString, username, password);
        }

        public UriServiceInfo(string id, string uriString, bool urlEncodedCredentials = false)
            : base(id)
        {
            Info = new UriInfo(uriString, urlEncodedCredentials);
        }

        public UriInfo Info { get; internal protected set; }

        public string Uri => Info.UriString;

        public string UserName => WebUtility.UrlDecode(Info.UserName);

        public string Password => WebUtility.UrlDecode(Info.Password);

        public string Host => Info.Host;

        public string[] Hosts => Info.Hosts;

        public int Port => Info.Port;

        public string Path => Info.Path;

        public string Query => Info.Query;

        public string Scheme => Info.Scheme;
    }
}
