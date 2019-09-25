using GraphQLDemo.Domain.DesignPattern;

namespace GraphQLDemo.Application.Repositories
{
    public interface IDesignPatternWriteOnlyRepository
    {
        int Add(DesignPatttern designPatttern);

        int Delete(DesignPatttern designPatttern);
    }
}
