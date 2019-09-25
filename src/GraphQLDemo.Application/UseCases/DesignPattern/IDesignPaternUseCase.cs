using GraphQL;
using System.Threading.Tasks;

namespace GraphQLDemo.Application.UseCases.DesignPattern
{
    public interface IDesignPaternUseCase
    {
        Task<ExecutionResult> Execute(string query);
    }
}
