using System;
using System.Collections.Generic;
using System.Text;

namespace GraphQL.Types
{
    /// <summary>
    /// The schema for the GraphQL request. Contains references to the 'query', 'mutation', and 'subscription' base graph types.
    /// <br/><br/>
    /// Also allows for adding custom directives, additional graph types, and custom value converters.
    /// <br/><br/>
    /// <see cref="Schema"/> only requires the <see cref="Schema.Query">Query</see> property to be set; although commonly the <see cref="Schema.Mutation">Mutation</see> and/or <see cref="Schema.Subscription">Subscription</see> properties are also set.
    /// </summary>
    public interface ISchema : IProvideMetadata
    {
        /// <summary>
        /// Returns true once the schema has been initialized.
        /// </summary>
        bool Initialized { get; }

        /// <summary>
        /// Initializes the schema. Called by <see cref="IDocumentExecuter"/> before validating or executing the request.
        /// <br/><br/>
        /// Note that middleware cannot be applied once the schema has been initialized. See <see cref="ExecutionOptions.FieldMiddleware"/>.
        /// </summary>
        void Initialize();


    }
}
