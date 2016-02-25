using System.Web;
using System.Web.Http;
using System.Web.Mvc;
using System.Web.Routing;

using Blue.General;
using Helix.Utility;

namespace Blue.WebAPI
{
    public class WebApiApplication : HttpApplication
    {
        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();
            GlobalConfiguration.Configure(WebApiConfig.Register);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
        }

        protected void Application_Error()
        {
            var errorContext =  new ErrorContext(HttpContext.Current);
            var ex = Server.GetLastError();

            Logger.Log("Error in Api", "Context: [{0}] Error: [{1}] ", Logger.LogType.Error, errorContext, ex.ToString());
            Server.ClearError();
        }
    }
}
