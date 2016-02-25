using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Http.Formatting;
using System.Web;
using System.Web.Http;

using Blue.Data.Models;
using Blue.Library.Api;
using Blue.Library.Exceptions;
using Blue.Library.Services;

namespace Blue.WebAPI.Controllers
{
    [CrossSiteScripting]
    public class PartsController : BaseApiController
    {
        private readonly PartServices _partServices;

        public PartsController()
        {
            _partServices = new PartServices(Token);

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
        public HttpResponseMessage Parts()
        {
            try
            {
                var response = _partServices.All();

                var data = new List<IDataResult>
                {
                    response
                };

                var result = new ApiResult(data, Stopwatch, "parts/parts", Token, Nonce, Cookie);

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
        [Authentication("Users, Admins")]
        public HttpResponseMessage ImageUpload(Part p)
        {
            try
            {
                var result = _partServices.SaveImage(p.ID, p.ImagePath);
                return Request.CreateResponse(HttpStatusCode.OK, new {message = $"{result.Message}"}, new JsonMediaTypeFormatter());
            }
            catch (InvalidTokenException tx)
            {
                return Request.CreateResponse(HttpStatusCode.Unauthorized, new {type = "invalid token", message = tx.Message}, new JsonMediaTypeFormatter());
            }
            catch (ValidationException vx)
            {
                return Request.CreateResponse(HttpStatusCode.NotAcceptable, new {type = "validation failure", message = vx.Message}, new JsonMediaTypeFormatter());
            }
            catch (BlueprintAppException appx)
            {
                return Request.CreateResponse(HttpStatusCode.NotAcceptable, new {type = "application exception", message = appx.Message}, new JsonMediaTypeFormatter());
            }
            catch (Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.InternalServerError, new {type = "general exception", message = ex.Message}, new JsonMediaTypeFormatter());
            }

        }

        [HttpGet]
        [TokenAuthorization]
        [Authentication(Roles = "Users, Admins")]
        public HttpResponseMessage Stock([FromUri] int partId)
        {
            try
            {
                var response = _partServices.Stock(partId);
                var data = new List<IDataResult>
                {
                    response
                };

                var result = new ApiResult(data, Stopwatch, "parts/stock", Token, Nonce, Cookie);

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
        public HttpResponseMessage Return([FromUri] int partId)
        {
            try
            {
                var response = _partServices.ReturnOrBorrow(partId, true);
                var data = new List<IDataResult>
                {
                    response
                };

                var result = new ApiResult(data, Stopwatch, "parts/stock", Token, Nonce, Cookie);

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
        public HttpResponseMessage Borrow([FromUri] int partId)
        {
            try
            {
                var response = _partServices.ReturnOrBorrow(partId);
                var data = new List<IDataResult>
                {
                    response
                };

                var result = new ApiResult(data, Stopwatch, "parts/stock", Token, Nonce, Cookie);

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
        //[TokenAuthorization]
        //[Authentication(Roles = "Users, Admins")]
        public HttpResponseMessage Latest()
        {
            try
            {
                var response = _partServices.All();

                var orderedList = response.Parts.OrderByDescending( o => o.Created).ToList().Take(60);
                response.Parts = orderedList;

                var data = new List<IDataResult>
                {
                    response
                };

                var result = new ApiResult(data, Stopwatch, "parts/parts", Token, Nonce, Cookie);

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
        public HttpResponseMessage Search([FromUri] string search)
        {
            try
            {
                var response = _partServices.Search(search);
                var data = new List<IDataResult>
                {
                    response
                };

                var result = new ApiResult(data, Stopwatch, "parts/parts", Token, Nonce, Cookie);

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
        public HttpResponseMessage AdvancedSearch([FromUri] string search)
        {
            try
            {
                var response = _partServices.Search(search);

                var orderedList = response.Parts.OrderByDescending(o => o.Created).ToList();
                response.Parts = orderedList;

                var data = new List<IDataResult>
                {
                    response
                };

                var result = new ApiResult(data, Stopwatch, "parts/parts", Token, Nonce, Cookie);

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
        public HttpResponseMessage History([FromUri] int partId)
        {
            try
            {
                var response = _partServices.History(partId);

                var data = new List<IDataResult>
                {
                    response
                };

                var result = new ApiResult(data, Stopwatch, "parts/part", Token, Nonce, Cookie);

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
        public HttpResponseMessage Part([FromUri] int partId)
        {
            try
            {
                var response = _partServices.Get(partId);

                var data = new List<IDataResult>
                {
                    response
                };

                var result = new ApiResult(data, Stopwatch, "parts/part", Token, Nonce, Cookie);

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
        public HttpResponseMessage Save(Part p)
        {
            try
            {
                var response = _partServices.Save(p);

                var data = new List<IDataResult>
                {
                    response
                };

                var result = new ApiResult(data, Stopwatch, "parts/save", Token, Nonce, Cookie);

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
        public HttpResponseMessage Destroy([FromUri]int partId)
        {
            try
            {
                var response = _partServices.Delete(partId);

                var data = new List<IDataResult>
                {
                    response
                };

                var result = new ApiResult(data, Stopwatch, "parts/destory", Token, Nonce, Cookie);

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
