using System;

namespace Blue.Data.Constants
{
    public class BlueConstants
    {
        public static string SUCCESS = "Success";
        public static string FAILURE = "Failure";

        public static string TOKEN_NAME = "x-blue-token";
        public static string NONCE_NAME = "x-blue-nonce";
        public static string AUTH_NAME =  "x-blue-auth";
        public static string TOKEN_BYPASS = "x-blue-bypass"; 

        public static DateTime BlueCurrentDate => DateTime.Now;
    }
}
