using System;
using System.Collections.Generic;
using System.Text;

namespace GraphQL.Types
{
    public class ListGraphType : GraphType, IProvideResolvedType
    {


        public Type Type { get; private set; }

        public IGraphType ResolvedType { get; set; }

        public override string ToString() => $"[{ResolvedType}]";
    }
}
