using System;
using System.Linq;
using System.Web;
using Blue.Data.Constants;
using Blue.Data.Controllers;
using Blue.Data.Models;
using Blue.Library.Exceptions;

namespace Blue.Library.Services
{
    public sealed class ApiServices
    {
        private static readonly object o;
        static ApiServices()
        {
            o = new object();
        }

        public static int GetNonce()
        {
            return new Random().Next(int.MaxValue);
        }

        public static string GetToken()
        {
            return Helix.Utility.General.GenerateRandomCode(8);
        }

        public static void AddSession(string token, long nonce, string device)
        {
            lock (o)
            {
                new ControllerContainer.SessionController().Save(new Session
                {
                    Device = device,
                    Token = token,
                    Nonce = nonce,
                    LastSeen = BlueConstants.BlueCurrentDate
                });
            }
        }

        public static void RemoveSession(string token)
        {
            lock (o)
            {
                if (string.IsNullOrEmpty(token))
                    return;

                (new ControllerContainer.SessionController()).Destroy("where token=@0", token);
            }
        }

        public static void TouchSession(string token, long nonce)
        {
            lock (o)
            {
                if (string.IsNullOrEmpty(token) || nonce == 0 || HttpContext.Current.Request.IsLocal)
                    return;

                var controller = new ControllerContainer.SessionController();

                var session = controller.Select("where token=@0", token).FirstOrDefault();

                if (session == null)
                    throw new InvalidTokenException($"Invalid token [{token}]. Please re-authenticate.");

                session.Nonce = nonce;
                session.LastSeen = BlueConstants.BlueCurrentDate;

                controller.Save(session);
            }
        }

        public static bool ValidateSession(string token, long nonce)
        {
            lock (o)
            {
                if (string.IsNullOrEmpty(token) || nonce == 0 )
                    return false;

                var controller = new ControllerContainer.SessionController();
                return controller.Select("where token=@0 and nonce=@1", token, nonce).Any();
            }
        }
    }
}
