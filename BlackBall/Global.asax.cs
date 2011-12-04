using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace BlackBall
{
    public class MvcApplication : HttpApplication
    {
        public static void RegisterGlobalFilters(GlobalFilterCollection filters)
        {
            filters.Add(new HandleErrorAttribute());
        }

        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");

            routes.MapRoute(name: "Home", url: "", defaults: new { controller = "Home", action = "Index" });
            routes.MapRoute(name: "About", url: "about", defaults: new { controller = "Home", action = "About" });
            routes.MapRoute(name: "Contact", url: "contact", defaults: new { controller = "Home", action = "Contact" });

            routes.MapRoute(name: "Register", url: "register", defaults: new { controller = "Account", action = "Register" });
            routes.MapRoute(name: "LogIn", url: "login", defaults: new { controller = "Account", action = "LogIn" });
            routes.MapRoute(name: "LogOut", url: "logout", defaults: new { controller = "Account", action = "LogOut" });
            
            routes.MapRoute(name: "Dashboard", url: "dashboard", defaults: new { controller = "Finance", action = "Dashboard" });
            routes.MapRoute(name: "AddInflowItem", url: "inflow/add", defaults: new { controller = "Finance", action = "AddInflowItem" });
            routes.MapRoute(name: "AddOutflowItem", url: "outflow/add", defaults: new { controller = "Finance", action = "AddOutflowItem" });
        }

        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();

            RegisterGlobalFilters(GlobalFilters.Filters);
            RegisterRoutes(RouteTable.Routes);
        }
    }
}
