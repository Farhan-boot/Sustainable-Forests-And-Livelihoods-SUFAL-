using System;

using PTSL.GENERIC.Common.Entity.CommonEntity;
using PTSL.GENERIC.Common.Entity.GeneralSetup;
using PTSL.GENERIC.Common.Enum.AccountManagement;

namespace PTSL.GENERIC.Common.Entity.AccountManagement;

public class AccountDeposit : BaseEntity
{
    public long AccountId { get; set; }
    public Account? Account { get; set; }

    public long FinancialYearId { get; set; }
    public FinancialYear? FinancialYear { get; set; }

    public long SourceOfFundId { get; set; }
    public SourceOfFund? SourceOfFund { get; set; }

    public DateTime DepositDate { get; set; }
    public double DepositAmount { get; set; }
    public DateTime DepositTransactionTime { get; set; } // Created time

    public long TransactionById { get; set; }
    public User? TransactionBy { get; set; }

    public AccountDepositStatus AccountDepositStatus { get; set; }
    public AccountDepositApprovalProcess AccountDepositApprovalProcess { get; set; }

    // Next approval
    public long? NextApprovalUserId { get; set; }
    public User? NextApprovalUser { get; set; }
    public long? NextApprovalUserRoleId { get; set; }
    public UserRole? NextApprovalUserRole { get; set; }
    public long? NextApprovalOrderNo { get; set; }
    // Next approval

    public List<AccountDepositApproval>? AccountDepositApprovals { get; set; }

    public string? Remarks { get; set; }

    public static bool IsStatusPending(AccountDepositStatus status) => status == AccountDepositStatus.Pending || status == AccountDepositStatus.PendingModified;
}
