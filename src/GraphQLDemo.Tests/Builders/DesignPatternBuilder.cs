using GraphQLDemo.Domain.DesignPattern;
using System;

namespace GraphQLDemo.Tests.Builders
{
    public class DesignPatternBuilder
    {

        public Guid Id { get; private set; }
        public string Name { get; private set; }

        public string Description { get; private set; }

        public string ExampleOfUse { get; private set; }

        public static DesignPatternBuilder New()
        {
            return new DesignPatternBuilder
            {
                Id = Guid.NewGuid(),
                Name = "Chain",
                Description = "Execução de um processo em cadeia",
                ExampleOfUse = "Se houver um processo que pode ser quebrado em vários pedaços e houver uma sequencia para execução"
            };
        }

        public DesignPatternBuilder WithId(Guid id)
        {
            Id = id;
            return this;
        }

        public DesignPatternBuilder WithName(string name)
        {
            Name = name;
            return this;
        }

        public DesignPatternBuilder WithDescription(string desc)
        {
            Description = desc;
            return this;
        }

        public DesignPatternBuilder WithExampleOfUse(string exampleOfUse)
        {
            ExampleOfUse = exampleOfUse;
            return this;
        }

        public DesignPatttern Build()
        {
            return new DesignPatttern(Id, Name, Description, ExampleOfUse);
        }
    }
}
