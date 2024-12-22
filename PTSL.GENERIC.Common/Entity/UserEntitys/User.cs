using System.Collections.Generic;

using PTSL.GENERIC.Common.Entity.AccountManagement;
using PTSL.GENERIC.Common.Entity.AIG;
using PTSL.GENERIC.Common.Entity.ApprovalLog;
using PTSL.GENERIC.Common.Entity.Beneficiary;
using PTSL.GENERIC.Common.Entity.CommonEntity;
using PTSL.GENERIC.Common.Entity.GeneralSetup;
using PTSL.GENERIC.Common.Entity.PermissionSettings;

namespace PTSL.GENERIC.Common.Entity
{
    public class User : BaseEntity
    {
        public List<BankAccountsInformation>? BankAccountsInformations { get; set; }
        public string? FirstName { get; set; }
        public string? LastName { get; set; }
        public string? RoleName { get; set; }
        public string? UserName { get; set; }
        public string? UserEmail { get; set; }
        public string? UserPassword { get; set; }
        public string? ImageUrl { get; set; }
        public string? UserPhone { get; set; }
        public string? UserGroup { get; set; }
        public int UserStatus { get; set; }

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

        public long? SurveyId { get; set; }
        public Survey? Survey { get; set; }

        public List<RepaymentLDFHistory>? RepaymentLDFHistories { get; set; }
        public List<GroupLDFInfoForm>? GroupLDFInfoForms { get; set; }
        public List<Survey>? Surveys { get; set; }

        public long? UserRoleId { get; set; }
        public UserRole? UserRole { get; set; }

        public UserType UserType { get; set; }
        public List<PermissionHeaderSettings>? PermissionHeaderSettings { get; set; }
        public List<PermissionRowSettings>? PermissionRowSettings { get; set; }
        public List<ApprovalLogForCfm>? ApprovalLogForCfmsSender { get; set; }
        public List<ApprovalLogForCfm>? ApprovalLogForCfmsReceiver { get; set; }

        // Map To Account into User
        public long? AccountsId { get; set; }
        public Account? Accounts { get; set; }

        public List<AccountsUserTagLog>? AccountsUserTagLogs { get; set; }
        public List<AccountDeposit>? AccountDeposits { get; set; }
        public List<AccountTransfer>? AccountTransfers { get; set; }
        public List<AccountTransferLog>? AccountTransferLogs { get; set; }
    }

    public class UserDropdownVM
    {
        public long Id { get; set; }
        public string? UserName { get; set; }
        public string? UserEmail { get; set; }
    }
}
