using GoodMorningTeam_08102021.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace GoodMorningTeam_08102021.Controllers
{
    public class DefaultController : Controller
    {
        // GET: Default
        public ActionResult Index(int? id)
        {
            return View();
        }
        public ActionResult Index2(EmployeeModel emp )
        {
            return Content(emp.EmpName);
        }

        public ActionResult HtmlHelperExample()
        {
            return View();
        }
    }
}