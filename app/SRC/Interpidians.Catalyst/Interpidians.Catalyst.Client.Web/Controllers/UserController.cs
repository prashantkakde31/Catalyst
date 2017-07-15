using Interpidians.Catalyst.Core.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Interpidians.Catalyst.Client.Web.Controllers
{
    public partial class UserController : Controller
    {
        private ILogger Logger;

        public UserController(ILogger logger)
        {
            this.Logger = logger;
        }
        //
        // GET: /User/

        public virtual ActionResult Index()
        {
            Logger.Info("Hi, This is Prashant");
            return View();
        }

    }
}
