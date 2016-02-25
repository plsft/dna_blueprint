using System;
using System.Collections.Generic;
using Blue.Data.Constants;
using Blue.Data.Models;
using Blue.Library.Api;
using Blue.Library.Results;
using Blue.Library.Services;
using Newtonsoft.Json;

namespace Blue.Library.Responses
{
    public sealed class AuthDataResponse : IDataResult
    {
        [JsonProperty("authResult")]
        public AuthResult AuthResult { get; set;  }

        [JsonProperty("message")]
        public string Message { get; set; }

        [JsonProperty("success")]
        public bool Success { get; set; }

        [JsonProperty("ticks")]
        public long Ticks { get; set; }
        
        public IEnumerable<IModel> Results { get; set; }

        [JsonProperty]
        public DateTime Timestamp { get; set; }

        public AuthDataResponse(UserObject user)
        {
            Timestamp = BlueConstants.BlueCurrentDate;
            Ticks = BlueConstants.BlueCurrentDate.Ticks;

            AuthResult = new AuthResult
            {
                User = user ?? new UserObject()
            };
        }

        public AuthDataResponse()
        {
            AuthResult = new AuthResult();
            Timestamp = BlueConstants.BlueCurrentDate;
            Ticks = BlueConstants.BlueCurrentDate.Ticks; 
        }

        public IList<IModel> Data { get; set; }
    }
}
