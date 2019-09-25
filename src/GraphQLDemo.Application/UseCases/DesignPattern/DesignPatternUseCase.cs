using System.Threading.Tasks;
using GraphQL;
using GraphQLDemo.Application.Repositories;

namespace GraphQLDemo.Application.UseCases.DesignPattern
{
    public class DesignPatternUseCase : IDesignPaternUseCase
    {
        private readonly IGraphQLRepository graphQLRepository;

        public DesignPatternUseCase(IGraphQLRepository graphQLRepository)
        {
            this.graphQLRepository = graphQLRepository;
        }
        public async Task<ExecutionResult> Execute(string query)
        {
            return await graphQLRepository.Execute(query);            
        }
    }
}
