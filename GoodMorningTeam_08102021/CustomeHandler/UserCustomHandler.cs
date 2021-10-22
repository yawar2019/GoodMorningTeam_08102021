using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Routing;

namespace GoodMorningTeam_08102021.CustomeHandler
{
    public class UserCustomHandler : IRouteHandler
    {
        public IHttpHandler GetHttpHandler(RequestContext requestContext)
        {
            return new CustomHandler();
        }
    }
    public class CustomHandler : IHttpHandler
    {
        public bool IsReusable
        {
            get;set;
        }

        public void ProcessRequest(HttpContext context)
        {
            context.Response.Redirect("https://www.google.com/");
        }
    }
}