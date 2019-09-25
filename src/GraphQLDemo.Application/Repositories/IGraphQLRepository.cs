using GraphQL;
using System.Threading.Tasks;

namespace GraphQLDemo.Application.Repositories
{
    public interface IGraphQLRepository
    {
        Task<ExecutionResult> Execute(string query);
    }
}
