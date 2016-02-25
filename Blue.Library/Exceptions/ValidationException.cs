using System;
using Helix.Utility;

namespace Blue.Library.Exceptions
{
    public sealed class ValidationException : Exception
    {
        public ValidationException(string message, params object[] p) 
            : base(string.Format(message,p))
        {
            base.Data["Type"] = "Validation"; 
            Logger.Log("Application Exception", message, Logger.LogType.Critical, p);
        }

        public ValidationException(string msg, Exception ex, params object[] p) 
            : base(string.Format(msg,p), ex)
        {
            base.Data["Type"] = "Validation";
            Logger.Log("Application Exception", ex?.ToString(), Logger.LogType.Critical, p);
        }

        public ValidationException()
            : base()
        {
            base.Data["Type"] = "Validation";
            Logger.Log("Application Validation Exception", "ValidationException", Logger.LogType.Critical);

        }
    }
}
