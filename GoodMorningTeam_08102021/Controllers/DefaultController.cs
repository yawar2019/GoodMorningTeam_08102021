using GoodMorningTeam_08102021.FilterExample;
using GoodMorningTeam_08102021.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace GoodMorningTeam_08102021.Controllers
{
    [CustomFilter]

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
            EmployeeEntities db = new Models.EmployeeEntities();
            ViewBag.States = new SelectList(db.States, "Id", "StateName");
            EmployeeModel emp = new EmployeeModel();
            emp.EmpName = "usha";

            return View(emp);
        }

        [HttpPost]
        public ActionResult HtmlHelperExample(string EmpName, string rbMale,int St,string cbStatments)
        {
            EmployeeEntities db = new Models.EmployeeEntities();
            ViewBag.States = new SelectList(db.States, "Id", "StateName");
            EmployeeModel emp = new EmployeeModel();
            emp.EmpName = "usha";
            var statename = db.States.Where(x => x.Id == St).SingleOrDefault();
            ViewBag.ShowResult = EmpName + "," + rbMale + "," + statename.StateName + "," + cbStatments;
            return View(emp);
        }
        [CustomFilter]
        public ActionResult ValidationExample()
        {
            ViewBag.Player = "Dhoni";
            return View();
        }

        [HttpPost]
        public ActionResult ValidationExample(RegistrationModel reg)
        {
            if (ModelState.IsValid)
            {
                return Redirect("ValidationExample");
            }

            return View(reg);
        }
    }
}