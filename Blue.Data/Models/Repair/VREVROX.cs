using System;
using System.Collections.Specialized;
using System.ComponentModel.DataAnnotations;
using Blue.Data.Extentions;
using Helix.Infra.Peta;
using Newtonsoft.Json;

namespace Blue.Data.Models.Repair
{
    [TableName("VREVROX")]
    public sealed class VREVROX : ModelBase<VREVROX>, IModel
    {
        [Ignore]
        public int ID { get; set; }

        [Required]
        [StringLength(6)]
        [CompositeKeyColumn]
        public string VEND_NUMBER { get; set; }

        [Required]
        [StringLength(10)]
        [CompositeKeyColumn]
        public string RO_NUMBER { get; set; }

        [Required]
        [StringLength(4)]
        [CompositeKeyColumn]
        public string RO_LINE { get; set; }

        [Required]
        [StringLength(17)]
        public string REQ_NUMBER { get; set; }

        [Required]
        [StringLength(4)]
        public string REQ_LINE { get; set; }

        [Required]
        [StringLength(25)]
        public string PART_NUMBER { get; set; }

        [Required]
        [StringLength(20)]
        public string SERIAL_NUMBER { get; set; }

        public DateTime DATE_OUT { get; set; }

        public DateTime DATE_DUE { get; set; }

        [Required]
        [StringLength(2)]
        public string ORIG_COND { get; set; }

        [Required]
        [StringLength(3)]
        public string PART_SUFFIX { get; set; }

    }
}
