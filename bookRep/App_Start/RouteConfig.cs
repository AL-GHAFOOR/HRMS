using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;
using System.Web.Mvc;
using System.Web.Routing;

namespace bookRep
{
    public class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");
            routes.IgnoreRoute("{ASPxUploadProgressHandlerPage}.ashx/{*pathInfo}");
            routes.MapHttpRoute(name: "EnvironmentConversions", routeTemplate: "api/{Controller}/{id}", defaults: new
            {
                id = RouteParameter.Optional
            });
            routes.MapRoute(
                name: "Default",
                url: "{controller}/{action}/{id}",
                defaults: new { controller = "UserAccount", action = "Account", id = UrlParameter.Optional }
            );
        }
    }
}
