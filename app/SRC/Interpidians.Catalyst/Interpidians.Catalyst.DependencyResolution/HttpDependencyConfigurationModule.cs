using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;

namespace Interpidians.Catalyst.DependencyResolution
{
    public class HttpDependencyConfigurationModule : IHttpModule
    {
        private Lazy<MvcDependencyResolver> config = new Lazy<MvcDependencyResolver>();

        public void Dispose()
        { }

        public void Init(HttpApplication context)
        {
            context.BeginRequest += (sender, args) =>
            {
                if (!this.config.IsValueCreated)
                    this.config.Value.Init();
            };
        }
    }
}
