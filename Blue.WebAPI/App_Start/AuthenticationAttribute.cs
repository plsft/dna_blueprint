using System;
using System.Linq;
using System.Net.Http;
using System.Security.Principal;
using System.Web;
using System.Web.Http.Controllers;
using System.Web.Security;
using Blue.Data.Constants;
using Blue.Library.Api;

namespace Blue.WebAPI
{
    public sealed class AuthenticationAttribute : System.Web.Http.Filters.AuthorizationFilterAttribute
    {
        public override bool AllowMultiple => false;

        public string Roles { get; set;  }

        public AuthenticationAttribute()
        {
        }

        public AuthenticationAttribute(string roles)
        {
            Roles = roles;
        }

        public override void OnAuthorization(HttpActionContext actionContext)
        {
            var headers = new AuthHeader(actionContext.Request.Headers?.ToString());

            if (actionContext.Request.IsLocal() || headers.AuthSignatureBypass)
                return;

            var authCookie = HttpContext.Current.Request.Cookies[FormsAuthentication.FormsCookieName];
            var roles = new string[8];

            if ((authCookie == null || authCookie.Value == "") && string.IsNullOrEmpty(headers.Auth) )
            {
                actionContext.Response = new HttpResponseMessage(System.Net.HttpStatusCode.Unauthorized)
                {
                    Content = new StringContent($"Please re-authenticate. Missing cookie or '{BlueConstants.AUTH_NAME}' header.")
                };

                base.OnAuthorization(actionContext);
                return;
            }

            try
            {
                var authtoken = string.IsNullOrWhiteSpace(authCookie?.Value) ? headers.Auth : authCookie.Value;
                var authTicket = FormsAuthentication.Decrypt(authtoken);

                if (authTicket != null)
                    roles = authTicket.UserData.Split(new[] { ',' }, StringSplitOptions.RemoveEmptyEntries);

                if (HttpContext.Current.User != null)
                    HttpContext.Current.User = new GenericPrincipal(HttpContext.Current.User.Identity, roles);

                if ((Roles != null) && !Roles.Split(',').Any(roles.Contains))
                {
                    actionContext.Response = new HttpResponseMessage(System.Net.HttpStatusCode.Unauthorized)
                    {
                        Content = new StringContent("Resource inaccessible by group. Please re-authenticate.")
                    };
                }
            }
            catch
            {
                actionContext.Response = new HttpResponseMessage(System.Net.HttpStatusCode.Unauthorized)
                {
                    Content = new StringContent("Please re-authenticate. Invalid AUTH token.")
                };
            }

            base.OnAuthorization(actionContext);
        }
    }
}