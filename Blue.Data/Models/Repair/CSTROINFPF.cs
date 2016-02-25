using System;
using System.Collections.Specialized;
using System.ComponentModel.DataAnnotations;
using Blue.Data.Extentions;
using Helix.Infra.Peta;
using Newtonsoft.Json;

namespace Blue.Data.Models.Repair
{
    [TableName("CSTROINFPF")]
    public sealed class CSTROINFPF : ModelBase<CSTROINFPF>, IModel
    {
        [Ignore]
        public int ID { get; set; }

        [Required]
        [StringLength(10)]
        [CompositeKeyColumn]
        public string KELL_RO_NO { get; set; }

        [Required]
        [StringLength(4)]
        [CompositeKeyColumn]
        public string KELL_RO_LINE { get; set; }

        [StringLength(20)]
        public string CUST_RO_NO { get; set; }

        [StringLength(20)]
        public string CUST_PO_NO { get; set; }

        [StringLength(20)]
        public string TAIL_NO { get; set; }

        public DateTime QUOTE_DATE { get; set; }

        public DateTime APPROVE_DATE { get; set; }

        public DateTime EST_DEL_DATE { get; set; }

        public DateTime REQ_DEL_DATE { get; set; }

        [StringLength(5)]
        public string C_WORK_STATUS { get; set; }

        [StringLength(20)]
        public string C_CUST_ADDR1 { get; set; }

        [StringLength(20)]
        public string C_CUST_ADDR2 { get; set; }

        [StringLength(20)]
        public string C_CUST_ADDR3 { get; set; }

        [StringLength(1)]
        public string C_CORE_UNIT { get; set; }

        [StringLength(1)]
        public string C_WARRANTY { get; set; }

    }
}
