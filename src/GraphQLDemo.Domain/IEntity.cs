using System;

namespace GraphQLDemo.Domain
{
    public interface IEntity
    {
        Guid Id { get; set; }
    }
}
