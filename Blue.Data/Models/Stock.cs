using System;
using Blue.Data.Constants;
using Helix.Infra.Peta;
using Newtonsoft.Json;

namespace Blue.Data.Models
{
    [TableName("Stock")]
    public sealed class Stock : ModelBase<Stock>, IModel
    {
        [JsonProperty("ID")]
        public int ID { get; set; }

        [JsonProperty("units")]
        public int Units { get; set; }

        [JsonProperty("partId")]
        public int PartId { get; set; }

        [JsonProperty("created")]
        public DateTime Created { get; set; }

        [JsonProperty("lastUpdate")]
        public DateTime LastUpdate { get; set; }


        public Stock()
        {
            Created = BlueConstants.BlueCurrentDate;
        }
        
    }
}
