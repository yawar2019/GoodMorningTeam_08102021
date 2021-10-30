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

        [HttpGet]
        public ActionResult Create()
        {
            return View();
        }
        [HttpPost]
        //[ActionName("CreateEmployee")]
        public ActionResult Create(EmployeeModel emp)
        {
            // FormCollection frm
            //string EmpName = frm["EmpName"];
            //string EmpSalary = frm["EmpSalary"];

            int i= db.SaveEmployee(emp);
            if (i > 0)
            {
                return RedirectToAction("index");
            }

            return View();
        }
    }
}