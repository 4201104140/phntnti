using System;
using System.Collections.Generic;
using System.Text;

namespace GraphQL
{
    public abstract class GraphQLAttribute : Attribute
    {
        public virtual void Modify(TypeConfig)
    }

    public sealed class GraphQLMetadataAttribute : 
    {
    }
}
