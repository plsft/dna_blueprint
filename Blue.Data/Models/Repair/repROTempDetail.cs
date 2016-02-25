using System;
using System.Collections.Specialized;
using System.ComponentModel.DataAnnotations;
using Blue.Data.Extentions;
using Helix.Infra.Peta;
using Newtonsoft.Json;

namespace Blue.Data.Models.Repair
{
    [TableName("repROTempDetail")]
    public sealed class repROTempDetail : ModelBase<repROTempDetail>, IModel
    {
        [Ignore]
        public int ID { get; set; }

        [Required]
        [CompositeKeyColumn]
        public uint TEMP_DETAIL_ID { get; set; }

        [Required]
        public uint TEMP_HEADER_ID { get; set; }

        [Required]
        [StringLength(17)]
        public string REQUEST_NUMBER { get; set; }

        [Required]
        public int REQUEST_LINE { get; set; }

        [StringLength(2)]
        public string REPAIR_TYPE { get; set; }

        [StringLength(25)]
        public string EXPT_PART_NUMBER { get; set; }

        [StringLength(3)]
        public string EXPT_PART_SUFFIX { get; set; }

        public int EXPT_QUANTITY { get; set; }

        [StringLength(2)]
        public string EXPT_CONDITION { get; set; }

        [StringLength(1)]
        public string EXPT_BENCH_TEST { get; set; }

        [StringLength(2)]
        public string EXPT_WAREHOUSE { get; set; }

        [StringLength(20)]
        public string EXPT_SERIAL { get; set; }

        [StringLength(5)]
        public string EXPT_OWNER { get; set; }

        [StringLength(25)]
        public string ORIG_PART_NUMBER { get; set; }

        [StringLength(3)]
        public string ORIG_PART_SUFFIX { get; set; }

        [StringLength(20)]
        public string ORIG_SER_NUMBER { get; set; }

        [StringLength(5)]
        public string ORIG_OWNER_CODE { get; set; }

        [StringLength(2)]
        public string ORIG_CONDITION { get; set; }

        public int ORIG_QUANTITY { get; set; }

        [StringLength(2)]
        public string ORIG_WAREHOUSE { get; set; }

        [StringLength(7)]
        public string COPS_ORD_NO { get; set; }

        public int COPS_LINE { get; set; }

        [StringLength(6)]
        public string CUST_NUMBER { get; set; }

        [StringLength(3)]
        public string CUST_SUFFIX { get; set; }

        [StringLength(25)]
        public string CUSTOMER_RO_NO { get; set; }

        [StringLength(13)]
        public string CUSTOMER_PO_NO { get; set; }

        [StringLength(25)]
        public string AIRCRAFT_TAIL_NO { get; set; }

        [StringLength(25)]
        public string WORK_STATUS { get; set; }

        [StringLength(1)]
        public string CORE_UNIT { get; set; }

        public DateTime DATE_QUOTED { get; set; }

        public DateTime DATE_APPROVED { get; set; }

        public DateTime ESTIMATED_DELIV_DATE { get; set; }

        public DateTime REQUIRED_DELIV_DATE { get; set; }

        [StringLength(25)]
        public string RMA_NUMBER { get; set; }

        public float EST_COST { get; set; }

        [StringLength(2)]
        public string DETAIL_MESSAGE_1 { get; set; }

        [StringLength(2)]
        public string DETAIL_MESSAGE_2 { get; set; }

        [StringLength(2)]
        public string DETAIL_MESSAGE_3 { get; set; }

        [StringLength(2)]
        public string DETAIL_MESSAGE_4 { get; set; }

        [StringLength(1)]
        public string DROP_SHIP_IND { get; set; }

        [StringLength(2)]
        public string LINE_STATUS { get; set; }

        [StringLength(255)]
        public string ASSIGNED_TO { get; set; }

        [StringLength(40)]
        public string REQUEST_GROUP { get; set; }

        public decimal MARKET_VALUE { get; set; }

        [StringLength(5)]
        public string C_WORK_STATUS { get; set; }

        [StringLength(20)]
        public string C_CUST_RO_NO { get; set; }

        [StringLength(20)]
        public string C_CUST_PO_NO { get; set; }

        [StringLength(20)]
        public string C_CUST_ADDR1 { get; set; }

        [StringLength(20)]
        public string C_CUST_ADDR2 { get; set; }

        [StringLength(20)]
        public string C_CUST_ADDR3 { get; set; }

        [StringLength(1)]
        public string C_WARRANTY { get; set; }

        [StringLength(1)]
        public string C_CORE_UNIT { get; set; }

        public DateTime C_DATE_QUOTED { get; set; }

        public DateTime C_DATE_APPROVED { get; set; }

        public DateTime C_EST_DATE { get; set; }

        public DateTime C_REQ_DATE { get; set; }

        [StringLength(20)]
        public string C_TAIL_NO { get; set; }

        public DateTime VEN_INIT_PROM_DATE { get; set; }

        public DateTime NEXT_FOLLOWUP_DATE { get; set; }

        [StringLength(1)]
        public string LINE_TYPE { get; set; }

    }
}
