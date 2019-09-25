using GraphQLDemo.Domain.DesignPattern;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;

namespace GraphQLDemo.Infrastructure.PostgresDataAcess
{
    public class Context : DbContext
    {
        public DbSet<DesignPatttern> DesignPattterns { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (Environment.GetEnvironmentVariable("GRAPHQL_CONN") != null)
            {
                optionsBuilder.UseNpgsql(Environment.GetEnvironmentVariable("GRAPHQL_CONN"), npgsqlOptionsAction: options =>
                {
                    options.EnableRetryOnFailure(2, TimeSpan.FromSeconds(5), new List<string>());
                    options.MigrationsHistoryTable("_MigrationHistory", "GraphQL");
                });
            }
            else
            {
                optionsBuilder.UseInMemoryDatabase("GraohQLInMemory");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new Entities.Map.DesignPatternMap());            

            base.OnModelCreating(modelBuilder);
        }
    }
}
