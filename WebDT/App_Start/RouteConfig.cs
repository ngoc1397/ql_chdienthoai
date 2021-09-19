using System.Web.Mvc;
using System.Web.Routing;

namespace WebDT
{
    public class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");

            routes.MapRoute(
                name: "Default",
                url: "{controller}/{action}/{id}",
                defaults: new { controller = "Home", action = "Index", id = UrlParameter.Optional }
                ,namespaces: new[] { "WebDT.Controllers" }
            );
            //routes.MapRoute(
            //    name: "Default",
            //    url: "{controller}/{action}/{id}",
            //    defaults: new { controller = "Login", action = "Index", id = UrlParameter.Optional },
            //    namespaces: new[] { "WebDT.Areas.Admin.Controllers" }
            //).DataTokens.Add("Area", "Admin");
        }
    }
}

