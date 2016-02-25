using System;
using System.Collections.Specialized;
using System.ComponentModel.DataAnnotations;
using Blue.Data.Extentions;
using Blue.Data.Validation;
using Helix.Infra.Peta;
using Newtonsoft.Json;

namespace Blue.Data.Models
{
    [TableName("Customers")]
    public sealed class Customer : ModelBase<Customer>, IModel
    {
        public int ID { get; set; }

        [Required]
        [StringLength(32, MinimumLength = 1)]
        [JsonProperty("firstName")]
        public string Firstname { get; set; }

        [Required]
        [StringLength(32, MinimumLength = 1)]
        [JsonProperty("lastName")]
        public string Lastname { get; set; }

        [Required]
        [StringLength(32, MinimumLength = 1)]
        [JsonProperty("address")]
        public string Address1 { get; set; }

        [Required]
        [StringLength(32, MinimumLength = 1)]
        [JsonProperty("city")]
        public string City { get; set; }

        [Required]
        [StringLength(32, MinimumLength = 1)]
        [JsonProperty("state")]
        public string State { get; set; }

        [Required]
        [StringLength(10, MinimumLength = 5)]
        [JsonProperty("zip")]
        public string Zip { get; set; }

        [Required]
        [JsonProperty("phone")]
        public string Phone { get; set; }

        [Required]
        [Regex(@"^([\w\.\-]+)@([\w\-]+)((\.(\w){2,3})+)$", ErrorMessage = "Email must be in user@domain.com format")]
        [JsonProperty("email")]
        public string Email { get; set; }

        [JsonProperty("created")]
        public DateTime Created { get; set; }

        [JsonProperty("lastUpdate")]
        public DateTime LastUpdate { get; set;  }


        public Customer()
        {
        }

        public Customer(NameValueCollection collection)
        {
            ID = collection["ID"].ToInt32();
            Firstname = collection["Firstname"];
            Lastname = collection["Lastname"];
            Address1 = collection["Address1"];
            City = collection["City"];
            State = collection["State"];
            Zip = collection["Zip"];
            Phone = collection["Phone"];
            Email = collection["Email"];

            Created = DateTime.Now;
        }
    }
}
