using GraphQL.Types;

namespace GraphQLDemo.Application.UseCases.DesignPattern.GraphQL
{
    public class DesignPatternInput : InputObjectGraphType
    {
        public DesignPatternInput()
        {
            Field<NonNullGraphType<StringGraphType>>("name");
        }
    }
}
