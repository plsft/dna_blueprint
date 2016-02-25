using System;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using Blue.Data.Constants;
using Blue.Data.Validation;
using Helix.Infra.Peta;
using Newtonsoft.Json;

namespace Blue.Data.Models
{
    [TableName("UserObject")]
    public sealed class UserObject : ModelBase<UserObject>, IModel
    {
        [JsonProperty("g_user_id")]
        public string g_user_id { get; set;  }

        [Required]
        [StringLength(32)]
        [JsonProperty("u_logon_name")]
        public string u_logon_name { get; set;  }

        [Required]
        [Regex(@"^([\w\.\-]+)@([\w\-]+)((\.(\w){2,3})+)$", ErrorMessage = "Email must be in user@domain.com format")]
        [JsonProperty("u_email_address")]
        public string u_email_address { get; set;  }

        [Required]
        [Column("u_user_security_password")]
        [JsonProperty("u_user_security_password")]
        public string u_user_security_password { get; set;  }

        [JsonProperty("d_date_created")]
        public DateTime d_date_created { get; set;  }

        [Column("d_date_registered")]
        [JsonProperty("d_date_registered")]
        public DateTime d_date_registered { get; set;  }

        [Ignore]
        [JsonProperty("roles")]
        public Role[] Roles { get; set;  }

        [Ignore]
        [JsonIgnore]
        
        public string RolesList
        {
            get { return Roles==null ? string.Empty : string.Join(",", Roles.Select(n => n.RoleName)); }
        }

        [Ignore]
        [JsonProperty("pwdExpired")]
        public bool PwdExpired => d_date_registered >= BlueConstants.BlueCurrentDate;

        [Ignore]
        public int ID { get; set; }

        public UserObject()
        {
            
        }
    }
}
