using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace inln_bootstrap
{
    public class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");

            //routes.MapRoute(
            //    name: "Project",
            //    url: "{controller}/Portfolio/Project/{id}",
            //    defaults: new { controller = "Web", action = "Project", page = true, id = UrlParameter.Optional }
            //);

            routes.MapRoute(
                "Default",
                "{controller}/{action}/{id}",
                new { controller = "Home", action = "Index", id = UrlParameter.Optional },
                new[] { "inln_bootstrap.Controllers" }
            );
        }
    }
}