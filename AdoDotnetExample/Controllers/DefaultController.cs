using AdoDotnetExample.Models;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Dapper;
namespace AdoDotnetExample.Controllers
{
    public class DefaultController : Controller
    {
        // GET: Default
        EmployeeContext db = new EmployeeContext();
        SqlConnection con = new SqlConnection(@"Data Source=AZAM-PC\SQLEXPRESS;Initial Catalog=Employee;Integrated Security=true");//User Id=;Password

        public ActionResult Index()
        {
            var query=con.Query<EmployeeModel>("sp_getRituEmployees",commandType:System.Data.CommandType.StoredProcedure).ToList();

            return View(query);

            //return View(db.GetEmployee());
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

            var paramdet = new DynamicParameters();
            paramdet.Add("@EmpName", emp.EmpName);
            paramdet.Add("@EmpSalary",emp.EmpSalary);
            int i = con.Execute("sp_insertRituEmployees", param: paramdet, commandType: System.Data.CommandType.StoredProcedure);
            // int i= db.SaveEmployee(emp);
            if (i > 0)
            {
                return RedirectToAction("index");
            }

            return View();
        }

        [HttpGet]
        public ActionResult Edit(int? id)
        {
            var paramdet = new DynamicParameters();
            paramdet.Add("@EmpId", id);
            //EmployeeModel emp = db.GetEmployeeById(id);
            EmployeeModel emp = con.QuerySingle<EmployeeModel>("sp_getNeerjaEmployeeDetailsById",param:paramdet, commandType: System.Data.CommandType.StoredProcedure);

            return View(emp);
        }

        [HttpPost]
       
        public ActionResult Edit(EmployeeModel emp)
        {
            var paramdet = new DynamicParameters();
            paramdet.Add("@EmpId", emp.EmpId);
            paramdet.Add("@EmpName", emp.EmpName);
            paramdet.Add("@EmpSalary", emp.EmpSalary);
            int i = con.Execute("sp_UpdateNeerjaEmployees", param: paramdet, commandType: System.Data.CommandType.StoredProcedure);

           // int i = db.UpdateEmployee(emp);
            if (i > 0)
            {
                return RedirectToAction("index");
            }

            return View();
        }
        [HttpGet]
        public ActionResult Delete(int? id)
        {
            EmployeeModel emp = db.GetEmployeeById(id);
            return View(emp);
        }

        [HttpPost]
        [ActionName("Delete")]
        public ActionResult DeleteConfirmed(int? id)
        {
            int i = db.DeleteEmployee(id);
            if (i > 0)
            {
                return RedirectToAction("index");
            }

            return View();
        }
    }
}