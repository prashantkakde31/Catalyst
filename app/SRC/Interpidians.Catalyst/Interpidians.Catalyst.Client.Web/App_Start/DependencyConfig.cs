using System;
using System.Web;
using SimpleInjector;
using SimpleInjector.Integration.Web;
using SimpleInjector.Integration.Web.Mvc;
using Interpidians.Catalyst.Core.Common;
using System.Web.Mvc;

namespace Interpidians.Catalyst.Client.Web
{
    public class DependencyConfig
    {
        public static void RegisterDependencies()
        {
            #region Simple Injector Configuration

            var container = new Container();
            container.Options.DefaultScopedLifestyle = new WebRequestLifestyle();

            // Register your types, for instance:
            //container.Register<IUserRepository, SqlUserRepository>(Lifestyle.Scoped);

            #region Core

            #endregion


            #region Infrastructure

            #region Data

            #endregion

            container.Register<ILogger, Logger>(Lifestyle.Singleton);
            #endregion


            // This is an extension method from the integration package.
            container.RegisterMvcControllers(System.Reflection.Assembly.GetExecutingAssembly());
            container.RegisterMvcIntegratedFilterProvider();

            container.Verify();

            DependencyResolver.SetResolver(new SimpleInjectorDependencyResolver(container));
            #endregion
        }
    }
}