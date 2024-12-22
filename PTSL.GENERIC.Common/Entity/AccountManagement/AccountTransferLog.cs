using System;

using PTSL.GENERIC.Common.Entity.CommonEntity;
using PTSL.GENERIC.Common.Enum.AccountManagement;

namespace PTSL.GENERIC.Common.Entity.AccountManagement;

public class AccountTransferLog : BaseEntity
{
    public long AccountTransferId { get; set; }
    public AccountTransfer? AccountTransfer { get; set; }

    public long? AccountTransferDetailsId { get; set; } // Not needed
    public AccountTransferDetails? AccountTransferDetails { get; set; } // Not needed
    public double? AmountChangedFrom { get; set; }
    public double? AmountChangedTo { get; set; }

    public long TransferStatusChangedById { get; set; }
    public User? TransferStatusChangedBy { get; set; }

    public AccountTransferStatus AccountTransferStatus { get; set; }
    public DateTime StatusCreatedDate { get; set; }

    public static AccountTransferLog CreateForNewTransfer(AccountTransfer accountTransfer, long userId)
    {
        return new AccountTransferLog
        {
            AccountTransferId = accountTransfer.Id,
            TransferStatusChangedById = userId,
            AccountTransferStatus = accountTransfer.AccountTransferStatus,
            StatusCreatedDate = DateTime.Now,
        };
    }

    public static AccountTransferLog CreateForApproveTransfer(AccountTransfer accountTransfer, long userId)
    {
        return new AccountTransferLog
        {
            AccountTransferId = accountTransfer.Id,
            TransferStatusChangedById = userId,
            AccountTransferStatus = AccountTransferStatus.Accepted,
            StatusCreatedDate = DateTime.Now,
        };
    }

    public static AccountTransferLog CreateForCancelTransfer(AccountTransfer accountTransfer, long userId)
    {
        return new AccountTransferLog
        {
            AccountTransferId = accountTransfer.Id,
            TransferStatusChangedById = userId,
            AccountTransferStatus = AccountTransferStatus.Cancel,
            StatusCreatedDate = DateTime.Now,
        };
    }

    public static AccountTransferLog CreateForRollbackTransfer(AccountTransfer accountTransfer, long userId)
    {
        return new AccountTransferLog
        {
            AccountTransferId = accountTransfer.Id,
            TransferStatusChangedById = userId,
            AccountTransferStatus = AccountTransferStatus.Rollback,
            StatusCreatedDate = DateTime.Now,
        };
    }

    public static AccountTransferLog CreateForModifyTransfer(AccountTransfer currentAccountTransfer, long userId, AccountTransfer newAccountTransfer)
    {
        return new AccountTransferLog
        {
            AccountTransferId = currentAccountTransfer.Id,
            TransferStatusChangedById = userId,
            AmountChangedFrom = currentAccountTransfer.TransferAmount,
            AmountChangedTo = newAccountTransfer.TransferAmount,
            AccountTransferStatus = AccountTransferStatus.PendingModified,
            StatusCreatedDate = DateTime.Now,
        };
    }
}
