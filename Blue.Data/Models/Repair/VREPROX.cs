using System;
using System.Collections.Specialized;
using System.ComponentModel.DataAnnotations;
using Blue.Data.Extentions;
using Helix.Infra.Peta;
using Newtonsoft.Json;

namespace Blue.Data.Models.Repair
{
    [TableName("VREPROX")]
    public sealed class VREPROX : ModelBase<VREPROX>, IModel
    {
        [Ignore]
        public int ID { get; set; }

        [Required]
        [StringLength(25)]
        [CompositeKeyColumn]
        public string PART_NUMBER { get; set; }

        [Required]
        [StringLength(20)]
        [CompositeKeyColumn]
        public string SERIAL_NUMBER { get; set; }

        [Required]
        [StringLength(10)]
        [CompositeKeyColumn]
        public string REPAIR_NUMBER { get; set; }

        [Required]
        [StringLength(4)]
        [CompositeKeyColumn]
        public string REPAIR_LINE { get; set; }

        [Required]
        [StringLength(17)]
        public string REQUEST_NUMBER { get; set; }

        [Required]
        [StringLength(4)]
        public string REQUEST_LINE { get; set; }

        [Required]
        [StringLength(6)]
        public string VENDOR_NUMBER { get; set; }

        public DateTime DATE_OUT { get; set; }

        public DateTime DATE_DUE { get; set; }

        [Required]
        [StringLength(2)]
        public string ORIG_COND { get; set; }

        [Required]
        [StringLength(2)]
        public string EXPT_COND { get; set; }

        [Required]
        [StringLength(3)]
        [CompositeKeyColumn]
        public string PART_SUFFIX { get; set; }

    }
}
