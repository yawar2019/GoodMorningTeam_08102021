using AdoDotnetExample.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace AdoDotnetExample.Controllers
{
    public class DefaultController : Controller
    {
        // GET: Default
        EmployeeContext db = new EmployeeContext();
        public ActionResult Index()
        {
            return View(db.GetEmployee());
        }
    }
}