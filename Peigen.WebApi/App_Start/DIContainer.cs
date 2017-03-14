using Autofac;
using Autofac.Integration.WebApi;
using Peigen.Domain.IEntityRepository;
using Peigen.Repository;
using Peigen.Service;
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
            
            var repository = Assembly.Load("Peigen.Repository");
            builder.RegisterAssemblyTypes(repository, repository).Where(t=>t.Name.EndsWith("Repository")).AsImplementedInterfaces();              
            var service = Assembly.Load("Peigen.Service");
            //builder.RegisterAssemblyTypes(service, service).Where(t => t.Name.EndsWith("Service")).AsImplementedInterfaces();            
            builder.RegisterAssemblyTypes(typeof(MemberService).Assembly).Where(t => t.Name.EndsWith("Service")).AsImplementedInterfaces();
            builder.RegisterApiControllers(Assembly.GetExecutingAssembly()).PropertiesAutowired();//注册api容器的实现
            builder.RegisterType<DatabaseFactory>().As<IDatabaseFactory>().InstancePerLifetimeScope();
            builder.RegisterWebApiFilterProvider(GlobalConfiguration.Configuration);
            IContainer container = builder.Build();
            config.DependencyResolver = new AutofacWebApiDependencyResolver(container);//注册api容器需要使用HttpConfiguration对象     

        }
    }
}