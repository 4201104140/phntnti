using System;
using System.Collections.Generic;
using System.Text;

namespace GraphQL.Types
{
    public class NonNullGraphType : GraphType, IProvideResolvedType
    {

        public Type Type { get; private set; }

        public IGraphType ResolvedType { get; set; }


    }
}
