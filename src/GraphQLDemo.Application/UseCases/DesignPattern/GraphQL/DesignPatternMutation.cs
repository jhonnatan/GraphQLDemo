using GraphQL.Types;
using GraphQLDemo.Application.Repositories;
using GraphQLDemo.Application.UseCases.Expressions;
using GraphQLDemo.Application.UseCases.Expressions.Where;
using System;
using System.Linq;

namespace GraphQLDemo.Application.UseCases.DesignPattern.GraphQL
{
    public class DesignPatternMutation : ObjectGraphType, IGraphMutationMarker
    {
        private readonly IDesignPatternReadOnlyRepository designPatternReadOnlyRepository;
        private readonly IDesignPatternWriteOnlyRepository designPatternWriteOnlyRepository;
        private readonly IMakeExpression makeExpression;

        public DesignPatternMutation(IDesignPatternReadOnlyRepository designPatternReadOnlyRepository, IDesignPatternWriteOnlyRepository designPatternWriteOnlyRepository,
            IMakeExpression makeExpression)
        {
            this.designPatternReadOnlyRepository = designPatternReadOnlyRepository;
            this.designPatternWriteOnlyRepository = designPatternWriteOnlyRepository;
            this.makeExpression = makeExpression;

            Patterns();
        }

        private void Patterns()
        {
            Field<DesignPatternType>("createDesignPattern",
                arguments: new QueryArguments(new QueryArgument<NonNullGraphType<StringGraphType>> { Name = "name"}),
                resolve: context => AddDesignPattern(context));

            Field<DesignPatternType>("deleteDesignPattern",
                arguments: new QueryArguments(new QueryArgument<NonNullGraphType<StringGraphType>> { Name = "where" }),
                resolve: context => DeleteDesignPattern(context));
        }

        private object AddDesignPattern(ResolveFieldContext<object> context)
        {
            var name = context.GetArgument<string>("name");
            var description = context.GetArgument<string>("description");
            var exampleOfUse = context.GetArgument<string>("exampleOfUse");
            var designPattern = new Domain.DesignPattern.DesignPatttern(name, description, exampleOfUse);

            if (designPattern.IsValid)
                this.designPatternWriteOnlyRepository.Add(designPattern);
            else
                return new ArgumentException(string.Join(",", designPattern.ValidationResult.Errors));

            return designPattern;
        }

        private object DeleteDesignPattern(ResolveFieldContext<object> context)
        {
            var arguments = context.GetArgument<WhereExpression>("where");
            var designPattern = this.designPatternReadOnlyRepository.GetDesignPattterns(this.makeExpression.GetExpression<Domain.DesignPattern.DesignPatttern>(arguments));

            if (designPattern != null)
                this.designPatternWriteOnlyRepository.Delete(designPattern.FirstOrDefault());
            else
                return new ArgumentException("Design Pattern not found");

            return designPattern;            
        }
    }
}
