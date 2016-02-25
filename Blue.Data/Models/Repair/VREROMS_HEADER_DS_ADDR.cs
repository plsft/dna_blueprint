using System.Collections.Specialized;
using System.ComponentModel.DataAnnotations;
using Blue.Data.Extentions;
using Helix.Infra.Peta;
using Newtonsoft.Json;

namespace Blue.Data.Models.Repair
{

    [TableName("VREROMS_HEADER_DS_ADDR")]
    public sealed class VREROMS_HEADER_DS_ADDR : ModelBase<VREROMS_HEADER_DS_ADDR>, IModel
    {
        [Ignore]
        public int ID { get; set; }

        [Required]
        [StringLength(10)]
        [CompositeKeyColumn]
        public string RO_NUMBER { get; set; }

        [Required]
        [CompositeKeyColumn]
        public decimal RETURN_TO_NO { get; set; }

        [Required]
        [CompositeKeyColumn]
        public decimal LINE_NUMBER { get; set; }

        [StringLength(40)]
        public string SHIP_TO_ADDR { get; set; }

    }
}
