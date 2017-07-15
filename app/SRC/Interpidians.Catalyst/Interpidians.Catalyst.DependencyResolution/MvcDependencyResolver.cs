using Interpidians.Catalyst.Core.Common;
using SimpleInjector.Integration.Web.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web.Mvc;

namespace Interpidians.Catalyst.DependencyResolution
{
    public class MvcDependencyResolver : IDependencyResolver
    {
        private IServiceLocator Config { get; set; }


        public void Init()
        {
            this.Config = DependencyConfiguration.Instance;
            //DependencyResolver.SetResolver(this);
            DependencyResolver.SetResolver(new SimpleInjectorDependencyResolver(DependencyConfiguration.Instance.Container));
        }

        public object GetService(Type serviceType)
        {
            try
            {
                return this.Config.GetInstance(serviceType);
            }
            catch (Exception ex)
            {
                if (serviceType.Namespace.StartsWith("Interpidians.Catalyst"))
                    throw ex;
                return null; // MVC uses default implementations
            }
        }

        public IEnumerable<object> GetServices(Type serviceType)
        {
            try
            {
                return this.Config.GetAllInstances(serviceType);
            }
            catch (Exception ex)
            {
                if (serviceType.Namespace.StartsWith("Interpidians.Catalyst"))
                    throw ex;
                return null; // MVC uses default implementations
            }
        }
    }
}
