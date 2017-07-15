using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Interpidians.Catalyst.Client.Web.Controllers
{
    public partial class ErrorController : BaseController
    {
        //
        // GET: /Error/

        public virtual ActionResult Index()
        {
            return View(MVC.Error.Views.ViewNames.Error);
        }

        public virtual ActionResult UnAuthorized()
        {
            return View();
        }

        public virtual ActionResult NotFound()
        {
            return View();
        }

        public virtual ActionResult FileNotFound()
        {
            return View();
        }
    }
}
