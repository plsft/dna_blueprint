using System;
using Blue.Data.Constants;
using Helix.Infra.Peta;
using Newtonsoft.Json;

namespace Blue.Data.Models
{
    [TableName("OrderDetail")]
    [TablePrimaryKey("ID")]
    public sealed class OrderDetail : ModelBase<OrderDetail>, IModel
    {
        [JsonProperty("ID")]
        public int ID { get; set;  }
        [JsonProperty("headerID")]
        public int HeaderID { get; set;  }
        [JsonProperty("orderLine")]
        public int OrderLine { get; set; }
        [JsonProperty("price")]
        public float Price { get; set;  }
        [JsonProperty("created")]
        public DateTime Created { get; set;  }

        public OrderDetail()
        {
            Created = BlueConstants.BlueCurrentDate;
        }
    }
}
