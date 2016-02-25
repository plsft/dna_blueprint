using Blue.Data.Models;
using Newtonsoft.Json;

namespace Blue.Library.Results
{
    public sealed class AuthResult
    {

        [JsonProperty("user")]
        public UserObject User { get; set; }

       
    }
}
