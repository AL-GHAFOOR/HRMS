using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;
using System.Web.Security;
using System.Web.SessionState;

namespace bookRep
{
    public class Global : System.Web.HttpApplication
    {

        protected void Application_Start()
        {

            AreaRegistration.RegisterAllAreas();
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);
        }
        protected void Session_Start(Object sender, EventArgs e)
        {
            HttpContext.Current.Session["underconstruction"] = "true";
            HttpContext.Current.Session["beingredirected"] = "false";
        }
        protected void Application_AcquireRequestState(Object sender, EventArgs e)
        {
            if (HttpContext.Current != null && HttpContext.Current.Session != null)
            {
                bool uc = false;
                var underconstruction = HttpContext.Current.Session["underconstruction"];
                if (underconstruction != null)
                {
                    uc = Boolean.Parse(underconstruction.ToString());
                }
                bool redirected = false; var beingredirected = HttpContext.Current.Session["beingredirected"];
                if (beingredirected != null)
                {
                    redirected = Boolean.Parse(beingredirected.ToString());
                }
                if (uc && !redirected)
                {
                    if (HttpContext.Current.Request.HttpMethod != "POST")
                    {
                        HttpContextBase context = new HttpContextWrapper(HttpContext.Current);
                        RouteData rd = RouteTable.Routes.GetRouteData(context);
                        string controllerName = rd.GetRequiredString("controller");
                        string actionName = rd.GetRequiredString("action");
                        if (actionName == "ResetPassowrd")
                        {
                            HttpContext.Current.Session["beingredirected"] = "true";
                            Response.Redirect("~/UserAccount/ResetPassowrd");
                        }
                        if (controllerName != "Std")
                        {
                            HttpContext.Current.Session["beingredirected"] = "true";
                            Response.Redirect("~/Home/Index");
                        }
                        //    HttpContext.Current.Session["beingredirected"] = "true";
                        //    Response.Redirect("~/Home/Index");

                    }
                }

                HttpContext.Current.Session["beingredirected"] = "false";
            }
        }
    }
}