using PTSL.GENERIC.Common.Entity.ApprovalLog;
using PTSL.GENERIC.Common.Entity.Beneficiary;
using PTSL.GENERIC.Common.Entity.CommonEntity;
using PTSL.GENERIC.Common.Entity.GeneralSetup;
using PTSL.GENERIC.Common.Enum.ForestManagement;

using System;
using System.Collections.Generic;
using System.Text;

namespace PTSL.GENERIC.Common.Entity.ForestManagement
{
   public class CommitteeManagement : BaseEntity
    {
        public List<ApprovalLogForCfm>? ApprovalLogForCfms { get; set; }
        public string? Name { get; set; }
        public string? NameBn { get; set; }

        // Forest administration
        public long? ForestCircleId { get; set; }
        public ForestCircle? ForestCircle { get; set; }
        public long? ForestDivisionId { get; set; }
        public ForestDivision? ForestDivision { get; set; }
        public long? ForestRangeId { get; set; }
        public ForestRange? ForestRange { get; set; }
        public long? ForestBeatId { get; set; }
        public ForestBeat? ForestBeat { get; set; }
        public long? ForestFcvVcfId { get; set; }
        public ForestFcvVcf? ForestFcvVcf { get; set; }

        // Civil administration
        public long? DivisionId { get; set; }
        public Division? Division { get; set; }
        public long? DistrictId { get; set; }
        public District? District { get; set; }
        public long? UpazillaId { get; set; }
        public Upazilla? Upazilla { get; set; }
        public long? UnionId { get; set; }
        public Union? Union { get; set; }

        //Other Info
        public long? NgoId { get; set; }
        public Ngo? Ngo { get; set; }
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

        public List<CommitteeManagementMember>? CommitteeManagementMembers { get; set; }

        // Approval
        public long? CommitteeApprovalStatus { get; set; }
        public long? CommitteeApprovalBy { get; set; }
        public DateTime? CommitteeApprovalDate { get; set; }


        // New Fild Add for new committee logic add
        public long? CommitteeTypeConfigurationId { get; set; }
        public CommitteeTypeConfiguration? CommitteeTypeConfiguration { get; set; }
        public long? CommitteesConfigurationId { get; set; }
        public CommitteesConfiguration? CommitteesConfiguration { get; set; }
        public long? CommitteeDesignationsConfigurationId { get; set; }
        public CommitteeDesignationsConfiguration? CommitteeDesignationsConfiguration { get; set; }

        //Approval Status
        public long? ApprovalStatus { get; set; }
    }
}
