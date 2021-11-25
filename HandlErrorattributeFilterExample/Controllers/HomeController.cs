using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace HandlErrorattributeFilterExample.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }

        [HandleError]
        public ActionResult Index2(string id)
        {
            try
            {
                int a = Convert.ToInt32(id), b = 10;
                int c = b / a;
            }
            catch (Exception ex)
            {

                throw new Exception("Please Coordinate to admin {0}",ex);
            }

            return View();
        }
    }
}