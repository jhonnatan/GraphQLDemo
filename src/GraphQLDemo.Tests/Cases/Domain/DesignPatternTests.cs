using FluentAssertions;
using GraphQLDemo.Tests.Builders;
using System;
using Xunit;

namespace GraphQLDemo.Tests.Cases.Domain
{
    public class DesignPatternTests
    {
        [Fact]
        public void ShouldCreateDomain()
        {
            var model = DesignPatternBuilder.New().Build();
            model.IsValid.Should().BeTrue();
        }

        [Fact]        
        public void NullOrEmptyShouldNotCreateWithId()
        {
            var model = DesignPatternBuilder.New().WithId(new Guid()).Build();
            model.IsValid.Should().BeFalse();
            model.ValidationResult.Errors.Should().HaveCountGreaterThan(0);
        }

        [Theory]
        [InlineData("")]
        [InlineData(null)]
        public void NullOrEmptyShouldNotCreateWithName(string name)
        {
            var model = DesignPatternBuilder.New().WithName(name).Build();
            model.IsValid.Should().BeFalse();
            model.ValidationResult.Errors.Should().HaveCountGreaterThan(0);
        }

        [Theory]
        [InlineData("")]
        [InlineData(null)]
        public void NullOrEmptyShouldNotCreateWithDescription(string desc)
        {
            var model = DesignPatternBuilder.New().WithDescription(desc).Build();
            model.IsValid.Should().BeFalse();
            model.ValidationResult.Errors.Should().HaveCountGreaterThan(0);
        }

        [Theory]
        [InlineData("")]
        [InlineData(null)]
        public void NullOrEmptyShouldNotCreateWithExampleOfUse(string exampleOfUse)
        {
            var model = DesignPatternBuilder.New().WithExampleOfUse(exampleOfUse).Build();
            model.IsValid.Should().BeFalse();
            model.ValidationResult.Errors.Should().HaveCountGreaterThan(0);
        }

    }
}
