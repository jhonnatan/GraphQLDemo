using GraphQL.Types;

namespace GraphQLDemo.Application.UseCases.Expressions.Where
{
    public class ExpressionType : EnumerationGraphType<Expression>
    {
        public ExpressionType()
        {
            AddValue("EQUALS", "", 0);
            AddValue("CONTAINS", "", 1);
            AddValue("DIFF", "", 2);
        }
    }
}
