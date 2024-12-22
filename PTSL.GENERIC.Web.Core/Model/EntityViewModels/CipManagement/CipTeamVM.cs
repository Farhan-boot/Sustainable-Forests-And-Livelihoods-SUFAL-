using PTSL.GENERIC.Web.Core.Helper.Enum.ForestManagement;
using PTSL.GENERIC.Web.Core.Model.EntityViewModels.ApprovalLog;
using PTSL.GENERIC.Web.Core.Model.EntityViewModels.Beneficiary;
using PTSL.GENERIC.Web.Core.Model.GeneralSetup;

namespace PTSL.GENERIC.Web.Core.Model.EntityViewModels.CipManagement
{
    public class CipTeamVM : BaseModel
    {
        // Forest administration
        public long ForestCircleId { get; set; }
        public ForestCircleVM? ForestCircle { get; set; }
        public long ForestDivisionId { get; set; }
        public ForestDivisionVM? ForestDivision { get; set; }
        public long ForestRangeId { get; set; }
        public ForestRangeVM? ForestRange { get; set; }
        public long ForestBeatId { get; set; }
        public ForestBeatVM? ForestBeat { get; set; }
        public long ForestFcvVcfId { get; set; }
        public ForestFcvVcfVM? ForestFcvVcf { get; set; }

        // Civil administration
        public long DivisionId { get; set; }
        public DivisionVM? Division { get; set; }
        public long DistrictId { get; set; }
        public DistrictVM? District { get; set; }
        public long UpazillaId { get; set; }
        public UpazillaVM? Upazilla { get; set; }
        public long UnionId { get; set; }
        public UnionVM? Union { get; set; }
        public long NgoId { get; set; }
        public NgoVM? Ngo { get; set; }

        //Other Info
        public string? TeamName { get; set; }
        public string? DocumentUrl { get; set; }
        public string? Remark { get; set; }
        public List<CipTeamMemberVM>? CipTeamMembers { get; set; }

        public string? CipTeamMembersJson { get; set; }

        //Approval Status
        public long? ApprovalStatus { get; set; }
        public List<ApprovalLogForCfmVM>? ApprovalLogForCfms { get; set; }
        public string? ApprovalStatusText { get; set; }

    }
}