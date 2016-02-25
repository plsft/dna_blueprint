using System;
using System.Collections.Generic;
using System.Linq;
using Blue.Data.Constants;
using Helix.Infra.Peta;
using Newtonsoft.Json;

namespace Blue.Data.Models
{
    [TableName("OrderHeader")]
    public sealed class OrderHeader : ModelBase<OrderHeader>, IModel
    {

        [JsonProperty("ID")]
        [CompositeKeyColumn]
        public int ID { get; set; }

        [JsonProperty("totalChanges")]
        [CompositeKeyColumn]
        public int TotalChanges { get; set; }

        [JsonProperty("lastUserID")]
        [CompositeKeyColumn]
        public int LastUserID { get; set; }

        [JsonProperty("created")]
        [RowVerColumn]
        public DateTime Created { get; set; }

        [VirtualColumn]
        [JsonProperty("details")]
        [Ignore]
        public IList<OrderDetail> Details { get; set; }

        [JsonProperty("lastUpdatedOn")]
        public DateTime LastUpdatedOn { get; set; }

        [Ignore]
        [RowVerColumn]
        public long Ticks => Created.Ticks;

        [VirtualColumn]
        [JsonProperty("isZero")]
        public bool IsZero
        {
            get { return !(Details?.Select(d => !d.Price.Equals(0f)).Any()) ?? false; }
        }

        public OrderHeader()
        {
            Created = BlueConstants.BlueCurrentDate;
            Details = new List<OrderDetail>();
        }

    }
}
