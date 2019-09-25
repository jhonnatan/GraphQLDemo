using System.Linq;
using System.Reflection;

namespace GraphQLDemo.Application.UseCases.Expressions
{
    public class Properties : IProperties
    {
        public PropertyInfo GetProperty<T>(string field) where T : class
        {
            var properties = typeof(T).GetProperties();
            var property = properties.Where(s=>s.Name.ToUpper() == field.ToUpper()).FirstOrDefault();
            return property;
        }
    }
}
