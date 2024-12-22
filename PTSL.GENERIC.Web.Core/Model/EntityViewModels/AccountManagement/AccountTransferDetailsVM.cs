namespace PTSL.GENERIC.Web.Core.Model.EntityViewModels.AccountManagement;

public class AccountTransferDetailsVM : BaseModel
{
    public long AccountTransferId { get; set; }
    public AccountTransferVM? AccountTransfer { get; set; }

    public long SourceOfFundId { get; set; }
    public SourceOfFundVM? SourceOfFund { get; set; }

    public double TransferDetailsAmount { get; set; }

    public string Purpose { get; set; } = string.Empty;

    public List<AccountTransferLogVM>? AccountTransferLogs { get; set; }
}
