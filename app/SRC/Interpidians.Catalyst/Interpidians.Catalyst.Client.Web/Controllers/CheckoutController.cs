using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Interpidians.Catalyst.Client.Web.Controllers
{
    public partial class CheckoutController : BaseController
    {
        //
        // GET: /Checkout/

        public virtual ActionResult Index()
        {
            return View();
        }

    }
}
