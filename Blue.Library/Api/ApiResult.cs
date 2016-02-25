using System.Collections.Generic;
using System.Diagnostics;
using Blue.Library.Services;
using Newtonsoft.Json;

namespace Blue.Library.Api
{
    public sealed class ApiResult : ApiResultBase
    {
        [JsonProperty("data")]
        public IList<IDataResult> Data { get; set; }

        public ApiResult(IList<IDataResult> data, string domain= "", string token = "", long nonce=0)
        {
            Data = data;

            MetaData = new RequestMetaData
            {
                Domain = domain, 
                Status = (data != null && data.Count != 0),
                Message = ((data != null && data.Count != 0) ? "ok" : "no data"),
                Token = token,
                Time = -1L,
                Nonce = nonce,
                Code = (data != null && data.Count != 0) ? 200 : 204
            };

            AddApiResult(MetaData);
            ApiServices.TouchSession(token, nonce);
        }

        public ApiResult(IList<IDataResult> data, Stopwatch sw = null, string domain="", string token = "", long nonce = 0, string cookie="")
        {
            Data = data;

            MetaData = new RequestMetaData
            {
                Domain = domain,
                Status = (((data != null && data.Count != 0) && data[0].Success)),
                Message = ((data != null && data.Count != 0) ? data[0].Message : "no data"),
                Token = token,
                Time = sw?.Elapsed.TotalMilliseconds ?? -1L,
                Code = (data != null && data.Count != 0) ? 200 : 204,
                Nonce = nonce, 
                Cookie = (((data != null && data.Count != 0) && data[0].Success)) ? cookie : ""
            };

            AddApiResult(MetaData);
            ApiServices.TouchSession(token, nonce);
        }
        
    }
}

