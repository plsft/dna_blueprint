using System;
using System.Collections.Specialized;
using System.ComponentModel.DataAnnotations;
using Blue.Data.Extentions;
using Helix.Infra.Peta;
using Newtonsoft.Json;

namespace Blue.Data.Models.Repair
{
    [TableName("VREROMS_DETAIL")]
    public sealed class VREROMS_DETAIL : ModelBase<VREROMS_DETAIL>, IModel
    {
        [Ignore]
        public int ID { get; set; }

        [Required]
        [StringLength(10)]
        [CompositeKeyColumn]
        public string REPAIR_ORDER_NO { get; set; }

        [Required]
        [CompositeKeyColumn]
        public decimal REPAIR_ORDER_LINE { get; set; }

        public DateTime DATE_CREATED { get; set; }

        public DateTime DATE_UPDATED { get; set; }

        [Required]
        public decimal REVISION_NUMBER { get; set; }

        [Required]
        [StringLength(17)]
        public string REQUEST_NUMBER { get; set; }

        [Required]
        [StringLength(4)]
        public string REQUEST_LINE { get; set; }

        [Required]
        [StringLength(4)]
        public string COPS_LINE { get; set; }

        [Required]
        [StringLength(13)]
        public string CUSTOMER_PO_NO { get; set; }

        [Required]
        [StringLength(6)]
        public string CUST_NUMBER { get; set; }

        [Required]
        [StringLength(3)]
        public string CUST_SUFFIX { get; set; }

        [Required]
        [StringLength(2)]
        public string LINE_STATUS { get; set; }

        [Required]
        public decimal PARENT_LINE { get; set; }

        public DateTime REVISION_DATE { get; set; }

        [Required]
        [StringLength(2)]
        public string REPAIR_TYPE { get; set; }

        [Required]
        [StringLength(1)]
        public string TEARDOWN_COMPL_IND { get; set; }

        [Required]
        [StringLength(1)]
        public string QC_HOLD_IND { get; set; }

        [Required]
        [StringLength(1)]
        public string AP_HOLD_IND { get; set; }

        [Required]
        [StringLength(6)]
        public string CONTROL_NUMBER { get; set; }

        [Required]
        [StringLength(25)]
        public string ORIG_PART_NUMBER { get; set; }

        [StringLength(3)]
        public string ORIG_PART_SUFFIX { get; set; }

        [Required]
        [StringLength(2)]
        public string ORIGINAL_CONDITION { get; set; }

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
        [StringLength(20)]
        public string RO_SERIAL_NUMBER { get; set; }

        [Required]
        public decimal ORIG_QUANTITY { get; set; }

        [Required]
        public decimal CONSUMABLE_XREF { get; set; }

        [Required]
        [StringLength(25)]
        public string EXPT_PART_NUMBER { get; set; }

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

        [StringLength(20)]
        public string EXPT_SER_NUMBER { get; set; }

        public decimal EXPT_QUANTITY { get; set; }

        [Required]
        [StringLength(1)]
        public string DISPOSITION { get; set; }

        [Required]
        public decimal ASSIGNED_VALUE { get; set; }

        [Required]
        public decimal EST_COST { get; set; }

        [Required]
        public decimal ACT_COST { get; set; }

        [Required]
        [StringLength(1)]
        public string TYPE_OF_CHARGE { get; set; }

        [Required]
        public decimal CUMM_COST { get; set; }

        [Required]
        public float MARKET_VALUE { get; set; }

        [Required]
        public decimal INVT_REP_COST { get; set; }

        [Required]
        public decimal INVT_AQUI_COST { get; set; }

        [Required]
        public decimal CURR_PARTS_COST { get; set; }

        [Required]
        public decimal CURR_LABOR_COST { get; set; }

        [Required]
        public decimal CURR_FREIGHT_COST { get; set; }

        [Required]
        public decimal CURR_OTHER_COST { get; set; }

        [Required]
        public decimal CUMM_PARTS_COST { get; set; }

        [Required]
        public decimal CUMM_LABOR_COST { get; set; }

        [Required]
        public decimal CUMM_FREIGHT_COST { get; set; }

