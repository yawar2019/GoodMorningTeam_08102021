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
        [Authorize]
        public ActionResult Dashboard()
        {
            return View();
        }
    }
}