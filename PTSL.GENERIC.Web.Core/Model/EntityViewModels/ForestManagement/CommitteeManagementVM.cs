using PTSL.GENERIC.Web.Core.Helper.Enum.ForestManagement;
using PTSL.GENERIC.Web.Core.Model.EntityViewModels.ApprovalLog;
using PTSL.GENERIC.Web.Core.Model.EntityViewModels.Beneficiary;
using PTSL.GENERIC.Web.Core.Model.GeneralSetup;

namespace PTSL.GENERIC.Web.Core.Model.EntityViewModels.ForestManagement
{
    public class CommitteeManagementVM : BaseModel
    {

        public string? Name { get; set; }
        public string? NameBn { get; set; }

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
        public long? UnionId { get; set; }
 
        public UnionVM? Union { get; set; }

        //Other Info
        public long NgoId { get; set; }
  
        public NgoVM? Ngo { get; set; }
        public CommitteeType CommitteeTypeId { get; set; }
        public SubCommitteeType? SubCommitteeTypeId { get; set; }
        public DateTime CommitteeFormDate { get; set; }
        public DateTime CommitteeEndDate { get; set; }

        //Bank Info
        public string? NameOfBankAC { get; set; }
        public string? AccountNumber { get; set; }
        public string? AccountType { get; set; }
        public string? BankName { get; set; }
        public string? BranchName { get; set; }
        public DateTime? AccountOpeningDate { get; set; }
        public string? Remark { get; set; }
        public bool IsInActiveCommittee { get; set; }
        public string? CommitteeManagementMembersJson { get; set; }
        
        public List<CommitteeManagementMemberVM>? CommitteeManagementMembers { get; set; }

        // Approval
        public long? CommitteeApprovalStatus { get; set; }
        public long? CommitteeApprovalBy { get; set; }
        public DateTime? CommitteeApprovalDate { get; set; }

        public string CommitteeTypeName { get; set; }

        // New Fild Add for new committee logic add
        public long? CommitteeTypeConfigurationId { get; set; }
        public CommitteeTypeConfigurationVM? CommitteeTypeConfiguration { get; set; }
        public long? CommitteesConfigurationId { get; set; }
        public CommitteesConfigurationVM? CommitteesConfiguration { get; set; }
        public long? CommitteeDesignationsConfigurationId { get; set; }
        public CommitteeDesignationsConfigurationVM? CommitteeDesignationsConfiguration { get; set; }

        //Approval Status
        public long? ApprovalStatus { get; set; }

        public List<ApprovalLogForCfmVM>? ApprovalLogForCfms { get; set; }

        //BackEndSite page
        public string? CommitteeApprovalStatusNmae { get; set; }

    }
}