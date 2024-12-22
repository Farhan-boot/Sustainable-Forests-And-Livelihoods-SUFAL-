using PTSL.GENERIC.Common.Entity.CommonEntity;

namespace PTSL.GENERIC.Common.Entity.AccountManagement;

public class AccountTransferDetails : BaseEntity
{
    public long AccountTransferId { get; set; }
    public AccountTransfer? AccountTransfer { get; set; }

    public long SourceOfFundId { get; set; }
    public SourceOfFund? SourceOfFund { get; set; }

    public double TransferDetailsAmount { get; set; }

    public string Purpose { get; set; } = string.Empty;

    public List<AccountTransferLog>? AccountTransferLogs { get; set; }
}
