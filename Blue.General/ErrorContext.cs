 
using System.Web;

namespace Blue.General
{
    public sealed class ErrorContext
    {
        private readonly HttpContext _ctx;

        public ErrorContext(HttpContext ctx)
        {
            if (ctx == null)
                _ctx = new HttpContext(new HttpRequest("", "", ""), new HttpResponse(null));

            _ctx = ctx;
        }

        public string ApplicationFilePath => _ctx.Request.PhysicalApplicationPath;

        public string RawUrl => _ctx.Request.RawUrl;

        public string Method => _ctx.Request.HttpMethod;

        public string UserAgent => _ctx.Request.UserAgent;

        public string UserAddress => _ctx.Request.UserHostAddress;

        public string Username => _ctx.User.Identity.Name;

        public override string ToString()
        {
            return $"ErrorContext=FilePath=[{ApplicationFilePath}], RawUrl=[{RawUrl}, Method=[{Method}, UA={UserAgent}, HostAddress=[{UserAddress}], User=[{Username}]";
        }
    }
}
