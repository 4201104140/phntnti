using PhnTnTi.Common;

namespace PhnTnTi.Connector.Services
{
    public interface IServiceInfo
    {
        string Id { get; }

        IApplicationInstanceInfo ApplicationInfo { get; }
    }
}
