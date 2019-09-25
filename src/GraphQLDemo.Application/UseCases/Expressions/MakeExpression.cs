using GraphQL;
using GraphQLDemo.Application.UseCases.Expressions.Where;
using System;
using System.Linq.Expressions;

namespace GraphQLDemo.Application.UseCases.Expressions
{
    public class MakeExpression : IMakeExpression
    {
        private readonly IProperties properties;

        public MakeExpression(IProperties properties)
        {
            this.properties = properties;
        }
        
        public Expression<Func<T, bool>> GetExpression<T>(WhereExpression where) where T : class
        {
            var property = properties.GetProperty<T>(where.Field);
            Expression<Func<T, bool>> expression = null;

            switch (where.Expression)
            {
                case Where.Expression.Equals:
                    expression = func => func.GetPropertyValue(property.Name).ToString() == where.Value;
                    break;
                case Where.Expression.Contains:
                    expression = func => func.GetPropertyValue(property.Name).ToString().Contains(where.Value);
                    break;
                case Where.Expression.Diff:
                    expression = func => func.GetPropertyValue(property.Name).ToString() != where.Value;
                    break;
                default:
                    break;
            }

            return expression;
        }
    }
}
