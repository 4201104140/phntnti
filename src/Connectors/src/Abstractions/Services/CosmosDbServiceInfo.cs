namespace PhnTnTi.Connector.Services
{
    public class CosmosDbServiceInfo : ServiceInfo
    {
        public CosmosDbServiceInfo(string id)
            : base(id)
        {
        }

        public string Host { get; set; }

        public string MasterKey { get; set; }

        public string ReadOnlyKey { get; set; }

        public string DatabaseId { get; set; }

        public string DatabaseLink { get; set; }
    }
}
