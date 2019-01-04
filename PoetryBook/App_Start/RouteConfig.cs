using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace PoetryBook
{
    public class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");

            routes.MapRoute(
                name: "Default",
                url: "{controller}/{action}/{id}",
                defaults: new { controller = "Home", action = "Index", id = UrlParameter.Optional },
                namespaces: new[] { "PoetryBook.Controllers" }
            );
            
            routes.MapRoute(
                name: "loginroute",
                url: "Login/",
                defaults: new { controller = "Account", action = "Login"},
                namespaces: new[] { "PoetryBook.Controllers" }

            );
        }
    }
}
