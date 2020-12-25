using System;
using System.Collections.Generic;
using System.Text;

namespace GraphQL.Types
{
    public interface INamedType
    {
        string Name { get; set; }
    }

    public interface IGraphType : IProvideMetadata, INamedType
    {
        string Description { get; set; }

        string DeprecationReason { get; set; }

        string CollectTypes()
    }
}
