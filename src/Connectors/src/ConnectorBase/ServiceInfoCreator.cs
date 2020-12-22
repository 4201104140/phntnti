//using Microsoft.Extensions.Configuration;
//using PhnTnTi.Common;
//using PhnTnTi.Connector.Services;
//using PhnTnTi.Extensions.Configuration;
//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Text;

//namespace PhnTnTi.Connector
//{
//    public class ServiceInfoCreator
//    {
//        private static readonly object _lock = new object();
//        private static ServiceInfoCreator _me;

//        protected internal IConfiguration Configuration { get; }

//        protected ServiceInfoCreator(IConfiguration configuration) => Configuration = configuration;

//        public static bool IsRelevant { get; } = true;

//        public IList<IServiceInfo> ServiceInfos { get; } = new List<IServiceInfo>();

//        protected internal IList<IServiceInfoFactory> Factories { get; } = new List<IServiceInfoFactory>();

//        public static ServiceInfoCreator Indtance(IConfiguration config)
//        {
//            if (config == null)
//            {
//                throw new ArgumentNullException(nameof(config));
//            }

//            if (config != _me?.Configuration)
//            {
//                lock (_lock)
//                {
//                    if(config!= _me?.Configuration)
//                    {
//                        _me = new ServiceInfoCreator(config);
                        
//                    }
//                }
//            }

//            return _me;
//        }

//        public virtual void BuildServiceInfoFactories()
//        {
//            Factories.Clear();

//            var factories = ReflectionHelpers
//        }

//        protected IServiceInfoFactory FindFactory(Service s)
//        {
//            foreach (var f in Factories)
//            {
//                if (f.Accepts(s))
//                {
//                    return f;
//                }
//            }

//            return null;
//        }

//        private void BuildServiceInfos()
//        {
//            ServiceInfos.Clear();

//            var appInfo = new ApplicationInstanceInfo(Configuration, true);
//            var serviceOpts = new ServicesOptions(Configuration);

//            foreach (var service in serviceOpts.Services.SelectMany(s => s.Value))
//            {
//                var factory = FindFactory(service);
//                if (factory != null && factory.Create(service) is ServiceInfo info)
//                {
//                    info.ApplicationInfo = appInfo;
//                    ServiceInfos.Add(info);
//                }
//            }
//        }
//    }
//}
