using System;
using System.Collections.Specialized;
using System.ComponentModel.DataAnnotations;
using Blue.Data.Extentions;
using Helix.Infra.Peta;
using Newtonsoft.Json;

namespace Blue.Data.Models.Repair
{

    [TableName("VRERRMS_DETAIL")]
    public sealed class VRERRMS_DETAIL : ModelBase<VRERRMS_DETAIL>, IModel
    {
        [Ignore]
        public int ID { get; set; }

        [Required]
        [StringLength(17)]
        [CompositeKeyColumn]
        public string REQUEST_NUMBER { get; set; }

        [Required]
        [CompositeKeyColumn]
        public float REQUEST_LINE { get; set; }

        [Required]
        [StringLength(10)]
        public string REPAIR_ORDER_NUMBER { get; set; }

        [Required]
        public float REPAIR_ORDER_LINE { get; set; }

        [Required]
        public int COPS_ORDER_LINE { get; set; }

        public DateTime DATE_CREATED { get; set; }

        public DateTime DATE_UPDATED { get; set; }

        [Required]
        [StringLength(1)]
        public string LINE_STATUS { get; set; }

        [Required]
        public int REVISION_NUMBER { get; set; }

        public DateTime REVISION_DATE { get; set; }

        [Required]
        [StringLength(2)]
        public string REPAIR_TYPE { get; set; }

        [Required]
        [StringLength(1)]
        public string REQUESTOR_HOLD_IND { get; set; }

        [Required]
        [StringLength(6)]
        public string CONTROL_NUMBER { get; set; }

        [Required]
        [StringLength(25)]
        public string ORIG_PART_NUMBER { get; set; }

        [Required]
        [StringLength(3)]
        public string ORIG_PART_SUFFIX { get; set; }

        [Required]
        [StringLength(2)]
        public string ORIG_CONDITION { get; set; }

        [Required]
        [StringLength(2)]
        public string ORIG_WAREHOUSE { get; set; }

        [Required]
        [StringLength(5)]
        public string ORIG_OWNER_CODE { get; set; }

        [Required]
        [StringLength(20)]
        public string ORIG_SER_NUMBER { get; set; }

        [Required]
        public int ORIG_QUANTITY { get; set; }

        [Required]
        [StringLength(25)]
        public string EXPT_PART_NUMBER { get; set; }

        [Required]
        [StringLength(3)]
        public string EXPT_PART_SUFFIX { get; set; }

        [Required]
        [StringLength(2)]
        public string EXPT_CONDITION { get; set; }

        [Required]
        [StringLength(2)]
        public string EXPT_WAREHOUSE { get; set; }

        [Required]
        [StringLength(5)]
        public string EXPT_OWNER_CODE { get; set; }

        [Required]
        [StringLength(20)]
        public string EXPT_SER_NUMBER { get; set; }

        [Required]
        public int EXPT_QUANTITY { get; set; }

        [Required]
        [StringLength(40)]
        public string EXPT_COMMENTS { get; set; }

        [Required]
        [StringLength(2)]
        public string DISPOSITION { get; set; }

        [Required]
        public float MARKET_VALUE { get; set; }

        [Required]
        [StringLength(50)]
        public string DROP_SHIP_IND { get; set; }

        [Required]
        [StringLength(2)]
        public string DETAIL_MESSAGE_1 { get; set; }

        [Required]
        [StringLength(2)]
        public string DETAIL_MESSAGE_2 { get; set; }

        [Required]
        [StringLength(2)]
        public string DETAIL_MESSAGE_3 { get; set; }

        [Required]
        [StringLength(2)]
        public string DETAIL_MESSAGE_4 { get; set; }

        [Required]
        [StringLength(1)]
        public string DESCRIPTION_IND { get; set; }

        [Required]
        [StringLength(15)]
        public string COPS_COMMENTS { get; set; }

        [Required]
        [StringLength(1)]
        public string QC_IND { get; set; }

        [Required]
        [StringLength(20)]
        public string ASC_REPAIR_SERIAL { get; set; }

        [Required]
        [StringLength(6)]
        public string SOURCE { get; set; }

        [Required]
        public int ORIG_LINE { get; set; }

        [Required]
        public int SPLIT_TO_LINE { get; set; }

        public DateTime DATE_ROED { get; set; }

        [Required]
        [StringLength(2)]
        public string ORIG_REPAIR_TYPE { get; set; }

        public DateTime PROMISE_DATE { get; set; }

        [Required]
        [StringLength(1)]
        public string COPS_WS { get; set; }

        [Required]
        [StringLength(7)]
        public string DUE_ORD_NO { get; set; }

        [Required]
        public int DUE_ORD_LINE { get; set; }

        [StringLength(1)]
        public string BENCH_TEST_ONLY { get; set; }

        [StringLength(9)]
        public string VENDOR_ID { get; set; }

        [StringLength(1)]
        public string VENDOR_TYPE { get; set; }

        [StringLength(14)]
        public string CAUSE_OF_ACTION { get; set; }

        [StringLength(255)]
        public string ASSIGNED_TO { get; set; }

        [StringLength(150)]
        public string REJECTED_REASON { get; set; }

        [StringLength(25)]
        public string REQUEST_GROUP { get; set; }

        [StringLength(255)]
        public string QUEUE_COMMENTS { get; set; }

        [StringLength(25)]
        public string QUEUE_STATUS { get; set; }

        public float NTE { get; set; }

        [StringLength(7)]
        public string COPS_ORDER { get; set; }

    }

}