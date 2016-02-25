using System;
using Helix.Infra.Peta;
using Newtonsoft.Json;

namespace Blue.Data.Models
{
    [TableName("History")]
    public sealed class PartHistory : ModelBase<PartHistory>, IModel
    {
        [JsonProperty("ID")]
        public int ID { get; set; }

        [JsonProperty("partID")]
        public int PartId { get; set;  }

        [JsonProperty("status")]
        public int Status { get; set;  }

        [JsonProperty("userID")]
        public int UserId { get; set;  }

        [JsonProperty("created")]
        public DateTime Created { get; set;  }

   

        public PartHistory()
        {
        }

         
    }
}
