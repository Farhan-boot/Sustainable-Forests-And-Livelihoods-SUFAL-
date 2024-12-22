using PTSL.GENERIC.Web.Core.Helper.Enum.ApprovalLog;
using PTSL.GENERIC.Web.Core.Helper.Enum.ForestManagement;
using PTSL.GENERIC.Web.Core.Model.EntityViewModels.Beneficiary;
using PTSL.GENERIC.Web.Core.Model.EntityViewModels.CipManagement;
using PTSL.GENERIC.Web.Core.Model.EntityViewModels.ForestManagement;
using PTSL.GENERIC.Web.Core.Model.EntityViewModels.InternalLoan;
using PTSL.GENERIC.Web.Core.Model.EntityViewModels.SystemUser;
using PTSL.GENERIC.Web.Core.Model.GeneralSetup;

namespace PTSL.GENERIC.Web.Core.Model.EntityViewModels.ApprovalLog
{
    public class ApprovalLogForCfmVM : BaseModel
    {
        public long? SenderId { get; set; }
        public UserVM? Sender { get; set; }

        public long? ReceiverId { get; set; }
        public UserVM? Receiver { get; set; }

        public DateTime? SendingDate { get; set; }
        public DateTime? SendingTime { get; set; }
        public string? Remark { get; set; }

        //Other Table Relation
        public long? CipId { get; set; }
        public CipVM? Cip { get; set; }
        public long? CipTeamId { get; set; }
        public CipTeamVM? CipTeam { get; set; }
        public long? BeneficiaryProfileId { get; set; }
        public SurveyVM? BeneficiaryProfile { get; set; }
        public long? CommitteeManagementId { get; set; }
        public CommitteeManagementVM? CommitteeManagement { get; set; }
        public long? InternalLoanInformationId { get; set; }
        public InternalLoanInformationVM? InternalLoanInformation { get; set; }
        public ApprovalLogForCfmStatus? ApprovalStatusId { get; set; }

        //New Fild add
        public long? SenderRoleId { get; set; }
        public UserRoleVM? SenderRole { get; set; }
        public long? ReceiverRoleId { get; set; }
        public UserRoleVM? ReceiverRole { get; set; }
    }
}