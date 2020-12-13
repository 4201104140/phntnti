using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;

namespace PhnTnTi.Common.Contexts
{
    public interface IApplicationContext
    {
        IConfiguration Configuration { get; }

        IServiceProvider ServiceProvider { get; }

        object GetService(string name, Type serviceType);

        T GetService<T>(string name);

        T GetService<T>();

        object GetService(Type serviceType);

        IEnumerable<T> GetServices<T>();

        bool ContainsService(string name, Type serviceType);

        bool ContainsService<T>(string name);

        void Register(string name, object instance);

        object Deregister(string name);
    }
}
