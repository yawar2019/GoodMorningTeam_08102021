using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using GoodMorningTeam_08102021.Models;
using System.Web.Security;

namespace GoodMorningTeam_08102021.Controllers
{
    public class LoginController : Controller
    {
        // GET: Login
        EmployeeEntities1 db = new EmployeeEntities1();
        public ActionResult Login()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Login(UserDetail user)
        {
            var loginUser = db.UserDetails.Where(s => s.UserName == user.UserName && s.Password == user.Password).SingleOrDefault();
            if(loginUser!=null)
            {
                FormsAuthentication.SetAuthCookie(user.UserName, false);
                return RedirectToAction("Dashboard");
            }
            return View();
        }
        [Authorize(Roles ="Admin,Manager")]
        public ActionResult Dashboard()
        {
            return View();
        }

        [Authorize(Roles ="Admin")]
        public ActionResult AboutUs()
        {
            return View();
        }

        [Authorize(Roles ="Manager")]
        public ActionResult ContactUs()
        {
            return View();
        }

        public ActionResult SignOut()
        {
            FormsAuthentication.SignOut();
            return Redirect("~/Login/Login");
        }

        [OutputCache(Duration = 20,Location =System.Web.UI.OutputCacheLocation.Client)]
        public ActionResult CheckedDateTime()
        {
            return View();
        }


        public ActionResult Test()
        {
            ViewData["studentId"] = 1211;
            ViewBag.StudentName = "TestName";

            TempData["StudentFees"] = 34567;

            return RedirectToAction("Test1");
        }
        public ActionResult Test1()//when u jump from test to test1 new request 
                                   //  .new request viewbag and viewdatawillbecomenull
        {
            
            ViewBag.Student = ViewData["studentId"];//null values
            //ViewBag.Fees = TempData["StudentFees"];
            //TempData we have two types method to retain keys
            //Keep and Peek Meethod

           TempData.Keep();
            ViewBag.Fees=TempData.Peek("StudentFees");

            return View();
        }

        public ActionResult ConsumeWcfService()
        {
            ServiceReference1.Service1Client obj = new ServiceReference1.Service1Client();

            return Content(obj.Add(12, 5).ToString());

        }
    }
}