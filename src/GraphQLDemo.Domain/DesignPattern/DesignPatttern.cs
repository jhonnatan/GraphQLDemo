using GraphQLDemo.Domain.Validator;
using System;

namespace GraphQLDemo.Domain.DesignPattern
{
    public class DesignPatttern : Entity
    {
        public string Name { get; private set; }

        public string Description { get;  private set; }

        public string ExampleOfUse { get; private set; }

        public DesignPatttern(Guid id, string name, string description, string exampleOfUse)
        {
            Id = id;
            Name = name;
            Description = description;
            ExampleOfUse = exampleOfUse;

            Validate(this, new DesignPatternValidator());
        }

        public DesignPatttern(string name, string description, string exampleOfUse)
        {
            Id = Guid.NewGuid();
            Name = name;
            Description = description;
            ExampleOfUse = exampleOfUse;

            Validate(this, new DesignPatternValidator());
        }
    }
}
