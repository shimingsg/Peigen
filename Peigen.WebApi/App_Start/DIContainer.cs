using Autofac;
using Peigen.Repository;
using Peigen.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Peigen.WebApi
{
    public class DIContainer
    {
        private static IContainer _container;
        public static void Dispose()
        {
            if (_container != null)
            {
                _container.Dispose();
                _container = null;
            }
        }

        public static void Init()
        {
            ContainerBuilder builder = new ContainerBuilder();
            builder.RegisterType<DatabaseFactory>().As<IDatabaseFactory>().InstancePerLifetimeScope();
            builder.RegisterAssemblyTypes(typeof(PublicNumberRepository).Assembly)
                .Where(t => t.Name.EndsWith("Repository"))
                .AsImplementedInterfaces().InstancePerLifetimeScope();
            builder.RegisterAssemblyTypes(typeof(WeiXinService).Assembly)
                .Where(t => t.Name.EndsWith("Service"))
                .AsImplementedInterfaces().InstancePerLifetimeScope();

            _container = builder.Build();
        }
    }
}