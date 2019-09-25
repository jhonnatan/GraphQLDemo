using GraphQL.Types;
using System;
using System.Collections.Generic;
using System.Text;

namespace GraphQLDemo.Application.UseCases.DesignPattern.GraphQL
{
    public class DesignPatternType : ObjectGraphType<Domain.DesignPattern.DesignPatttern>
    {
        public DesignPatternType()
        {
            Name = "DesignPattern";
            Description = "Design Patterns used in development projects";

            Field<IdGraphType>("id");
            Field(x => x.Name).Description("Design Pattern Name");
            Field(x => x.Description).Description("Design Pattern Description");
            Field(x => x.ExampleOfUse, nullable: true).Description("Design Pattern Example of Use");
        }
    }
}
