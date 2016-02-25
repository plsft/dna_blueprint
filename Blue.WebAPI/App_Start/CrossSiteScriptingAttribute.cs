using System.Net.Http;
using System.Web.Http.Filters;

namespace Blue.WebAPI
{
    /// <summary>
    /// Cross Site Scripting support for AJAX/JSON callbacks
    /// </summary>
    public class CrossSiteScriptingAttribute : ActionFilterAttribute
    {
        public override void OnActionExecuted(HttpActionExecutedContext actionExecutedContext)
        {
            if (actionExecutedContext.Response != null)
            {
                actionExecutedContext.Response.Headers.Add("Access-Control-Allow-Origin", "*");
                actionExecutedContext.Response.Headers.Add("Access-Control-Allow-Methods", "GET, POST, PUT, OPTIONS, DELETE");
                actionExecutedContext.Response.Headers.Add("Access-Control-Allow-Headers", "content-type, accept");

                if (actionExecutedContext.Request.IsLocal())
                    actionExecutedContext.Response.Headers.Add("X-Localhost-Security-Bypass", "true");
            }


            base.OnActionExecuted(actionExecutedContext);
        }
    }
}