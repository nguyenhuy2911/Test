using Autofac;
using Autofac.Integration.WebApi;
using PingYourPackage.Domain.Entities.Core;
using PingYourPackage.Domain.Services.IService;
using PingYourPackage.Domain.Services.IServices;
using PingYourPackage.Domain.Services.Service;
using System.Data.Entity;
using System.Reflection;
using System.Web.Http;

namespace PingYourPackage.API.Config
{
    public class AutofacWebAPI
    {
        public static void Initialize(HttpConfiguration config)
        {
            Initialize(config,
            RegisterServices(new ContainerBuilder()));
        }
        public static void Initialize(HttpConfiguration config, IContainer container)
        {
            config.DependencyResolver =
            new AutofacWebApiDependencyResolver(container);
        }
        private static IContainer RegisterServices(ContainerBuilder builder)
        {
            builder.RegisterAssemblyTypes(
            Assembly.GetExecutingAssembly())
            .PropertiesAutowired();
            //EF DbContext
            builder.RegisterType<EntitiesContext>().As<DbContext>().InstancePerRequest();
            //Repositories
            builder.RegisterGeneric(typeof(EntityRepository<>)).As(typeof(IEntityRepository<>)).InstancePerRequest();
            //Services
            builder.RegisterType<CryptoService>().As<ICryptoService>().InstancePerRequest();
            builder.RegisterType<MembershipService>().As<IMembershipService>().InstancePerRequest();
            builder.RegisterType<ShipmentService>().As<IShipmentService>().InstancePerRequest();
            return builder.Build();
        }
    }
}
