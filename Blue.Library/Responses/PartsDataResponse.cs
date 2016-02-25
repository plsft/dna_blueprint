using System;
using System.Collections.Generic;
using Blue.Data.Constants;
using Blue.Data.CustomModels;
using Blue.Data.Models;
using Blue.Library.Api;
using Blue.Library.Services;
using Newtonsoft.Json;

namespace Blue.Library.Responses
{
    public sealed class PartsDataResponse : IDataResult
    {
        [JsonProperty("customerparts", NullValueHandling = NullValueHandling.Ignore)]
        public IList<CustomerInvoicePartModel> CustomerParts { get; set; }

        [JsonProperty("parts", NullValueHandling = NullValueHandling.Ignore)]
        public IEnumerable<Part> Parts { get; set; }

        [JsonProperty("results", NullValueHandling = NullValueHandling.Ignore)]
        public IEnumerable<IModel> Results { get; set; }

        [JsonProperty("message")]
        public string Message { get; set; }

        [JsonProperty("success")]
        public bool Success { get; set; }

        //[JsonProperty("nonce")]
        //public int Nonce { get; set; }

        //[JsonProperty("token")]
        //public string Token { get; set; }

        [JsonProperty("ticks")]
        public long Ticks { get; set; }

        [JsonProperty]
        public DateTime Timestamp { get; private set; }

        public PartsDataResponse()
        {
            Timestamp = BlueConstants.BlueCurrentDate;
            Ticks = DateTime.Now.Ticks;
        }
    }
}
