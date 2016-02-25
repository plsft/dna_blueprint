using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using System.Net.Http.Formatting;
using System.Web.Http;
using Blue.Data.Models;
using Blue.Library.Api;
using Blue.Library.Exceptions;
using Blue.Library.Services;

namespace Blue.WebAPI.Controllers
{
    [CrossSiteScripting]
    public class InvoicesController : BaseApiController
    {
        private readonly InvoiceServices _invoiceServices;

        public InvoicesController()
        {
            _invoiceServices = new InvoiceServices(Token);

        }

        [HttpOptions]
        [AllowAnonymous]
        public HttpResponseMessage Options()
        {
            return new HttpResponseMessage { StatusCode = HttpStatusCode.OK };
        }

        [HttpGet]
        [TokenAuthorization]
        [Authentication(Roles = "Users, Admins")]
        public HttpResponseMessage Invoices()
        {
            try
            {
                var response = _invoiceServices.All();

                var data = new List<IDataResult>
                {
                    response
                };

                var result = new ApiResult(data, Stopwatch, "invoices/invoices", Token, Nonce, Cookie);

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


        [HttpGet]
        [TokenAuthorization]
        [Authentication(Roles = "Users, Admins")]
        public HttpResponseMessage Invoice([FromUri] int invoiceId)
        {
            try
            {
                var response = _invoiceServices.Get(invoiceId);

                var data = new List<IDataResult>
                {
                    response
                };

                var result = new ApiResult(data, Stopwatch, "invoices/invoice", Token, Nonce, Cookie);

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

        [HttpPost]
        [TokenAuthorization]
        [Authentication(Roles = "Users, Admins")]
        public HttpResponseMessage Save(Invoice i)
        {
            try
            {
                var response = _invoiceServices.Save(i);

                var data = new List<IDataResult>
                {
                    response
                };

                var result = new ApiResult(data, Stopwatch, "invoices/save", Token, Nonce, Cookie);

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



        [HttpDelete]
        [TokenAuthorization]
        [Authentication(Roles = "Admins")]
        public HttpResponseMessage Destroy([FromUri]int invoiceId)
        {
            try
            {
                var response = _invoiceServices.Delete(invoiceId);

                var data = new List<IDataResult>
                {
                    response
                };

                var result = new ApiResult(data, Stopwatch, "invoices/destory", Token, Nonce, Cookie);

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
