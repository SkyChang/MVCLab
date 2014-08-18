using Autofac;
using Autofac.Integration.Mvc;
using MVCLab.Infrastructure.Data.CRM;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Web;
using System.Web.Mvc;


namespace MVCLab.Web.App_Start
{
    public class AutofacConfig
    {
        public static void RegisterAutofac()
        {
            ContainerBuilder builder = new ContainerBuilder();

            builder.RegisterControllers(Assembly.GetExecutingAssembly());
            //builder.RegisterApiControllers(Assembly.GetExecutingAssembly());


            builder.RegisterType<UnitOfWork>().As<IUnitOfWork>().InstancePerRequest();


            //var service = Assembly.Load("xx");
            //builder.RegisterAssemblyTypes(xx).AsImplementedInterfaces();

            IContainer container = builder.Build();
            DependencyResolver.SetResolver(new AutofacDependencyResolver(container));
        }
    }
}