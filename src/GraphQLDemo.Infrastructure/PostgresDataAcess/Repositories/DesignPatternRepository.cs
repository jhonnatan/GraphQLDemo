using AutoMapper;
using GraphQLDemo.Application.Repositories;
using GraphQLDemo.Domain.DesignPattern;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;

namespace GraphQLDemo.Infrastructure.PostgresDataAcess.Repositories
{
    public class DesignPatternRepository : IDesignPatternWriteOnlyRepository, IDesignPatternReadOnlyRepository
    {
        private readonly IMapper mapper;

        public DesignPatternRepository(IMapper mapper)
        {
            this.mapper = mapper;
        }

        public int Add(DesignPatttern designPatttern)
        {
            using (var context = new Context())
            {
                context.DesignPattterns.Add(designPatttern);
                return context.SaveChanges();
            }
        }

        public int Delete(DesignPatttern designPatttern)
        {
            using (var context = new Context())
            {
                context.DesignPattterns.Remove(designPatttern);
                return context.SaveChanges();
            }
        }

        public List<DesignPatttern> GetAll()
        {
            var designPatterns = new List<DesignPatttern>();
            using (var context = new Context())
            {
                designPatterns = mapper.Map<List<DesignPatttern>>(context.DesignPattterns.ToList());
            }
            return designPatterns;
        }

        public List<DesignPatttern> GetDesignPattterns(Expression<Func<DesignPatttern, bool>> condition)
        {
            using (var context = new Context())
            {
                return context.DesignPattterns.Where(condition).ToList();
            }
        }
    }
}
