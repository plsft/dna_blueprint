using System;
using System.Collections.Specialized;
using System.ComponentModel.DataAnnotations;
using Blue.Data.Extentions;
using Helix.Infra.Peta;
using Newtonsoft.Json;

namespace Blue.Data.Models.Repair
{

    [TableName("VRERRMS_HEADER")]
    public sealed class VRERRMS_HEADER : ModelBase<VRERRMS_HEADER>, IModel
    {
        [Ignore]
        public int ID { get; set; }

        [Required]
        [StringLength(17)]
        [CompositeKeyColumn]
        public string REQUEST_NUMBER { get; set; }

        [Required]
        [CompositeKeyColumn]
        public int REQUEST_LINE { get; set; }

        public DateTime DATE_CREATED { get; set; }

        public DateTime DATE_UPDATED { get; set; }

        public DateTime REQ_DATE { get; set; }

        [Required]
        [StringLength(3)]
        public string SALES_AGENT { get; set; }

        [Required]
        public int REVISION_NUMBER { get; set; }

        public DateTime REVISION_DATE { get; set; }

        [Required]
        [StringLength(2)]
        public string STATUS { get; set; }

        [Required]
        [StringLength(6)]
        public string CUST_NUMBER { get; set; }

        [Required]
        [StringLength(3)]
        public string CUST_SUFFIX { get; set; }

        [Required]
        [StringLength(12)]
        public string CUSTOMER_PO_NUMBER { get; set; }

        [Required]
        [StringLength(2)]
        public string PRINT_IND { get; set; }

        [Required]
        [StringLength(2)]
        public string HEADER_MSG_1 { get; set; }

        [Required]
        [StringLength(2)]
        public string HEADER_MSG_2 { get; set; }

        [Required]
        [StringLength(2)]
        public string HEADER_MSG_3 { get; set; }

        [Required]
        [StringLength(2)]
        public string HEADER_MSG_4 { get; set; }

        [Required]
        [StringLength(1)]
        public string DESCRIPTION_IND { get; set; }

        [Required]
        public int DETAIL_LINE_NO_CTR { get; set; }

        [Required]
        [StringLength(3)]
        public string REFER_TO { get; set; }

        [StringLength(10)]
        public string REQUEST_TYPE { get; set; }

        [StringLength(10)]
        public string URGENCY { get; set; }

        [StringLength(50)]
        public string COMMENTS { get; set; }

        [StringLength(10)]
        public string COMM_DEF_ORD_TYPE { get; set; }

    }


}