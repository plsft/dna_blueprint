using System;
using System.Collections.Specialized;
using System.ComponentModel.DataAnnotations;
using Blue.Data.Extentions;
using Helix.Infra.Peta;
using Newtonsoft.Json;

namespace Blue.Data.Models.Repair
{
    [TableName("repROCommentsTempDetail")]
    public sealed class repROCommentsTempDetail : ModelBase<repROCommentsTempDetail>, IModel
    {
        [Ignore]
        public int ID { get; set; }

        [Required]
        [CompositeKeyColumn]
        public uint TEMP_DETAIL_ID { get; set; }

        [Required]
        [CompositeKeyColumn]
        public uint TEMP_HEADER_ID { get; set; }

        [Required]
        [CompositeKeyColumn]
        public int LINE { get; set; }

        [StringLength(40)]
        public string VALUE { get; set; }

        [StringLength(1)]
        public string INTERNAL_ONLY { get; set; }

    }
}
