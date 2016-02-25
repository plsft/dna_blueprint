using System;
using System.Collections.Specialized;
using System.ComponentModel.DataAnnotations;
using Blue.Data.Extentions;
using Helix.Infra.Peta;
using Newtonsoft.Json;

namespace Blue.Data.Models.Repair
{
    [TableName("VREROMS_HEADER")]
    public sealed class VREROMS_HEADER : ModelBase<VREROMS_HEADER>, IModel
    {
        [Ignore]
        public int ID { get; set; }

        [Required]
        [StringLength(10)]
        [CompositeKeyColumn]
        public string RO_NUMBER { get; set; }

        [Required]
        [CompositeKeyColumn]
        public decimal RO_LINE { get; set; }

        public DateTime DATE_CREATED { get; set; }

        public DateTime DATE_UPDATED { get; set; }

        public DateTime REQ_DATE { get; set; }

        public DateTime ISSUE_DATE { get; set; }

        [Required]
        public decimal REVISION_NUMBER { get; set; }

        public DateTime REVISION_DATE { get; set; }

        [Required]
        [StringLength(3)]
        public string REPAIR_REFER_TO { get; set; }

        [Required]
        [StringLength(1)]
        public string STATUS { get; set; }

        [Required]
        [StringLength(2)]
        public string REPAIR_TYPE { get; set; }

        [Required]
        [StringLength(1)]
        public string TD_COMPLETE { get; set; }

        [Required]
        [StringLength(6)]
        public string VENDOR_NUMBER { get; set; }

        [Required]
        public decimal DISCOUNT_PERCENT { get; set; }

        [Required]
        public decimal DISC_DAYS { get; set; }

        [Required]
        [StringLength(1)]
        public string DISCOUNT_DP_IND { get; set; }

        [Required]
        public decimal NET_DAYS { get; set; }

        [Required]
        [StringLength(1)]
        public string NET_DP_IND { get; set; }

        [Required]
        [StringLength(10)]
        public string OTHER_TERMS { get; set; }

        [Required]
        public decimal RETURN_TO_NO { get; set; }

        [Required]
        [StringLength(3)]
        public string RETURN_VIA { get; set; }

        [Required]
        [StringLength(3)]
        public string SHIP_VIA { get; set; }

        [Required]
        [StringLength(2)]
        public string PRINT_IND { get; set; }

        [Required]
        [StringLength(2)]
        public string HEADER_MESSAGE_1 { get; set; }

        [Required]
        [StringLength(2)]
        public string HEAD_MESSAGE_2 { get; set; }

        [Required]
        [StringLength(2)]
        public string HEADER_MESSAGE_3 { get; set; }

        [Required]
        [StringLength(2)]
        public string HEADER_MESSAGE_4 { get; set; }

        [Required]
        [StringLength(1)]
        public string DESCRIPTION_IND { get; set; }

        [Required]
        public decimal DETAIL_LINE_NO_CTR { get; set; }

        [Required]
        [StringLength(1)]
        public string READ_LOCK_IND { get; set; }

        [Required]
        [StringLength(2)]
        public string RO_PRINT_IND { get; set; }

        [Required]
        [StringLength(2)]
        public string PT_PRINT_IND { get; set; }

        [Required]
        [StringLength(1)]
        public string ORDER_TYPE { get; set; }

        [Required]
        [StringLength(20)]
        public string AWB { get; set; }

        [Required]
        public decimal RELEASE_NUMBER { get; set; }

        [StringLength(10)]
        public string URGENCY { get; set; }

        [StringLength(25)]
        public string SHIP_ATTN { get; set; }

        [StringLength(25)]
        public string SHIP_PHONE { get; set; }

        [StringLength(25)]
        public string SHIP_FAX { get; set; }

        [StringLength(25)]
        public string BILL_ATTN { get; set; }

        [StringLength(25)]
        public string BILL_PHONE { get; set; }

        [StringLength(25)]
        public string BILL_FAX { get; set; }

        [StringLength(25)]
        public string RETURN_ATTN { get; set; }

        [StringLength(25)]
        public string RETURN_PHONE { get; set; }

        [StringLength(25)]
        public string RETURN_FAX { get; set; }

        [StringLength(2)]
        public string COMM_DEF_ORD_TYPE { get; set; }

        public int LAST_RELEASE_NO { get; set; }

        public uint CONTACT_ID { get; set; }

        [StringLength(1)]
        public string APPROVAL_STATUS { get; set; }
    }

}
