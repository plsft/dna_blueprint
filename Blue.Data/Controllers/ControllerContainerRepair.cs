using Blue.Data.Models.Repair;
using Blue.Data.Repositories;

namespace Blue.Data.Controllers
{
    public class ControllerContainerRepair
    {
        public sealed partial class VREROMS_DETAILController : GenericControllerBase<VREROMS_DETAIL>, IController<VREROMS_DETAIL>
        {
            public VREROMS_DETAILController() : base(new RepairRepositoryContainer.VREROMS_DETAILRepository(), "VREROMS_DETAIL") { }
        }

        public sealed partial class VREROMS_HEADERController : GenericControllerBase<VREROMS_HEADER>, IController<VREROMS_HEADER>
        {
            public VREROMS_HEADERController() : base(new RepairRepositoryContainer.VREROMS_HEADERRepository(), "VREROMS_HEADER") { }
        }
        public sealed partial class VRERRMS_DETAILController : GenericControllerBase<VRERRMS_DETAIL>, IController<VRERRMS_DETAIL>
        {
            public VRERRMS_DETAILController() : base(new RepairRepositoryContainer.VRERRMS_DETAILRepository(), "VRERRMS_DETAIL") { }
        }
        public sealed partial class VRERRMS_HEADERController : GenericControllerBase<VRERRMS_HEADER>, IController<VRERRMS_HEADER>
        {
            public VRERRMS_HEADERController() : base(new RepairRepositoryContainer.VRERRMS_HEADERRepository(), "VRERRMS_HEADER") { }
        }
        public sealed partial class VREVROXController : GenericControllerBase<VREVROX>, IController<VREVROX>
        {
            public VREVROXController() : base(new RepairRepositoryContainer.VREVROXRepository(), "VREVROX") { }
        }
        public sealed partial class VREPROXController : GenericControllerBase<VREPROX>, IController<VREPROX>
        {
            public VREPROXController() : base(new RepairRepositoryContainer.VREPROXRepository(), "VREPROX") { }
        }
        public sealed partial class VREROMS_HEADER_DS_ADDRController : GenericControllerBase<VREROMS_HEADER_DS_ADDR>, IController<VREROMS_HEADER_DS_ADDR>
        {
            public VREROMS_HEADER_DS_ADDRController() : base(new RepairRepositoryContainer.VREROMS_HEADER_DS_ADDRRepository(), "VREROMS_HEADER_DS_ADDR") { }
        }
        public sealed partial class CSTROINFPFController : GenericControllerBase<CSTROINFPF>, IController<CSTROINFPF>
        {
            public CSTROINFPFController() : base(new RepairRepositoryContainer.CSTROINFPFRepository(), "CSTROINFPF") { }
        }
        public sealed partial class repROCommentsTempDetailController : GenericControllerBase<repROCommentsTempDetail>, IController<repROCommentsTempDetail>
        {
            public repROCommentsTempDetailController() : base(new RepairRepositoryContainer.repROCommentsTempDetailRepository(), "repROCommentsTempDetail") { }
        }
        public sealed partial class repROCommentsTempHeaderController : GenericControllerBase<repROCommentsTempHeader>, IController<repROCommentsTempHeader>
        {
            public repROCommentsTempHeaderController() : base(new RepairRepositoryContainer.repROCommentsTempHeaderRepository(), "repROCommentsTempHeader") { }
        }
        public sealed partial class repROTempDetailController : GenericControllerBase<repROTempDetail>, IController<repROTempDetail>
        {
            public repROTempDetailController() : base(new RepairRepositoryContainer.repROTempDetailRepository(), "repROTempDetail") { }
        }
        public sealed partial class repROTempHeaderController : GenericControllerBase<repROTempHeader>, IController<repROTempHeader>
        {
            public repROTempHeaderController() : base(new RepairRepositoryContainer.repROTempHeaderRepository(), "repROTempHeader") { }
        }
    }
}
