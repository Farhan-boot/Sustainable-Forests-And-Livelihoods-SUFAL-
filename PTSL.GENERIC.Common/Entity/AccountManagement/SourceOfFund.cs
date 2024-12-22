using PTSL.GENERIC.Common.Entity.CommonEntity;

namespace PTSL.GENERIC.Common.Entity.AccountManagement;

public class SourceOfFund : BaseEntity
{
    public string? Name { get; set; }
    public string? NameBn { get; set; }

    public List<AccountDeposit>? AccountDeposits { get; set; }
    public List<AccountTransfer>? AccountTransfers { get; set; }
    public List<AccountTransferDetails>? AccountTransferDetails { get; set; }
}
