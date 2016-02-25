using System.Collections.Generic;
using Newtonsoft.Json;

namespace Blue.Library.Api
{
    public sealed class ApiErrorResult : ApiResultBase
    {
        [JsonProperty("data")]
        public IList<IDataResult> Data { get; set; }


        public ApiErrorResult(string error, string domain="", string token = "", int code = 0, long nonce = 0)
        {
            Data = new List<IDataResult>();

            MetaData = new RequestMetaData
            {
                Domain =  domain,
                Status = false,
                Token = token,
                Nonce = nonce,
                Message = error,
                Time = 0L,
                Code = code
            };

            AddApiResult(MetaData);
        }

    }
}
