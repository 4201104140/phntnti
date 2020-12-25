using GraphQL.Utilities;
using System;
using System.Collections.Generic;
using System.Text;

namespace GraphQL.Types
{
    public class Schema : MetadataProvider, ISchema, IServiceProvider, IDisposable
    {
        private IServiceProvider _services;
        
    }
}
