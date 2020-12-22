using Microsoft.Extensions.Configuration;

namespace PhnTnTi.Extensions.Configuration
{
    public class ServicesOptions : AbstractServiceOptions
    {
        public ServicesOptions()
        {
        }

        public ServicesOptions(IConfigurationRoot root, string configPrefix = "")
            : base(root, configPrefix)
        {
        }

        public ServicesOptions(IConfiguration config, string configPrefix = "")
            : base(config, configPrefix)
        {
        }
    }
}
