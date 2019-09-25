using Autofac;
using System;

namespace GraphQLDemo.Infrastructure.Modules
{
    public class ApplicationModule : Autofac.Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterAssemblyTypes(typeof(ApplicationException).Assembly)
               .AsImplementedInterfaces()
               .AsSelf().InstancePerLifetimeScope();
        }
    }
}
