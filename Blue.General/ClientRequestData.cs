 
using System.Web;

namespace Blue.General
{ 
 public sealed class ClientRequestData
    {
        public static string RemoteIP
        {
            get
            {
                try
                {
                    return HttpContext.Current.Request.ServerVariables["REMOTE_ADDR"];
                }
                catch
                {
                    return "(unknown)";
                }
            }
        }

        public static string UserAgent
        {
            get
            {
                try
                {
                    return HttpContext.Current.Request.ServerVariables["HTTP_USER_AGENT"];
                }
                catch
                {
                    return "(none)";
                }
            }
        }

        public static string LocalServerIP
        {
            get
            {
                try
                {
                    return HttpContext.Current.Request.ServerVariables["LOCAL_ADDR"];
                }
                catch
                {
                    return "(none)";
                }
            }
        }
    }
}
