using System;

using PTSL.GENERIC.Common.Entity.CommonEntity;
using PTSL.GENERIC.Common.Entity.GeneralSetup;
using PTSL.GENERIC.Common.Enum.AccountManagement;

namespace PTSL.GENERIC.Common.Entity.AccountManagement;

public class AccountTransfer : BaseEntity
{
    public long FromAccountId { get; set; }
    public Account? FromAccount { get; set; }

    public long ToAccountId { get; set; }
    public Account? ToAccount { get; set; }

    public long FinancialYearId { get; set; }
    public FinancialYear? FinancialYear { get; set; }

    public DateTime TransferDate { get; set; }
    public double TransferAmount { get; set; }

    public AccountTransferStatus AccountTransferStatus { get; set; }
    public AccountTransferApprovalProcess AccountTransferApprovalProcess { get; set; }
    public DateTime TransferTransactionTime { get; set; } // Created time

    public long TransferRequestedById { get; set; }
    public User? TransferRequestedBy { get; set; }

    public string? Remarks { get; set; }

    // Next approval
    public long? NextApprovalUserId { get; set; }
    public User? NextApprovalUser { get; set; }
    public long? NextApprovalUserRoleId { get; set; }
    public UserRole? NextApprovalUserRole { get; set; }
    public long? NextApprovalOrderNo { get; set; }
    // Next approval

    public List<AccountTransferDetails>? AccountTransferDetails { get; set; }
    public List<AccountTransferLog>? AccountTransferLogs { get; set; }
    public List<AccountTransferApproval>? AccountTransferApprovals { get; set; }

    public static bool IsStatusPending(AccountTransferStatus status) => status == AccountTransferStatus.Pending || status == AccountTransferStatus.PendingModified;

    public static (bool isSuccess, string? errorMessage) AcceptTransfer(ref Account fromAccount, ref Account toAccount, double amount)
    {
        fromAccount.CurrentBlockAmount -= amount;
        if (fromAccount.CurrentBlockAmount < 0)
        {
            return (false, "From account does not have enough available balance");
        }

        fromAccount.CurrentAccountBalance -= amount;
        if (fromAccount.CurrentAvailableBalance < 0)
        {
            return (false, "From account does not have enough available balance");
        }

        toAccount.CurrentAccountBalance += amount;
        return (true, null);
    }

    public static (bool isSuccess, string? errorMessage) Cancel(ref Account fromAccount, double amount)
    {
        fromAccount.CurrentBlockAmount -= amount;
        if (fromAccount.CurrentBlockAmount < 0)
        {
            return (false, "From account does not have enough available balance");
        }

        return (true, null);
    }

    public static (bool isSuccess, string? errorMessage) RollbackTransfer(ref Account fromAccount, ref Account toAccount, double amount)
    {
        toAccount.CurrentAccountBalance -= amount;
        if (toAccount.CurrentAvailableBalance < 0)
        {
            return (false, "To account does not have enough available balance");
        }

        fromAccount.CurrentAccountBalance += amount;

        return (true, null);
    }
}
