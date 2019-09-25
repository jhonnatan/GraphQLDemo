using GraphQLDemo.Domain.DesignPattern;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace GraphQLDemo.Application.Repositories
{
    public interface IDesignPatternReadOnlyRepository
    {
        List<DesignPatttern> GetDesignPattterns(Expression<Func<DesignPatttern, bool>> condition);
        List<DesignPatttern> GetAll();

    }
}
