using FluentValidation;
using System;

namespace GraphQLDemo.Domain.Validator
{
    public class DesignPatternValidator : AbstractValidator<DesignPattern.DesignPatttern>
    {
        public DesignPatternValidator()
        {
            RuleFor(r => r.Id).NotNull().NotEqual(new Guid());
            RuleFor(r => r.Name).NotNull().NotEmpty();
            RuleFor(r => r.Description).NotNull().NotEmpty();
            RuleFor(r => r.ExampleOfUse).NotNull().NotEmpty();
        }
    }
}
