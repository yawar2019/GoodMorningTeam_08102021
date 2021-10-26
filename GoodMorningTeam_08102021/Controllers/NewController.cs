using GoodMorningTeam_08102021.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace GoodMorningTeam_08102021.Controllers
{
    [RoutePrefix("Mega")]
    public class NewController : Controller
    {
         ///testing
         public string getId(string id)
        {
            return id;
        }

        public string getmeEmpId(int? eid,string Name)
        {
            return "My Employee Id is" + eid+" Name is "+ Name;
        }
        public string getmeEmployess(int? id)
        {
            return "My Employee Id is" + id+" Name is "+Request.QueryString["Name"];
        }

        [Route("~/Hi/Roshan")]
        [Route("Hi/Srikanth")]
        [Route("Hi/devyani")]
        [Route("New/Wish")]
        public string Wish()
        {
            return "Good Morning Team";
        }

        public ActionResult getData()
        {
            EmployeeModel emp = new EmployeeModel();
            emp.EmpId = 1211;
            emp.EmpName = "Roshan";
            emp.EmpSalary = 250000;

            ViewBag.Employee = emp;

            return View();
        }

        public ActionResult getMultipleData()
        {
            List<EmployeeModel> listObj = new List<EmployeeModel>();

            EmployeeModel emp1 = new EmployeeModel();
            emp1.EmpId = 1211;
            emp1.EmpName = "Roshan";
            emp1.EmpSalary = 250000;

            EmployeeModel emp2 = new EmployeeModel();
            emp2.EmpId = 1212;
            emp2.EmpName = "Barghavi";
            emp2.EmpSalary = 350000;

            EmployeeModel emp3 = new EmployeeModel();
            emp3.EmpId = 1213;
            emp3.EmpName = "sreekanth";
            emp3.EmpSalary = 450000;

            listObj.Add(emp1);
            listObj.Add(emp2);
            listObj.Add(emp3);


            ViewBag.Employee = listObj;
            

            return View();
        }

        public ActionResult getViewModel()
        {
            EmployeeModel emp = new EmployeeModel();
            emp.EmpId = 1211;
            emp.EmpName = "Roshan";
            emp.EmpSalary = 250000;
            return View(emp);
        }

        public ViewResult getListViewModelData(int?id)
        {
            List<EmployeeModel> listObj = new List<EmployeeModel>();

            EmployeeModel emp1 = new EmployeeModel();
            emp1.EmpId = 1211;
            emp1.EmpName = "Roshan";
            emp1.EmpSalary = 250000;

            EmployeeModel emp2 = new EmployeeModel();
            emp2.EmpId = 1212;
            emp2.EmpName = "Barghavi";
            emp2.EmpSalary = 350000;

            EmployeeModel emp3 = new EmployeeModel();
            emp3.EmpId = 1213;
            emp3.EmpName = "sreekanth";
            emp3.EmpSalary = 450000;

            listObj.Add(emp1);
            listObj.Add(emp2);
            listObj.Add(emp3);

            DepartmentModel dept = new Models.DepartmentModel();
            dept.DeptId = 1;
            dept.DeptName = "IT";

            DepartmentModel dept1 = new Models.DepartmentModel();
            dept1.DeptId = 2;
            dept1.DeptName = "Marketing";

            DepartmentModel dept2 = new Models.DepartmentModel();
            dept2.DeptId = 3;
            dept2.DeptName = "Hr";

            List<DepartmentModel> listdept = new List<DepartmentModel>();
            listdept.Add(dept);
            listdept.Add(dept1);
            listdept.Add(dept2);

            EmpDept eobj = new Models.EmpDept();
            eobj.emp = listObj;
            eobj.dept = listdept;

            return View(eobj);
        }

        public RedirectResult GotoGoogle()
        {
            return Redirect("http://www.google.com");
        }
        public RedirectResult GotoGoogle2()
        {
            return Redirect("~/new/getListViewModelData?id=1");
        }

        public FileResult getmeFile()
        {
            return File("~/Web.config", "text/plain");
        }

        public FileResult getmeFile2()
        {
            return File("~/Web.config", "application/xml");
        }
        public FileResult getmeFile3()
        {
            return File("~/ActionResult.pdf", "application/pdf", "ActionResult.pdf");
        }

       public ActionResult PartialViewExample()
        {
            EmployeeModel emp = new EmployeeModel();
            emp.EmpId = 1211;
            emp.EmpName = "Roshan";
            emp.EmpSalary = 250000;
          
            return View(emp);
        }
        public ActionResult EmailChecker(string EmailId)
        {
            return Content(EmailId);
        }


        [Route("Hi/Roshan/{Content}")]
        [Route("Hi/Srikanth/{Content}")]
        [Route("Hi/{Content}/devyani")]
        [Route("New/Test/{Content}/Wish")]
        public string AttibuteExwithParam(string Content)
        {
            return "Good Morning Team "+Content;
        }
        [Route("Class/Student/{Id:int}")]
        public string AttibuteExwithParam2(int Id)
        {
            return "Good Morning student - Id " + Id;
        }

        [Route("Class/Student/{Name:alpha}")]
        public string AttibuteExwithParam3(string Name)
        {
            return "Good Morning student - Name " + Name;
        }

        [Route("Class/StudentDb/{Id:int:min(100)}")]
        public string AttibuteExwithParam3(int Id)
        {
            return "Good Morning student - Id " + Id;
        }


        [Route("Class/StudentDb2/{status:bool}")]
        public string AttibuteExwithParam4(bool status)
        {
            return "Good Morning student - Status " + status;
        }

        public JsonResult Testjson()
        {
            List<EmployeeModel> listObj = new List<EmployeeModel>();

            EmployeeModel emp1 = new EmployeeModel();
            emp1.EmpId = 1211;
            emp1.EmpName = "Roshan";
            emp1.EmpSalary = 250000;

            EmployeeModel emp2 = new EmployeeModel();
            emp2.EmpId = 1212;
            emp2.EmpName = "Barghavi";
            emp2.EmpSalary = 350000;

            EmployeeModel emp3 = new EmployeeModel();
            emp3.EmpId = 1213;
            emp3.EmpName = "sreekanth";
            emp3.EmpSalary = 450000;

            listObj.Add(emp1);
            listObj.Add(emp2);
            listObj.Add(emp3);

            return Json(listObj,JsonRequestBehavior.AllowGet);
        }
    }
}