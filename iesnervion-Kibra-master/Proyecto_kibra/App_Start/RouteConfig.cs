using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace Proyecto_kibra
{
    public class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");

            //si existe la base de datos, redirigimos a home, 
            //en caso contrario redirigimos a install controller.
            /*
                routes.MapRoute(
                name: "Install",
                url: "{controller}/{action}/{id}",
                defaults: new { controller = "Install", action = "Index", id = UrlParameter.Optional } );
             */



            routes.MapRoute(
                name: "Default",
                url: "{controller}/{action}/{id}",
                defaults: new { controller = "Home", action = "Index", id = UrlParameter.Optional }
            );
        }
    }
}