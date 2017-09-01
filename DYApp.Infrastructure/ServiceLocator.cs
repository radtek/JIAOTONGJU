using Autofac;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace DYApp.Infrastructure
{
    public  class ServiceLocator
    {
        public static ServiceLocator Instance = new ServiceLocator();

        private readonly IContainer autofacContainer;
        public ServiceLocator()
        {
            ContainerBuilder containerBuilder = new ContainerBuilder();
            Assembly Domain = Assembly.Load("DYApp.Domain");
            Assembly Repositories = Assembly.Load("DYApp.Repositories");
            Assembly Application = Assembly.Load("DYApp.Application");
            Assembly ServiceContracts = Assembly.Load("DYApp.ServiceContracts");
            containerBuilder.RegisterAssemblyTypes(Repositories);
            containerBuilder.RegisterAssemblyTypes(Application);
            containerBuilder.RegisterAssemblyTypes(Domain).SingleInstance();
            containerBuilder.RegisterAssemblyTypes(Domain, Repositories).AsImplementedInterfaces();
            containerBuilder.RegisterAssemblyTypes(ServiceContracts, Application).AsImplementedInterfaces();
            containerBuilder.RegisterAssemblyTypes(Application);

            autofacContainer = containerBuilder.Build();

        }

        public T GetRef<T>()
        {
            return this.autofacContainer.Resolve<T>();
        }
    }
}
