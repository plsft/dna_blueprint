using System;
using System.Collections.Specialized;
using System.ComponentModel.DataAnnotations;
using Blue.Data.Extentions;
using Helix.Infra.Peta;
using Newtonsoft.Json;

namespace Blue.Data.Models
{
    [TableName("Invoices")]
    public sealed class Invoice : ModelBase<Invoice>, IModel
    {
        [JsonProperty("ID")]
        public int ID { get; set;  }

        [Required]
        [JsonProperty("customerID")]
        public int CustomerId { get; set;  }

        [Required]
        [JsonProperty("partID")]
        [MaxLength]
        public int PartId { get; set; }

        [Required]
        [JsonProperty("amount")]
        public float Amount { get; set;  }

        [Required]
        [JsonProperty("due")]
        public DateTime Due { get; set;  }

        [Required]
        [JsonProperty("status")]
        public int Status { get; set;  }

        [JsonProperty("created")]
        public DateTime Created { get; set; }

        public Invoice()
        {
            Created = DateTime.Now;
        }

        public Invoice(NameValueCollection collection)
        {
            ID = collection["ID"].ToInt32();
            CustomerId = collection["CustomerId"].ToInt32();
            PartId = collection["PartId"].ToInt32();
            Amount = float.Parse(collection["Amount"]);
            Due = DateTime.Parse(collection["Due"]);
            Status = collection["Status"].ToInt32();
            Created = DateTime.Now;
        }
    }
}
