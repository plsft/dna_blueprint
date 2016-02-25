using System.Diagnostics;
using System.Net;
using System.Net.Http;
using System.Web;
using System.Web.Http;
using Blue.Data.Constants;
using Blue.Data.Extentions;

namespace Blue.WebAPI.Controllers
{
    [CrossSiteScripting]
    public class BaseApiController : ApiController
    {
        public Stopwatch Stopwatch { get; set; }
        public string Token { get; set; }
        public long Nonce { get; set;  }
        public string Cookie { get; set;  }
        public BaseApiController()
        {
            HttpContext.Current.Response.ContentType = "application/json";

            Token = HttpContext.Current.Request.Headers.Get(BlueConstants.TOKEN_NAME);
            Nonce = HttpContext.Current.Request.Headers.Get(BlueConstants.NONCE_NAME).ToInt64();
            Cookie = HttpContext.Current.Request.Headers.Get(BlueConstants.AUTH_NAME);

            Stopwatch = new Stopwatch();
            Stopwatch.Start();
        }

/*        [HttpOptions]
        [AllowAnonymous]
        public HttpResponseMessage Options()
        {
            return new HttpResponseMessage { StatusCode = HttpStatusCode.OK };
        }*/
    }
}
