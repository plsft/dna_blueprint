using System;
using System.ComponentModel.DataAnnotations;
using Blue.Data.Enums;
using Helix.Infra.Peta;
using Newtonsoft.Json;

namespace Blue.Data.Models
{
    [TableName("Parts")]
    public sealed class Part : ModelBase<Part>, IModel
    {
        [JsonProperty("ID")]
        [Column("ID")]
        public int ID { get; set;  }

        [Column("Descr")]
        [Required]
        [JsonProperty("description")]
        public string Description { get; set;  }

        [Required]
        [JsonProperty("amount")]
        [RowVerColumn]
        public float Amount { get; set;  }

        [Required]
        [JsonProperty("status")]
        [RowVerColumn]
        public int Status { get; set;  }

        [JsonProperty("imagePath")]
        [RowVerColumn]
        public string ImagePath { get; set;  }

        [Required]
        [JsonProperty("title")]
        [RowVerColumn]
        public string Title { get; set;  }

        [Required]
        [JsonProperty("borrowed")]
        [RowVerColumn]
        public bool Borrowed { get; set; }

        [JsonProperty("lastUpdate")]
        [RowVerColumn]
        public DateTime LastUpdate { get; set;  }

        [Ignore] //we ignore to prevent the DAL from trying to bind this column to database table
        [JsonProperty("isAvailable")]
        public bool Available => PartStatus == PartStatusEnum.InStock;

        [Ignore]
        [JsonIgnore]
        public PartStatusEnum PartStatus => (PartStatusEnum)Status;

        [JsonProperty("created")]
        [RowVerColumn]
        public DateTime Created { get; set; }

        [Ignore]
        [JsonIgnore]
        [RowVerColumn]
        public long Ticks => Created.Ticks;
    }
}
