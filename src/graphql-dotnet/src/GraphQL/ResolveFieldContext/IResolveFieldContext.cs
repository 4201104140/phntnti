using GraphQL.Execution;
using System;
using System.Collections.Generic;
using System.Text;

namespace GraphQL
{
    public interface IResolveFieldContext : IProvideUserContext
    {
        string FieldName { get; }

        Field
    }
}
