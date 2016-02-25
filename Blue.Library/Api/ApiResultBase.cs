using System;
using System.Net;
using Newtonsoft.Json;

namespace Blue.Library.Api
{
    public abstract class ApiResultBase
    {
        [JsonProperty("meta")]
        internal RequestMetaData MetaData { get; set; }

        public sealed class RequestMetaData
        {
            [JsonProperty("domain")]
            public string Domain { get; set; }

            [JsonProperty("timestamp")]
            public long Timestamp => DateTime.Now.Ticks;

            [JsonProperty("requestId")]
            public string RequestId => Guid.NewGuid().ToString();

            [JsonProperty("server")]
            public string Server => Dns.GetHostName();

            [JsonProperty("code")]
            public int Code { get; set; }

            [JsonProperty("status")]
            public bool Status { get; set; }

            [JsonProperty("message")]
            public string Message { get; set; }

            [JsonProperty("token")]
            public string Token { get; set; }

            [JsonProperty("nonce")]
            public long Nonce { get; set; }

            [JsonProperty("cookie")]
            public string Cookie { get; set; }

            [JsonProperty("queryTime")]
            public double Time { get; set; }
        }


        protected void AddApiResult(RequestMetaData metadata)
        {
            if (!General.AppSettings.ApiHealthLogging)
                return;

            General.Db.ExecuteSql(Data.Sql.Api.SqlCommands.InsertApiHealthRecordSql, 
                metadata.Domain, metadata.Status, metadata.Message, metadata.Token, metadata.Time, metadata.Code, metadata.Server, metadata.RequestId);
        }
    }
}
