namespace PTSL.GENERIC.Common.Enum.AccountManagement;

public enum AccountTransferStatus
{
    Pending = 0,
    PendingModified = 1,
    Accepted = 2, // +
    Cancel = 3, // -
    Rollback = 4, // -
}
