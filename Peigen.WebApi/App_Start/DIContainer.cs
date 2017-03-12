using Autofac;
using Autofac.Integration.WebApi;
using Peigen.Repository;
using System.Reflection;
using System.Web.Http;

namespace Peigen.WebApi
{
    public class DIContainer
    {
        

        public static void Init()
        {
            ContainerBuilder builder = new ContainerBuilder();
            HttpConfiguration config = GlobalConfiguration.Configuration;
            builder.RegisterApiControllers(Assembly.GetExecutingAssembly()).PropertiesAutowired();//注册api容器的实现


            builder.RegisterType<DatabaseFactory>().As<IDatabaseFactory>().InstancePerLifetimeScope();
            //builder.RegisterType<UnitOfWork>().As<IUnitOfWork>().InstancePerLifetimeScope();

            //builder.RegisterAssemblyTypes(typeof(StuEducationRepo).Assembly)
            //    .Where(t => t.Name.EndsWith("Repo"))
            //    .AsImplementedInterfaces().InstancePerLifetimeScope();

            builder.RegisterWebApiFilterProvider(GlobalConfiguration.Configuration);
            IContainer container = builder.Build();
            config.DependencyResolver = new AutofacWebApiDependencyResolver(container);//注册api容器需要使用HttpConfiguration对象     

        }
    }
}