using GraphQL.Utilities;
using System;
using System.Collections.Generic;
using System.Reflection;
using System.Text;

namespace GraphQL.Types
{
    public abstract class GraphType : MetadataProvider, IGraphType
    {
        private string _name;

        protected GraphType()
        {
            if ()
        }

        protected bool IsTypeModifier => this is ListGraphType || this is NonNullGraphType;

        private string GetDefaultName()
        {
            var type = GetType();

            var attr = type.GetCustomAttribute<>()
        }
    }
}
