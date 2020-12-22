namespace PhnTnTi.Common.Net
{
    public class HostInfo
    {
        public string Hostname { get; set; }

        public string IpAddress { get; set; }

        public bool Override { get; set; }

        public HostInfo()
        {
        }

        public HostInfo(string hostname)
        {
            Hostname = hostname;
        }
    }
}
