using System;
using System.Web;
using System.Web.Http;
using System.Web.Mvc;
using System.Web.Routing;
using Interpidians.Catalyst.Core.Common;
using Interpidians.Catalyst.DependencyResolution;
using System.Globalization;
using System.Threading;
using Interpidians.Catalyst.Client.Web.Helpers;


namespace Interpidians.Catalyst.Client.Web
{
    // Note: For instructions on enabling IIS6 or IIS7 classic mode, 
    // visit http://go.microsoft.com/?LinkId=9394801
    public class MvcApplication : System.Web.HttpApplication
    {
        private ILogger Logger;

        protected void Application_Start()
        {
            //Set Culture to en-US by default
            Thread.CurrentThread.CurrentUICulture = new CultureInfo("en-US");
            ModelBinders.Binders.Add(typeof(DateTime), new DateTimeModelBinder());
            ModelBinders.Binders.Add(typeof(DateTime?), new DateTimeModelBinder());

            AreaRegistration.RegisterAllAreas();

            //WebApiConfig.Register(GlobalConfiguration.Configuration);
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);


            //DependencyConfig.RegisterDependencies();

            // Changing the default view engine order for performance
            ViewEngines.Engines.RemoveAt(0);
            ViewEngines.Engines.Add(new WebFormViewEngine());
        }

        protected void Application_Error()
        {
            var exception = Server.GetLastError();
            if (exception == null)
                return;

            Logger = DependencyConfiguration.Instance.GetInstance<ILogger>();
            this.Logger.Error(exception.ToString());

            // Clear the error
            Server.ClearError();

            // Redirect to a landing page
            //Response.Redirect("~/Error/Index");
        }
    }
}