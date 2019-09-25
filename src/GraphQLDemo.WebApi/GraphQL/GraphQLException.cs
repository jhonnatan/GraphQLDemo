using System;

namespace GraphQLDemo.WebApi.GraphQL
{
    public class GraphQLException : Exception
    {
        public GraphQLException(string businessMessage) : base(businessMessage)
        {
        }
    }
}
