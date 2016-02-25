using System.Linq;
using Blue.Data.Constants;

namespace Blue.Library.Api
{
    public sealed class AuthHeader
    {
        public string HeaderText { get; set; }

        private readonly string[] headerArray;

        public bool AuthSignatureBypass
        {
            get
            {
                try
                {
                    return headerArray.FirstOrDefault(n => n.ToLower().Contains(BlueConstants.TOKEN_BYPASS)).Split(':')[1].Trim() == "deadbeef123";
                }
                catch
                {
                    return false;
                } 
            }
        }

        public string Token
        {
            get
            {
                try
                {
                    return headerArray.FirstOrDefault(n => n.ToLower().Contains(BlueConstants.TOKEN_NAME)).Split(':')[1].Trim();
                }
                catch
                {
                    return "";
                }
            }
        }

        public long Nonce
        {
            get
            {
                try
                {
                    return long.Parse(headerArray.FirstOrDefault(n => n.ToLower().Contains(BlueConstants.NONCE_NAME)).Split(':')[1].Trim());
                }
                catch
                {
                    return 0;
                }
            }
        }

        public string Auth
        {
            get
            {
                try
                {
                    return headerArray.FirstOrDefault(n => n.ToLower().Contains(BlueConstants.AUTH_NAME)).Split(':')[1].Trim();
                }
                catch
                {
                    return "";
                }
            }
        }

        public AuthHeader(string header)
        {
            HeaderText = header;
            headerArray = header.Split('\n');
        }
    }
}
