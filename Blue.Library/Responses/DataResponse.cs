using System;
using System.Collections.Generic;

using Blue.Data.Constants;
using Blue.Data.Models;
using Blue.Library.Api;
using Blue.Library.Services;
using Newtonsoft.Json;

namespace Blue.Library.Responses
{
    public sealed class DataResponse : IDataResult
    {
        [JsonProperty("message")]
        public string Message { get; set; }

        [JsonProperty("success")]
        public bool Success { get; set; }

        [JsonProperty("results")]
        public IEnumerable<IModel> Results { get; set; }

        [JsonProperty]
        public DateTime Timestamp { get; private set;  }

        public DataResponse()
        {
            Timestamp = BlueConstants.BlueCurrentDate;
        }
    }
}
