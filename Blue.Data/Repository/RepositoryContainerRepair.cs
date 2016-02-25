
using System.Net.Sockets;
using Helix.Infra.Peta;
using Blue.Data.Infra;

namespace Blue.Data.Repositories
{
   public sealed class RepairRepositoryContainer
    {
        [TableName("VREPROX")] public sealed class VREPROXRepository : AppDataRepository, IRepository { }
        [TableName("VREROMS_DETAIL")] public sealed class VREROMS_DETAILRepository : AppDataRepository, IRepository { }
        [TableName("VREROMS_HEADER")] public sealed class VREROMS_HEADERRepository : AppDataRepository, IRepository { }
        [TableName("VREROMS_HEADER_DS_ADDR")] public sealed class VREROMS_HEADER_DS_ADDRRepository : AppDataRepository, IRepository { }
        [TableName("VRERRMS_DETAIL")] public sealed class VRERRMS_DETAILRepository : AppDataRepository, IRepository { }
        [TableName("VRERRMS_HEADER")] public sealed class VRERRMS_HEADERRepository : AppDataRepository, IRepository { }
        [TableName("VREVROX")] public sealed class VREVROXRepository : AppDataRepository, IRepository { }
        [TableName("CSTROINFPF")] public sealed class CSTROINFPFRepository : AppDataRepository, IRepository { }
        [TableName("repROCommentsTempDetail")] public sealed class repROCommentsTempDetailRepository : AppDataRepository, IRepository { }
        [TableName("repROCommentsTempHeader")] public sealed class repROCommentsTempHeaderRepository : AppDataRepository, IRepository { }
        [TableName("repROTempDetail")] public sealed class repROTempDetailRepository : AppDataRepository, IRepository { }
        [TableName("repROTempHeader")] public sealed class repROTempHeaderRepository : AppDataRepository, IRepository { }
    }
}
