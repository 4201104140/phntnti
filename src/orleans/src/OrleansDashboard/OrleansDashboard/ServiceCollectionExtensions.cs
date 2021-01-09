using Orleans.Hosting;
using System;
using System.Collections.Generic;
using System.Text;

namespace Orleans
{
    public static class ServiceCollectionExtensions
    {
        public static ISiloHostBuilder UseDashboard(this ISiloHostBuilder builder)
        {

            return builder;
        }
    }
}
