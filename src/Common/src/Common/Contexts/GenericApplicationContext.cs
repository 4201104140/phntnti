using Microsoft.Extensions.Configuration;
using System;

namespace PhnTnTi.Common.Contexts
{
    public class GenericApplicationContext : AbstractApplicationContext
    {
        public GenericApplicationContext(IServiceProvider serviceProvider, IConfiguration configuration)
            : base(serviceProvider, configuration)
        {
        }
    }
}
