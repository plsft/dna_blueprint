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
    public class CustomersController : BaseApiController
    {
        private readonly CustomerServices _customerServices;

        public CustomersController()
        {
            _customerServices = new CustomerServices(Token);

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
        public HttpResponseMessage Customers()
        {
            try
            {
                var response = _customerServices.All();

                var data = new List<IDataResult>
                {
                    response
                };

                var result = new ApiResult(data, Stopwatch, "customers/customers", Token, Nonce, Cookie);

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
        public HttpResponseMessage Customer([FromUri] int customerId)
        {
            try
            {
                var response = _customerServices.Get(customerId);

                var data = new List<IDataResult>
                {
                    response
                };

                var result = new ApiResult(data, Stopwatch, "customers/customer", Token, Nonce, Cookie);

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
        public HttpResponseMessage Save(Customer c)
        {
            try
            {
                var response = _customerServices.Save(c);

                var data = new List<IDataResult>
                {
                    response
                };

                var result = new ApiResult(data, Stopwatch, "customers/save", Token, Nonce, Cookie);

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
        public HttpResponseMessage Destroy([FromUri]int customerId)
        {
            try
            {
                var response = _customerServices.Delete(customerId);

                var data = new List<IDataResult>
                {
                    response
                };

                var result = new ApiResult(data, Stopwatch, "customers/destory", Token, Nonce, Cookie);

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
