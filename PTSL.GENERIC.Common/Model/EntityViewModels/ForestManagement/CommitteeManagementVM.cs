using PTSL.GENERIC.Common.Entity.ApprovalLog;
using PTSL.GENERIC.Common.Entity.Beneficiary;
using PTSL.GENERIC.Common.Entity.ForestManagement;
using PTSL.GENERIC.Common.Entity.GeneralSetup;
using PTSL.GENERIC.Common.Enum.ForestManagement;
using PTSL.GENERIC.Common.Helper;
using PTSL.GENERIC.Common.Model.BaseModels;
using PTSL.GENERIC.Common.Model.EntityViewModels.Beneficiary;
using PTSL.GENERIC.Common.Model.EntityViewModels.GeneralSetup;
using System;
using System.Collections.Generic;
using System.Text;

namespace PTSL.GENERIC.Common.Model.EntityViewModels.ForestManagement
{
   public class CommitteeManagementVM : BaseModel
    {

        public string? Name { get; set; }
        public string? NameBn { get; set; }

        // Forest administration
        public long ForestCircleId { get; set; }
        [SwaggerExclude]
        public ForestCircleVM? ForestCircle { get; set; }
        public long ForestDivisionId { get; set; }
        [SwaggerExclude]
        public ForestDivisionVM? ForestDivision { get; set; }
        public long ForestRangeId { get; set; }
        [SwaggerExclude]
        public ForestRangeVM? ForestRange { get; set; }
        public long ForestBeatId { get; set; }
        [SwaggerExclude]
        public ForestBeatVM? ForestBeat { get; set; }
        public long ForestFcvVcfId { get; set; }
        public ForestFcvVcf? ForestFcvVcf { get; set; }

        // Civil administration
        public long DivisionId { get; set; }
        [SwaggerExclude]
        public DivisionVM? Division { get; set; }
        public long DistrictId { get; set; }
        [SwaggerExclude]
        public DistrictVM? District { get; set; }
        public long UpazillaId { get; set; }
        [SwaggerExclude]
        public UpazillaVM? Upazilla { get; set; }
        public long? UnionId { get; set; }
        [SwaggerExclude]
        public UnionVM? Union { get; set; }

        //Other Info
        public long NgoId { get; set; }
        [SwaggerExclude]
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
        [SwaggerExclude]
        public List<CommitteeManagementMember>? CommitteeManagementMembers { get; set; }

        // Approval
        public long? CommitteeApprovalStatus { get; set; }
        public long? CommitteeApprovalBy { get; set; }
        public DateTime? CommitteeApprovalDate { get; set; }


        // New Fild Add for new committee logic add
        public long? CommitteeTypeConfigurationId { get; set; }
        [SwaggerExclude]
        public CommitteeTypeConfiguration? CommitteeTypeConfiguration { get; set; }
        public long? CommitteesConfigurationId { get; set; }
        [SwaggerExclude]
        public CommitteesConfiguration? CommitteesConfiguration { get; set; }
        public long? CommitteeDesignationsConfigurationId { get; set; }
        [SwaggerExclude]
        public CommitteeDesignationsConfiguration? CommitteeDesignationsConfiguration { get; set; }

        //Approval Status
        public long? ApprovalStatus { get; set; }

        public List<ApprovalLogForCfm>? ApprovalLogForCfms { get; set; }

    }
}
