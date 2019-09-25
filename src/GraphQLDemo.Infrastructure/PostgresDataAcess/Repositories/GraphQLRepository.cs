using GraphQLDemo.Application.Repositories;
using GraphQL.Types;
using System.Threading.Tasks;
using GraphQL;

namespace GraphQLDemo.Infrastructure.PostgresDataAcess.Repositories
{
    public class GraphQLRepository : IGraphQLRepository
    {
        private readonly ISchema schema;

        public GraphQLRepository(ISchema schema)
        {
            this.schema = schema;
        }
        public async Task<ExecutionResult> Execute(string query)
        {
            return await new DocumentExecuter().ExecuteAsync(_ =>
            {
                _.Schema = schema;
                _.Query = query;
                _.UserContext = new Context();
            });                
        }
    }
}
