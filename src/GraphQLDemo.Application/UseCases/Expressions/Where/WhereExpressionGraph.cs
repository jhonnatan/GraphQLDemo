using GraphQL.Types;

namespace GraphQLDemo.Application.UseCases.Expressions.Where
{
    public class WhereExpressionGraph : InputObjectGraphType<WhereExpression>
    {
        public WhereExpressionGraph()
        {
            Field(f=>f.Field);
            Field<NonNullGraphType<ExpressionType>>("expression");
            Field(f => f.Value);
        }
    }
}
