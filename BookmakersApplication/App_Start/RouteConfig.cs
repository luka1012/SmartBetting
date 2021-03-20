using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace BookmakersApplication
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
            );

            routes.MapRoute(
            name: "UserTips",
            url: "{controller}/{action}/{id}",
            defaults: new {controller="UserTips",action="Index",id=UrlParameter.Optional }
        );
            routes.MapRoute(
            name: "Message", 
            url: "{controller}/{action}/{id}", 
            defaults: new { controller = "UserTips", action = "Get", id = UrlParameter.Optional } // Parameter defaults
             );
            routes.MapRoute(
           name: "Tickets",
           url: "{controller}/{action}/{id}",
           defaults: new { controller = "Tickets", action = "Index", id = UrlParameter.Optional } // Parameter defaults
            );

            routes.MapRoute(
          name: "TicketsforDelete",
          url: "{controller}/{action}/{id}",
          defaults: new { controller = "Tickets", action = "DeleteConfirmed", id = UrlParameter.Optional } // Parameter defaults
           );

        }
    }
}
