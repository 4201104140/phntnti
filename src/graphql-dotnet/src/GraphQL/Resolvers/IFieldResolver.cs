using System;
using System.Collections.Generic;
using System.Text;

namespace GraphQL.Resolvers
{
    public interface IFieldResolver
    {
        object Resolve()
    }
}
