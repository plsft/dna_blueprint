using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Http.Formatting;
using System.Web;
using System.Web.Http;

using Blue.Data.Models.Repair;
using Blue.Library.Api;
using Blue.Library.Exceptions;
using Blue.Library.Services;

namespace Blue.WebAPI.Controllers
{
    [CrossSiteScripting]
    public class RepairController : BaseApiController
    {
        private readonly RepairServices _repairServices;

        public RepairController()
        {
            _repairServices = new RepairServices(Token);
        }

        [HttpOptions]
        [AllowAnonymous]
        public HttpResponseMessage Options()
        {
            return new HttpResponseMessage { StatusCode = HttpStatusCode.OK };
        }


        [HttpGet]
        [AllowAnonymous]
        public HttpResponseMessage FindOrders(string docNo)
        {
            try
            {
                var response = _repairServices.FindOrders(docNo);
                var data = new List<IDataResult>
                {
                    response
                };
                var result = new ApiResult(data, Stopwatch, "repairs/orders", Token, Nonce, Cookie);
                return Request.CreateResponse(HttpStatusCode.OK, result, new JsonMediaTypeFormatter());
            }
            catch (InvalidTokenException tx)
            {
                return Request.CreateResponse(HttpStatusCode.Unauthorized, new { type = "invalid token", message = tx.Message }, new JsonMediaTypeFormatter());
            }
            catch (ValidationException vx)
            {
                return Request.CreateResponse(HttpStatusCode.NotAcceptable, new { type = "validation failure", message = vx.Message }, new JsonMediaTypeFormatter());
            }
            catch (BlueprintAppException appx)
            {
                return Request.CreateResponse(HttpStatusCode.NotAcceptable, new { type = "application exception", message = appx.Message }, new JsonMediaTypeFormatter());
            }
            catch (Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.InternalServerError, new { type = "general exception", message = ex.Message }, new JsonMediaTypeFormatter());
            }

        }
    }
}
