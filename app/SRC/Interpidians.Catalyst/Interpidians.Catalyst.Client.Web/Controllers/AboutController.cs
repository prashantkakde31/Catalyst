using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Interpidians.Catalyst.Client.Web.Controllers
{
    public partial class AboutController : Controller
    {
        //
        // GET: /About/

        public virtual ActionResult Index()
        {
            return View();
        }

        //
        // GET: /Team/

        public virtual ActionResult Team()
        {
            return View();
        }

        //
        // GET: /Testimonial/

        public virtual ActionResult Testimonial()
        {
            return View();
        }

    }
}
