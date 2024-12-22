using PTSL.GENERIC.Web.Core.Helper.Enum.ForestManagement;
using PTSL.GENERIC.Web.Core.Model.EntityViewModels.Beneficiary;
using PTSL.GENERIC.Web.Core.Model.GeneralSetup;

namespace PTSL.GENERIC.Web.Core.Model.EntityViewModels.ForestManagement
{
    public class CommitteeManagementMemberVM : BaseModel
    {
        public string? Name { get; set; }
        public string? NameBn { get; set; }
        //Fk
        public long CommitteeManagementId { get; set; }
        public CommitteeManagementVM? CommitteeManagement { get; set; }

        //Other Info
        public long? CommitteeDesignationId { get; set; }
        public CommitteeDesignationVM? CommitteeDesignation { get; set; }
        public long? SurveyId { get; set; }
        public SurveyVM? Survey { get; set; }
        public long? OtherCommitteeMemberId { get; set; }
        public OtherCommitteeMemberVM? OtherCommitteeMember { get; set; }

        public long? CommitteeDesignationsConfigurationId { get; set; }
        public CommitteeDesignationsConfigurationVM? CommitteeDesignationsConfiguration { get; set; }
    }
}