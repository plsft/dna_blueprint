using System;
using Helix.Utility;

namespace Blue.Library.Exceptions
{
    public sealed class InvalidTokenException : Exception
    {
        public InvalidTokenException(string message, params object[] p) 
            : base(string.Format(message, p))
        {
            base.Data["Type"] = "Token";
            Logger.Log("Application Exception", message, Logger.LogType.Critical, p);
        }

        public InvalidTokenException(string msg, Exception ex, params object[] p) 
            : base(string.Format(msg, p), ex)
        {
            base.Data["Type"] = "Token";
            Logger.Log("API Invalid Token Exception", ex?.ToString(), Logger.LogType.Critical, p);
        }

        public InvalidTokenException()
            : base()
        {
            base.Data["Type"] = "Token";
            Logger.Log("API Invalid Token Exception", "InvalidTokenException", Logger.LogType.Critical);

        }
    }
}
