using GraphQL.Types;
using GraphQLDemo.Application.Repositories;
using GraphQLDemo.Application.UseCases.Expressions;
using GraphQLDemo.Application.UseCases.Expressions.Where;

namespace GraphQLDemo.Application.UseCases.DesignPattern.GraphQL
{
    public class DesignPatternQuery : ObjectGraphType, IGraphQueryMarker
    {
        private readonly IDesignPatternReadOnlyRepository designPatternReadOnlyRepository;
        private readonly IMakeExpression makeExpression;

        public DesignPatternQuery(IDesignPatternReadOnlyRepository designPatternReadOnlyRepository, IMakeExpression makeExpression)
        {
            this.designPatternReadOnlyRepository = designPatternReadOnlyRepository;
            this.makeExpression = makeExpression;

            Field<ListGraphType<DesignPatternType>>("designPattern",
                arguments: new QueryArguments(new QueryArgument<WhereExpressionGraph> { Name = "where" }),
                resolve: context =>
                {
                    WhereExpression arguments = context.GetArgument<WhereExpression>("where");
                    return (arguments != null) ?
                        this.designPatternReadOnlyRepository.GetDesignPattterns(this.makeExpression.GetExpression<Domain.DesignPattern.DesignPatttern>(arguments)) :
                        this.designPatternReadOnlyRepository.GetAll();
                });
        }
    }
}