        [Required]
        public decimal CUMM_OTHER_COST { get; set; }

        [Required]
        public decimal RECEIPT_QUANTITY { get; set; }

        [Required]
        [StringLength(1)]
        public string DROP_SHIP_IND { get; set; }

        [Required]
        [StringLength(3)]
        public string SHIPPER_ID { get; set; }

        [Required]
        [StringLength(3)]
        public string CARRIER { get; set; }

        [Required]
        public decimal RELEASE_NUMBER { get; set; }

        [Required]
        public decimal FREIGHT { get; set; }

        [Required]
        [StringLength(24)]
        public string AWB { get; set; }

        [Required]
        [StringLength(10)]
        public string FLIGHT { get; set; }

        [Required]
        public decimal PIECES_SHIPPED { get; set; }

        [Required]
        [StringLength(20)]
        public string INVOICE_NUMBER { get; set; }

        [Required]
        public decimal WEIGHT { get; set; }

        [Required]
        [StringLength(1)]
        public string FINAL_INVOICE_IND { get; set; }

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
        [StringLength(1)]
        public string QC_ACCEPT_IND { get; set; }

        [Required]
        [StringLength(1)]
        public string QC_REJECT_IND { get; set; }

        [Required]
        public decimal QTY_RETURNED { get; set; }

        [Required]
        [StringLength(1)]
        public string QC_APPROVER_ID { get; set; }

        [Required]
        [StringLength(15)]
        public string COPS_COMMENTS { get; set; }

        [Required]
        [StringLength(25)]
        public string QC_COMMENTS { get; set; }

        [Required]
        [StringLength(5)]
        public string DELETE_USERID { get; set; }

        [Required]
        [StringLength(7)]
        public string COPS_ORD_NO { get; set; }

        [Required]
        public decimal NO_OF_RETURNS { get; set; }

        [Required]
        [StringLength(6)]
        public string SOURCE { get; set; }

        [Required]
        [StringLength(1)]
        public string OUT_ON_REPAIR { get; set; }

        [Required]
        public decimal ORIG_QUOTE { get; set; }

        [Required]
        public decimal LAST_QUOTE { get; set; }

        [Required]
        public decimal ORIG_LINE { get; set; }

        [Required]
        public decimal LINE_SPLIT_TO { get; set; }

        [Required]
        [StringLength(2)]
        public string TYPE_CLASS { get; set; }

        [Required]
        [StringLength(1)]
        public string CUST_PROP { get; set; }

        [Required]
        [StringLength(2)]
        public string ORIG_REPAIR_TYPE { get; set; }

        public DateTime PROMISE_DATE { get; set; }

        [Required]
        [StringLength(7)]
        public string DUE_ORD_NO { get; set; }

        [Required]
        public decimal DUE_ORD_LINE { get; set; }

        [Required]
        [StringLength(1)]
        public string COST_CHANGE_FLAG { get; set; }

        [Required]
        public decimal PREV_LAST_QUOTE { get; set; }

        public DateTime NEXT_REVW_DATE { get; set; }

        public DateTime RECEIPT_DATE { get; set; }

        public DateTime SHIP_DATE { get; set; }

        public DateTime INVOICE_DATE { get; set; }

        public DateTime DATE_RETURNED { get; set; }

        public DateTime DATE_CANCELLED { get; set; }

        [StringLength(1)]
        public string OFF_UNIT_EXPT_IND { get; set; }

        public DateTime VEN_INIT_PROM_DATE { get; set; }

        public DateTime NEXT_FOLLOWUP_DATE { get; set; }

        public DateTime VEN_UPDT_PROM_DATE { get; set; }

        public DateTime LAST_CONTACT_DATE { get; set; }

        [StringLength(1)]
        public string CUSTOMER_APPROVED { get; set; }

        [StringLength(1)]
        public string LINE_TYPE { get; set; }

        public DateTime LAST_QUOTE_DATE { get; set; }

        public DateTime CUST_APPROVED_DATE { get; set; }

        [StringLength(1)]
        public string BENCH_CHECK { get; set; }

    }
}