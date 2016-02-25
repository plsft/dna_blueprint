using System;
using Helix.Infra.Peta;
using Newtonsoft.Json;

namespace Blue.Data.Models
{
    [TableName("Sessions")]
    public class Session : ModelBase<Session>, IModel
    {
        [JsonProperty("ID")]
        public int ID { get; set; }
        [JsonProperty("token")]
        public string Token { get; set; }
        [JsonProperty("nonce")]
        public long Nonce { get; set;  }
        [JsonProperty("device")]
        public string Device { get; set;  }
        [JsonProperty("created")]
        public DateTime Created { get; set;  }
        [JsonProperty("lastSeen")]
        public DateTime LastSeen { get; set;  }

        public Session()
        {
            
        }
    }
}
