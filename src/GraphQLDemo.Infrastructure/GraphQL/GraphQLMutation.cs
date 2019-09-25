using GraphQL.Types;
using GraphQLDemo.Application.Repositories;
using System.Collections.Generic;
using System.Linq;

namespace GraphQLDemo.Infrastructure.GraphQL
{
    public class GraphQLMutation : ObjectGraphType<object>
    {
        public GraphQLMutation(IEnumerable<IGraphMutationMarker> graphQueryMarkers)
        {
            Name = "GraphQLMutation";

            graphQueryMarkers.ToList().ForEach(f =>
            {
                var mutation = f as ObjectGraphType<object>;
                mutation.Fields.ToList().ForEach(s => AddField(s));
            });
        }
    }
}
