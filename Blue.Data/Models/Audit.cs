using System;
using Helix.Infra.Peta;
using Newtonsoft.Json;

namespace Blue.Data.Models
{
    [TableName("Audit")]
    public sealed class Audit
    {
        [JsonProperty("ID")]
        public int ID { get; set;  }

        [JsonProperty("endPoint")]
        public string Endpoint { get; set; }

        [JsonProperty("operation")]
        public string Operation { get; set; }

        [JsonProperty("userId")]
        public int UserId { get; set; }

        [JsonProperty("created")]
        public DateTime Created { get; set; }

        [JsonProperty("table")]
        [Column("TableName")]
        public string Table { get; set; }

        [JsonProperty("column")]
        [Column("ColumnName")]
        public string Column { get; set; }

        [JsonProperty("oldValue")]
        public string OldValue { get; set; }

        [JsonProperty("newValue")]
        public string NewValue{ get; set; }

        [JsonProperty("TransactionID")]
        public string TransactionID { get; set; }



    }
}
