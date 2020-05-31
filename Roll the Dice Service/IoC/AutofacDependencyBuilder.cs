using Autofac;
using Autofac.Integration.WebApi;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Web;
using System.Web.Http;
using static Roll_the_Dice_Service.IoC.InjectableAttribute;

namespace Roll_the_Dice_Service.IoC
{
    public class AutofacDependencyBuilder
    {

        public static void DependencyBuilder()
        {
            var builder = new ContainerBuilder();

            builder.RegisterApiControllers(Assembly.GetExecutingAssembly());

            builder.RegisterAssemblyTypes(AppDomain.CurrentDomain.GetAssemblies())
                                      .Where(t => t.GetCustomAttribute<InjectableAttributeScoped>() != null)
                                      .AsImplementedInterfaces()
                                      .InstancePerRequest();

            builder.RegisterAssemblyTypes(AppDomain.CurrentDomain.GetAssemblies())
                                     .Where(t => t.GetCustomAttribute<InjectableAttributeTransient>() != null)
                                     .AsImplementedInterfaces()
                                     .InstancePerRequest();

            builder.RegisterAssemblyTypes(AppDomain.CurrentDomain.GetAssemblies())
                                     .Where(t => t.GetCustomAttribute<InjectableAttributeSingleton>() != null)
                                     .AsImplementedInterfaces()
                                     .InstancePerRequest();

            builder.RegisterWebApiFilterProvider(GlobalConfiguration.Configuration);

            var container = builder.Build();
            var resolver = new AutofacWebApiDependencyResolver(container);

            GlobalConfiguration.Configuration.DependencyResolver = resolver;
        }
    }
}