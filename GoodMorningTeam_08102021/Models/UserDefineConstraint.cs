using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Routing;

namespace GoodMorningTeam_08102021.Models
{
    public class UserDefineConstraint : IRouteConstraint
    {
        public bool Match(HttpContextBase httpContext, Route route, string parameterName, RouteValueDictionary values, RouteDirection routeDirection)
        {
            string EmailId = values["EmailId"].ToString();
            if (EmailId.Contains("@"))
            {
                return true;
            }
            return false;
        }
    }
}