using System.Net.Http;
using System.Web.Http.Controllers;
using System.Web.Http.Filters;

using Blue.Library.Api;
using Blue.Library.Services;

namespace Blue.WebAPI
{
    public sealed class TokenAuthorizationAttribute : ActionFilterAttribute
    {
        public override void OnActionExecuting(HttpActionContext actionContext)
        {
            if (actionContext.Request != null)
            {
                var headers = new AuthHeader(actionContext.Request.Headers?.ToString());

                if (actionContext.Request.IsLocal() || headers.AuthSignatureBypass)
                    return;
                
                if (!ApiServices.ValidateSession(headers.Token, headers.Nonce))
                {
                    actionContext.Response = new HttpResponseMessage(System.Net.HttpStatusCode.Unauthorized)
                    {
                        Content = new StringContent($"Invalid token/nonce combination for token: [{headers.Token}]. Access Denied.")
                    };
                }
            }

            base.OnActionExecuting(actionContext);
        }

        
    }
}