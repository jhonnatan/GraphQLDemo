using Autofac;
using GraphQL.Types;
using GraphQLDemo.Infrastructure.GraphQL;

namespace GraphQLDemo.Infrastructure.Modules
{
    public class InfrastructureModule : Autofac.Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterAssemblyTypes(typeof(InfrastructureException).Assembly)
               .AsImplementedInterfaces()
               .AsSelf().InstancePerLifetimeScope();

            builder.RegisterType<GraphQLSchema>().As<ISchema>().InstancePerLifetimeScope();
            builder.RegisterType<GraphQLQuery>().AsSelf().AsImplementedInterfaces().SingleInstance();
            builder.RegisterType<GraphQLMutation>().AsSelf().AsImplementedInterfaces().SingleInstance();

        }
    }
}
