using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace ISSSTE.TramitesDigitales2016.PeticionesWeb.Presentacion
{
    public class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");

            routes.MapMvcAttributeRoutes();

            routes.MapRoute(
               name: "Administrador",
               url: "Administrador",
               defaults: new { controller = "Administrator", action = "Index" }
            );

            routes.MapRoute(
                name: "Default",
                url: "{controller}/{action}/{id}",
                defaults: new { controller = "Prueba", action = "index", id = UrlParameter.Optional }
            //routes.MapRoute(
            //    name: "Default",
            //    url: "{controller}/{action}/{id}",
            //    defaults: new { controller = "CausaAsunto", action = "Index", id = UrlParameter.Optional }


            //http://localhost:2142/Reportes/Reportes
            );
        }
    }
}
