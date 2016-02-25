using System;
using Helix.Infra.Peta;
using Newtonsoft.Json;

namespace Blue.Data.Models
{
    [TableName("Locks")]
    public sealed class Lock : IModel
    {
        [JsonProperty("ID")]
        public int ID { get; set;  }

        [JsonProperty("objectID")]
        public string ObjectId { get; set;  }

        [JsonProperty("objectType")]
        public string ObjectType { get; set;  }

        [JsonProperty("userID")]
        public int UserId { get; set;  }

        [JsonProperty("token")]
        public string Token { get; set;  }

        [JsonProperty("created")]
        public DateTime Created { get; set;  }

        [JsonProperty("expires")]
        public DateTime Expires { get; set;  }

        [JsonProperty("rowVer")]
        [Column("RowVersion")]
        public string RowVer { get; set;  }

        [Ignore]
        [JsonProperty("expired")]
        public bool Expired => DateTime.Now >= Expires;
    }
}
