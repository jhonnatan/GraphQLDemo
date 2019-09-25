using System.Reflection;

namespace GraphQLDemo.Application.UseCases.Expressions
{
    public interface IProperties
    {
        PropertyInfo GetProperty<T>(string field) where T : class;
    }
}
