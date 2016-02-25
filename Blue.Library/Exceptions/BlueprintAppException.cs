using System;
using Helix.Utility;

namespace Blue.Library.Exceptions
{
    public sealed class BlueprintAppException : Exception
    {
        public BlueprintAppException(string message, params object[] p) 
            : base(string.Format(message,p))
        {
            base.Data["Type"] = "App";
            Logger.Log("Application Exception", message, Logger.LogType.Critical, p);
        }

        public BlueprintAppException(string msg, Exception ex, params object[] p) 
            : base(string.Format(msg,p), ex)
        {
            base.Data["Type"] = "App";
            Logger.Log("Application Exception", ex?.ToString(), Logger.LogType.Critical, p);
        }

        public BlueprintAppException()
            : base()
        {
            base.Data["Type"] = "App";
            Logger.Log("Core Application Exception", "BlueprintAppException", Logger.LogType.Critical);

        }
    }
}
