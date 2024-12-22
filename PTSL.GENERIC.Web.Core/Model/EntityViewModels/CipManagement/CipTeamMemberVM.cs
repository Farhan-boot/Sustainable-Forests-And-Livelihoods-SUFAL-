using PTSL.GENERIC.Web.Core.Helper.Enum.ForestManagement;
using PTSL.GENERIC.Web.Core.Model.EntityViewModels.Beneficiary;
using PTSL.GENERIC.Web.Core.Model.EntityViewModels.ForestManagement;
using PTSL.GENERIC.Web.Core.Model.GeneralSetup;

namespace PTSL.GENERIC.Web.Core.Model.EntityViewModels.CipManagement
{
    public class CipTeamMemberVM : BaseModel
    {
        //Fk
        public long CipTeamId { get; set; }
        public CipTeamVM? CipTeam { get; set; }

        //Other Info
        public long? CipId { get; set; }
        public CipVM? Cip { get; set; }

        //New Field add
        public string? DesignetionName { get; set; }
        public long? OtherCommitteeMemberId { get; set; }
        public OtherCommitteeMemberVM? OtherCommitteeMember { get; set; }
    }
}