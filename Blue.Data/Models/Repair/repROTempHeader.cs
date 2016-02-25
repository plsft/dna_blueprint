using System;
using System.Collections.Specialized;
using System.ComponentModel.DataAnnotations;
using Blue.Data.Extentions;
using Helix.Infra.Peta;
using Newtonsoft.Json;

namespace Blue.Data.Models.Repair
{
    [TableName("repROTempHeader")]
    public sealed class repROTempHeader : ModelBase<repROTempHeader>, IModel
    {
        [Ignore]
        public int ID { get; set; }

        [Required]
        [CompositeKeyColumn]
        public uint TEMP_HEADER_ID { get; set; }

        [StringLength(10)]
        public string RO_NUMBER { get; set; }

        [StringLength(2)]
        public string RO_TYPE { get; set; }

        public DateTime RO_DATE { get; set; }

        [StringLength(15)]
        public string URGENCY { get; set; }

        [StringLength(2)]
        public string REPAIR_TYPE { get; set; }

        [StringLength(9)]
        public string VENDOR_ID { get; set; }

        [StringLength(25)]
        public string SHIP_ATTN { get; set; }

        [StringLength(25)]
        public string SHIP_PHONE { get; set; }

        [StringLength(25)]
        public string SHIP_FAX { get; set; }

        [StringLength(3)]
        public string SHIP_METHOD { get; set; }

        public int RETURN_CODE { get; set; }

        [StringLength(25)]
        public string RETURN_ATTN { get; set; }

        [StringLength(25)]
        public string RETURN_PHONE { get; set; }

        [StringLength(25)]
        public string RETURN_FAX { get; set; }

        [StringLength(3)]
        public string RETURN_METHOD { get; set; }

        [StringLength(25)]
        public string BILL_ATTN { get; set; }

        [StringLength(25)]
        public string BILL_PHONE { get; set; }

        [StringLength(25)]
        public string BILL_FAX { get; set; }

        [StringLength(25)]
        public string BILL_TERMS { get; set; }

        [StringLength(40)]
        public string GROUP_NAME { get; set; }

        [StringLength(255)]
        public string ASSIGNED_TO { get; set; }

        [StringLength(3)]
        public string REPAIR_REFER_TO { get; set; }

        [StringLength(2)]
        public string HEADER_MESSAGE_1 { get; set; }

        [StringLength(2)]
        public string HEAD_MESSAGE_2 { get; set; }

        [StringLength(2)]
        public string HEADER_MESSAGE_3 { get; set; }

        [StringLength(2)]
        public string HEADER_MESSAGE_4 { get; set; }

        [StringLength(1)]
        public string DESCRIPTION_IND { get; set; }

        public int BILL_NETDAYS { get; set; }

        [StringLength(2)]
        public string COMM_DEF_ORD_TYPE { get; set; }

        public uint CONTACT_ID { get; set; }

    }
}
