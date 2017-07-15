using Interpidians.Catalyst.Core.ApplicationService;
using Interpidians.Catalyst.Core.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Interpidians.Catalyst.Client.Web.Controllers
{
    public partial class EmployeeController : BaseController
    {
        private IEmployeeService Service { get; set; }

        public EmployeeController(IEmployeeService service)
        {
            this.Service = service;
        }

        public virtual ActionResult Index()
        {
            return this.RedirectToAction(MVC.Employee.List());
        }

        public virtual ActionResult List()
        {
            List<Employee> lstEmployee = this.Service.GetAll();

            return View(lstEmployee);
        }

    }
}
