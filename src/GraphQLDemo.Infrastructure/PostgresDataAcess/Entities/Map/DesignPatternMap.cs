using GraphQLDemo.Domain.DesignPattern;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace GraphQLDemo.Infrastructure.PostgresDataAcess.Entities.Map
{
    public class DesignPatternMap : IEntityTypeConfiguration<Domain.DesignPattern.DesignPatttern>
    {
        public void Configure(EntityTypeBuilder<DesignPatttern> builder)
        {
            builder.ToTable("DesignPattern", "GraphQL");
            builder.HasKey(s => s.Id);
        }
    }
}
