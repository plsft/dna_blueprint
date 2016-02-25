using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using System.Net.Http.Formatting;
using System.Web.Http;
using System.Web.Security;

using Blue.Data.Models;
using Blue.General;
using Blue.Library.Api;
using Blue.Library.Exceptions;
using Blue.Library.Responses;
using Blue.Library.Services;
using Helix.Security;

namespace Blue.WebAPI.Controllers
{
    [CrossSiteScripting]
    public sealed class AuthController : BaseApiController
    {
        private readonly UserServices _userServices;

        public AuthController() : base()
        {
            _userServices = new UserServices();
        }

        [HttpOptions]
        [AllowAnonymous]
        public HttpResponseMessage Options()
        {
            return new HttpResponseMessage { StatusCode = HttpStatusCode.OK };
        }

        [HttpGet]
        [AllowAnonymous]
        public HttpResponseMessage Login(string username, string password)
        {
            try
            {
                Token = ApiServices.GetToken();
                var response = _userServices.Login(username, password);
                var nonce = ApiServices.GetNonce(); 

                var auth = new Auth.AuthTicket
                {
                    Domain = FormsAuthentication.CookieDomain, 
                    ExpirationInMinutes = 60,
                    Persistent = true,
                    UserData = $"{response.AuthResult.User?.RolesList}",
                    UserName = username,
                    Version = 1
                };

                var cookie = Auth.GetAuthTicket(auth);

                var data = new List<IDataResult>
                {
                    new AuthDataResponse(response.AuthResult.User)
                    {
                        Message = response.Message,
                        Success = response.Success, 
                    }
                };

                ApiServices.AddSession(Token, nonce, ClientRequestData.UserAgent);

                var result = new ApiResult(data, Stopwatch, "auth/login", Token, nonce, cookie);
                return Request.CreateResponse(HttpStatusCode.OK, result, new JsonMediaTypeFormatter());
            }
            catch (InvalidTokenException tx)
            {
                return Request.CreateResponse(HttpStatusCode.Unauthorized, new { message = tx.Message }, new JsonMediaTypeFormatter());
            }
            catch (BlueprintAppException appx)
            {
                return Request.CreateResponse(HttpStatusCode.NotAcceptable, new {message = appx.Message}, new JsonMediaTypeFormatter());
            }
            catch (Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.InternalServerError, new { message = ex.Message }, new JsonMediaTypeFormatter());
            }
        }

        [HttpGet]
        [AllowAnonymous]
        public HttpResponseMessage Passthrough(string uid)
        {
            try
            {
                Token = ApiServices.GetToken();
                var response = _userServices.Login(uid);
                var nonce = ApiServices.GetNonce();

                var auth = new Auth.AuthTicket
                {
                    Domain = FormsAuthentication.CookieDomain, //AppSettings.ApplicationUrl,
                    ExpirationInMinutes = 60,
                    Persistent = true,
                    UserData = $"{response.AuthResult.User?.RolesList}",
                    UserName = response.AuthResult.User.u_logon_name,
                    Version = 1
                };

                var cookie = Auth.GetAuthTicket(auth);

                var data = new List<IDataResult>
                {
                    new AuthDataResponse(response.AuthResult.User)
                    {
                        Message = response.Message,
                        Success = response.Success,
                    }
                };

                ApiServices.AddSession(Token, Nonce, ClientRequestData.UserAgent);

                var result = new ApiResult(data, Stopwatch, "auth/login", Token, Nonce);
                return Request.CreateResponse(HttpStatusCode.OK, result, new JsonMediaTypeFormatter());
            }
            catch (InvalidTokenException tx)
            {
                return Request.CreateResponse(HttpStatusCode.Unauthorized, new { message = tx.Message }, new JsonMediaTypeFormatter());
            }
            catch (BlueprintAppException appx)
            {
                return Request.CreateResponse(HttpStatusCode.NotAcceptable, new { message = appx.Message }, new JsonMediaTypeFormatter());
            }
            catch (Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.InternalServerError, new { message = ex.Message }, new JsonMediaTypeFormatter());
            }
        }

        /*
        [HttpPost]
        [AllowAnonymous]
        public HttpResponseMessage Register(User u)
        {
            try
            {
                Token = ApiServices.GetToken();
                var response = _userServices.Register(u);
                var nonce = ApiServices.GetNonce();
                var auth = new Auth.AuthTicket
                {
                    Domain = FormsAuthentication.CookieDomain, //AppSettings.ApplicationUrl,
                    ExpirationInMinutes = 60,
                    Persistent = true,
                    UserData = $"{response.AuthResult.User?.RolesList}",
                    UserName = u.Username,
                    Version = 1
                };

                var cookie = Auth.GetAuthTicket(auth);

                var data = new List<IDataResult>
                {
                    new AuthDataResponse(response.AuthResult.User)
                    {
                        Message = response.Message,
                        Success = response.Success,
                    }
                };

                ApiServices.AddSession(Token, nonce, ClientRequestData.UserAgent);

                var result = new ApiResult(data, Stopwatch, "auth/register", Token, nonce, cookie);
                return Request.CreateResponse(HttpStatusCode.OK, result, new JsonMediaTypeFormatter());
            }
            catch (BlueprintAppException appx)
            {
                return Request.CreateResponse(HttpStatusCode.NotAcceptable, new {type="application exception", message = appx.Message}, new JsonMediaTypeFormatter());
            }
            catch (Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.InternalServerError, new {type="general exception", message = ex.Message}, new JsonMediaTypeFormatter());
            }

        }

        [HttpGet]
        [Authentication]
        [TokenAuthorization]
        public HttpResponseMessage Logout(string username)
        {
            try
            {
                var result = new ApiResult(null, Stopwatch, "auth/logout", Token, Nonce, Cookie);
                FormsAuthentication.SignOut();
                ApiServices.RemoveSession(Token);

                return Request.CreateResponse(HttpStatusCode.OK, result, new JsonMediaTypeFormatter());
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
        */
    }
}