using GraphQL.Types;
using GraphQLDemo.Application.Repositories;
using System.Collections.Generic;
using System.Linq;

namespace GraphQLDemo.Infrastructure.GraphQL
{
    public class GraphQLQuery : ObjectGraphType<object>
    {
        public GraphQLQuery(IEnumerable<IGraphQueryMarker> graphQueryMarkers)
        {
            Name = "GraphQLQuery";

            graphQueryMarkers.ToList().ForEach(s =>
            {
                var query = s as ObjectGraphType<object>;
                query.Fields.ToList().ForEach(x => AddField(x));
            });
        }
    }
}
