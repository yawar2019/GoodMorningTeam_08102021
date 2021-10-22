using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace GoodMorningTeam_08102021
{
    public class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");

            routes.MapMvcAttributeRoutes();
            routes.Add(new Route("test", new CustomeHandler.UserCustomHandler()));
            routes.MapRoute(
                name: "Student",
                url: "Hyderabad/Public",
                defaults: new {  controller = "New", action = "getId", id = UrlParameter.Optional }
            );

          

            routes.MapRoute(
            name: "alpha",
            url: "{controller}/{action}/{id}",//home/index/1211
            defaults: new { controller = "New", action = "getId", id = UrlParameter.Optional }
        );
        }
    }
}
